using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;

namespace WindowsFormsApp2
{
    public partial class MatrixTransformForm : Form
    {
        private Pen mFunctionPen = new Pen(Color.LightSeaGreen, 3f);
        private Brush mFunctionBrush = Brushes.LightSeaGreen;

        private Pen mAxisPen = new Pen(Color.DimGray, 3f);
        private Brush mAxisBrush = Brushes.DimGray;
        private Font mAxisFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        private int mYShiftForTextAboveX = 20;

        private Pen mAxisPointsPen = new Pen(Color.DimGray, 2f);
        private Brush mAxisPointsBrush = Brushes.Gray;
        private Font mAxisPointsFont = new Font(FontFamily.GenericSansSerif, 10);

        private int mAxisPointsHeight = 8;
        private int mAxisPointsDrawingStep = 10;

        private Pen mInfoPen = new Pen(Color.DodgerBlue, 2f);
        private Pen mInfoDashesPen = new Pen(Color.DodgerBlue, 3f);
        private Brush mInfoBrush = Brushes.DodgerBlue;
        private Font mInfoFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        private Pen mSolutionPen = new Pen(Color.Black, 2f);
        private Brush mSolutionBrush = Brushes.Black;
        private Font mSolutionFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);

        private float a = -100;
        private float b = 100;
        private float epsilon = 0.001f;
        int iterationsLimit = 1000;
        private int showEach = 1;

        private float functionPointsStep = 0.5f;

        private Thread mWorker;
        
        private float scale = 5f;

        private float centerXPos = 0;
        private float centerYPos = 0;
        private float currXPos = 0;
        private float currYPos = 0;

        private Func<float, float> func;


        private static float Foo(float x)
        {
            float xSquashed = x * x * x / 10000;
            return xSquashed - 10;
        }

        private static float Foo2(float x)
        {
            float xSquashed = -x * x * x / 10000;
            return xSquashed - 10;
        }

        public MatrixTransformForm()
        {
            InitializeComponent();

            mInfoDashesPen.DashStyle = DashStyle.Dash;
            mSolutionPen.DashStyle = DashStyle.Dash;

            UpdateAxisPointsDrawingStep();

            m_picture.MouseWheel += m_picture_MouseWheel;

            func = Foo2;

            this.ResizeRedraw = true;
        }

        private void mDrawButton_Click(object sender, EventArgs e)
        {
            RedrawAxisAndFunction();
            
            mWorker = new Thread(() => Secant(func, a, b));
            mWorker.Start();
        }

        private void mPicture_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
            RedrawAxisAndFunction();
        }

        private void RedrawAxisAndFunction()
        {
            Refresh();
            
            using (Graphics imageGraphics = m_picture.CreateGraphics())
            {
                imageGraphics.CompositingQuality = CompositingQuality.HighQuality;
                imageGraphics.SmoothingMode = SmoothingMode.HighQuality;
                imageGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                var relativeCenterX = m_picture.Width / 2;
                var relativeCenterY = m_picture.Height / 2;
                {
                    Matrix center = new Matrix();
                    center.Translate(ApplyXShift(relativeCenterX), ApplyYShift(relativeCenterY));

                    imageGraphics.Transform = center;
                    
                    // Draw Axis
                    imageGraphics.DrawLine(mAxisPen, -relativeCenterX + centerXPos, 0, relativeCenterX + centerXPos, 0);
                    imageGraphics.DrawLine(mAxisPen, 0, -relativeCenterY + centerYPos, 0, relativeCenterY + centerYPos);

                    //imageGraphics.DrawString("X", mAxisFont, mAxisBrush, relativeCenterX - 30, -30);
                    //imageGraphics.DrawString("Y", mAxisFont, mAxisBrush, 10, -relativeCenterY + 10);

                    // Draw axis points
                    var halfPointLen = mAxisPointsHeight / 2;
                    var axisPointsTextShift = mAxisPointsHeight / 2;
                    for (int i = 1; i <= relativeCenterX; ++i)
                    {
                        var currentValue = i * mAxisPointsDrawingStep;
                        var scaledValue = ScaleCoord(currentValue);

                        // Draw X
                        imageGraphics.DrawLine(mAxisPointsPen, scaledValue, halfPointLen, scaledValue, -halfPointLen);
                        imageGraphics.DrawString(
                            currentValue.ToString(), mAxisPointsFont, mAxisPointsBrush,
                            scaledValue, axisPointsTextShift);

                        imageGraphics.DrawLine(mAxisPointsPen, -scaledValue, halfPointLen, -scaledValue, -halfPointLen);
                        imageGraphics.DrawString(
                            (-currentValue).ToString(), mAxisPointsFont, mAxisPointsBrush,
                            -scaledValue, axisPointsTextShift);

                        // Draw Y
                        imageGraphics.DrawLine(mAxisPointsPen, halfPointLen, -scaledValue, -halfPointLen, -scaledValue);
                        imageGraphics.DrawString(
                            currentValue.ToString(), mAxisPointsFont, mAxisPointsBrush,
                            axisPointsTextShift, -scaledValue);

                        imageGraphics.DrawLine(mAxisPointsPen, halfPointLen, scaledValue, -halfPointLen, scaledValue);
                        imageGraphics.DrawString(
                            (-currentValue).ToString(), mAxisPointsFont, mAxisPointsBrush,
                            axisPointsTextShift, scaledValue);
                    }
                }

                // Draw function
                var start = Math.Min(a, b);
                var end = Math.Max(a, b);
                for (float i = start + functionPointsStep, iPrev = start; 
                     i <= end;
                     i += Math.Max(functionPointsStep/scale, 0.5f))
                {
                    var scaledYPrev = ScaleCoord(-func(iPrev));
                    var scaledXPrev = ScaleCoord(iPrev);

                    var scaledY = ScaleCoord(-func(i));
                    var scaledX = ScaleCoord(i);

                    /*TODO: если будет время, не рисовать точки функции, что мы не видим
                     var coordScaler = Math.Max(scale, 1);

                    if (Math.Abs(scaledY) > (coordScaler * ((float)m_picture.Height/2 + Math.Abs(centerYPos)))
                         || Math.Abs(scaledXPrev) > coordScaler * ((float)m_picture.Width + Math.Abs(centerXPos)))
                    {
                        iPrev = i;
                        continue;
                    }*/

                    imageGraphics.DrawLine(mFunctionPen, scaledXPrev, scaledYPrev, scaledX, scaledY);
                    iPrev = i;
                }

                var scaledA = ScaleCoord(a);
                var scaledB = ScaleCoord(b);

                // Draw borders
                imageGraphics.DrawString("a", mInfoFont, mInfoBrush, scaledA, -mYShiftForTextAboveX);
                imageGraphics.DrawString("b", mInfoFont, mInfoBrush, scaledB, -mYShiftForTextAboveX);
                
                imageGraphics.DrawLine(mInfoDashesPen, scaledA, 0, scaledA, ScaleCoord(-func(a)));
                imageGraphics.DrawLine(mInfoDashesPen, scaledB, 0, scaledB, ScaleCoord(-func(b)));

                SizeF pointSize = new SizeF(10, 10);
                float pointShift = -4;
                imageGraphics.FillEllipse(
                    mInfoBrush, 
                    new RectangleF(new PointF(scaledA + pointShift, pointShift), pointSize)
                );

                imageGraphics.FillEllipse(
                    mInfoBrush,
                    new RectangleF(new PointF(scaledB + pointShift, pointShift), pointSize)
                );
            }
        }

        private void mResetButton_Click(object sender, EventArgs e) => Reset();
        
        private void Reset() => RedrawAxisAndFunction();

        public double Secant(Func<float, float> f, float xa, float xb)
        {
            using (Graphics imageGraphics = m_picture.CreateGraphics())
            {
                imageGraphics.CompositingQuality = CompositingQuality.HighQuality;
                imageGraphics.SmoothingMode = SmoothingMode.HighQuality;
                imageGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                Matrix center = new Matrix();
                center.Translate(ApplyXShift(m_picture.Width / 2), ApplyYShift(m_picture.Height / 2));

                imageGraphics.Transform = center;

                return Secant(f, xa, xb, imageGraphics);
            }
        }
        // y = x^3; y = sqrt(x,3);
        // [-1;1]
        public double Secant(Func<float, float> f, float xa, float xb, Graphics imageGraphics)
        {
            //Bitmap b = new Bitmap(m_picture.Width, m_picture.Height);
            //
            //m_picture.Invoke((MethodInvoker)delegate
            //{
            //    DrawToBitmap(b,
            //        new Rectangle(
            //            m_picture.Width / 2, -m_picture.Height / 2, m_picture.Width, m_picture.Height));
            //});
            //b.Save("bmp.jpeg", ImageFormat.Jpeg);


            //for(f(xa) * f(xb) >= 0)
            //{
            //    throw new ArgumentException("f(a) and f(b) should have opposite signs.");
            //}
            
            float xlast;
            float x = 0;
            int currentIterationNumber = 0;
            bool showLast = false;
            float scaledX;
            do
            {

                xlast = x;
                var fxb = f(xb);
                var fxa = f(xa);


                x = xb - fxb * (xb - xa) / (fxb - fxa);
                var fX = func(x);

                {
                    scaledX = ScaleCoord(x);

                    mSolutionLabel.Invoke(
                        (MethodInvoker)delegate
                        {
                            mSolutionLabel.Text = "x[" + currentIterationNumber + "] = " + x
                                                 + "\nf(x) = " + fX;
                        });

                    Thread.Sleep(200);

                    imageGraphics.DrawLine(mInfoPen, 
                        ScaleCoord(xb), ScaleCoord(-f(xb)),
                        ScaleCoord(xa), ScaleCoord(-f(xa)));

                    SizeF pointSize = new SizeF(8, 8);
                    float pointShift = -4;

                    Thread.Sleep(200);
                    // point on X axis
                    imageGraphics.FillEllipse(
                        mInfoBrush,
                        new RectangleF(new PointF(scaledX + pointShift, pointShift), pointSize)
                    );
                    imageGraphics.DrawString(
                        "x[" + currentIterationNumber + "]", mSolutionFont, mSolutionBrush,
                        scaledX,
                        -mYShiftForTextAboveX
                    );

                    Thread.Sleep(500);

                    imageGraphics.DrawLine(mSolutionPen, scaledX, 0, scaledX, ScaleCoord(-fX));
                    // point on function
                    imageGraphics.FillEllipse(
                        mFunctionBrush,
                        new RectangleF(new PointF(scaledX + pointShift, ScaleCoord(-fX) + pointShift), pointSize)
                    );
                }

                if (f(x) * f(xa) > 0)
                {
                    xa = x;
                }
                else
                {
                    xb = x;
                }

                ++currentIterationNumber;
            }
            while (Math.Abs(x - xlast) > epsilon || (xb - xa) <= epsilon || currentIterationNumber > iterationsLimit);

            return x;
        }
        

        private void m_picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                centerXPos += currXPos - e.X;
                centerYPos += currYPos - e.Y;

                RedrawAxisAndFunction();
            }

            currXPos = e.X;
            currYPos = e.Y;

            mXAndYInfoLabel.Text = 
                "x: " + ((e.X - m_picture.Width / 2 + centerXPos) / scale) + 
                " y: " + ((e.Y - m_picture.Height / 2 + centerYPos) / scale);
        }

        //public static double GetRoot(Func<double, double> f, double x_prev, double x_curr, double e)
        //{
        //    double x_next = 0
        //    do
        //    {
        //        double tmp = x_next;
        //        //t =( b*f(a)-f(b)*a)/(f(a)-f(b)); //1
        //        //t = a+(f(b)*(b-a))/(f(b)-f(a));  //2
        //        x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
        //        x_prev = x_curr;
        //        x_curr = tmp;
        //    } while (Math.Abs(x_next - x_curr) > e);

        //    return x_next;
        //}

        private float ApplyXShift(float x)
        {
            return x - centerXPos;
        }
        private float ApplyYShift(float y)
        {
            return y - centerYPos;
        }

        private float ScaleCoord(float x)
        {
            return scale * x;
        }

        private void m_picture_MouseWheel(object sender, MouseEventArgs e)
        {
            var multiplier = (float)(e.Delta > 0 ? 1.1 : 0.9);
            scale *= multiplier;

            UpdateAxisPointsDrawingStep();

            RedrawAxisAndFunction();
        }

        private void UpdateAxisPointsDrawingStep()
        {
            mAxisPointsDrawingStep = 10;
            for (var tmpScale = scale; tmpScale < 2f; tmpScale *= 2)
            {
                mAxisPointsDrawingStep *= 2;
            }
        }
    }


    //public partial class MatrixTransformForm2 : Form
    //{
    //    private Pen mFigurePen = new Pen(Color.LightSeaGreen, 3f);
    //    private Pen mAxisPen = new Pen(Color.DimGray, 2.5f);
    //    private Brush mAxisBrush = Brushes.DimGray;
        
    //    private PointF[] mFigureMatrix;

    //    public MatrixTransformForm2()
    //    {
    //        InitializeComponent();

    //        this.ResizeRedraw = true;
    //        Reset();
    //    }

    //    private void mDrawButton_Click(object sender, EventArgs e) => Redraw();
    //    private void mPicture_Resize(object sender, EventArgs e) => Redraw();
        
    //    private void Redraw()
    //    {
    //        Refresh();

    //        using (Graphics imageGraphics = m_picture.CreateGraphics())
    //        {
    //            Matrix center = new Matrix();
    //            center.Translate(m_picture.Width / 2, m_picture.Height / 2);

    //            imageGraphics.Transform = center;

    //            imageGraphics.DrawLine(mAxisPen, -m_picture.Width / 2, 0, m_picture.Width / 2, 0);
    //            imageGraphics.DrawLine(mAxisPen, 0, -m_picture.Height / 2, 0, m_picture.Height / 2);
                
    //            imageGraphics.DrawString("X", Font, mAxisBrush, m_picture.Width / 2 - 30, -30);
    //            imageGraphics.DrawString("Y", Font, mAxisBrush, 10, -m_picture.Height / 2 + 10);

    //            imageGraphics.DrawPolygon(mFigurePen, mFigureMatrix);
    //        }
    //    }

    //    private void mRotateButton_Click(object sender, EventArgs e)
    //    {
    //        int rotationAngle = (int)mRotationAngleUpDown.Value;
            
    //        TransformFigure(matrix => matrix.RotateAt(rotationAngle, new PointF(0, 0)));
            
    //        Redraw();
    //    }

    //    private void mScaleButton_Click(object sender, EventArgs e)
    //    {
    //        float scalarX = (float)mXScalarUpDown.Value;
    //        float scalarY = (float)mYScalarUpDown.Value;

    //        TransformFigure(matrix => matrix.Scale(scalarX, scalarY));
            
    //        Redraw();
    //    }

    //    private void mResetButton_Click(object sender, EventArgs e) => Reset();

    //    private void mTranslationButton_Click(object sender, EventArgs e)
    //    {
    //        float translateX = (float)mXTranslationUpDown.Value;
    //        float translateY = (float)mYTranslationUpDown.Value;

    //        for(int i = 0; i < mFigureMatrix.Length; ++i)
    //        {
    //            mFigureMatrix[i].X += translateX;
    //            mFigureMatrix[i].Y -= translateY;
    //        }

    //        Redraw();
    //    }

    //    private void mMirrorXButton_Click(object sender, EventArgs e)
    //    {
    //        Mirror(false, true);
    //        Redraw();
    //    }

    //    private void mMirrorYButton_Click(object sender, EventArgs e)
    //    {
    //        Mirror(true, false);
    //        Redraw();
    //    }

    //    private void Reset()
    //    {
    //        mFigureMatrix = new PointF[]
    //        {
    //            new PointF(0, 50),
    //            new PointF(50, 100),
    //            new PointF(50, -100),
    //            new PointF(-50, -40),
    //            new PointF(-50, 100),
    //        };

    //        Mirror(false, true);
    //        Redraw();
    //    }
        
    //    private void Mirror(bool mirrorX, bool mirrorY)
    //    {
    //        TransformFigure(matrix =>
    //            matrix.Scale(
    //                mirrorX ? -1 : 1,
    //                mirrorY ? -1 : 1));
    //    }

    //    private void TransformFigure(Action<Matrix> transformer)
    //    {
    //        Matrix matrix = new Matrix();
    //        matrix.Translate(m_picture.Width / 2, m_picture.Height / 2);

    //        transformer(matrix);

    //        matrix.TransformVectors(mFigureMatrix);
    //    }
    //}
}

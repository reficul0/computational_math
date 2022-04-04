using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WindowsFormsApp2
{
    public partial class ChordsSolutionForm : Form
    {
        private static float Foo(float x)
        {
            var newX = x + 1;
            return newX * newX - 1.5f;
        }
        private static float Foo2(float x)
        {
            var newX = (-x - 1);
            return newX * newX * newX + x*x - 1;
        }

        private static float Foo3(float x)
        {
            return (-Math.Abs(x-0.1f) + 0.6f);
        }

        Dictionary<String, Func<float, float>> mFunctionsByNameList = new Dictionary<String, Func<float, float>>
        {
            { "-|x-0.1| + 0.6", Foo3 },
            { "(-x-1)^3 + x^2 - 1", Foo2 },
            { "(x + 1)^2 - 1.5f", Foo }
        };
        
        public ChordsSolutionForm()
        {
            InitializeComponent();

            m_picture.MouseWheel += mPicture_MouseWheel;

            this.ResizeRedraw = true;

            mFunctionsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (var functionByNameObj in mFunctionsByNameList)
            {
                var functionByName = (KeyValuePair<String, Func<float, float>>)functionByNameObj;
                mFunctionsComboBox.Items.Insert(0, functionByName.Key);
            }

            mFunctionsComboBox.SelectedIndex = 0;

            Reset();
        }

        private void mSolveButton_Click(object sender, EventArgs e)
        {
            RedrawAxisAndFunction();

            mSolveButton.Enabled = false;
            mSolveButton.Text = "Solving...";
            lock (mSettingsMutex)
            {
                mWorker = new Thread(
                    () =>
                    {
                        try
                        {
                            FindRootViaChords(mSelectedFunc, a, b);

                        }
                        catch (ThreadInterruptedException)
                        {
                            return;
                        }
                        catch (Exception err)
                        {
                            System.Windows.Forms.MessageBox.Show(this, err.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        mSolveButton.Invoke(
                            (MethodInvoker)delegate
                            {
                                mSolveButton.Text = "Solve";
                                mSolveButton.Enabled = true;
                            });
                    });
                mWorker.Start();
            }
        }

        private void mPicture_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
            RedrawAxisAndFunction();
        }
        
        private void mPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mCenterXPos += mMouseXPos - e.X;
                mCenterYPos += mMouseYPos - e.Y;

                RedrawAxisAndFunction();
            }

            mMouseXPos = e.X;
            mMouseYPos = e.Y;

            mXAndYInfoLabel.Text =
                "x: " + ((e.X - m_picture.Width / 2 + mCenterXPos) / mGraphicScale) +
                " y: " + (MapYToCurrentCoordinateSystem(e.Y - m_picture.Height / 2 + mCenterYPos) / mGraphicScale);
        }

        private void mPicture_MouseWheel(object sender, MouseEventArgs e)
        {
            var multiplier = (float)(e.Delta > 0 ? 1.1 : 0.9);
            mGraphicScale *= multiplier;

            UpdateAxisPointsDrawingStep();

            RedrawAxisAndFunction();
        }

        #region solution settings

        private void mABoundTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                a = (float)Double.Parse(mABoundTextBox.Text, NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(this, err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                mABoundTextBox.Undo();
            }
        }
        private void mBBoundTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                b = (float)Double.Parse(mBBoundTextBox.Text, NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(this, err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                mBBoundTextBox.Undo();
            }
        }
        
        private void mEpsilonTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epsilon = (float)Double.Parse(mEpsilonTextBox.Text, NumberStyles.Any | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
            }
            catch (Exception err)
            {
                System.Windows.Forms.MessageBox.Show(this, err.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                mEpsilonTextBox.Undo();
            }
        }

        private void mFunctionsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedFunctionDescr = (string)mFunctionsComboBox.SelectedItem;
            mSelectedFunc = mFunctionsByNameList[selectedFunctionDescr];
        }

        private void mAnimationSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            lock (mSettingsMutex)
            {
                mAnimationSpeed = mAnimationSpeedTrackBar.Value;
            }
        } 

        #endregion

        private void mResetButton_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void Reset()
        {
            if (mWorker != null && mWorker.IsAlive)
            {
                mWorker.Interrupt();
                mWorker.Join();

                mSolveButton.Text = "Solve";
                mSolveButton.Enabled = true;
            }

            mAxisPointsDrawingStep = mStartingAxisPointsDrawingStep;

            mCenterXPos = 0;
            mCenterYPos = 0;
            mMouseXPos = 0;
            mMouseYPos = 0;

            mABoundTextBox.Text = (-2).ToString();
            mBBoundTextBox.Text = 0.5f.ToString(CultureInfo.InvariantCulture);
            mEpsilonTextBox.Text = 0.001f.ToString(CultureInfo.InvariantCulture);
            iterationsLimit = 1000;

            mFunctionPointsStep = 0.01f;

            mGraphicScale = 5f;
            UpdateAxisPointsDrawingStep();

            RedrawAxisAndFunction();
        }

        
        public double FindRootViaChords(Func<float, float> f, float xa, float xb)
        {
            using (Graphics imageGraphics = m_picture.CreateGraphics())
            {
                imageGraphics.CompositingQuality = CompositingQuality.HighQuality;
                imageGraphics.SmoothingMode = SmoothingMode.HighQuality;
                imageGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                Matrix center = new Matrix();
                center.Translate(ShiftXToCenter(m_picture.Width / 2), ShiftYToCenter(m_picture.Height / 2));

                imageGraphics.Transform = center;

                return FindRootViaChords(f, xa, xb, imageGraphics);
            }
        }

        public double FindRootViaChords(Func<float, float> f, float xa, float xb, Graphics imageGraphics)
        {
            {
                var fxa = f(xa);
                var fxb = f(xb);
                if (fxa != 0 && fxb!=0 && f(xa) * f(xb) >= 0)
                {
                    throw new ArgumentException("f(a) and f(b) should have opposite signs.");
                }
            }

            int currentIterationNumber = 0;
            float xLast;
            float x = CalculateXNext(f, ref xa, ref xb, currentIterationNumber, imageGraphics);
            ++currentIterationNumber;
            do
            {
                // check interruption
                Thread.Sleep(0);
                xLast = x;

                x = CalculateXNext(f, ref xa, ref xb, currentIterationNumber, imageGraphics);
                ++currentIterationNumber;
            }
            while (Math.Abs(x - xLast) > epsilon
                    && currentIterationNumber < iterationsLimit);

            return x;
        }
        private float CalculateXNext(Func<float, float> f, ref float xa, ref float xb, int currentIterationNumber, Graphics imageGraphics)
        {
            float x = xb - f(xb) * (xb - xa) / (f(xb) - f(xa));

            var fX = f(x);
            {
                var scaledX = ScaleCoord(x);

                mSolutionLabel.Invoke(
                    (MethodInvoker)delegate
                    {
                        mSolutionLabel.Text = "x[" + currentIterationNumber + "] = " + x
                                             + "\nf(x) = " + fX;
                    });

                Thread.Sleep(GetAnimationSleepTimeout(200));

                imageGraphics.DrawLine(Resources.mInfoPen,
                    ScaleCoord(xb), ScaleCoord(MapYToCurrentCoordinateSystem(f(xb))),
                    ScaleCoord(xa), ScaleCoord(MapYToCurrentCoordinateSystem(f(xa))));

                SizeF pointSize = new SizeF(8, 8);
                float pointShift = -4;

                Thread.Sleep(GetAnimationSleepTimeout(200));

                // point on X axis
                imageGraphics.FillEllipse(
                    Resources.mInfoBrush,
                    new RectangleF(new PointF(scaledX + pointShift, MapYToCurrentCoordinateSystem(-pointShift)), pointSize)
                );
                imageGraphics.DrawString(
                    "x[" + currentIterationNumber + "]", Resources.mSolutionFont, Resources.mSolutionBrush,
                    scaledX,
                    MapYToCurrentCoordinateSystem(mYShiftForTextAboveX)
                );

                Thread.Sleep(GetAnimationSleepTimeout(500));

                imageGraphics.DrawLine(Resources.mSolutionPen, scaledX, 0, scaledX, ScaleCoord(-fX));
                // point on function
                imageGraphics.FillEllipse(
                    Resources.mFunctionBrush,
                    new RectangleF(
                        new PointF(scaledX + pointShift,
                                          ScaleCoord(MapYToCurrentCoordinateSystem(fX)) + pointShift),
                        pointSize)
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

            return x;
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
                    center.Translate(ShiftXToCenter(relativeCenterX), ShiftYToCenter(relativeCenterY));

                    imageGraphics.Transform = center;

                    // Draw Axis
                    imageGraphics.DrawLine(Resources.mAxisPen, -relativeCenterX + mCenterXPos, 0, relativeCenterX + mCenterXPos, 0);
                    imageGraphics.DrawLine(Resources.mAxisPen, 0, -relativeCenterY + mCenterYPos, 0, relativeCenterY + mCenterYPos);
                    
                    // Draw axis points
                    var halfPointLen = mAxisPointsHeight / 2;
                    var axisPointsTextShift = mAxisPointsHeight / 2;
                    for (int i = 1; i <= relativeCenterX; ++i)
                    {
                        var currentValue = i * mAxisPointsDrawingStep;
                        var scaledValue = ScaleCoord(MapYToCurrentCoordinateSystem(-currentValue));

                        // Draw X
                        imageGraphics.DrawLine(Resources.mAxisPointsPen, -scaledValue, halfPointLen, -scaledValue, -halfPointLen);
                        imageGraphics.DrawString(
                            currentValue.ToString(), Resources.mAxisPointsFont, Resources.mAxisPointsBrush,
                            -scaledValue, axisPointsTextShift);

                        imageGraphics.DrawLine(Resources.mAxisPointsPen, scaledValue, halfPointLen, scaledValue, -halfPointLen);
                        imageGraphics.DrawString(
                            (-currentValue).ToString(), Resources.mAxisPointsFont, Resources.mAxisPointsBrush,
                            scaledValue, axisPointsTextShift);

                        // Draw Y
                        imageGraphics.DrawLine(Resources.mAxisPointsPen, halfPointLen, scaledValue, -halfPointLen, scaledValue);
                        imageGraphics.DrawString(
                            (-currentValue).ToString(), Resources.mAxisPointsFont, Resources.mAxisPointsBrush,
                            axisPointsTextShift, scaledValue);

                        imageGraphics.DrawLine(Resources.mAxisPointsPen, halfPointLen, -scaledValue, -halfPointLen, -scaledValue);
                        imageGraphics.DrawString(
                            currentValue.ToString(), Resources.mAxisPointsFont, Resources.mAxisPointsBrush,
                            axisPointsTextShift, -scaledValue);
                    }
                }

                // Draw function
                var start = Math.Min(a, b);
                var end = Math.Max(a, b);
                var optimizedFunctionPointsStep = Math.Max(mFunctionPointsStep / mGraphicScale, mMinimumFunctionPointsStep);
                {
                    float i = start + optimizedFunctionPointsStep;
                    var scaledY = ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(i)));
                    var scaledX = ScaleCoord(i);
                    for (float iPrev = start;
                                i <= end;
                                i += optimizedFunctionPointsStep)
                    {
                        var scaledYPrev = ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(iPrev)));
                        var scaledXPrev = ScaleCoord(iPrev);

                        scaledY = ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(i)));
                        scaledX = ScaleCoord(i);

                        /*TODO: если будет время, не рисовать точки функции, что мы не видим
                         var coordScaler = Math.Max(mGraphicScale, 1);

                        if (Math.Abs(scaledY) > (coordScaler * ((float)m_picture.Height/2 + Math.Abs(mCenterYPos)))
                             || Math.Abs(scaledXPrev) > coordScaler * ((float)m_picture.Width + Math.Abs(mCenterXPos)))
                        {
                            iPrev = i;
                            continue;
                        }*/

                        imageGraphics.DrawLine(Resources.mFunctionPen, scaledXPrev, scaledYPrev, scaledX, scaledY);
                        iPrev = i;
                    }
                    // paint closing line just in case
                    imageGraphics.DrawLine(Resources.mFunctionPen, 
                        scaledX, scaledY,
                        ScaleCoord(end), ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(end))));
                }

                var scaledA = ScaleCoord(a);
                var scaledB = ScaleCoord(b);

                // Draw borders
                imageGraphics.DrawString("a", Resources.mInfoFont, Resources.mInfoBrush, scaledA, MapYToCurrentCoordinateSystem(mYShiftForTextAboveX));
                imageGraphics.DrawString("b", Resources.mInfoFont, Resources.mInfoBrush, scaledB, MapYToCurrentCoordinateSystem(mYShiftForTextAboveX));

                imageGraphics.DrawLine(Resources.mInfoDashesPen, scaledA, 0, scaledA, ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(a))));
                imageGraphics.DrawLine(Resources.mInfoDashesPen, scaledB, 0, scaledB, ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(b))));
                
                // points on x axis
                SizeF pointSize = new SizeF(10, 10);
                float pointShift = -4;
                imageGraphics.FillEllipse(
                    Resources.mInfoBrush,
                    new RectangleF(new PointF(scaledA + pointShift, MapYToCurrentCoordinateSystem(-pointShift)), pointSize)
                );
                imageGraphics.FillEllipse(
                    Resources.mInfoBrush,
                    new RectangleF(new PointF(scaledB + pointShift, MapYToCurrentCoordinateSystem(-pointShift)), pointSize)
                );

                // points on function
                imageGraphics.FillEllipse(
                    Resources.mFunctionBrush,
                    new RectangleF(
                        new PointF(scaledA + pointShift,
                            ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(a))) + pointShift),
                        pointSize)
                    );
                imageGraphics.FillEllipse(
                    Resources.mFunctionBrush,
                    new RectangleF(
                        new PointF(scaledB + pointShift,
                            ScaleCoord(MapYToCurrentCoordinateSystem(mSelectedFunc(b))) + pointShift),
                        pointSize)
                    );
            }
        }

        private void UpdateAxisPointsDrawingStep()
        {
            mAxisPointsDrawingStep = mStartingAxisPointsDrawingStep;
            for (var tmpScale = mGraphicScale; tmpScale < 2f; tmpScale *= mSpeedOfAxisPointsDisappearWhenScaling)
            {
                mAxisPointsDrawingStep *= mAxisPointsStepWhenScaling;
            }
        }

        private float ShiftXToCenter(float x)
        {
            return x - mCenterXPos;
        }
        private float ShiftYToCenter(float y)
        {
            return y - mCenterYPos;
        }

        private float ScaleCoord(float coord)
        {
            return mGraphicScale * coord;
        }

        private float MapYToCurrentCoordinateSystem(float y)
        {
            return -y;
        }

        private int GetAnimationSleepTimeout(int timeoutMs)
        {
            lock (mSettingsMutex)
            {
                return timeoutMs / mAnimationSpeed;
            }
        }

        private readonly int mYShiftForTextAboveX = 20;

        private readonly int mAxisPointsHeight = 8;
        private readonly int mStartingAxisPointsDrawingStep = 10;
        // increasing - points disappear slower
        // decreasing - points disappear faster
        private readonly float mSpeedOfAxisPointsDisappearWhenScaling = 1.83f;
        // will display only points that = i*mAxisPointsDrawingStep*mAxisPointsStepWhenScaling
        //                             for i from 1 to axis border that user see
        private int mAxisPointsDrawingStep = 10;
        private readonly int mAxisPointsStepWhenScaling = 2;

        private float mCenterXPos = 0;
        private float mCenterYPos = 0;
        private float mMouseXPos = 0;
        private float mMouseYPos = 0;

        private float a;
        private float b;
        private float epsilon;
        int iterationsLimit = 1000;

        private float mFunctionPointsStep;
        private readonly float mMinimumFunctionPointsStep = 0.1f;

        // increasing - zooming in
        // decreasing - zooming out 
        private float mGraphicScale;

        private Int32 mAnimationSpeed = 1;

        private Thread mWorker;
        private Func<float, float> mSelectedFunc;

        private object mSettingsMutex = new object();

    }

    public static class Resources
    {
        public static Pen mFunctionPen = new Pen(Color.LightSeaGreen, 3f);
        public static Brush mFunctionBrush = Brushes.LightSeaGreen;

        public static Pen mAxisPen = new Pen(Color.DimGray, 3f);
        public static Brush mAxisBrush = Brushes.DimGray;
        public static Font mAxisFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        public static Pen mAxisPointsPen = new Pen(Color.DimGray, 2f);
        public static Brush mAxisPointsBrush = Brushes.Gray;
        public static Font mAxisPointsFont = new Font(FontFamily.GenericSansSerif, 8);

        public static Pen mInfoPen = new Pen(Color.DodgerBlue, 2f);
        public static Pen mInfoDashesPen = new Pen(Color.DodgerBlue, 3f);
        public static Brush mInfoBrush = Brushes.DodgerBlue;
        public static Font mInfoFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);

        public static Pen mSolutionPen = new Pen(Color.Black, 2f);
        public static Brush mSolutionBrush = Brushes.Black;
        public static Font mSolutionFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);


        static Resources()
        {
            mInfoDashesPen.DashStyle = DashStyle.Dash;
            mSolutionPen.DashStyle = DashStyle.Dash;
        }
    }
}

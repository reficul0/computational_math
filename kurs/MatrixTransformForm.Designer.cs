
namespace WindowsFormsApp2
{
    partial class MatrixTransformForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_picture = new System.Windows.Forms.PictureBox();
            this.mDrawButton = new System.Windows.Forms.Button();
            this.mRotateButton = new System.Windows.Forms.Button();
            this.mScaleButton = new System.Windows.Forms.Button();
            this.mResetButton = new System.Windows.Forms.Button();
            this.mMirrorXButton = new System.Windows.Forms.Button();
            this.Reflect = new System.Windows.Forms.Label();
            this.mMirrorYButton = new System.Windows.Forms.Button();
            this.mRotationAngleUpDown = new System.Windows.Forms.NumericUpDown();
            this.mAngleLabel = new System.Windows.Forms.Label();
            this.mXScalarLabel = new System.Windows.Forms.Label();
            this.mXScalarUpDown = new System.Windows.Forms.NumericUpDown();
            this.mYScalarLabel = new System.Windows.Forms.Label();
            this.mYScalarUpDown = new System.Windows.Forms.NumericUpDown();
            this.mTransformationsgroupBox = new System.Windows.Forms.GroupBox();
            this.mYTranslationLabel = new System.Windows.Forms.Label();
            this.mYTranslationUpDown = new System.Windows.Forms.NumericUpDown();
            this.mXTranslationLabel = new System.Windows.Forms.Label();
            this.mXTranslationUpDown = new System.Windows.Forms.NumericUpDown();
            this.mTranslationButton = new System.Windows.Forms.Button();
            this.mXAndYInfoLabel = new System.Windows.Forms.Label();
            this.mSolutionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRotationAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXScalarUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYScalarUpDown)).BeginInit();
            this.mTransformationsgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mYTranslationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXTranslationUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_picture
            // 
            this.m_picture.AccessibleName = "";
            this.m_picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_picture.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_picture.Location = new System.Drawing.Point(12, 12);
            this.m_picture.Name = "m_picture";
            this.m_picture.Size = new System.Drawing.Size(1232, 658);
            this.m_picture.TabIndex = 0;
            this.m_picture.TabStop = false;
            this.m_picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_picture_MouseMove);
            this.m_picture.Resize += new System.EventHandler(this.mPicture_Resize);
            // 
            // mDrawButton
            // 
            this.mDrawButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mDrawButton.Location = new System.Drawing.Point(518, 677);
            this.mDrawButton.Name = "mDrawButton";
            this.mDrawButton.Size = new System.Drawing.Size(106, 34);
            this.mDrawButton.TabIndex = 1;
            this.mDrawButton.Text = "Draw";
            this.mDrawButton.UseVisualStyleBackColor = true;
            this.mDrawButton.Click += new System.EventHandler(this.mDrawButton_Click);
            // 
            // mRotateButton
            // 
            this.mRotateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mRotateButton.Location = new System.Drawing.Point(13, 19);
            this.mRotateButton.Name = "mRotateButton";
            this.mRotateButton.Size = new System.Drawing.Size(87, 44);
            this.mRotateButton.TabIndex = 2;
            this.mRotateButton.Text = "Rotate";
            this.mRotateButton.UseVisualStyleBackColor = true;
            // 
            // mScaleButton
            // 
            this.mScaleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mScaleButton.Location = new System.Drawing.Point(164, 19);
            this.mScaleButton.Name = "mScaleButton";
            this.mScaleButton.Size = new System.Drawing.Size(110, 44);
            this.mScaleButton.TabIndex = 3;
            this.mScaleButton.Text = "Scale";
            this.mScaleButton.UseVisualStyleBackColor = true;
            // 
            // mResetButton
            // 
            this.mResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mResetButton.Location = new System.Drawing.Point(630, 677);
            this.mResetButton.Name = "mResetButton";
            this.mResetButton.Size = new System.Drawing.Size(110, 34);
            this.mResetButton.TabIndex = 4;
            this.mResetButton.Text = "Reset";
            this.mResetButton.UseVisualStyleBackColor = true;
            this.mResetButton.Click += new System.EventHandler(this.mResetButton_Click);
            // 
            // mMirrorXButton
            // 
            this.mMirrorXButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mMirrorXButton.Location = new System.Drawing.Point(689, 22);
            this.mMirrorXButton.Name = "mMirrorXButton";
            this.mMirrorXButton.Size = new System.Drawing.Size(44, 44);
            this.mMirrorXButton.TabIndex = 5;
            this.mMirrorXButton.Text = "X";
            this.mMirrorXButton.UseVisualStyleBackColor = true;
            // 
            // Reflect
            // 
            this.Reflect.AutoSize = true;
            this.Reflect.Location = new System.Drawing.Point(648, 39);
            this.Reflect.Name = "Reflect";
            this.Reflect.Size = new System.Drawing.Size(41, 13);
            this.Reflect.TabIndex = 6;
            this.Reflect.Text = "Reflect";
            // 
            // mMirrorYButton
            // 
            this.mMirrorYButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mMirrorYButton.Location = new System.Drawing.Point(737, 22);
            this.mMirrorYButton.Name = "mMirrorYButton";
            this.mMirrorYButton.Size = new System.Drawing.Size(44, 44);
            this.mMirrorYButton.TabIndex = 7;
            this.mMirrorYButton.Text = "Y";
            this.mMirrorYButton.UseVisualStyleBackColor = true;
            // 
            // mRotationAngleUpDown
            // 
            this.mRotationAngleUpDown.Location = new System.Drawing.Point(99, 38);
            this.mRotationAngleUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.mRotationAngleUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.mRotationAngleUpDown.Name = "mRotationAngleUpDown";
            this.mRotationAngleUpDown.Size = new System.Drawing.Size(52, 20);
            this.mRotationAngleUpDown.TabIndex = 9;
            this.mRotationAngleUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // mAngleLabel
            // 
            this.mAngleLabel.AutoSize = true;
            this.mAngleLabel.Location = new System.Drawing.Point(96, 22);
            this.mAngleLabel.Name = "mAngleLabel";
            this.mAngleLabel.Size = new System.Drawing.Size(37, 13);
            this.mAngleLabel.TabIndex = 10;
            this.mAngleLabel.Text = "Angle:";
            // 
            // mXScalarLabel
            // 
            this.mXScalarLabel.AutoSize = true;
            this.mXScalarLabel.Location = new System.Drawing.Point(273, 19);
            this.mXScalarLabel.Name = "mXScalarLabel";
            this.mXScalarLabel.Size = new System.Drawing.Size(48, 13);
            this.mXScalarLabel.TabIndex = 12;
            this.mXScalarLabel.Text = "X scalar:";
            // 
            // mXScalarUpDown
            // 
            this.mXScalarUpDown.DecimalPlaces = 3;
            this.mXScalarUpDown.Location = new System.Drawing.Point(276, 35);
            this.mXScalarUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.mXScalarUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.mXScalarUpDown.Name = "mXScalarUpDown";
            this.mXScalarUpDown.Size = new System.Drawing.Size(56, 20);
            this.mXScalarUpDown.TabIndex = 11;
            this.mXScalarUpDown.ThousandsSeparator = true;
            this.mXScalarUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // mYScalarLabel
            // 
            this.mYScalarLabel.AutoSize = true;
            this.mYScalarLabel.Location = new System.Drawing.Point(335, 19);
            this.mYScalarLabel.Name = "mYScalarLabel";
            this.mYScalarLabel.Size = new System.Drawing.Size(48, 13);
            this.mYScalarLabel.TabIndex = 14;
            this.mYScalarLabel.Text = "Y scalar:";
            // 
            // mYScalarUpDown
            // 
            this.mYScalarUpDown.DecimalPlaces = 3;
            this.mYScalarUpDown.Location = new System.Drawing.Point(338, 35);
            this.mYScalarUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.mYScalarUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.mYScalarUpDown.Name = "mYScalarUpDown";
            this.mYScalarUpDown.Size = new System.Drawing.Size(54, 20);
            this.mYScalarUpDown.TabIndex = 13;
            this.mYScalarUpDown.ThousandsSeparator = true;
            this.mYScalarUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // mTransformationsgroupBox
            // 
            this.mTransformationsgroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mTransformationsgroupBox.Controls.Add(this.mYTranslationLabel);
            this.mTransformationsgroupBox.Controls.Add(this.mYTranslationUpDown);
            this.mTransformationsgroupBox.Controls.Add(this.mXTranslationLabel);
            this.mTransformationsgroupBox.Controls.Add(this.mXTranslationUpDown);
            this.mTransformationsgroupBox.Controls.Add(this.mTranslationButton);
            this.mTransformationsgroupBox.Controls.Add(this.mRotateButton);
            this.mTransformationsgroupBox.Controls.Add(this.mMirrorYButton);
            this.mTransformationsgroupBox.Controls.Add(this.mYScalarLabel);
            this.mTransformationsgroupBox.Controls.Add(this.Reflect);
            this.mTransformationsgroupBox.Controls.Add(this.mRotationAngleUpDown);
            this.mTransformationsgroupBox.Controls.Add(this.mMirrorXButton);
            this.mTransformationsgroupBox.Controls.Add(this.mYScalarUpDown);
            this.mTransformationsgroupBox.Controls.Add(this.mAngleLabel);
            this.mTransformationsgroupBox.Controls.Add(this.mXScalarLabel);
            this.mTransformationsgroupBox.Controls.Add(this.mXScalarUpDown);
            this.mTransformationsgroupBox.Controls.Add(this.mScaleButton);
            this.mTransformationsgroupBox.Location = new System.Drawing.Point(236, 717);
            this.mTransformationsgroupBox.Name = "mTransformationsgroupBox";
            this.mTransformationsgroupBox.Size = new System.Drawing.Size(790, 72);
            this.mTransformationsgroupBox.TabIndex = 15;
            this.mTransformationsgroupBox.TabStop = false;
            this.mTransformationsgroupBox.Text = "Transformations";
            // 
            // mYTranslationLabel
            // 
            this.mYTranslationLabel.AutoSize = true;
            this.mYTranslationLabel.Location = new System.Drawing.Point(577, 22);
            this.mYTranslationLabel.Name = "mYTranslationLabel";
            this.mYTranslationLabel.Size = new System.Drawing.Size(68, 13);
            this.mYTranslationLabel.TabIndex = 19;
            this.mYTranslationLabel.Text = "Y translation:";
            // 
            // mYTranslationUpDown
            // 
            this.mYTranslationUpDown.DecimalPlaces = 3;
            this.mYTranslationUpDown.Location = new System.Drawing.Point(580, 38);
            this.mYTranslationUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.mYTranslationUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.mYTranslationUpDown.Name = "mYTranslationUpDown";
            this.mYTranslationUpDown.Size = new System.Drawing.Size(65, 20);
            this.mYTranslationUpDown.TabIndex = 18;
            this.mYTranslationUpDown.ThousandsSeparator = true;
            this.mYTranslationUpDown.Value = new decimal(new int[] {
            11,
            0,
            0,
            65536});
            // 
            // mXTranslationLabel
            // 
            this.mXTranslationLabel.AutoSize = true;
            this.mXTranslationLabel.Location = new System.Drawing.Point(515, 22);
            this.mXTranslationLabel.Name = "mXTranslationLabel";
            this.mXTranslationLabel.Size = new System.Drawing.Size(68, 13);
            this.mXTranslationLabel.TabIndex = 17;
            this.mXTranslationLabel.Text = "X translation:";
            // 
            // mXTranslationUpDown
            // 
            this.mXTranslationUpDown.DecimalPlaces = 3;
            this.mXTranslationUpDown.Location = new System.Drawing.Point(518, 38);
            this.mXTranslationUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.mXTranslationUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.mXTranslationUpDown.Name = "mXTranslationUpDown";
            this.mXTranslationUpDown.Size = new System.Drawing.Size(56, 20);
            this.mXTranslationUpDown.TabIndex = 16;
            this.mXTranslationUpDown.ThousandsSeparator = true;
            this.mXTranslationUpDown.Value = new decimal(new int[] {
            31,
            0,
            0,
            65536});
            // 
            // mTranslationButton
            // 
            this.mTranslationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mTranslationButton.Location = new System.Drawing.Point(405, 19);
            this.mTranslationButton.Name = "mTranslationButton";
            this.mTranslationButton.Size = new System.Drawing.Size(110, 44);
            this.mTranslationButton.TabIndex = 15;
            this.mTranslationButton.Text = "Translate";
            this.mTranslationButton.UseVisualStyleBackColor = true;
            // 
            // mXAndYInfoLabel
            // 
            this.mXAndYInfoLabel.AutoSize = true;
            this.mXAndYInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mXAndYInfoLabel.Location = new System.Drawing.Point(21, 21);
            this.mXAndYInfoLabel.Name = "mXAndYInfoLabel";
            this.mXAndYInfoLabel.Size = new System.Drawing.Size(155, 25);
            this.mXAndYInfoLabel.TabIndex = 16;
            this.mXAndYInfoLabel.Text = "X: 32.2 Y: 41.1";
            // 
            // mSolutionLabel
            // 
            this.mSolutionLabel.AutoSize = true;
            this.mSolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mSolutionLabel.Location = new System.Drawing.Point(21, 56);
            this.mSolutionLabel.Name = "mSolutionLabel";
            this.mSolutionLabel.Size = new System.Drawing.Size(90, 25);
            this.mSolutionLabel.TabIndex = 17;
            this.mSolutionLabel.Text = "Solution";
            // 
            // MatrixTransformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1256, 800);
            this.Controls.Add(this.mSolutionLabel);
            this.Controls.Add(this.mXAndYInfoLabel);
            this.Controls.Add(this.mTransformationsgroupBox);
            this.Controls.Add(this.mResetButton);
            this.Controls.Add(this.mDrawButton);
            this.Controls.Add(this.m_picture);
            this.Name = "MatrixTransformForm";
            this.Text = "MatrixTransformForm";
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRotationAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXScalarUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mYScalarUpDown)).EndInit();
            this.mTransformationsgroupBox.ResumeLayout(false);
            this.mTransformationsgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mYTranslationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXTranslationUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picture;
        private System.Windows.Forms.Button mDrawButton;
        private System.Windows.Forms.Button mRotateButton;
        private System.Windows.Forms.Button mScaleButton;
        private System.Windows.Forms.Button mResetButton;
        private System.Windows.Forms.Button mMirrorXButton;
        private System.Windows.Forms.Label Reflect;
        private System.Windows.Forms.Button mMirrorYButton;
        private System.Windows.Forms.NumericUpDown mRotationAngleUpDown;
        private System.Windows.Forms.Label mAngleLabel;
        private System.Windows.Forms.Label mXScalarLabel;
        private System.Windows.Forms.NumericUpDown mXScalarUpDown;
        private System.Windows.Forms.Label mYScalarLabel;
        private System.Windows.Forms.NumericUpDown mYScalarUpDown;
        private System.Windows.Forms.GroupBox mTransformationsgroupBox;
        private System.Windows.Forms.Button mTranslationButton;
        private System.Windows.Forms.Label mYTranslationLabel;
        private System.Windows.Forms.NumericUpDown mYTranslationUpDown;
        private System.Windows.Forms.Label mXTranslationLabel;
        private System.Windows.Forms.NumericUpDown mXTranslationUpDown;
        private System.Windows.Forms.Label mXAndYInfoLabel;
        private System.Windows.Forms.Label mSolutionLabel;
    }
}


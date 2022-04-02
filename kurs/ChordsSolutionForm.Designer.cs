
namespace WindowsFormsApp2
{
    partial class ChordsSolutionForm
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
            this.mSolveButton = new System.Windows.Forms.Button();
            this.mResetButton = new System.Windows.Forms.Button();
            this.mRotationAngleUpDown = new System.Windows.Forms.NumericUpDown();
            this.mAngleLabel = new System.Windows.Forms.Label();
            this.mXScalarLabel = new System.Windows.Forms.Label();
            this.mXScalarUpDown = new System.Windows.Forms.NumericUpDown();
            this.mSolutionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mAnimationSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.mBBoundLabel = new System.Windows.Forms.Label();
            this.mBBoundTextBox = new System.Windows.Forms.TextBox();
            this.mABoundLabel = new System.Windows.Forms.Label();
            this.mABoundTextBox = new System.Windows.Forms.TextBox();
            this.mXAndYInfoLabel = new System.Windows.Forms.Label();
            this.mSolutionLabel = new System.Windows.Forms.Label();
            this.mEpsilonLabel = new System.Windows.Forms.Label();
            this.mEpsilonTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRotationAngleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXScalarUpDown)).BeginInit();
            this.mSolutionSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAnimationSpeedTrackBar)).BeginInit();
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
            this.m_picture.Size = new System.Drawing.Size(1232, 643);
            this.m_picture.TabIndex = 0;
            this.m_picture.TabStop = false;
            this.m_picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mPicture_MouseMove);
            this.m_picture.Resize += new System.EventHandler(this.mPicture_Resize);
            // 
            // mSolveButton
            // 
            this.mSolveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mSolveButton.Location = new System.Drawing.Point(513, 662);
            this.mSolveButton.Name = "mSolveButton";
            this.mSolveButton.Size = new System.Drawing.Size(106, 34);
            this.mSolveButton.TabIndex = 1;
            this.mSolveButton.Text = "Solve";
            this.mSolveButton.UseVisualStyleBackColor = true;
            this.mSolveButton.Click += new System.EventHandler(this.mSolveButton_Click);
            // 
            // mResetButton
            // 
            this.mResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mResetButton.Location = new System.Drawing.Point(625, 662);
            this.mResetButton.Name = "mResetButton";
            this.mResetButton.Size = new System.Drawing.Size(110, 34);
            this.mResetButton.TabIndex = 4;
            this.mResetButton.Text = "Reset";
            this.mResetButton.UseVisualStyleBackColor = true;
            this.mResetButton.Click += new System.EventHandler(this.mResetButton_Click);
            // 
            // mRotationAngleUpDown
            // 
            this.mRotationAngleUpDown.Location = new System.Drawing.Point(373, 32);
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
            this.mAngleLabel.Location = new System.Drawing.Point(370, 16);
            this.mAngleLabel.Name = "mAngleLabel";
            this.mAngleLabel.Size = new System.Drawing.Size(37, 13);
            this.mAngleLabel.TabIndex = 10;
            this.mAngleLabel.Text = "Angle:";
            // 
            // mXScalarLabel
            // 
            this.mXScalarLabel.AutoSize = true;
            this.mXScalarLabel.Location = new System.Drawing.Point(431, 16);
            this.mXScalarLabel.Name = "mXScalarLabel";
            this.mXScalarLabel.Size = new System.Drawing.Size(48, 13);
            this.mXScalarLabel.TabIndex = 12;
            this.mXScalarLabel.Text = "X scalar:";
            // 
            // mXScalarUpDown
            // 
            this.mXScalarUpDown.DecimalPlaces = 3;
            this.mXScalarUpDown.Location = new System.Drawing.Point(434, 32);
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
            // mSolutionSettingsGroupBox
            // 
            this.mSolutionSettingsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mSolutionSettingsGroupBox.Controls.Add(this.mEpsilonLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mEpsilonTextBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.label1);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mAnimationSpeedTrackBar);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mBBoundLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mBBoundTextBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mABoundLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mABoundTextBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mRotationAngleUpDown);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mAngleLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mXScalarLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mXScalarUpDown);
            this.mSolutionSettingsGroupBox.Location = new System.Drawing.Point(169, 702);
            this.mSolutionSettingsGroupBox.Name = "mSolutionSettingsGroupBox";
            this.mSolutionSettingsGroupBox.Size = new System.Drawing.Size(876, 87);
            this.mSolutionSettingsGroupBox.TabIndex = 15;
            this.mSolutionSettingsGroupBox.TabStop = false;
            this.mSolutionSettingsGroupBox.Text = "Solution settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Animation speed";
            // 
            // mAnimationSpeedTrackBar
            // 
            this.mAnimationSpeedTrackBar.AutoSize = false;
            this.mAnimationSpeedTrackBar.LargeChange = 10;
            this.mAnimationSpeedTrackBar.Location = new System.Drawing.Point(632, 45);
            this.mAnimationSpeedTrackBar.Maximum = 500;
            this.mAnimationSpeedTrackBar.Minimum = 1;
            this.mAnimationSpeedTrackBar.Name = "mAnimationSpeedTrackBar";
            this.mAnimationSpeedTrackBar.Size = new System.Drawing.Size(238, 33);
            this.mAnimationSpeedTrackBar.TabIndex = 24;
            this.mAnimationSpeedTrackBar.TabStop = false;
            this.mAnimationSpeedTrackBar.Value = 1;
            this.mAnimationSpeedTrackBar.Scroll += new System.EventHandler(this.mAnimationSpeedTrackBar_Scroll);
            // 
            // mBBoundLabel
            // 
            this.mBBoundLabel.AutoSize = true;
            this.mBBoundLabel.Location = new System.Drawing.Point(124, 26);
            this.mBBoundLabel.Name = "mBBoundLabel";
            this.mBBoundLabel.Size = new System.Drawing.Size(63, 13);
            this.mBBoundLabel.TabIndex = 23;
            this.mBBoundLabel.Text = "right bound:";
            // 
            // mBBoundTextBox
            // 
            this.mBBoundTextBox.Location = new System.Drawing.Point(127, 45);
            this.mBBoundTextBox.Name = "mBBoundTextBox";
            this.mBBoundTextBox.Size = new System.Drawing.Size(100, 20);
            this.mBBoundTextBox.TabIndex = 22;
            this.mBBoundTextBox.TextChanged += new System.EventHandler(this.mBBoundTextBox_TextChanged);
            // 
            // mABoundLabel
            // 
            this.mABoundLabel.AutoSize = true;
            this.mABoundLabel.Location = new System.Drawing.Point(17, 26);
            this.mABoundLabel.Name = "mABoundLabel";
            this.mABoundLabel.Size = new System.Drawing.Size(57, 13);
            this.mABoundLabel.TabIndex = 21;
            this.mABoundLabel.Text = "left bound:";
            // 
            // mABoundTextBox
            // 
            this.mABoundTextBox.Location = new System.Drawing.Point(20, 45);
            this.mABoundTextBox.Name = "mABoundTextBox";
            this.mABoundTextBox.Size = new System.Drawing.Size(100, 20);
            this.mABoundTextBox.TabIndex = 20;
            this.mABoundTextBox.TextChanged += new System.EventHandler(this.mABoundTextBox_TextChanged);
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
            // mEpsilonLabel
            // 
            this.mEpsilonLabel.AutoSize = true;
            this.mEpsilonLabel.Location = new System.Drawing.Point(249, 24);
            this.mEpsilonLabel.Name = "mEpsilonLabel";
            this.mEpsilonLabel.Size = new System.Drawing.Size(27, 13);
            this.mEpsilonLabel.TabIndex = 27;
            this.mEpsilonLabel.Text = "eps:";
            // 
            // mEpsilonTextBox
            // 
            this.mEpsilonTextBox.Location = new System.Drawing.Point(252, 43);
            this.mEpsilonTextBox.Name = "mEpsilonTextBox";
            this.mEpsilonTextBox.Size = new System.Drawing.Size(100, 20);
            this.mEpsilonTextBox.TabIndex = 26;
            this.mEpsilonTextBox.TextChanged += new System.EventHandler(this.mEpsilonTextBox_TextChanged);
            // 
            // ChordsSolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1256, 800);
            this.Controls.Add(this.mSolutionLabel);
            this.Controls.Add(this.mXAndYInfoLabel);
            this.Controls.Add(this.mSolutionSettingsGroupBox);
            this.Controls.Add(this.mResetButton);
            this.Controls.Add(this.mSolveButton);
            this.Controls.Add(this.m_picture);
            this.Name = "ChordsSolutionForm";
            this.Text = "ChordsSolutionForm";
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mRotationAngleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mXScalarUpDown)).EndInit();
            this.mSolutionSettingsGroupBox.ResumeLayout(false);
            this.mSolutionSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAnimationSpeedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picture;
        private System.Windows.Forms.Button mSolveButton;
        private System.Windows.Forms.Button mResetButton;
        private System.Windows.Forms.NumericUpDown mRotationAngleUpDown;
        private System.Windows.Forms.Label mAngleLabel;
        private System.Windows.Forms.Label mXScalarLabel;
        private System.Windows.Forms.NumericUpDown mXScalarUpDown;
        private System.Windows.Forms.GroupBox mSolutionSettingsGroupBox;
        private System.Windows.Forms.Label mXAndYInfoLabel;
        private System.Windows.Forms.Label mSolutionLabel;
        private System.Windows.Forms.TextBox mABoundTextBox;
        private System.Windows.Forms.Label mBBoundLabel;
        private System.Windows.Forms.TextBox mBBoundTextBox;
        private System.Windows.Forms.Label mABoundLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar mAnimationSpeedTrackBar;
        private System.Windows.Forms.Label mEpsilonLabel;
        private System.Windows.Forms.TextBox mEpsilonTextBox;
    }
}


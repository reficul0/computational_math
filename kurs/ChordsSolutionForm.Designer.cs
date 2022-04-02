
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
            this.mSolutionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.mFunctionsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mEpsilonLabel = new System.Windows.Forms.Label();
            this.mEpsilonTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mAnimationSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.mBBoundLabel = new System.Windows.Forms.Label();
            this.mBBoundTextBox = new System.Windows.Forms.TextBox();
            this.mABoundLabel = new System.Windows.Forms.Label();
            this.mABoundTextBox = new System.Windows.Forms.TextBox();
            this.mXAndYInfoLabel = new System.Windows.Forms.Label();
            this.mSolutionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_picture)).BeginInit();
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
            this.mSolveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.mResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mResetButton.Location = new System.Drawing.Point(625, 662);
            this.mResetButton.Name = "mResetButton";
            this.mResetButton.Size = new System.Drawing.Size(110, 34);
            this.mResetButton.TabIndex = 4;
            this.mResetButton.Text = "Reset";
            this.mResetButton.UseVisualStyleBackColor = true;
            this.mResetButton.Click += new System.EventHandler(this.mResetButton_Click);
            // 
            // mSolutionSettingsGroupBox
            // 
            this.mSolutionSettingsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mSolutionSettingsGroupBox.Controls.Add(this.mFunctionsComboBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.label2);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mEpsilonLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mEpsilonTextBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.label1);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mAnimationSpeedTrackBar);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mBBoundLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mBBoundTextBox);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mABoundLabel);
            this.mSolutionSettingsGroupBox.Controls.Add(this.mABoundTextBox);
            this.mSolutionSettingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mSolutionSettingsGroupBox.Location = new System.Drawing.Point(251, 701);
            this.mSolutionSettingsGroupBox.Name = "mSolutionSettingsGroupBox";
            this.mSolutionSettingsGroupBox.Size = new System.Drawing.Size(751, 87);
            this.mSolutionSettingsGroupBox.TabIndex = 15;
            this.mSolutionSettingsGroupBox.TabStop = false;
            this.mSolutionSettingsGroupBox.Text = "Solution settings";
            // 
            // mFunctionsComboBox
            // 
            this.mFunctionsComboBox.FormattingEnabled = true;
            this.mFunctionsComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mFunctionsComboBox.Location = new System.Drawing.Point(371, 45);
            this.mFunctionsComboBox.Name = "mFunctionsComboBox";
            this.mFunctionsComboBox.Size = new System.Drawing.Size(121, 24);
            this.mFunctionsComboBox.TabIndex = 30;
            this.mFunctionsComboBox.SelectedValueChanged += new System.EventHandler(this.mFunctionsComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "function:";
            // 
            // mEpsilonLabel
            // 
            this.mEpsilonLabel.AutoSize = true;
            this.mEpsilonLabel.Location = new System.Drawing.Point(250, 26);
            this.mEpsilonLabel.Name = "mEpsilonLabel";
            this.mEpsilonLabel.Size = new System.Drawing.Size(35, 17);
            this.mEpsilonLabel.TabIndex = 27;
            this.mEpsilonLabel.Text = "eps:";
            // 
            // mEpsilonTextBox
            // 
            this.mEpsilonTextBox.Location = new System.Drawing.Point(253, 45);
            this.mEpsilonTextBox.Name = "mEpsilonTextBox";
            this.mEpsilonTextBox.Size = new System.Drawing.Size(100, 23);
            this.mEpsilonTextBox.TabIndex = 26;
            this.mEpsilonTextBox.TextChanged += new System.EventHandler(this.mEpsilonTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "animation speed:";
            // 
            // mAnimationSpeedTrackBar
            // 
            this.mAnimationSpeedTrackBar.AutoSize = false;
            this.mAnimationSpeedTrackBar.LargeChange = 10;
            this.mAnimationSpeedTrackBar.Location = new System.Drawing.Point(499, 41);
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
            this.mBBoundLabel.Location = new System.Drawing.Point(125, 26);
            this.mBBoundLabel.Name = "mBBoundLabel";
            this.mBBoundLabel.Size = new System.Drawing.Size(84, 17);
            this.mBBoundLabel.TabIndex = 23;
            this.mBBoundLabel.Text = "right bound:";
            // 
            // mBBoundTextBox
            // 
            this.mBBoundTextBox.Location = new System.Drawing.Point(128, 45);
            this.mBBoundTextBox.Name = "mBBoundTextBox";
            this.mBBoundTextBox.Size = new System.Drawing.Size(100, 23);
            this.mBBoundTextBox.TabIndex = 22;
            this.mBBoundTextBox.TextChanged += new System.EventHandler(this.mBBoundTextBox_TextChanged);
            // 
            // mABoundLabel
            // 
            this.mABoundLabel.AutoSize = true;
            this.mABoundLabel.Location = new System.Drawing.Point(18, 26);
            this.mABoundLabel.Name = "mABoundLabel";
            this.mABoundLabel.Size = new System.Drawing.Size(75, 17);
            this.mABoundLabel.TabIndex = 21;
            this.mABoundLabel.Text = "left bound:";
            // 
            // mABoundTextBox
            // 
            this.mABoundTextBox.Location = new System.Drawing.Point(21, 45);
            this.mABoundTextBox.Name = "mABoundTextBox";
            this.mABoundTextBox.Size = new System.Drawing.Size(100, 23);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mFunctionsComboBox;
    }
}


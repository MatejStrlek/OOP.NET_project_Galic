namespace WIndowsFormApp
{
    partial class InitForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cbGender = new ComboBox();
            cbLanguage = new ComboBox();
            btnLanguage = new Button();
            btnGender = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 106);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Choose language:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 106);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Choose gender:";
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(261, 124);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 23);
            cbGender.TabIndex = 2;
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Items.AddRange(new object[] { "English", "Croatian" });
            cbLanguage.Location = new Point(14, 124);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(121, 23);
            cbLanguage.TabIndex = 3;
            // 
            // btnLanguage
            // 
            btnLanguage.Location = new Point(141, 123);
            btnLanguage.Name = "btnLanguage";
            btnLanguage.Size = new Size(75, 23);
            btnLanguage.TabIndex = 4;
            btnLanguage.Text = "Select";
            btnLanguage.UseVisualStyleBackColor = true;
            btnLanguage.Click += btnLanguage_Click;
            // 
            // btnGender
            // 
            btnGender.Location = new Point(388, 123);
            btnGender.Name = "btnGender";
            btnGender.Size = new Size(75, 23);
            btnGender.TabIndex = 5;
            btnGender.Text = "Select";
            btnGender.UseVisualStyleBackColor = true;
            btnGender.Click += btnGender_Click;
            // 
            // InitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 279);
            Controls.Add(btnGender);
            Controls.Add(btnLanguage);
            Controls.Add(cbLanguage);
            Controls.Add(cbGender);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InitForm";
            Text = "FIFA world cup 2018.";
            FormClosing += InitForm_FormClosing;
            Load += InitForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbGender;
        private ComboBox cbLanguage;
        private Button btnLanguage;
        private Button btnGender;
    }
}
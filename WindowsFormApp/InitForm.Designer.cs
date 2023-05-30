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
            btnOpenApp = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 84);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Choose language:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(190, 84);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Choose gender:";
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(176, 102);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 23);
            cbGender.TabIndex = 2;
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Items.AddRange(new object[] { "English", "Croatian" });
            cbLanguage.Location = new Point(14, 102);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(121, 23);
            cbLanguage.TabIndex = 3;
            // 
            // btnOpenApp
            // 
            btnOpenApp.Location = new Point(110, 169);
            btnOpenApp.Name = "btnOpenApp";
            btnOpenApp.Size = new Size(96, 44);
            btnOpenApp.TabIndex = 4;
            btnOpenApp.Text = "Open App";
            btnOpenApp.UseVisualStyleBackColor = true;
            btnOpenApp.Click += btnOpenApp_Click;
            // 
            // InitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 225);
            Controls.Add(btnOpenApp);
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
        private Button btnOpenApp;
    }
}
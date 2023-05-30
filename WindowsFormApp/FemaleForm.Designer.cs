namespace WindowsFormApp
{
    partial class FemaleForm
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
            label1 = new Label();
            cbFavoriteFemaleTeam = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 42);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Favorite female team:";
            // 
            // cbFavoriteFemaleTeam
            // 
            cbFavoriteFemaleTeam.FormattingEnabled = true;
            cbFavoriteFemaleTeam.Location = new Point(28, 60);
            cbFavoriteFemaleTeam.Name = "cbFavoriteFemaleTeam";
            cbFavoriteFemaleTeam.Size = new Size(121, 23);
            cbFavoriteFemaleTeam.TabIndex = 1;
            // 
            // FemaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbFavoriteFemaleTeam);
            Controls.Add(label1);
            Name = "FemaleForm";
            Text = "Female Form";
            Load += FemaleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavoriteFemaleTeam;
    }
}
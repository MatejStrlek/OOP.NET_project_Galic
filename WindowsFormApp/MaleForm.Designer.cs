﻿namespace WindowsFormApp
{
    partial class MaleForm
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
            cbFavoriteMaleTeam = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 37);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "Favorite male team:";
            // 
            // cbFavoriteMaleTeam
            // 
            cbFavoriteMaleTeam.FormattingEnabled = true;
            cbFavoriteMaleTeam.Location = new Point(48, 55);
            cbFavoriteMaleTeam.Name = "cbFavoriteMaleTeam";
            cbFavoriteMaleTeam.Size = new Size(121, 23);
            cbFavoriteMaleTeam.TabIndex = 1;
            // 
            // MaleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbFavoriteMaleTeam);
            Controls.Add(label1);
            Name = "MaleForm";
            Text = "Male Form";
            Load += MaleForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbFavoriteMaleTeam;
    }
}
namespace Project.V1
{
    partial class FormAbout
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
            textBoxHelp_TLA = new TextBox();
            buttonHelpOK_TLA = new Button();
            SuspendLayout();
            // 
            // textBoxHelp_TLA
            // 
            textBoxHelp_TLA.Enabled = false;
            textBoxHelp_TLA.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxHelp_TLA.Location = new Point(6, 8);
            textBoxHelp_TLA.Multiline = true;
            textBoxHelp_TLA.Name = "textBoxHelp_TLA";
            textBoxHelp_TLA.ReadOnly = true;
            textBoxHelp_TLA.Size = new Size(506, 230);
            textBoxHelp_TLA.TabIndex = 0;
            textBoxHelp_TLA.Text = "Sprint 7\r\n\r\nРаботу выполнил Тяжов Леонид Александрович \r\n\r\nПКТб-24-1\r\n\r\nПредметная область: Авторемонтная мастерская";
            textBoxHelp_TLA.TextChanged += buttonHelpOK_TLA_Click;
            // 
            // buttonHelpOK_TLA
            // 
            buttonHelpOK_TLA.BackColor = Color.SpringGreen;
            buttonHelpOK_TLA.FlatStyle = FlatStyle.System;
            buttonHelpOK_TLA.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonHelpOK_TLA.ForeColor = Color.Turquoise;
            buttonHelpOK_TLA.Location = new Point(364, 244);
            buttonHelpOK_TLA.Name = "buttonHelpOK_TLA";
            buttonHelpOK_TLA.Size = new Size(125, 47);
            buttonHelpOK_TLA.TabIndex = 1;
            buttonHelpOK_TLA.Text = "ОК";
            buttonHelpOK_TLA.UseVisualStyleBackColor = false;
            buttonHelpOK_TLA.Click += buttonHelpOK_TLA_Click;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 298);
            Controls.Add(buttonHelpOK_TLA);
            Controls.Add(textBoxHelp_TLA);
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Справка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxHelp_TLA;
        private Button buttonHelpOK_TLA;
    }
}
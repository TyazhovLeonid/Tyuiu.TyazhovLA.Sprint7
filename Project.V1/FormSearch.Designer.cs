namespace Project.V1
{
    partial class FormSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
            groupBoxSearchForm_TLA = new GroupBox();
            buttonGoSearch_TLA = new Button();
            textBoxSearch_TLA = new TextBox();
            groupBoxSearchForm_TLA.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxSearchForm_TLA
            // 
            groupBoxSearchForm_TLA.Controls.Add(buttonGoSearch_TLA);
            groupBoxSearchForm_TLA.Controls.Add(textBoxSearch_TLA);
            groupBoxSearchForm_TLA.Location = new Point(12, 12);
            groupBoxSearchForm_TLA.Name = "groupBoxSearchForm_TLA";
            groupBoxSearchForm_TLA.Size = new Size(387, 79);
            groupBoxSearchForm_TLA.TabIndex = 0;
            groupBoxSearchForm_TLA.TabStop = false;
            groupBoxSearchForm_TLA.Text = "Введите номер:";
            // 
            // buttonGoSearch_TLA
            // 
            buttonGoSearch_TLA.BackgroundImage = (Image)resources.GetObject("buttonGoSearch_TLA.BackgroundImage");
            buttonGoSearch_TLA.BackgroundImageLayout = ImageLayout.Zoom;
            buttonGoSearch_TLA.Location = new Point(169, 35);
            buttonGoSearch_TLA.Name = "buttonGoSearch_TLA";
            buttonGoSearch_TLA.Size = new Size(27, 27);
            buttonGoSearch_TLA.TabIndex = 1;
            buttonGoSearch_TLA.UseVisualStyleBackColor = true;
            buttonGoSearch_TLA.Click += buttonGoSearch_TLA_Click;
            // 
            // textBoxSearch_TLA
            // 
            textBoxSearch_TLA.Location = new Point(20, 35);
            textBoxSearch_TLA.Name = "textBoxSearch_TLA";
            textBoxSearch_TLA.Size = new Size(143, 27);
            textBoxSearch_TLA.TabIndex = 0;
            // 
            // FormSearch
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(232, 103);
            Controls.Add(groupBoxSearchForm_TLA);
            MaximumSize = new Size(250, 150);
            MinimumSize = new Size(250, 150);
            Name = "FormSearch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поиск по гос. номеру автомобиля";
            groupBoxSearchForm_TLA.ResumeLayout(false);
            groupBoxSearchForm_TLA.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxSearchForm_TLA;
        private TextBox textBoxSearch_TLA;
        private Button buttonGoSearch_TLA;
    }
}
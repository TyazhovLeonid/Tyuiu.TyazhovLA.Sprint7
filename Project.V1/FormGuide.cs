using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.V1
{
    public partial class FormGuide : Form
    {
        public FormGuide()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormGuide));
            textBoxGuide_TLA = new TextBox();
            buttonOK_TLA = new Button();
            SuspendLayout();
            // 
            // textBoxGuide_TLA
            // 
            textBoxGuide_TLA.BackColor = SystemColors.ControlLightLight;
            textBoxGuide_TLA.Enabled = false;
            textBoxGuide_TLA.ForeColor = SystemColors.InactiveBorder;
            textBoxGuide_TLA.Location = new Point(11, 14);
            textBoxGuide_TLA.Multiline = true;
            textBoxGuide_TLA.Name = "textBoxGuide_TLA";
            textBoxGuide_TLA.ReadOnly = true;
            textBoxGuide_TLA.Size = new Size(388, 505);
            textBoxGuide_TLA.TabIndex = 0;
            textBoxGuide_TLA.Text = resources.GetString("textBoxGuide_TLA.Text");
            // 
            // buttonOK_TLA
            // 
            buttonOK_TLA.FlatStyle = FlatStyle.Popup;
            buttonOK_TLA.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonOK_TLA.Location = new Point(323, 525);
            buttonOK_TLA.Name = "buttonOK_TLA";
            buttonOK_TLA.Size = new Size(74, 32);
            buttonOK_TLA.TabIndex = 1;
            buttonOK_TLA.Text = "OK";
            buttonOK_TLA.UseVisualStyleBackColor = true;
            buttonOK_TLA.Click += buttonOK_TLA_Click;
            // 
            // FormGuide
            // 
            ClientSize = new Size(412, 562);
            Controls.Add(buttonOK_TLA);
            Controls.Add(textBoxGuide_TLA);
            Name = "FormGuide";
            Text = "Руководство пользователя";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBoxGuide_TLA;
        private Button buttonOK_TLA;

        private void buttonOK_TLA_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

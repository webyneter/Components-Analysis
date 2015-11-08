using System;
using System.Windows.Forms;


namespace Webyneter.ComponentsAnalysis.App
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.main_form_icon;
        }
    }
}

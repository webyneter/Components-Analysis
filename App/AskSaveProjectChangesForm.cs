using System;
using System.Windows.Forms;


namespace Webyneter.ComponentsAnalysis.App
{
    public partial class AskSaveProjectChangesForm : Form
    {
        public AskSaveProjectChangesForm()
        {
            InitializeComponent();
        }

        private void AskSaveProjectChangesForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.main_form_icon;
        }
    }
}

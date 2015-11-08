using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;

using wilsone8.FastDirectoryEnumerator;

using Webyneter.ComponentsAnalysis.App.Properties;
using Webyneter.ComponentsAnalysis.Core;


namespace Webyneter.ComponentsAnalysis.App
{
    public partial class CreateProjectForm : Form
    {
        public string ProjectFilePath { get; private set; }

        private readonly ResourceManager resourceManager;

        public CreateProjectForm()
        {
            InitializeComponent();

            resourceManager = new ResourceManager(typeof(CreateProjectForm));
        }

        private void CreateProjectForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.main_form_icon;
            tbDir.Text = Settings.Default.ProjectFilesDir;
            fbdDialog.SelectedPath = Settings.Default.ProjectFilesDir;
        }

        private int CalculateMaxProjectFileNumber(string dirPath)
        {
            int maxOrdNum = 0;
            foreach (FileData fd in FastDirectoryEnumerator.EnumerateFiles(dirPath, 
                "*" + Project.ProjectFileExtension, SearchOption.TopDirectoryOnly))
            {
                int ordNum;
                string tail = fd.Name.TrimStart(resourceManager.GetString("ProjectFileNameDefault").ToCharArray())
                    .TrimEnd(Project.ProjectFileExtension.ToCharArray());
                if (int.TryParse(tail, out ordNum)
                    && ordNum > maxOrdNum)
                {
                    maxOrdNum = ordNum;
                }
            }
            return maxOrdNum;
        }

        private void btnNameReset_Click(object sender, EventArgs e)
        {
            tbName.Text = resourceManager.GetString("ProjectFileNameDefault").TrimEnd(' ');
            int ordNum = CalculateMaxProjectFileNumber(Settings.Default.ProjectFilesDir);
            if (ordNum > 0)
            {
                tbName.Text += ordNum + 1;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(tbDir.Text, tbName.Text + Project.ProjectFileExtension)))
            {
                lblWarning.Visible = cbOverwriteExisting.Visible = true;
                btnOk.Enabled = cbOverwriteExisting.Checked;
            }
            else
            {
                lblWarning.Visible = cbOverwriteExisting.Visible = false;
                btnOk.Enabled = true;
            }
        }

        private void tbDir_TextChanged(object sender, EventArgs e)
        {
            btnNameReset_Click(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ProjectFilePath = Path.Combine(tbDir.Text, tbName.Text + Project.ProjectFileExtension);
        }

        private void cbOverwriteExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(tbDir.Text, tbName.Text + Project.ProjectFileExtension)))
            {
                btnOk.Enabled = cbOverwriteExisting.Checked;
            }
        }
    }
}
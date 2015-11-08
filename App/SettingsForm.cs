using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Kernels;

using Infralution.Localization;

using Webyneter.ComponentsAnalysis.App.Properties;
using Webyneter.ComponentsAnalysis.Core;
using Webyneter.ComponentsAnalysis.Core.Analysis.KPCA;
using Webyneter.ComponentsAnalysis.Miscellaneous;


namespace Webyneter.ComponentsAnalysis.App
{
    public partial class SettingsForm : Form
    {
        public DataTable ImportedInputData { get; set; }

        private bool recentsChangedMessageShown;
        private readonly ResourceManager resourceManager;
        private readonly int selectedLanguageIndex = -1;

        private event EventHandler RecentsChanged = delegate { };
        private event EventHandler KernelSelected = delegate { };
        
        public SettingsForm()
        {
            InitializeComponent();

            resourceManager = new ResourceManager(typeof(SettingsForm));

            cbLanguages.Items.Clear();
            int i = 0;
            foreach (var ci in Utilities.SupportedAppDomainCultures)
            {
                cbLanguages.Items.Add(ci);
                if (CultureManager.ApplicationUICulture.Parent.Equals(ci)
                    || CultureManager.ApplicationUICulture.Equals(ci))
                {
                    cbLanguages.SelectedIndex = selectedLanguageIndex = i;
                }
                ++i;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            RecentsChanged += (s, ea) => 
                MessageBox.Show(resourceManager.GetString("ChangesWillTakePlaceAfterRestartOnly"));
            KernelSelected += (s, ea) =>
            {
                if (rbKPCAGaussianKernel.Checked)
                {
                    numKPCASigma.Enabled = true;
                    lblKPCADegree.Enabled = 
                        lblKPCAConstant.Enabled = 
                        numKPCADegree.Enabled = 
                        numKPCAConstant.Enabled = false;
                }
                else if (rbKPCAPolynomialKernel.Checked)
                {
                    lblKPCADegree.Enabled = 
                        lblKPCAConstant.Enabled = 
                        numKPCADegree.Enabled = 
                        numKPCAConstant.Enabled =
                        numKPCASigma.Enabled = false;
                }
            };

            Icon = Properties.Resources.main_form_icon;
            MinimumSize = Settings.Default.AppWindowMinimumSizeDefault;
            Size = MinimumSize;
            btnKPCAEstimated.Enabled = (ImportedInputData != null);
            ApplySettings();
        }

        private void ApplySettings()
        {
            tbProjectsDir.Text = fbdProjectsDir.SelectedPath = Settings.Default.ProjectFilesDir;
            nudRecentsMemorised.Value = Settings.Default.RecentProjectsMemorised;
            tbInputFilesDir.Text = fbdInputFilesDir.SelectedPath = Settings.Default.InputFilesDir;
            lblSupportedInputFileFormatsList.Text += string.Join(", ", Project.SupportedInputExtensionFormatMap);
            tbOutputFilesDir.Text = fbdOutputFilesDir.SelectedPath = Settings.Default.OutputFilesDir;
            cbPCAAnalysisMethod.DataSource = cbKPCAAnalysisMethod.DataSource = Enum.GetValues(typeof(AnalysisMethod));
            cbPCAAnalysisMethod.SelectedItem = Settings.Default.PCAMethod;
            cbKPCAAnalysisMethod.SelectedItem = Settings.Default.KPCAMethod;
            cbKPCACenterInFeatureSpace.Checked = Settings.Default.KPCACenterInFeatureSpace;
            switch (Settings.Default.KPCAKernelKind)
            {
                case KPCAKernelKind.Gaussian:
                    rbKPCAGaussianKernel.Checked = true;
                    numKPCASigma.Value = (decimal)Settings.Default.KPCASigma;
                    break;
                case KPCAKernelKind.Polynomial:
                    rbKPCAPolynomialKernel.Checked = true;
                    numKPCAConstant.Value = (decimal) Settings.Default.KPCAConstant;
                    numKPCADegree.Value = (decimal) Settings.Default.KPCADegree;
                    break;
            }
            KernelSelected(this, new EventArgs());
        }

        private void ApplyChanges()
        {
            Settings.Default.ProjectFilesDir = tbProjectsDir.Text;
            Settings.Default.RecentProjectsMemorised = (byte) nudRecentsMemorised.Value;
            Settings.Default.InputFilesDir = tbInputFilesDir.Text;
            Settings.Default.OutputFilesDir = tbOutputFilesDir.Text;
            var selLang = cbLanguages.Items[cbLanguages.SelectedIndex].ToString();
            if (!CultureManager.ApplicationUICulture.Name.Equals(selLang))
            {
                var cult = CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(info => info.Name == selLang);
                //CultureManager.ApplicationUICulture = new CultureInfo(cult);
                CultureManager.ApplicationUICulture = cult;
            }
            Settings.Default.PCAMethod = (AnalysisMethod) cbPCAAnalysisMethod.SelectedItem;
            Settings.Default.KPCAMethod = (AnalysisMethod) cbKPCAAnalysisMethod.SelectedItem;
            Settings.Default.KPCACenterInFeatureSpace = cbKPCACenterInFeatureSpace.Checked;
            if (rbKPCAGaussianKernel.Checked)
            {
                Settings.Default.KPCAKernelKind = KPCAKernelKind.Gaussian;
                Settings.Default.KPCASigma = (double) numKPCASigma.Value;
            }
            else if (rbKPCAPolynomialKernel.Checked)
            {
                Settings.Default.KPCAKernelKind = KPCAKernelKind.Polynomial;
                Settings.Default.KPCAConstant = (double) numKPCAConstant.Value;
                Settings.Default.KPCADegree = (int) numKPCADegree.Value;
            }
        }

        private void btnProjectsDirResetPath_Click(object sender, EventArgs e)
        {
            tbProjectsDir.Text = Settings.Default.ProjectsDirDefault();
        }

        private void btnInputFilesDirResetPath_Click(object sender, EventArgs e)
        {
            tbInputFilesDir.Text = Settings.Default.InputFilesDirDefault();
        }

        private void btnOutputFilesDirResetPath_Click(object sender, EventArgs e)
        {
            tbOutputFilesDir.Text = Settings.Default.OutputFilesDirDefault();
        }

        private void brnResetLanguage_Click(object sender, EventArgs e)
        {
            cbLanguages.SelectedIndex = selectedLanguageIndex;
        }

        private void btnProjectsDirBrowse_Click(object sender, EventArgs e)
        {
            if (fbdProjectsDir.ShowDialog() == DialogResult.OK)
            {
                tbProjectsDir.Text = fbdProjectsDir.SelectedPath;
            }
        }

        private void btnInputFilesDirBrowse_Click(object sender, EventArgs e)
        {
            if (fbdInputFilesDir.ShowDialog() == DialogResult.OK)
            {
                tbInputFilesDir.Text = fbdInputFilesDir.SelectedPath;
            }
        }

        private void btnOutputFilesDirBrowse_Click(object sender, EventArgs e)
        {
            if (fbdOutputFilesDir.ShowDialog() == DialogResult.OK)
            {
                tbOutputFilesDir.Text = fbdOutputFilesDir.SelectedPath;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e) { ApplyChanges(); }

        private void nudRecentsMemorized_ValueChanged(object sender, EventArgs e)
        {
            if (recentsChangedMessageShown)
            {
                RecentsChanged(this, new EventArgs());
                recentsChangedMessageShown = true;
            }
        }

        private void rbGaussianKernel_CheckedChanged(object sender, EventArgs e)
        {
            KernelSelected(this, new EventArgs());
        }

        private void rbPolynomialKernel_CheckedChanged(object sender, EventArgs e)
        {
            KernelSelected(this, new EventArgs());
        }

        private void btnKPCAEstimated_Click(object sender, EventArgs e)
        {
            if (ImportedInputData != null)
            {
                string[] columnNames;
                numKPCASigma.Value = (decimal) Gaussian.Estimate(ImportedInputData.ToMatrix(out columnNames)
                    .GetColumns(0, 1).ToArray()).Sigma;
            }
        }
    }
}

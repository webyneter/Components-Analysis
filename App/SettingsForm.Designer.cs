namespace Webyneter.ComponentsAnalysis.App
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.lblRecentsMemorized = new System.Windows.Forms.Label();
            this.lblSupportedInputFileFormats = new System.Windows.Forms.Label();
            this.tlpOutputFilesDir = new System.Windows.Forms.TableLayoutPanel();
            this.btnOutputFilesDirBrowse = new System.Windows.Forms.Button();
            this.tbOutputFilesDir = new System.Windows.Forms.TextBox();
            this.btnOutputFilesDirReset = new System.Windows.Forms.Button();
            this.tlpInputFilesDir = new System.Windows.Forms.TableLayoutPanel();
            this.btnInputFilesDirBrowse = new System.Windows.Forms.Button();
            this.tbInputFilesDir = new System.Windows.Forms.TextBox();
            this.btnInputFilesDirReset = new System.Windows.Forms.Button();
            this.lblProjectsDir = new System.Windows.Forms.Label();
            this.lblInputFilesDir = new System.Windows.Forms.Label();
            this.lblOutputFilesDir = new System.Windows.Forms.Label();
            this.tlpProjectsDir = new System.Windows.Forms.TableLayoutPanel();
            this.btnProjectsDirBrowse = new System.Windows.Forms.Button();
            this.tbProjectsDir = new System.Windows.Forms.TextBox();
            this.btnProjectsDirReset = new System.Windows.Forms.Button();
            this.lblSupportedInputFileFormatsList = new System.Windows.Forms.Label();
            this.nudRecentsMemorised = new System.Windows.Forms.NumericUpDown();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.tlpLanguage = new System.Windows.Forms.TableLayoutPanel();
            this.btnLanguageReset = new System.Windows.Forms.Button();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.tpAnalysis = new System.Windows.Forms.TabPage();
            this.tcAnalysisMethods = new System.Windows.Forms.TabControl();
            this.tpPCA = new System.Windows.Forms.TabPage();
            this.tlpPCA = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbPCAAnalysisMethod = new System.Windows.Forms.ComboBox();
            this.tpKernelPCA = new System.Windows.Forms.TabPage();
            this.tlpKPCA = new System.Windows.Forms.TableLayoutPanel();
            this.cbKPCACenterInFeatureSpace = new System.Windows.Forms.CheckBox();
            this.panelKPCAOptions = new System.Windows.Forms.Panel();
            this.numKPCASigma = new System.Windows.Forms.NumericUpDown();
            this.numKPCAConstant = new System.Windows.Forms.NumericUpDown();
            this.numKPCADegree = new System.Windows.Forms.NumericUpDown();
            this.lblKPCAConstant = new System.Windows.Forms.Label();
            this.lblKPCADegree = new System.Windows.Forms.Label();
            this.btnKPCAEstimated = new System.Windows.Forms.Button();
            this.rbKPCAPolynomialKernel = new System.Windows.Forms.RadioButton();
            this.rbKPCAGaussianKernel = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.cbKPCAAnalysisMethod = new System.Windows.Forms.ComboBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.fbdProjectsDir = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdInputFilesDir = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdOutputFilesDir = new System.Windows.Forms.FolderBrowserDialog();
            this.cultureManager = new Infralution.Localization.CultureManager(this.components);
            this.tlpGeneral.SuspendLayout();
            this.tlpOutputFilesDir.SuspendLayout();
            this.tlpInputFilesDir.SuspendLayout();
            this.tlpProjectsDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentsMemorised)).BeginInit();
            this.tlpLanguage.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpAnalysis.SuspendLayout();
            this.tcAnalysisMethods.SuspendLayout();
            this.tpPCA.SuspendLayout();
            this.tlpPCA.SuspendLayout();
            this.tpKernelPCA.SuspendLayout();
            this.tlpKPCA.SuspendLayout();
            this.panelKPCAOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCASigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCAConstant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCADegree)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            resources.ApplyResources(this.tlpGeneral, "tlpGeneral");
            this.tlpGeneral.Controls.Add(this.lblRecentsMemorized, 0, 1);
            this.tlpGeneral.Controls.Add(this.lblSupportedInputFileFormats, 0, 3);
            this.tlpGeneral.Controls.Add(this.tlpOutputFilesDir, 1, 4);
            this.tlpGeneral.Controls.Add(this.tlpInputFilesDir, 1, 2);
            this.tlpGeneral.Controls.Add(this.lblProjectsDir, 0, 0);
            this.tlpGeneral.Controls.Add(this.lblInputFilesDir, 0, 2);
            this.tlpGeneral.Controls.Add(this.lblOutputFilesDir, 0, 4);
            this.tlpGeneral.Controls.Add(this.tlpProjectsDir, 1, 0);
            this.tlpGeneral.Controls.Add(this.lblSupportedInputFileFormatsList, 1, 3);
            this.tlpGeneral.Controls.Add(this.nudRecentsMemorised, 1, 1);
            this.tlpGeneral.Controls.Add(this.lblLanguage, 0, 5);
            this.tlpGeneral.Controls.Add(this.tlpLanguage, 1, 5);
            this.tlpGeneral.Name = "tlpGeneral";
            // 
            // lblRecentsMemorized
            // 
            resources.ApplyResources(this.lblRecentsMemorized, "lblRecentsMemorized");
            this.lblRecentsMemorized.Name = "lblRecentsMemorized";
            // 
            // lblSupportedInputFileFormats
            // 
            resources.ApplyResources(this.lblSupportedInputFileFormats, "lblSupportedInputFileFormats");
            this.lblSupportedInputFileFormats.Name = "lblSupportedInputFileFormats";
            // 
            // tlpOutputFilesDir
            // 
            resources.ApplyResources(this.tlpOutputFilesDir, "tlpOutputFilesDir");
            this.tlpOutputFilesDir.Controls.Add(this.btnOutputFilesDirBrowse, 0, 0);
            this.tlpOutputFilesDir.Controls.Add(this.tbOutputFilesDir, 1, 0);
            this.tlpOutputFilesDir.Controls.Add(this.btnOutputFilesDirReset, 2, 0);
            this.tlpOutputFilesDir.Name = "tlpOutputFilesDir";
            // 
            // btnOutputFilesDirBrowse
            // 
            resources.ApplyResources(this.btnOutputFilesDirBrowse, "btnOutputFilesDirBrowse");
            this.btnOutputFilesDirBrowse.Name = "btnOutputFilesDirBrowse";
            this.btnOutputFilesDirBrowse.UseVisualStyleBackColor = true;
            this.btnOutputFilesDirBrowse.Click += new System.EventHandler(this.btnOutputFilesDirBrowse_Click);
            // 
            // tbOutputFilesDir
            // 
            resources.ApplyResources(this.tbOutputFilesDir, "tbOutputFilesDir");
            this.tbOutputFilesDir.Name = "tbOutputFilesDir";
            this.tbOutputFilesDir.ReadOnly = true;
            // 
            // btnOutputFilesDirReset
            // 
            resources.ApplyResources(this.btnOutputFilesDirReset, "btnOutputFilesDirReset");
            this.btnOutputFilesDirReset.Name = "btnOutputFilesDirReset";
            this.btnOutputFilesDirReset.UseVisualStyleBackColor = true;
            this.btnOutputFilesDirReset.Click += new System.EventHandler(this.btnOutputFilesDirResetPath_Click);
            // 
            // tlpInputFilesDir
            // 
            resources.ApplyResources(this.tlpInputFilesDir, "tlpInputFilesDir");
            this.tlpInputFilesDir.Controls.Add(this.btnInputFilesDirBrowse, 0, 0);
            this.tlpInputFilesDir.Controls.Add(this.tbInputFilesDir, 1, 0);
            this.tlpInputFilesDir.Controls.Add(this.btnInputFilesDirReset, 2, 0);
            this.tlpInputFilesDir.Name = "tlpInputFilesDir";
            // 
            // btnInputFilesDirBrowse
            // 
            resources.ApplyResources(this.btnInputFilesDirBrowse, "btnInputFilesDirBrowse");
            this.btnInputFilesDirBrowse.Name = "btnInputFilesDirBrowse";
            this.btnInputFilesDirBrowse.UseVisualStyleBackColor = true;
            this.btnInputFilesDirBrowse.Click += new System.EventHandler(this.btnInputFilesDirBrowse_Click);
            // 
            // tbInputFilesDir
            // 
            resources.ApplyResources(this.tbInputFilesDir, "tbInputFilesDir");
            this.tbInputFilesDir.Name = "tbInputFilesDir";
            this.tbInputFilesDir.ReadOnly = true;
            // 
            // btnInputFilesDirReset
            // 
            resources.ApplyResources(this.btnInputFilesDirReset, "btnInputFilesDirReset");
            this.btnInputFilesDirReset.Name = "btnInputFilesDirReset";
            this.btnInputFilesDirReset.UseVisualStyleBackColor = true;
            this.btnInputFilesDirReset.Click += new System.EventHandler(this.btnInputFilesDirResetPath_Click);
            // 
            // lblProjectsDir
            // 
            resources.ApplyResources(this.lblProjectsDir, "lblProjectsDir");
            this.lblProjectsDir.Name = "lblProjectsDir";
            // 
            // lblInputFilesDir
            // 
            resources.ApplyResources(this.lblInputFilesDir, "lblInputFilesDir");
            this.lblInputFilesDir.Name = "lblInputFilesDir";
            // 
            // lblOutputFilesDir
            // 
            resources.ApplyResources(this.lblOutputFilesDir, "lblOutputFilesDir");
            this.lblOutputFilesDir.Name = "lblOutputFilesDir";
            // 
            // tlpProjectsDir
            // 
            resources.ApplyResources(this.tlpProjectsDir, "tlpProjectsDir");
            this.tlpProjectsDir.Controls.Add(this.btnProjectsDirBrowse, 0, 0);
            this.tlpProjectsDir.Controls.Add(this.tbProjectsDir, 1, 0);
            this.tlpProjectsDir.Controls.Add(this.btnProjectsDirReset, 2, 0);
            this.tlpProjectsDir.Name = "tlpProjectsDir";
            // 
            // btnProjectsDirBrowse
            // 
            resources.ApplyResources(this.btnProjectsDirBrowse, "btnProjectsDirBrowse");
            this.btnProjectsDirBrowse.Name = "btnProjectsDirBrowse";
            this.btnProjectsDirBrowse.UseVisualStyleBackColor = true;
            this.btnProjectsDirBrowse.Click += new System.EventHandler(this.btnProjectsDirBrowse_Click);
            // 
            // tbProjectsDir
            // 
            resources.ApplyResources(this.tbProjectsDir, "tbProjectsDir");
            this.tbProjectsDir.Name = "tbProjectsDir";
            this.tbProjectsDir.ReadOnly = true;
            // 
            // btnProjectsDirReset
            // 
            resources.ApplyResources(this.btnProjectsDirReset, "btnProjectsDirReset");
            this.btnProjectsDirReset.Name = "btnProjectsDirReset";
            this.btnProjectsDirReset.UseVisualStyleBackColor = true;
            this.btnProjectsDirReset.Click += new System.EventHandler(this.btnProjectsDirResetPath_Click);
            // 
            // lblSupportedInputFileFormatsList
            // 
            resources.ApplyResources(this.lblSupportedInputFileFormatsList, "lblSupportedInputFileFormatsList");
            this.lblSupportedInputFileFormatsList.Name = "lblSupportedInputFileFormatsList";
            // 
            // nudRecentsMemorised
            // 
            resources.ApplyResources(this.nudRecentsMemorised, "nudRecentsMemorised");
            this.nudRecentsMemorised.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRecentsMemorised.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRecentsMemorised.Name = "nudRecentsMemorised";
            this.nudRecentsMemorised.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRecentsMemorised.ValueChanged += new System.EventHandler(this.nudRecentsMemorized_ValueChanged);
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // tlpLanguage
            // 
            resources.ApplyResources(this.tlpLanguage, "tlpLanguage");
            this.tlpLanguage.Controls.Add(this.btnLanguageReset, 2, 0);
            this.tlpLanguage.Controls.Add(this.cbLanguages, 1, 0);
            this.tlpLanguage.Name = "tlpLanguage";
            // 
            // btnLanguageReset
            // 
            resources.ApplyResources(this.btnLanguageReset, "btnLanguageReset");
            this.btnLanguageReset.Name = "btnLanguageReset";
            this.btnLanguageReset.UseVisualStyleBackColor = true;
            this.btnLanguageReset.Click += new System.EventHandler(this.brnResetLanguage_Click);
            // 
            // cbLanguages
            // 
            resources.ApplyResources(this.cbLanguages, "cbLanguages");
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.Name = "cbLanguages";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpGeneral);
            this.tcMain.Controls.Add(this.tpAnalysis);
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.tlpGeneral);
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // tpAnalysis
            // 
            this.tpAnalysis.Controls.Add(this.tcAnalysisMethods);
            resources.ApplyResources(this.tpAnalysis, "tpAnalysis");
            this.tpAnalysis.Name = "tpAnalysis";
            this.tpAnalysis.UseVisualStyleBackColor = true;
            // 
            // tcAnalysisMethods
            // 
            this.tcAnalysisMethods.Controls.Add(this.tpPCA);
            this.tcAnalysisMethods.Controls.Add(this.tpKernelPCA);
            resources.ApplyResources(this.tcAnalysisMethods, "tcAnalysisMethods");
            this.tcAnalysisMethods.Name = "tcAnalysisMethods";
            this.tcAnalysisMethods.SelectedIndex = 0;
            // 
            // tpPCA
            // 
            this.tpPCA.Controls.Add(this.tlpPCA);
            resources.ApplyResources(this.tpPCA, "tpPCA");
            this.tpPCA.Name = "tpPCA";
            this.tpPCA.UseVisualStyleBackColor = true;
            // 
            // tlpPCA
            // 
            resources.ApplyResources(this.tlpPCA, "tlpPCA");
            this.tlpPCA.Controls.Add(this.label7, 0, 0);
            this.tlpPCA.Controls.Add(this.cbPCAAnalysisMethod, 1, 0);
            this.tlpPCA.Name = "tlpPCA";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // cbPCAAnalysisMethod
            // 
            resources.ApplyResources(this.cbPCAAnalysisMethod, "cbPCAAnalysisMethod");
            this.cbPCAAnalysisMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPCAAnalysisMethod.Name = "cbPCAAnalysisMethod";
            // 
            // tpKernelPCA
            // 
            this.tpKernelPCA.Controls.Add(this.tlpKPCA);
            resources.ApplyResources(this.tpKernelPCA, "tpKernelPCA");
            this.tpKernelPCA.Name = "tpKernelPCA";
            this.tpKernelPCA.UseVisualStyleBackColor = true;
            // 
            // tlpKPCA
            // 
            resources.ApplyResources(this.tlpKPCA, "tlpKPCA");
            this.tlpKPCA.Controls.Add(this.cbKPCACenterInFeatureSpace, 1, 1);
            this.tlpKPCA.Controls.Add(this.panelKPCAOptions, 1, 2);
            this.tlpKPCA.Controls.Add(this.label10, 0, 0);
            this.tlpKPCA.Controls.Add(this.cbKPCAAnalysisMethod, 1, 0);
            this.tlpKPCA.Name = "tlpKPCA";
            // 
            // cbKPCACenterInFeatureSpace
            // 
            resources.ApplyResources(this.cbKPCACenterInFeatureSpace, "cbKPCACenterInFeatureSpace");
            this.cbKPCACenterInFeatureSpace.Checked = true;
            this.cbKPCACenterInFeatureSpace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlpKPCA.SetColumnSpan(this.cbKPCACenterInFeatureSpace, 2);
            this.cbKPCACenterInFeatureSpace.Name = "cbKPCACenterInFeatureSpace";
            this.cbKPCACenterInFeatureSpace.UseVisualStyleBackColor = true;
            // 
            // panelKPCAOptions
            // 
            resources.ApplyResources(this.panelKPCAOptions, "panelKPCAOptions");
            this.tlpKPCA.SetColumnSpan(this.panelKPCAOptions, 2);
            this.panelKPCAOptions.Controls.Add(this.numKPCASigma);
            this.panelKPCAOptions.Controls.Add(this.numKPCAConstant);
            this.panelKPCAOptions.Controls.Add(this.numKPCADegree);
            this.panelKPCAOptions.Controls.Add(this.lblKPCAConstant);
            this.panelKPCAOptions.Controls.Add(this.lblKPCADegree);
            this.panelKPCAOptions.Controls.Add(this.btnKPCAEstimated);
            this.panelKPCAOptions.Controls.Add(this.rbKPCAPolynomialKernel);
            this.panelKPCAOptions.Controls.Add(this.rbKPCAGaussianKernel);
            this.panelKPCAOptions.Name = "panelKPCAOptions";
            // 
            // numKPCASigma
            // 
            this.numKPCASigma.DecimalPlaces = 4;
            resources.ApplyResources(this.numKPCASigma, "numKPCASigma");
            this.numKPCASigma.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numKPCASigma.Name = "numKPCASigma";
            this.numKPCASigma.Value = new decimal(new int[] {
            2236,
            0,
            0,
            262144});
            // 
            // numKPCAConstant
            // 
            this.numKPCAConstant.DecimalPlaces = 4;
            resources.ApplyResources(this.numKPCAConstant, "numKPCAConstant");
            this.numKPCAConstant.Name = "numKPCAConstant";
            // 
            // numKPCADegree
            // 
            resources.ApplyResources(this.numKPCADegree, "numKPCADegree");
            this.numKPCADegree.Name = "numKPCADegree";
            this.numKPCADegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lblKPCAConstant
            // 
            resources.ApplyResources(this.lblKPCAConstant, "lblKPCAConstant");
            this.lblKPCAConstant.Name = "lblKPCAConstant";
            // 
            // lblKPCADegree
            // 
            resources.ApplyResources(this.lblKPCADegree, "lblKPCADegree");
            this.lblKPCADegree.Name = "lblKPCADegree";
            // 
            // btnKPCAEstimated
            // 
            resources.ApplyResources(this.btnKPCAEstimated, "btnKPCAEstimated");
            this.btnKPCAEstimated.Name = "btnKPCAEstimated";
            this.btnKPCAEstimated.UseVisualStyleBackColor = true;
            this.btnKPCAEstimated.Click += new System.EventHandler(this.btnKPCAEstimated_Click);
            // 
            // rbKPCAPolynomialKernel
            // 
            resources.ApplyResources(this.rbKPCAPolynomialKernel, "rbKPCAPolynomialKernel");
            this.rbKPCAPolynomialKernel.Name = "rbKPCAPolynomialKernel";
            this.rbKPCAPolynomialKernel.UseVisualStyleBackColor = true;
            this.rbKPCAPolynomialKernel.CheckedChanged += new System.EventHandler(this.rbPolynomialKernel_CheckedChanged);
            // 
            // rbKPCAGaussianKernel
            // 
            resources.ApplyResources(this.rbKPCAGaussianKernel, "rbKPCAGaussianKernel");
            this.rbKPCAGaussianKernel.Name = "rbKPCAGaussianKernel";
            this.rbKPCAGaussianKernel.UseVisualStyleBackColor = true;
            this.rbKPCAGaussianKernel.CheckedChanged += new System.EventHandler(this.rbGaussianKernel_CheckedChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cbKPCAAnalysisMethod
            // 
            this.cbKPCAAnalysisMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKPCAAnalysisMethod.FormattingEnabled = true;
            resources.ApplyResources(this.cbKPCAAnalysisMethod, "cbKPCAAnalysisMethod");
            this.cbKPCAAnalysisMethod.Name = "cbKPCAAnalysisMethod";
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.tcMain, 0, 0);
            this.tlpMain.Controls.Add(this.tlpButtons, 0, 1);
            this.tlpMain.Name = "tlpMain";
            // 
            // tlpButtons
            // 
            resources.ApplyResources(this.tlpButtons, "tlpButtons");
            this.tlpButtons.Controls.Add(this.btnOk, 0, 0);
            this.tlpButtons.Controls.Add(this.btnCancel, 1, 0);
            this.tlpButtons.Controls.Add(this.btnApply, 2, 0);
            this.tlpButtons.Name = "tlpButtons";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cultureManager
            // 
            this.cultureManager.ManagedControl = this;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpGeneral.PerformLayout();
            this.tlpOutputFilesDir.ResumeLayout(false);
            this.tlpOutputFilesDir.PerformLayout();
            this.tlpInputFilesDir.ResumeLayout(false);
            this.tlpInputFilesDir.PerformLayout();
            this.tlpProjectsDir.ResumeLayout(false);
            this.tlpProjectsDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentsMemorised)).EndInit();
            this.tlpLanguage.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpAnalysis.ResumeLayout(false);
            this.tcAnalysisMethods.ResumeLayout(false);
            this.tpPCA.ResumeLayout(false);
            this.tlpPCA.ResumeLayout(false);
            this.tlpPCA.PerformLayout();
            this.tpKernelPCA.ResumeLayout(false);
            this.tlpKPCA.ResumeLayout(false);
            this.tlpKPCA.PerformLayout();
            this.panelKPCAOptions.ResumeLayout(false);
            this.panelKPCAOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCASigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCAConstant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numKPCADegree)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.Label lblProjectsDir;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.Label lblInputFilesDir;
        private System.Windows.Forms.Label lblOutputFilesDir;
        private System.Windows.Forms.TableLayoutPanel tlpProjectsDir;
        private System.Windows.Forms.TextBox tbProjectsDir;
        private System.Windows.Forms.Button btnProjectsDirReset;
        private System.Windows.Forms.Button btnProjectsDirBrowse;
        private System.Windows.Forms.TableLayoutPanel tlpInputFilesDir;
        private System.Windows.Forms.Button btnInputFilesDirBrowse;
        private System.Windows.Forms.TextBox tbInputFilesDir;
        private System.Windows.Forms.Button btnInputFilesDirReset;
        private System.Windows.Forms.TableLayoutPanel tlpOutputFilesDir;
        private System.Windows.Forms.Button btnOutputFilesDirBrowse;
        private System.Windows.Forms.TextBox tbOutputFilesDir;
        private System.Windows.Forms.Button btnOutputFilesDirReset;
        private System.Windows.Forms.Label lblSupportedInputFileFormats;
        private System.Windows.Forms.Label lblSupportedInputFileFormatsList;
        private System.Windows.Forms.Label lblRecentsMemorized;
        private System.Windows.Forms.NumericUpDown nudRecentsMemorised;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.FolderBrowserDialog fbdProjectsDir;
        private System.Windows.Forms.FolderBrowserDialog fbdInputFilesDir;
        private System.Windows.Forms.FolderBrowserDialog fbdOutputFilesDir;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbLanguages;
        private Infralution.Localization.CultureManager cultureManager;
        private System.Windows.Forms.TableLayoutPanel tlpLanguage;
        private System.Windows.Forms.Button btnLanguageReset;
        private System.Windows.Forms.TabPage tpAnalysis;
        private System.Windows.Forms.TabControl tcAnalysisMethods;
        private System.Windows.Forms.TabPage tpPCA;
        private System.Windows.Forms.TabPage tpKernelPCA;
        private System.Windows.Forms.TableLayoutPanel tlpPCA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tlpKPCA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbKPCACenterInFeatureSpace;
        private System.Windows.Forms.Panel panelKPCAOptions;
        private System.Windows.Forms.RadioButton rbKPCAGaussianKernel;
        private System.Windows.Forms.RadioButton rbKPCAPolynomialKernel;
        private System.Windows.Forms.Button btnKPCAEstimated;
        private System.Windows.Forms.NumericUpDown numKPCASigma;
        private System.Windows.Forms.NumericUpDown numKPCAConstant;
        private System.Windows.Forms.NumericUpDown numKPCADegree;
        private System.Windows.Forms.Label lblKPCAConstant;
        private System.Windows.Forms.Label lblKPCADegree;
        private System.Windows.Forms.ComboBox cbPCAAnalysisMethod;
        private System.Windows.Forms.ComboBox cbKPCAAnalysisMethod;
    }
}
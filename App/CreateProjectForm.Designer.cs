namespace Webyneter.ComponentsAnalysis.App
{
    partial class CreateProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProjectForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInputFilesDir = new System.Windows.Forms.TableLayoutPanel();
            this.tbDir = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tlpProjectsDir = new System.Windows.Forms.TableLayoutPanel();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnNameReset = new System.Windows.Forms.Button();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.cbOverwriteExisting = new System.Windows.Forms.CheckBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.fbdDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cultureManager = new Infralution.Localization.CultureManager(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpInputFilesDir.SuspendLayout();
            this.tlpProjectsDir.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.tlpInputFilesDir, 1, 1);
            this.tlpMain.Controls.Add(this.lblName, 0, 0);
            this.tlpMain.Controls.Add(this.tlpProjectsDir, 1, 0);
            this.tlpMain.Controls.Add(this.tlpButtons, 1, 5);
            this.tlpMain.Controls.Add(this.lblDirectory, 0, 1);
            this.tlpMain.Controls.Add(this.cbOverwriteExisting, 1, 3);
            this.tlpMain.Controls.Add(this.lblWarning, 1, 2);
            this.tlpMain.Name = "tlpMain";
            // 
            // tlpInputFilesDir
            // 
            resources.ApplyResources(this.tlpInputFilesDir, "tlpInputFilesDir");
            this.tlpInputFilesDir.Controls.Add(this.tbDir, 0, 0);
            this.tlpInputFilesDir.Name = "tlpInputFilesDir";
            // 
            // tbDir
            // 
            resources.ApplyResources(this.tbDir, "tbDir");
            this.tbDir.Name = "tbDir";
            this.tbDir.ReadOnly = true;
            this.tbDir.TextChanged += new System.EventHandler(this.tbDir_TextChanged);
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // tlpProjectsDir
            // 
            resources.ApplyResources(this.tlpProjectsDir, "tlpProjectsDir");
            this.tlpProjectsDir.Controls.Add(this.tbName, 0, 0);
            this.tlpProjectsDir.Controls.Add(this.btnNameReset, 1, 0);
            this.tlpProjectsDir.Name = "tlpProjectsDir";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnNameReset
            // 
            resources.ApplyResources(this.btnNameReset, "btnNameReset");
            this.btnNameReset.Name = "btnNameReset";
            this.btnNameReset.UseVisualStyleBackColor = true;
            this.btnNameReset.Click += new System.EventHandler(this.btnNameReset_Click);
            // 
            // tlpButtons
            // 
            resources.ApplyResources(this.tlpButtons, "tlpButtons");
            this.tlpButtons.Controls.Add(this.btnOk, 1, 0);
            this.tlpButtons.Controls.Add(this.btnCancel, 0, 0);
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
            // 
            // lblDirectory
            // 
            resources.ApplyResources(this.lblDirectory, "lblDirectory");
            this.lblDirectory.Name = "lblDirectory";
            // 
            // cbOverwriteExisting
            // 
            resources.ApplyResources(this.cbOverwriteExisting, "cbOverwriteExisting");
            this.cbOverwriteExisting.Name = "cbOverwriteExisting";
            this.cbOverwriteExisting.UseVisualStyleBackColor = true;
            this.cbOverwriteExisting.CheckedChanged += new System.EventHandler(this.cbOverwriteExisting_CheckedChanged);
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.Name = "lblWarning";
            // 
            // cultureManager
            // 
            this.cultureManager.ManagedControl = this;
            // 
            // CreateProjectForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreateProjectForm";
            this.Load += new System.EventHandler(this.CreateProjectForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpInputFilesDir.ResumeLayout(false);
            this.tlpInputFilesDir.PerformLayout();
            this.tlpProjectsDir.ResumeLayout(false);
            this.tlpProjectsDir.PerformLayout();
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.TableLayoutPanel tlpInputFilesDir;
        private System.Windows.Forms.TextBox tbDir;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel tlpProjectsDir;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnNameReset;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbOverwriteExisting;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.FolderBrowserDialog fbdDialog;
        private Infralution.Localization.CultureManager cultureManager;
    }
}
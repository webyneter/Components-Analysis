namespace Webyneter.ComponentsAnalysis.App
{
    partial class ImportInputDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportInputDataForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpImportOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.tlpInputFile = new System.Windows.Forms.TableLayoutPanel();
            this.btnInputFileBrowse = new System.Windows.Forms.Button();
            this.tbInputFile = new System.Windows.Forms.TextBox();
            this.lblSheetToImport = new System.Windows.Forms.Label();
            this.tlpSheetToImport = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectSheetToImport = new System.Windows.Forms.Button();
            this.cbSheets = new System.Windows.Forms.ComboBox();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.dgvExcelInput = new System.Windows.Forms.DataGridView();
            this.tlpContentTop = new System.Windows.Forms.TableLayoutPanel();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.tlpOptions = new System.Windows.Forms.TableLayoutPanel();
            this.cbAutosizeColumns = new System.Windows.Forms.ComboBox();
            this.lblAutosizeColumns = new System.Windows.Forms.Label();
            this.gbHints = new System.Windows.Forms.GroupBox();
            this.tlpHints = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cultureManager = new Infralution.Localization.CultureManager(this.components);
            this.ofdInput = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain.SuspendLayout();
            this.tlpFormButtons.SuspendLayout();
            this.tlpImportOptions.SuspendLayout();
            this.tlpInputFile.SuspendLayout();
            this.tlpSheetToImport.SuspendLayout();
            this.tlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInput)).BeginInit();
            this.tlpContentTop.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.tlpOptions.SuspendLayout();
            this.gbHints.SuspendLayout();
            this.tlpHints.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            resources.ApplyResources(this.tlpMain, "tlpMain");
            this.tlpMain.Controls.Add(this.tlpFormButtons, 0, 2);
            this.tlpMain.Controls.Add(this.tlpImportOptions, 0, 0);
            this.tlpMain.Controls.Add(this.tlpContent, 0, 1);
            this.tlpMain.Name = "tlpMain";
            // 
            // tlpFormButtons
            // 
            resources.ApplyResources(this.tlpFormButtons, "tlpFormButtons");
            this.tlpFormButtons.Controls.Add(this.btnOk, 1, 0);
            this.tlpFormButtons.Controls.Add(this.btnCancel, 0, 0);
            this.tlpFormButtons.Name = "tlpFormButtons";
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
            // tlpImportOptions
            // 
            resources.ApplyResources(this.tlpImportOptions, "tlpImportOptions");
            this.tlpImportOptions.Controls.Add(this.lblInputFile, 0, 0);
            this.tlpImportOptions.Controls.Add(this.tlpInputFile, 1, 0);
            this.tlpImportOptions.Controls.Add(this.lblSheetToImport, 0, 1);
            this.tlpImportOptions.Controls.Add(this.tlpSheetToImport, 1, 1);
            this.tlpImportOptions.Name = "tlpImportOptions";
            // 
            // lblInputFile
            // 
            resources.ApplyResources(this.lblInputFile, "lblInputFile");
            this.lblInputFile.Name = "lblInputFile";
            // 
            // tlpInputFile
            // 
            resources.ApplyResources(this.tlpInputFile, "tlpInputFile");
            this.tlpInputFile.Controls.Add(this.btnInputFileBrowse, 0, 0);
            this.tlpInputFile.Controls.Add(this.tbInputFile, 1, 0);
            this.tlpInputFile.Name = "tlpInputFile";
            // 
            // btnInputFileBrowse
            // 
            resources.ApplyResources(this.btnInputFileBrowse, "btnInputFileBrowse");
            this.btnInputFileBrowse.Name = "btnInputFileBrowse";
            this.btnInputFileBrowse.UseVisualStyleBackColor = true;
            this.btnInputFileBrowse.Click += new System.EventHandler(this.btnInputFileBrowse_Click);
            // 
            // tbInputFile
            // 
            resources.ApplyResources(this.tbInputFile, "tbInputFile");
            this.tbInputFile.Name = "tbInputFile";
            this.tbInputFile.ReadOnly = true;
            // 
            // lblSheetToImport
            // 
            resources.ApplyResources(this.lblSheetToImport, "lblSheetToImport");
            this.lblSheetToImport.Name = "lblSheetToImport";
            // 
            // tlpSheetToImport
            // 
            resources.ApplyResources(this.tlpSheetToImport, "tlpSheetToImport");
            this.tlpSheetToImport.Controls.Add(this.btnSelectSheetToImport, 0, 0);
            this.tlpSheetToImport.Controls.Add(this.cbSheets, 1, 0);
            this.tlpSheetToImport.Name = "tlpSheetToImport";
            // 
            // btnSelectSheetToImport
            // 
            resources.ApplyResources(this.btnSelectSheetToImport, "btnSelectSheetToImport");
            this.btnSelectSheetToImport.Name = "btnSelectSheetToImport";
            this.btnSelectSheetToImport.UseVisualStyleBackColor = true;
            this.btnSelectSheetToImport.Click += new System.EventHandler(this.btnSelectSheetToImport_Click);
            // 
            // cbSheets
            // 
            resources.ApplyResources(this.cbSheets, "cbSheets");
            this.cbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheets.Name = "cbSheets";
            // 
            // tlpContent
            // 
            resources.ApplyResources(this.tlpContent, "tlpContent");
            this.tlpContent.Controls.Add(this.dgvExcelInput, 0, 1);
            this.tlpContent.Controls.Add(this.tlpContentTop, 0, 0);
            this.tlpContent.Name = "tlpContent";
            // 
            // dgvExcelInput
            // 
            this.dgvExcelInput.AllowUserToAddRows = false;
            this.dgvExcelInput.AllowUserToDeleteRows = false;
            this.dgvExcelInput.AllowUserToResizeColumns = false;
            this.dgvExcelInput.AllowUserToResizeRows = false;
            this.dgvExcelInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExcelInput.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvExcelInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExcelInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcelInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvExcelInput, "dgvExcelInput");
            this.dgvExcelInput.Name = "dgvExcelInput";
            this.dgvExcelInput.ReadOnly = true;
            this.dgvExcelInput.RowHeadersVisible = false;
            // 
            // tlpContentTop
            // 
            resources.ApplyResources(this.tlpContentTop, "tlpContentTop");
            this.tlpContentTop.Controls.Add(this.gbOptions, 0, 0);
            this.tlpContentTop.Controls.Add(this.gbHints, 1, 0);
            this.tlpContentTop.Name = "tlpContentTop";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.tlpOptions);
            resources.ApplyResources(this.gbOptions, "gbOptions");
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.TabStop = false;
            // 
            // tlpOptions
            // 
            resources.ApplyResources(this.tlpOptions, "tlpOptions");
            this.tlpOptions.Controls.Add(this.cbAutosizeColumns, 1, 0);
            this.tlpOptions.Controls.Add(this.lblAutosizeColumns, 0, 0);
            this.tlpOptions.Name = "tlpOptions";
            // 
            // cbAutosizeColumns
            // 
            resources.ApplyResources(this.cbAutosizeColumns, "cbAutosizeColumns");
            this.cbAutosizeColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutosizeColumns.Name = "cbAutosizeColumns";
            this.cbAutosizeColumns.SelectedIndexChanged += new System.EventHandler(this.cbAutosizeColumns_SelectedIndexChanged);
            // 
            // lblAutosizeColumns
            // 
            resources.ApplyResources(this.lblAutosizeColumns, "lblAutosizeColumns");
            this.lblAutosizeColumns.Name = "lblAutosizeColumns";
            // 
            // gbHints
            // 
            this.gbHints.Controls.Add(this.tlpHints);
            resources.ApplyResources(this.gbHints, "gbHints");
            this.gbHints.Name = "gbHints";
            this.gbHints.TabStop = false;
            // 
            // tlpHints
            // 
            resources.ApplyResources(this.tlpHints, "tlpHints");
            this.tlpHints.Controls.Add(this.richTextBox1, 0, 0);
            this.tlpHints.Name = "tlpHints";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // cultureManager
            // 
            this.cultureManager.ManagedControl = this;
            // 
            // ofdInput
            // 
            this.ofdInput.AddExtension = false;
            this.ofdInput.RestoreDirectory = true;
            resources.ApplyResources(this.ofdInput, "ofdInput");
            // 
            // ImportInputDataForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tlpMain);
            this.Name = "ImportInputDataForm";
            this.Load += new System.EventHandler(this.ImportInputDataForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpFormButtons.ResumeLayout(false);
            this.tlpImportOptions.ResumeLayout(false);
            this.tlpImportOptions.PerformLayout();
            this.tlpInputFile.ResumeLayout(false);
            this.tlpInputFile.PerformLayout();
            this.tlpSheetToImport.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInput)).EndInit();
            this.tlpContentTop.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.tlpOptions.ResumeLayout(false);
            this.tlpOptions.PerformLayout();
            this.gbHints.ResumeLayout(false);
            this.tlpHints.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Infralution.Localization.CultureManager cultureManager;
        private System.Windows.Forms.TableLayoutPanel tlpImportOptions;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.TableLayoutPanel tlpInputFile;
        private System.Windows.Forms.Button btnInputFileBrowse;
        private System.Windows.Forms.TextBox tbInputFile;
        private System.Windows.Forms.TableLayoutPanel tlpFormButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSheetToImport;
        private System.Windows.Forms.TableLayoutPanel tlpSheetToImport;
        private System.Windows.Forms.ComboBox cbSheets;
        private System.Windows.Forms.Button btnSelectSheetToImport;
        private System.Windows.Forms.OpenFileDialog ofdInput;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.DataGridView dgvExcelInput;
        private System.Windows.Forms.TableLayoutPanel tlpContentTop;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.GroupBox gbHints;
        private System.Windows.Forms.TableLayoutPanel tlpOptions;
        private System.Windows.Forms.TableLayoutPanel tlpHints;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox cbAutosizeColumns;
        private System.Windows.Forms.Label lblAutosizeColumns;
    }
}
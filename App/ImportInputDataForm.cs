using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

using Accord.IO;

using Webyneter.ComponentsAnalysis.App.Properties;
using Webyneter.ComponentsAnalysis.Core;
using Webyneter.ComponentsAnalysis.Core.Miscellaneous;
using Webyneter.ComponentsAnalysis.Miscellaneous;
using Webyneter.ComponentsAnalysis.Miscellaneous.ExtensionMethods;


namespace Webyneter.ComponentsAnalysis.App
{
    public partial class ImportInputDataForm : Form
    {
        public DataTable ExcelData { get; private set; }
        public DataTable XmlData { get; private set; }

        private enum FormEnabledState : byte
        {
            FormInvisible,
            FormVisible,
            ExcelPicked,
            XmlPicked,
            SheetSelected,
        }
        private readonly Dictionary<FormEnabledState, Control[]> stateControlsMap;
        private readonly ResourceManager resourceManager = new ResourceManager(typeof(ImportInputDataForm));
        private readonly Dictionary<string, DataGridViewAutoSizeColumnsMode> itemModeMap;
        private ExcelReader excelReader;
        private DataTable selectedSheetData;

        public ImportInputDataForm()
        {
            InitializeComponent();

            itemModeMap = new Dictionary<string, DataGridViewAutoSizeColumnsMode>
            {
                { resourceManager.GetString("Fill"), DataGridViewAutoSizeColumnsMode.Fill },
                { resourceManager.GetString("AllCells"), DataGridViewAutoSizeColumnsMode.AllCells },
                { resourceManager.GetString("AllCellsExceptHeader"), 
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader },
                { resourceManager.GetString("ColumnHeader"), DataGridViewAutoSizeColumnsMode.ColumnHeader },
                { resourceManager.GetString("DisplayedCells"), DataGridViewAutoSizeColumnsMode.DisplayedCells },
                { resourceManager.GetString("DisplayedCellsExceptHeader"), 
                    DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader },
                { resourceManager.GetString("None"), DataGridViewAutoSizeColumnsMode.None }
            };
            cbAutosizeColumns.Items.AddRange(itemModeMap.Keys.ToArray());
            cbAutosizeColumns.SelectedIndex = 0;

            stateControlsMap = new Dictionary<FormEnabledState, Control[]>
            {
                { FormEnabledState.FormInvisible, new Control[]{} },
                { FormEnabledState.FormVisible, new Control[]
                {
                    lblInputFile,
                    btnInputFileBrowse,
                    tbInputFile
                }},
                { FormEnabledState.ExcelPicked, new Control[]
                {
                    lblSheetToImport,
                    btnSelectSheetToImport,
                    cbSheets
                }},
                { FormEnabledState.SheetSelected, new Control[]
                {
                    tlpContent,
                    btnOk
                }},
                { FormEnabledState.XmlPicked, new Control[]
                {
                    btnOk
                }}
            };
            var controls = new List<Control>();
            foreach (var stateControlPair in stateControlsMap)
            {
                controls.AddRange(stateControlPair.Value);
            }
            stateControlsMap[FormEnabledState.FormInvisible] = controls.ToArray();
        }
        
        private void ImportInputDataForm_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.main_form_icon;
            MinimumSize = Settings.Default.AppWindowMinimumSizeDefault;
            Size = MinimumSize;
            ofdInput.InitialDirectory = Settings.Default.InputFilesDir;
            string filter = resourceManager.GetObject("AllFiles") + "|*.*|";
            foreach (var extFormatPair in Project.SupportedInputExtensionFormatMap)
            {
                filter += string.Format("{0}|*{1}|", extFormatPair.Value, extFormatPair.Key);
            }
            ofdInput.Filter = filter.TrimEnd('|');
            SetEnabledState(FormEnabledState.FormInvisible);
            SetEnabledState(FormEnabledState.FormVisible);
        }

        private void SetEnabledState(FormEnabledState state)
        {
            foreach (var control in stateControlsMap[state])
            {
                switch (state)
                {
                    case FormEnabledState.FormInvisible:
                        control.Enabled = false;
                        break;

                    default:
                        control.Enabled = true;
                        break;
                }
            }
        }

        private void btnInputFileBrowse_Click(object sender, System.EventArgs e)
        {
            if (ofdInput.ShowDialog() == DialogResult.OK)
            {
                tbInputFile.Text = ofdInput.FileName;
                SupportedInputFileFormat? supportedInputFileFormat;
                if (Project.TryGetSupportedInputFileFormat(Path.GetExtension(ofdInput.FileName), 
                    out supportedInputFileFormat))
                {
                    switch (supportedInputFileFormat)
                    {
                        case SupportedInputFileFormat.Excel2003:
                        case SupportedInputFileFormat.Excel2007:
                            excelReader = new ExcelReader(ofdInput.FileName);
                            cbSheets.DataSource = new ExcelReader(ofdInput.FileName).GetWorksheetList();
                            SetEnabledState(FormEnabledState.ExcelPicked);
                            break;
                        case SupportedInputFileFormat.XML:
                            XmlData = new DataTable();
                            XmlData.ReadXml(ofdInput.FileName);
                            SetEnabledState(FormEnabledState.XmlPicked);
                            break;
                    }
                }
            }
        }

        private void btnSelectSheetToImport_Click(object sender, System.EventArgs e)
        {
            selectedSheetData = excelReader.GetWorksheet(cbSheets.SelectedItem.ToString());
            dgvExcelInput.DataSource = selectedSheetData;
            foreach (DataGridViewColumn col in dgvExcelInput.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.Selected = true;
            }
            dgvExcelInput.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            SetEnabledState(FormEnabledState.SheetSelected);
        }

        private void btnCancel_Click(object sender, EventArgs e) { Close(); }

        private void cbAutosizeColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvExcelInput.AutoSizeColumnsMode = itemModeMap[cbAutosizeColumns.SelectedItem.ToString()];
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (excelReader != null)
            {
                var inds = new HashSet<int>();
                foreach (DataGridViewColumn col in dgvExcelInput.SelectedColumns)
                {
                    inds.Add(col.Index);
                }
                ExcelData = ((DataTable)dgvExcelInput.DataSource).Copy();
                for (int i = ExcelData.Columns.Count - 1; i >= 0; --i)
                {
                    if (!inds.Contains(i))
                    {
                        ExcelData.Columns.RemoveAt(i);
                    }
                }
                ExcelData.ReplaceAllOccurrences(DBNull.Value, 0);
                ExcelData.AcceptChanges();
            }
        }
    }
}

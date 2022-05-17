using System.Data;
using System.Text.Json;
using System.Diagnostics;
using System.Xml.Linq;
using static Converter.Parser;
using System.Text.RegularExpressions;

namespace Converter
{
    public partial class FormPrincipal : Form
    {
        private string fileExtension = "";
        private string filePath = "";

        DataTable dataTable = new DataTable();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = new DataTable();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "TXT, CSV, XML, JSON (*.txt; *.csv; *.xml; *.json)|*.txt;*.csv;*.xml;*.json";
            openDialog.Title = "Escolha um arquivo";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                inputPath.Text = openDialog.FileName;

                filePath = openDialog.FileName;
                fileExtension = openDialog.SafeFileName.Split('.')[1];

                if (fileExtension == "csv")
                {
                    dataTable = ReadCSV(filePath);
                    dataGrid.DataSource = dataTable;
                }

                if (fileExtension == "json")
                {
                    dataTable = ReadJSON(filePath);
                    dataGrid.DataSource = dataTable;
                }

                if (fileExtension == "xml")
                {
                    dataTable = ReadXML(filePath);
                    dataGrid.DataSource = dataTable;
                }

                if (fileExtension == "txt")
                {
                    dataTable = ReadTXT(filePath);
                    dataGrid.DataSource = dataTable;
                }
            }
        }

        private void btnConvertTxt_Click(object sender, EventArgs e) => ToTXT(dataTable);

        private void btnConvertJson_Click(object sender, EventArgs e) => ToJSON(dataTable);

        private void btnConvertXml_Click(object sender, EventArgs e) => ToXML(dataTable);

        private void btnConvertCsv_Click(object sender, EventArgs e) => ToCSV(dataTable);
       
    }
}
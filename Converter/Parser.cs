using System.Data;
using System.Text;
using System.Xml.Linq;

namespace Converter
{
    internal class Parser
    {
        public static void ToXML(DataTable dataTable)
        {
            List<string> lines = new List<string>();

            DataColumnCollection columns = dataTable.Columns;

            foreach (DataRow row in dataTable.Rows)
            {
                lines.Add(string.Join(',', row.ItemArray));
            }

            var xml = new XElement(
                "root",
                lines.Select(line => new XElement(
                    "row", 
                    line.Split(',').Select((column, index) => new XElement(
                        columns[index].ToString(), column
                    )
                ))
            ));

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Arquivo XML (*.xml)|*.xml";
            saveDialog.Title = "Salvar XML";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                xml.Save(saveDialog.FileName);
                MessageBox.Show("Salvo com sucesso!");
            }
        }

        public static void ToJSON(DataTable dataTable)
        {
            StringBuilder fileContent = new StringBuilder();
            DataColumnCollection columnNames = dataTable.Columns;

            fileContent.Append("[");

            int rowIndex = 0;
            foreach(DataRow row in dataTable.Rows)
            {
                fileContent.Append("{");

                string jsonRow = "";

                int columnIndex = 0;
                foreach(DataColumn column in columnNames)
                {
                    jsonRow += "\"" + column.ToString() + "\":\"" + row[column.ToString()] + "\",";
                    if(columnIndex == columnNames.Count - 1)
                    {
                        jsonRow = jsonRow.TrimEnd(',');
                    }
                    columnIndex++;
                }
                
                fileContent.Append(jsonRow);
                fileContent.Append("},");
                if(rowIndex == dataTable.Rows.Count - 1)
                {
                    fileContent.Length--;
                }
                rowIndex++;
            }
            fileContent.Append("]");

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JSON Document (*.json)|*.json";
            saveDialog.Title = "Salvar JSON";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                File.WriteAllText(saveDialog.FileName, fileContent.ToString());
                MessageBox.Show("Salvo com sucesso!");
            }
        }

        public static void ToCSV(DataTable dataTable)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (DataColumn col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var col in row.ItemArray)
                {
                    fileContent.Append(col.ToString() + ",");
                }

                fileContent.Replace(",", Environment.NewLine, fileContent.Length - 1, 1);
            }

            fileContent.Replace(",", Environment.NewLine, fileContent.Length - 1, 1);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Arquivo CSV (*.CSV)|*.csv";
            saveDialog.Title = "Salvar CSV";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                File.WriteAllText(saveDialog.FileName, fileContent.ToString());
                MessageBox.Show("Salvo com sucesso!");
            }


        }
        public static void ToTXT(DataTable dataTable)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (DataColumn col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + '\t');
            }

            fileContent.Replace("\t", Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (var column in row.ItemArray)
                {
                    fileContent.Append(column.ToString() + '\t');
                }

                fileContent.Replace("\t", Environment.NewLine, fileContent.Length - 1, 1);
            }

            fileContent.Replace("\t", Environment.NewLine, fileContent.Length - 1, 1);

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Arquivo TXT (*.txt)|*.txt";
            saveDialog.Title = "Salvar TXT";
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                File.WriteAllText(saveDialog.FileName, fileContent.ToString());
                MessageBox.Show("Salvo com sucesso!");
            }
        }


        public static DataTable ReadCSV(string filePath)
        {
            try
            {
                DataTable dataTable = new DataTable();
                StreamReader reader = new StreamReader(filePath);

                int lineIndex = 0;
                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] values = line!.Split(',');

                    if (lineIndex == 0)
                    {
                        for (int col = 0; col < values.Length; col++)
                        {
                            dataTable.Columns.Add(values[col].ToString());
                        }
                    }
                    else
                    {
                        DataRow row = dataTable.NewRow();
                        for (int col = 0; col < values.Length; col++)
                        {
                            row[col] = values[col].ToString();
                        }
                        dataTable.Rows.Add(row);

                    }
                    lineIndex++;
                }

                reader.Close();

                return dataTable;
            }
            catch
            {
                MessageBox.Show("Um erro ocorreu ao abrir o arquivo. Tente outro", "Aviso");
                return new DataTable();
            }
        }

        public static DataTable ReadTXT(string filePath)
        {
            try
            {
                DataTable dataTable = new DataTable();
                StreamReader reader = new StreamReader(filePath);
                int lineIndex = 0;

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    string[] values = line!.Split('\t');

                    if (lineIndex == 0)
                    {
                        for (int col = 0; col < values.Length; col++)
                        {
                            dataTable.Columns.Add(values[col].ToString());
                        }
                    }
                    else
                    {
                        DataRow row = dataTable.NewRow();
                        for (int col = 0; col < values.Length; col++)
                        {
                            row[col] = values[col].ToString();
                        }
                        dataTable.Rows.Add(row);

                    }
                    lineIndex++;
                }

                reader.Close();
                return dataTable;
            }
            catch
            {
                MessageBox.Show("Um erro ocorreu ao abrir o arquivo. Tente outro", "Aviso");
                return new DataTable();
            }
        }

        public static DataTable ReadJSON(string filePath)
        {
            try
            {
                DataTable dataTable = new DataTable();
                StreamReader reader = new StreamReader(filePath);

                string jsonText = reader.ReadToEnd();

                string[] jsonArrayElements = jsonText
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("\t", "")
                    .Replace("\n", "")
                    .Replace("\r", "")
                    .Split("},{");

                List<string> columnNamesList = new List<string>();

                foreach (string jsonElement in jsonArrayElements)
                {
                    string[] pairs = jsonElement.Replace("{", "").Replace("}", "").Split(',');

                    foreach (string pair in pairs)
                    {
                        string columnName = pair.Split(":")[0].Replace("\"", "").Trim();
                        if (!columnNamesList.Contains(columnName))
                            columnNamesList.Add(columnName);
                    }
                }

                foreach (string columnName in columnNamesList)
                {
                    dataTable.Columns.Add(columnName);
                }

                foreach (string jsonElement in jsonArrayElements)
                {
                    string[] pairs = jsonElement.Replace("{", "").Replace("}", "").Split(',');

                    DataRow row = dataTable.NewRow();

                    foreach (string pair in pairs)
                    {
                        string columnName = pair.Split(":")[0].Replace("\"", "").Trim();
                        string value = pair.Split(":")[1].Replace("\"", "").Trim();
                        row[columnName] = value;
                    }
                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
            catch
            {
                MessageBox.Show("Um erro ocorreu ao abrir o arquivo. Tente outro", "Aviso");
                return new DataTable();
            }
        }

        public static DataTable ReadXML(string filePath)
        {
            try
            {
                DataTable dataTable = new DataTable();
                XDocument document = XDocument.Load(filePath);

                List<XElement> data = document.Descendants("row").ToList();

                foreach (XElement element in data.First().Descendants())
                    dataTable.Columns.Add(element.Name.LocalName);

                foreach (XElement item in data)
                {
                    DataRow row = dataTable.NewRow();

                    foreach (XElement element in item.Descendants())
                        row[element.Name.LocalName] = element.Value;

                    dataTable.Rows.Add(row);
                }

                return dataTable;
            }
            catch
            {
                MessageBox.Show("Um erro ocorreu ao abrir o arquivo. Tente outro", "Aviso");
                return new DataTable();
            }
        }

    }
}

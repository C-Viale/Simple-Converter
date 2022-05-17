namespace Converter
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputPath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnConvertTxt = new System.Windows.Forms.Button();
            this.btnConvertJson = new System.Windows.Forms.Button();
            this.btnConvertXml = new System.Windows.Forms.Button();
            this.btnConvertCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPath
            // 
            this.inputPath.Location = new System.Drawing.Point(10, 12);
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(579, 23);
            this.inputPath.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(597, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(113, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "Abrir Arquivo";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(10, 42);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.Size = new System.Drawing.Size(700, 364);
            this.dataGrid.TabIndex = 2;
            // 
            // btnConvertTxt
            // 
            this.btnConvertTxt.Location = new System.Drawing.Point(10, 411);
            this.btnConvertTxt.Name = "btnConvertTxt";
            this.btnConvertTxt.Size = new System.Drawing.Size(170, 23);
            this.btnConvertTxt.TabIndex = 3;
            this.btnConvertTxt.Text = "Conveter para TXT";
            this.btnConvertTxt.UseVisualStyleBackColor = true;
            this.btnConvertTxt.Click += new System.EventHandler(this.btnConvertTxt_Click);
            // 
            // btnConvertJson
            // 
            this.btnConvertJson.Location = new System.Drawing.Point(186, 411);
            this.btnConvertJson.Name = "btnConvertJson";
            this.btnConvertJson.Size = new System.Drawing.Size(170, 23);
            this.btnConvertJson.TabIndex = 4;
            this.btnConvertJson.Text = "Converter para JSON";
            this.btnConvertJson.UseVisualStyleBackColor = true;
            this.btnConvertJson.Click += new System.EventHandler(this.btnConvertJson_Click);
            // 
            // btnConvertXml
            // 
            this.btnConvertXml.Location = new System.Drawing.Point(364, 411);
            this.btnConvertXml.Name = "btnConvertXml";
            this.btnConvertXml.Size = new System.Drawing.Size(170, 23);
            this.btnConvertXml.TabIndex = 5;
            this.btnConvertXml.Text = "Converter para XML";
            this.btnConvertXml.UseVisualStyleBackColor = true;
            this.btnConvertXml.Click += new System.EventHandler(this.btnConvertXml_Click);
            // 
            // btnConvertCsv
            // 
            this.btnConvertCsv.Location = new System.Drawing.Point(540, 411);
            this.btnConvertCsv.Name = "btnConvertCsv";
            this.btnConvertCsv.Size = new System.Drawing.Size(170, 23);
            this.btnConvertCsv.TabIndex = 6;
            this.btnConvertCsv.Text = "Converter para CSV";
            this.btnConvertCsv.UseVisualStyleBackColor = true;
            this.btnConvertCsv.Click += new System.EventHandler(this.btnConvertCsv_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 440);
            this.Controls.Add(this.btnConvertCsv);
            this.Controls.Add(this.btnConvertXml);
            this.Controls.Add(this.btnConvertJson);
            this.Controls.Add(this.btnConvertTxt);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.inputPath);
            this.Name = "FormPrincipal";
            this.Text = "Conversor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox inputPath;
        private Button btnOpenFile;
        private DataGridView dataGrid;
        private Button btnConvertTxt;
        private Button btnConvertJson;
        private Button btnConvertXml;
        private Button btnConvertCsv;
    }
}
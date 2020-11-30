using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ErrorLogReader
{
    public partial class Main : Form
    {
        private DataTable _dataTable;

        public Main()
        {
            InitializeComponent();
        }

        private void AddRow(List<string> data, DataTable dt)
        {
            //loop the rows
            foreach (var column in data.Select(row => row.Split(new string[] { "\",\"" }, StringSplitOptions.None)))
            {
                var dr = dt.NewRow();
                //loop the columns
                for (var i = 0; i < column.Length; i++)
                {
                    var value = column[i].TrimStart('"').TrimEnd('"');
                    dr[i] = value;
                }
                dt.Rows.Add(dr);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                var data = ReadFile(openFileDialog.FileName);
                _dataTable = CreateDataTable();
                AddRow(data, _dataTable);
            }

            WriteToDb(_dataTable);
        }

        private DataTable CreateDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("TimeStamp", typeof(string)));
            dt.Columns.Add(new DataColumn("Level", typeof(string)));
            dt.Columns.Add(new DataColumn("Vip_Ip", typeof(string)));
            dt.Columns.Add(new DataColumn("Vip_Port", typeof(string)));
            dt.Columns.Add(new DataColumn("Client_Ip", typeof(string)));
            dt.Columns.Add(new DataColumn("Client_Port", typeof(string)));
            dt.Columns.Add(new DataColumn("Rule_Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Rule_Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Method", typeof(string)));
            dt.Columns.Add(new DataColumn("Action", typeof(string)));
            dt.Columns.Add(new DataColumn("Follow_Up", typeof(string)));
            dt.Columns.Add(new DataColumn("Attack", typeof(string)));
            dt.Columns.Add(new DataColumn("Host", typeof(string)));
            dt.Columns.Add(new DataColumn("Url", typeof(string)));
            dt.Columns.Add(new DataColumn("Query_Str", typeof(string)));
            dt.Columns.Add(new DataColumn("Detail", typeof(string)));
            dt.Columns.Add(new DataColumn("Protocol", typeof(string)));
            dt.Columns.Add(new DataColumn("SessionId", typeof(string)));
            dt.Columns.Add(new DataColumn("Country", typeof(string)));
            dt.Columns.Add(new DataColumn("User_Agent", typeof(string)));
            dt.Columns.Add(new DataColumn("Proxy_Ip", typeof(string)));
            dt.Columns.Add(new DataColumn("Proxy_Port", typeof(string)));
            dt.Columns.Add(new DataColumn("Authenticated_User", typeof(string)));
            dt.Columns.Add(new DataColumn("Referer", typeof(string)));
            dt.Columns.Add(new DataColumn("Fingerprint", typeof(string)));
            dt.Columns.Add(new DataColumn("Req_Risk_Score", typeof(string)));
            dt.Columns.Add(new DataColumn("Client_Risk_Score", typeof(string)));

            return dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private List<string> ReadFile(string filename)
        {
            using var reader = new StreamReader(filename);
            var list = new List<string>();
            var rowNum = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                if (line != null && rowNum > 0)
                {
                    list.Add(line);
                }

                rowNum++;
            }

            return list;
        }

        private void WriteToDb(DataTable dt)
        {
            var conn = ErrorLogReader.Default.ConectionString;

            using var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.KeepIdentity);
            foreach (DataColumn col in dt.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.BulkCopyTimeout = 600;
            bulkCopy.DestinationTableName = "Waf_Logs";
            bulkCopy.WriteToServer(dt);

            MessageBox.Show("Complete", $"{dt.Rows.Count} rows have been upload");
        }
    }
}
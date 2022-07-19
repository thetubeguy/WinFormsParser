using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Security;
using System.Text.RegularExpressions;
using System.Data;

namespace WinFormsParser
{
    public partial class frmParser : Form
    {
        public string ConnectionString = "Data Source=:memory:";
        public SqliteConnection conn = new();
        public SqliteCommand cmd;
        public StreamReader sr;
        public frmParser()
        {
            InitializeComponent();
        }

        private void frmParser_FormClosing(object sender, EventArgs e)
        {
            
            if(conn.State == ConnectionState.Open) conn.Close();
        }

        private void frmParser_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = ConnectionString;
            conn.Open();
            ExecuteSQLStmt("CREATE TABLE parserdata (int rowid)");
        }


        public void ExecuteSQLStmt(string sql)
        {
 
            cmd = new SqliteCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
        }



        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sr = new StreamReader(openFileDialog1.FileName);

                   
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }

                txtOutput.Text = "Loaded file:  " + openFileDialog1.FileName + "\r\n";
                cmbDelimiter.Enabled = true;
                btnSelectFile.Enabled = false;
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            string oneRow;

            oneRow = sr.ReadLine();

            // Using columns names in first line of input file, add columns to database table

            string[] columnArray = oneRow.Split(cmbDelimiter.Text);

            foreach(string column in columnArray)
            {
                ExecuteSQLStmt($"ALTER TABLE parserdata ADD COLUMN {column} String;");
            }

           oneRow = sr.ReadLine();

            int id = 1;

            while(oneRow != null)
            {

                string[] valueArray = oneRow.Split(cmbDelimiter.Text);
                List<string> values = new List<string>();

                bool quoteDetected = false;
                string temp = "";

                for(int i = 0; i < valueArray.Count(); i++ )
                {
                    if(valueArray[i][0] == '"')
                        quoteDetected = true;

                    if (!quoteDetected)
                        values.Add("'" + valueArray[i] + "'");
                    else
                    {
                        if (valueArray[i][valueArray[i].Length - 1] == '"')
                        {
                            temp += valueArray[i];
                            values.Add(temp);
                            quoteDetected = false;
                            temp = "";
                        }
                        else
                            temp += valueArray[i] + " ";
                    }
                }

                string formattedRow  = id + "," +  String.Join(cmbDelimiter.Text, values);

                ExecuteSQLStmt($"INSERT INTO parserdata VALUES ({formattedRow})");

                id++;
                oneRow = sr.ReadLine();
            }


            sr.Close();

            cmbQuery.Enabled = true;
            btnParse.Enabled = false;

        }


        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            string sql = "";
            bool postProcessing = false;
            string expression = "";
            int column1 = 99;
            int column2 = 99;

            switch (cmbQuery.SelectedIndex)
            {

                case 0: sql += "SELECT rowid,first_name, last_name, company_name FROM parserdata WHERE company_name like '%Esq%'";
                    break;
                case 1: sql += "SELECT rowid,first_name, last_name, company_name FROM parserdata WHERE county like '%Derbyshire%'";
                    break;
                case 2: sql += "SELECT rowid,first_name, last_name, company_name, address FROM parserdata";
                    postProcessing = true;
                    expression = @"^[0-9]{3}\s";
                    column1 = 4;
                    break;
                case 3: sql += "SELECT rowid,first_name, last_name, company_name FROM parserdata WHERE LENGTH(web) > 35";
                    break;
                case 4: sql += "SELECT rowid,first_name, last_name, company_name, postal FROM parserdata";
                    postProcessing = true;
                    expression = @"^[A-Z]+[0-9]{1}\s";
                    column1 = 4;
                    break;

                case 5:
                    sql += "SELECT rowid,first_name, last_name, company_name, phone1, phone2 FROM parserdata";
                    postProcessing = true;
                    expression = @"^([0-9]+)-([0-9]+)";
                    column1 = 4;
                    column2 = 5;
                    break;

            }
            

            cmd = new SqliteCommand(sql, conn);
            try
            {
                string tempOutput = "";
                int rowCount = 0;

                using (var reader = cmd.ExecuteReader())
                {

                    
                    while (reader.Read())
                    {
                        if (!postProcessing)
                        {
                            rowCount++;
                            tempOutput += reader.GetString(0) + "-" + reader.GetString(1) + "  " + reader.GetString(2) + "-" + reader.GetString(3) + "\r\n";
                        }
                        else if(column2 == 99)
                        {
                            if (Regex.IsMatch(reader.GetString(column1), expression))
                            {
                                rowCount++;
                                tempOutput += reader.GetString(0) + "-" + reader.GetString(1) + "  " + reader.GetString(2) + "-" + reader.GetString(3) + "\r\n";
                            }
                        }
                        else
                        {
                            Match match1 = Regex.Match(reader.GetString(column1), expression);
                            Match match2 = Regex.Match(reader.GetString(column2), expression);

                            int phone1Number = Int32.Parse(match1.Groups[1].Value + match1.Groups[2].Value);
                            int phone2Number = Int32.Parse(match2.Groups[1].Value + match2.Groups[2].Value);
                            
                            if(phone1Number > phone2Number)
                            {
                                rowCount++;
                                tempOutput += reader.GetString(0) + "-" + reader.GetString(1) + "  " + reader.GetString(2) + "-" + reader.GetString(3) + "\r\n";
                            }
                        }
                        
                    }
                  

                }

                txtOutput.Text = "Count: " + rowCount + "\r\n\r\n" + tempOutput;
            }
            catch (SqlException ae)
            {
                MessageBox.Show(ae.Message.ToString());
            }
        }

        private void cmbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnParse.Enabled = true;
            cmbDelimiter.Enabled = false;
        }

        private void cmbQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRunQuery.Enabled = true;
            btnReset.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ExecuteSQLStmt("DROP TABLE parserdata");
            ExecuteSQLStmt("CREATE TABLE parserdata (int rowid)");
            btnRunQuery.Enabled=false;
            cmbQuery.Text = "Select A Query";
            cmbQuery.Enabled=false; 
            btnSelectFile.Enabled=true;
            btnReset.Enabled=false;
            txtOutput.Text = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EmployeeDatabase
{
    public partial class EmployeeRegistration : Form
    {

        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Junester\Documents\First Database.accdb";

        public EmployeeRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool found  = false;
            string firstname = "";
            string lastname = "";
            string salary = "";
            string date = "";
            string address = "";
            string position = "";

            OleDbConnection thisConnection = new OleDbConnection(connectionString);

            string sql1 = "SELECT * FROM EMPLOYEEFILE";

            OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
            thisConnection.Open();

            OleDbDataReader thisReader = thisCommand.ExecuteReader();
            while (thisReader.Read()) {
                if (thisReader["EMPCODE"].ToString().Trim() == EmployeeBox.Text.Trim()) {
                    found = true;
                    firstname = thisReader["EMPFIRSTNAME"].ToString();
                    lastname = thisReader["EMPLASTNAME"].ToString();
                    salary = thisReader["EMPSALARY"].ToString();
                    date = thisReader["EMPDATEHIRED"].ToString();
                    address = thisReader["EMPADDRESS"].ToString();
                    position = thisReader["EMPPOSITION"].ToString();
                    break;
                }
                    
            }

            if (found == true)
            {
                firstBox.Text = firstname;
                lastBox.Text = lastname;
                salaryBox.Text = salary;
                dateHire.Text = date;
                addressBox.Text = address;
                positionBox.Text = position;
            }
            else
            {
                MessageBox.Show("Employee Code Not Found");
                EmployeeBox.Clear();
                firstBox.Clear();
                lastBox.Clear();
                salaryBox.Clear();
                dateHire.Clear();
                addressBox.Clear();
                positionBox.Clear();
            }

            thisConnection.Close();
            thisReader.Close();
        }

        private void clr_Btn_Click(object sender, EventArgs e)
        {
            EmployeeBox.Clear();
            firstBox.Clear();
            lastBox.Clear();
            salaryBox.Clear();
            dateHire.Clear();
            addressBox.Clear();
            positionBox.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM EMPLOYEEFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(thisAdapter);

            thisAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            DataSet thisSet = new DataSet();
            thisAdapter.Fill(thisSet, "EMPLOYEEFILE");

            DataRow findRow = thisSet.Tables["EMPLOYEEFILE"].Rows.Find(EmployeeBox.Text);
            
            
            if (EmployeeBox.Text == "" || firstBox.Text == "" || lastBox.Text == "" || salaryBox.Text == ""|| addressBox.Text == "" || positionBox.Text == "")
            {
                MessageBox.Show("No input detected. Please try again!");
            }
            else if (findRow == null)
            {
                DataRow thisRow = thisSet.Tables["EMPLOYEEFILE"].NewRow();
                thisRow["EMPCODE"] = EmployeeBox.Text;
                thisRow["EMPFIRSTNAME"] = firstBox.Text;
                thisRow["EMPLASTNAME"] = lastBox.Text;
                thisRow["EMPSALARY"] = salaryBox.Text;
                thisRow["EMPDATEHIRED"] = dateHired.Value;
                thisRow["EMPADDRESS"] = addressBox.Text;
                thisRow["EMPPOSITION"] = positionBox.Text;
                thisSet.Tables["EMPLOYEEFILE"].Rows.Add(thisRow);
                thisAdapter.Update(thisSet, "EMPLOYEEFILE");

                MessageBox.Show("Entries Successfully Recorded!");
            }
            else
                MessageBox.Show("Duplicate Entries Detected!");
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

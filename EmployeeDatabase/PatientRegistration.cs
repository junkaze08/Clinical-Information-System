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
    public partial class PatientRegistration : Form
    {

        string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Junester\Documents\First Database.accdb";

        public PatientRegistration()
        {
            InitializeComponent();
        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (patientCode.Text == "" || firstName.Text == "" || lastName.Text == "" || addressBox.Text == "" || telephoneBox.Text == "" || mothersName.Text == "" ||
                genderBox.Text == "" || birthdayBox.Text == "" || ageBox.Text == "" || weightBox.Text == "" || heightBox.Text == "")
            {
                MessageBox.Show("No Input Detected. Please Try Again");
            }
            else
            {
                patientF();
            }
        }

        public void patientF() 
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql = "SELECT * FROM PATIENTFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql, thisConnection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(thisAdapter);
            DataSet thisSet = new DataSet();
            thisAdapter.Fill(thisSet, "PATIENTFILE");
            DataRow thisRow = thisSet.Tables["PATIENTFILE"].NewRow();

            try
            {
                thisRow["PATIENTCODE"] = patientCode.Text;
                thisRow["PATIENTFIRSTNAME"] = firstName.Text;
                thisRow["PATIENTLASTNAME"] = lastName.Text;
                thisRow["PATIENTADDRESS"] = addressBox.Text;
                thisRow["PatientTELNO"] = Convert.ToInt32(telephoneBox.Text);
                thisRow["PatientFathersName"] = fatherBox.Text;
                thisRow["PatientMothersName"] = mothersName.Text;
                thisRow["PatientGender"] = genderBox.Text;
                thisRow["PatientBirthday"] = birthdayBox.Value;
                thisRow["PATIENTAGE"] = ageBox.Text;
                thisRow["PATIENTWEIGHT"] = weightBox.Text;
                thisRow["PATIENTHEIGHT"] = heightBox.Text;
                thisSet.Tables["PATIENTFILE"].Rows.Add(thisRow);
                thisAdapter.Update(thisSet, "PATIENTFILE");
                MessageBox.Show("Entry Successfully Recorded!");
            }
            catch (Exception)
            {
                MessageBox.Show("Code already exist, code must be unique");
            }
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            patientCode.Clear();
            firstName.Clear();
            lastName.Clear();
            addressBox.Clear();
            telephoneBox.Clear();
            genderBox.Clear();
            fatherBox.Clear();
            mothersName.Clear();
            genderBox.Clear();
            ageBox.Clear();
            weightBox.Clear();
            heightBox.Clear();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class ImmunizationEntry : Form
    {

        private string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Junester\Documents\First Database.accdb";

        public ImmunizationEntry()
        {
            InitializeComponent();
        }

        private void patientCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                bool found = false;
                string name = "";
                string address = "";
                string telNo = "";
                string father = "";
                string mother = "";
                string gender = "";
                string birth = "";
                string age = "";
                string weight = "";
                string height = "";

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM PATIENTFILE WHERE PATIENTCODE = '" + patientCode.Text + "'";
                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();
                OleDbDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read()) {
                    if (thisReader["PATIENTCODE"].ToString().Trim() == patientCode.Text.Trim());
                    found = true;
                    name = thisReader["PATIENTFIRSTNAME"].ToString() + " " + thisReader["PATIENTLASTNAME"].ToString();
                    address = thisReader["PATIENTADDRESS"].ToString();
                    telNo = thisReader["PATIENTTELNO"].ToString();
                    father = thisReader["PatientFathersName"].ToString();
                    mother = thisReader["PatientMothersName"].ToString();
                    gender = thisReader["PatientGender"].ToString();
                    birth = thisReader["PatientBirthday"].ToString();
                    age = thisReader["PATIENTAGE"].ToString();
                    weight = thisReader["PatientWeight"].ToString();
                    height = thisReader["PatientHeight"].ToString();
                    break;
                }
                if (found == true)
                {
                    patientName.Text = name;
                    addressBox.Text = address;
                    telBox.Text = telNo;
                    fatherBox.Text = father;
                    motherBox.Text = mother;
                    genderBox.Text = gender;
                    birthdayBox.Text = birth;
                    ageBox.Text = age;
                    weightBox.Text = weight;
                    heightBox.Text = height;
                }
                else
                {
                    MessageBox.Show("No Patient ID found!");
                    patientName.Clear();
                    addressBox.Clear();
                    telBox.Clear();
                    fatherBox.Clear();
                    motherBox.Clear();
                    genderBox.Clear();
                    birthdayBox.Clear();
                    ageBox.Clear();
                    weightBox.Clear();
                    heightBox.Clear();
                }
            }
        }

        private void vacxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                bool found = false;
                string vaccineCode = "";
                string vaccineName = "";
                string vaccineDescription = "";
                string vaccinePrice = "";
                string shotNum = "";
                string status = "";

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM VACCINEFILE WHERE VACCODE = '" + vacxCode.Text + "'";

                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();

                OleDbDataReader thisReader = thisCommand.ExecuteReader();

                for (int horizontal = 0; horizontal < vaccineGrid.Rows.Count; horizontal++) {
                    for (int vertical = 0; vertical < vaccineGrid.Columns.Count; vertical++)
                    {
                        if (vaccineGrid.Rows[horizontal].Cells[vertical].Value != null && vaccineGrid.Rows[horizontal].Cells[vertical].Value.Equals(vacxCode.Text.Trim())) {
                            MessageBox.Show("Vaccine already searched!");
                            thisConnection.Close();
                            return;
                        }
                    }
                }

                while (thisReader.Read()) {
                    if (thisReader["VACCODE"].ToString().Trim() == vacxCode.Text.Trim())
                        found = true;
                        vaccineCode = thisReader["VACCODE"].ToString();
                        vaccineName = thisReader["VACNAME"].ToString();
                        vaccineDescription = thisReader["VACDESC"].ToString();
                        vaccinePrice = thisReader["VACPRICE"].ToString();
                        shotNum = thisReader["VACNUMSHOT"].ToString();
                        status = thisReader["VACSTATUS"].ToString();
                    break;
                }
                int r = vaccineGrid.Rows.Add();
                if (found == true)
                {
                    vaccineGrid.Rows[r].Cells["VACCODE"].Value = vaccineCode;
                    vaccineGrid.Rows[r].Cells["VACNAME"].Value = vaccineName;
                    vaccineGrid.Rows[r].Cells["VACDESC"].Value = vaccineDescription;
                    vaccineGrid.Rows[r].Cells["VACPRICE"].Value = vaccinePrice;
                    vaccineGrid.Rows[r].Cells["VACNUMSHOT"].Value = shotNum;
                    vaccineGrid.Rows[r].Cells["VACSTATUS"].Value = status;
                }
                else
                    MessageBox.Show("Vaccine Code Not Found");
                thisConnection.Close();
                thisReader.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (immuneNo.Text == "" || vacxCode.Text == "" || shotNum.Text == "" || reactBox.Text == "" || dateImmu.Text == "" || patientCode.Text == "" ||
                weightBox.Text == "" || heightBox.Text == "" || prepResult.Text == "" || immuneResult.Text == "")
            {
                MessageBox.Show("No Input Detected. Please Try Again");
            }
            else if (validImmuH() == true) {
                MessageBox.Show("Duplicate ID Detected. Please Try Again");
            }
            else
            {
                ImmuHeader();
                ImmuDetail();
            }
        }

        public bool validImmuH() {

            bool duplicate = false;

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql1 = "SELECT * FROM IMMUNIZATIONHEADERFILE WHERE IMMHIMMUNO = '" + immuneNo.Text + "'";
            OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
            thisConnection.Open();
            OleDbDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {
                if (thisReader["IMMHIMMUNO"].ToString().Trim() == immuneNo.Text.Trim())
                {
                    return duplicate = true;
                }
            }
                return duplicate;
        }

        public void ImmuDetail() {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql2 = "SELECT * FROM IMMUNIZATIONDETAILFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql2, thisConnection);
            OleDbCommand thisCommand = new OleDbCommand(sql2, thisConnection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisSet = new DataSet();
            thisAdapter.Fill(thisSet, "IMMUNIZATIONDETAILFILE");

            try
            {
                DataRow thisRow = thisSet.Tables["IMMUNIZATIONDETAILFILE"].NewRow();
                thisRow["IMMDIMMUHNO"] = immuneNo.Text;
                thisRow["IMMDVACCODE"] = vacxCode.Text;
                thisRow["IMMDSHOTNUM"] = Convert.ToInt32(shotNum.Text);
                thisRow["IMMDREACTION"] = reactBox.Text;
                thisSet.Tables["IMMUNIZATIONDETAILFILE"].Rows.Add(thisRow);
                thisAdapter.Update(thisSet, "IMMUNIZATIONDETAILFILE");
            MessageBox.Show("Entries Successfully Recorded!");
            }
                catch (Exception)
            {
                MessageBox.Show("Duplicate Entries on Immunization Detail File");
                    }
            }

        public void ImmuHeader() {
            OleDbConnection thisConnection1 = new OleDbConnection(connectionString);
            string sql3 = "SELECT * FROM IMMUNIZATIONHEADERFILE";
            OleDbDataAdapter thisAdapter1 = new OleDbDataAdapter(sql3, thisConnection1);
            OleDbCommand thisCommand1 = new OleDbCommand(sql3, thisConnection1);
            OleDbCommandBuilder commandBuilder1 = new OleDbCommandBuilder(thisAdapter1);

            DataSet thisSet1 = new DataSet();
            thisAdapter1.Fill(thisSet1, "IMMUNIZATIONHEADERFILE");

                try
                {
                DataRow thisRow1 = thisSet1.Tables["IMMUNIZATIONHEADERFILE"].NewRow();
                    thisRow1["IMMHIMMUNO"] = immuneNo.Text;
                    thisRow1["IMMHDATE"] = dateImmu.Value;
                    thisRow1["IMMHPATCODE"] = patientCode.Text;
                    thisRow1["IMMHPATWEIGHT"] = weightBox.Text;
                    thisRow1["IMMHPATHEIGHT"] = heightBox.Text;
                    thisRow1["IMMHPREPBY"] = prepResult.Text;
                    thisRow1["IMMHIMMUBY"] = immuneResult.Text;
                    thisSet1.Tables["IMMUNIZATIONHEADERFILE"].Rows.Add(thisRow1);
                    thisAdapter1.Update(thisSet1, "IMMUNIZATIONHEADERFILE");
                    MessageBox.Show("Entries Successfully Recorded!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Duplicate Immunization Header File");
                }
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            patientCode.Clear();
            patientName.Clear();
            addressBox.Clear();
            telBox.Clear();
            fatherBox.Clear();
            motherBox.Clear();
            genderBox.Clear();
            birthdayBox.Clear();
            ageBox.Clear();
            weightBox.Clear();
            heightBox.Clear();
            immuneBox.Clear();
            immuneResult.Clear();
            prepBox.Clear();
            prepResult.Clear();
        }

        private void prepBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM EMPLOYEEFILE WHERE EMPCODE = '" + prepBox.Text + "'";
                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();
                OleDbDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    if (thisReader["EMPCODE"].ToString().Trim() == prepBox.Text.Trim())
                    {
                        if (thisReader["EMPPOSITION"].ToString().Trim().ToUpper() == "DOCTOR")
                        {
                            found = true;
                            prepResult.Text = thisReader["EMPFIRSTNAME"].ToString() + " " + thisReader["EMPLASTNAME"].ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Person is not authorized! Doctor is only allowed!");
                            return;
                        }
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("Employee Code does not exist.");
                }
            }
        }

        private void immuneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM EMPLOYEEFILE WHERE EMPCODE = '" + immuneBox.Text + "'";
                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();
                OleDbDataReader thisReader = thisCommand.ExecuteReader();

                while (thisReader.Read())
                {
                    if (thisReader["EMPCODE"].ToString().Trim() == immuneBox.Text.Trim())
                    {
                        if (thisReader["EMPPOSITION"].ToString().Trim().ToUpper() == "NURSE")
                        {
                            found = true;
                            immuneResult.Text = thisReader["EMPFIRSTNAME"].ToString() + " " + thisReader["EMPLASTNAME"].ToString();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Person is not authorized! Nurse is only allowed!");
                            return;
                        }
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("Employee Code does not exist.");
                }
            }
        }
    }
}
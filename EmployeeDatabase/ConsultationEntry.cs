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
    public partial class ConsultationEntry : Form
    {

        private string connectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Junester\Documents\First Database.accdb";

        public ConsultationEntry()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void patientCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
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
                while (thisReader.Read())
                {
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
                thisConnection.Close();
                thisReader.Close();
            }
        }

        private void clrButton_Click(object sender, EventArgs e)
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
            prepBox.Clear();
            prep1.Clear();
            examineBox.Clear();
            immune1.Clear();
            diagcodeBox.Clear();
            consulBox.Clear();
            immuniBox.Clear();
            physicianBox.Clear();
        }

        private void prepBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                string fcode = "";

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM EMPLOYEEFILE WHERE EMPCODE = '" + prepBox.Text + "'";
                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();
                OleDbDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    if (thisReader["EMPCODE"].ToString().Trim() == prepBox.Text.Trim())
                    {
                        found = true;
                        fcode = thisReader["EMPFIRSTNAME"].ToString() + " " + thisReader["EMPLASTNAME"].ToString();
                    }
                }
                if (found == true)
                {
                    prep1.Text = fcode;
                }
                else
                    MessageBox.Show("No Patient ID found!");
            }
        }

        private void immuneBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                string lcode = "";

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM EMPLOYEEFILE WHERE EMPCODE = '" + examineBox.Text + "'";
                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();
                OleDbDataReader thisReader = thisCommand.ExecuteReader();
                while (thisReader.Read())
                {
                    if (thisReader["EMPCODE"].ToString().Trim() == examineBox.Text.Trim())
                    {
                        found = true;
                        lcode = thisReader["EMPFIRSTNAME"].ToString() + " " + thisReader["EMPLASTNAME"].ToString();
                    }
                }
                if (found == true)
                {
                    immune1.Text = lcode;
                }
                else
                    MessageBox.Show("No Patient ID found!");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (consulBox.Text == "" || diagcodeBox.Text == "" || physicianBox.Text == "" || immuniBox.Text == "" || dateInput.Text == "" || patientCode.Text == "" ||
                weightBox.Text == "" || heightBox.Text == "" || bodytempBox.Text == "" || prepBox.Text == "" || examineBox.Text == "")
            {
                MessageBox.Show("No Input Detected. Please Try Again");
            }
            else if (validConsulH() == true)
            {
                MessageBox.Show("Duplicate ID Detected. Please Try Again");
            }
            else
            {
                consulheader();
                consuldetail();
            }
        }

        public bool validConsulH()
        {

            bool duplicate = false;

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql1 = "SELECT * FROM CONSULTATIONHEADERFILE WHERE CONHNO = '" + consulBox.Text + "'";
            OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
            thisConnection.Open();
            OleDbDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {
                if (thisReader["CONHNO"].ToString().Trim() == consulBox.Text.Trim())
                {
                    return duplicate = true;
                }
            }
            return duplicate;
        }

        public void consuldetail()
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql2 = "SELECT * FROM CONSULTATIONDETAILFILE";
            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql2, thisConnection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisSet = new DataSet();
            thisAdapter.Fill(thisSet, "CONSULTATIONDETAILFILE");
            DataRow thisRow = thisSet.Tables["CONSULTATIONDETAILFILE"].NewRow();

            try
            {
                thisRow["CONDNO"] = consulBox.Text;
                thisRow["CONDDIAGNOSISCODE"] = diagcodeBox.Text;
                thisRow["CONDNOTES"] = physicianBox.Text;
                thisSet.Tables["CONSULTATIONDETAILFILE"].Rows.Add(thisRow);
                thisAdapter.Update(thisSet, "CONSULTATIONDETAILFILE");
                MessageBox.Show("Entries Successfully Recorded!");
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Entries Detected!");
            }
        }

        public void consulheader()
        {
            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string sql2 = "SELECT * FROM CONSULTATIONHEADERFILE";

            OleDbDataAdapter thisAdapter = new OleDbDataAdapter(sql2, thisConnection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(thisAdapter);

            DataSet thisSet = new DataSet();
            thisAdapter.Fill(thisSet, "CONSULTATIONHEADERFILE");
            DataRow thisRow = thisSet.Tables["CONSULTATIONHEADERFILE"].NewRow();
            try
            {
                thisRow["CONHNO"] = consulBox.Text;
                thisRow["CONHIMMUREF"] = immuniBox.Text;
                thisRow["CONHDATE"] = dateInput.Text;
                thisRow["CONHPATIENTCODE"] = patientCode.Text;
                thisRow["CONHPATIENTWEIGHT"] = weightBox.Text;
                thisRow["CONHPATIENTHEIGHT"] = heightBox.Text;
                thisRow["CONHPATIENTBODYTEMP"] = bodytempBox.Text;
                thisRow["CONHREFSLIPS"] = forlabtest();
                thisRow["CONHPREPAREDBY"] = prep1.Text;
                thisRow["CONHEXAMINEDBY"] = immune1.Text;
                thisSet.Tables["CONSULTATIONHEADERFILE"].Rows.Add(thisRow);
                thisAdapter.Update(thisSet, "CONSULTATIONHEADERFILE");
                MessageBox.Show("Entries Successfully Recorded!");
            }
            catch (Exception)
            {
                MessageBox.Show("Duplicate Entries Detected!");
            }
        }

        public string forlabtest()
        {
            string labtest = "";
            if (labCheck.Checked == true)
            {
                return labtest += "For Laboratory Test";
            }
            if (admissionCheck.Checked == true)
            {
                return labtest += "For Admission Test";
            }
            return labtest;
        }

        private void diagcodeBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bool found = false;
                string diagnosisCode = "";
                string diagnosisName = "";
                string diagnosisStatus = "";

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string sql1 = "SELECT * FROM DIAGNOSISFILE WHERE DIAGNOSISCODE = '" + diagcodeBox.Text + "'";

                OleDbCommand thisCommand = new OleDbCommand(sql1, thisConnection);
                thisConnection.Open();

                OleDbDataReader thisReader = thisCommand.ExecuteReader();
                for (int horizontal = 0; horizontal < diagnosisInfo.Rows.Count; horizontal++)
                {
                    for (int vertical = 0; vertical < diagnosisInfo.Columns.Count; vertical++)
                    {
                        if (diagnosisInfo.Rows[horizontal].Cells[vertical].Value != null && diagnosisInfo.Rows[horizontal].Cells[vertical].Value.Equals(diagcodeBox.Text.Trim()))
                        {
                            MessageBox.Show("Vaccine already searched!");
                            thisConnection.Close();
                            return;
                        }
                    }
                }
                while (thisReader.Read())
                {
                    if (thisReader["DIAGNOSISCODE"].ToString().Trim() == diagcodeBox.Text.Trim())
                    found = true;
                    diagnosisCode = thisReader["DIAGNOSISCODE"].ToString();
                    diagnosisName = thisReader["DIAGNOSISNAME"].ToString();
                    diagnosisStatus = thisReader["DIAGNOSISSTATUS"].ToString();
                    break;
                }
                int r = diagnosisInfo.Rows.Add();
                if (found == true)
                {
                    diagnosisInfo.Rows[r].Cells["DIAGNOSISCODE"].Value = diagnosisCode;
                    diagnosisInfo.Rows[r].Cells["DIAGNOSISNAME"].Value = diagnosisName;
                    diagnosisInfo.Rows[r].Cells["DIAGNOSISSTATUS"].Value = diagnosisStatus;
                }
                else
                    MessageBox.Show("Vaccine Code Not Found");
                thisConnection.Close();
                thisReader.Close();
            }
        }
    }
}
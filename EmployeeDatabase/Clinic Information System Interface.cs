using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDatabase
{
    public partial class ClinicInformationSystem : Form
    {
        public ClinicInformationSystem()
        {
            InitializeComponent();
        }

        private void empBtn_Click(object sender, EventArgs e)
        {
            EmployeeRegistration empform = new EmployeeRegistration();
            this.Hide();
            empform.ShowDialog();
            this.Show();
        }

        private void immBtn_Click(object sender, EventArgs e)
        {
            ImmunizationEntry immform = new ImmunizationEntry();
            this.Hide();
            immform.ShowDialog();  
            this.Show();
        }

        private void consulBtn_Click(object sender, EventArgs e)
        {
            ConsultationEntry consulform = new ConsultationEntry();
            this.Hide();
            consulform.ShowDialog();
            this.Show();
        }

        private void patregBtn_Click(object sender, EventArgs e)
        {
            PatientRegistration patregform = new PatientRegistration();
            this.Hide();
            patregform.ShowDialog();
            this.Show();
        }

        private void ClinicInformationSystem_Load(object sender, EventArgs e)
        {

        }
    }
}

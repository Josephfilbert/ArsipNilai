using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArsipNilai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static String connectionString = "Server=JOSEPH-NOTEBOOK\\SQLEXPRESS;Database=ArsipNilai;Trusted_Connection=true";
        static String RelationLabelInterfaceText = "Showing contents for relation : ";

        private void btnShowAllData_Click(object sender, EventArgs e)
        {
            new frmAllData().ShowDialog();
        }

        //for cohesive function
        private void ShowContentRoutine(String RelationName, ref DataGridView datagridRef)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SELECT * FROM @relName", conn);
                    command.Parameters.Add(new SqlParameter("relName", RelationName));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        datagridRef.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Arsip Nilai", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnTampilMahasiswa_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("Student", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "Student";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("SemesterData", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "SemesterData";
        }
    }
}

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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static String connectionString = @"Server=JOSEPH-NOTEBOOK\SQLEXPRESS;Database=ArsipNilai;Trusted_Connection=true";
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

                    SqlCommand command = new SqlCommand(String.Format("SELECT * FROM {0}", RelationName), conn);
                    //command.Parameters.Add(new SqlParameter("@relName", RelationName));

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
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void show_relation_button(Object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string rName = (string)button.Tag;
            ShowContentRoutine(rName, ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + rName;
        }

        private void tombol_tambah_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string relationName = (string)button.Tag;
            string tampilButtonName;

            if (relationName == "Student")
            {
                tampilButtonName = "btnTampilMahasiswa";
            }
            else if (relationName == "Courses")
            {
                tampilButtonName = "btnTampilDataMataKuliah";
            }
            else if (relationName == "SemesterData")
            {
                tampilButtonName = "btnTampilDataSemester";
            }
            else if(relationName == "Scores")
            {
                tampilButtonName = "btnTampilDataNilai";
            }
            else return;

            if(new dlgEditData(relationName).ShowDialog() == DialogResult.OK)
            {
                Button tampilButton = (Button)this.Controls.Find(tampilButtonName, true).FirstOrDefault();
                tampilButton.PerformClick();
            }
        }
    }
}

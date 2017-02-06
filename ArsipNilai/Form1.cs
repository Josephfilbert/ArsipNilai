﻿using System;
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

        public static String connectionString = "Server=JOSEPH-NOTEBOOK\\SQLEXPRESS;Database=ArsipNilai;Trusted_Connection=true";
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

        private void btnTampilMahasiswa_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("Student", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "Student";
        }

        private void btnTampilDataSemester_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("SemesterData", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "SemesterData";
        }

        private void btnTampilDataMataKuliah_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("Courses", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "Courses";
        }

        private void btnTampilDataNilai_Click(object sender, EventArgs e)
        {
            ShowContentRoutine("Scores", ref dgvAnyData);
            lblActiveRelation.Text = RelationLabelInterfaceText + "Scores";
        }

        private void btnTambahMahasiswa_Click(object sender, EventArgs e)
        {
            if(new dlgEditData("Student").ShowDialog() == DialogResult.OK)
            {
                //refresh the list
                btnTampilMahasiswa.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new dlgEditData("SemesterData").ShowDialog() == DialogResult.OK)
            {
                //refresh the list
                btnTampilDataSemester.PerformClick();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArsipNilai
{
    public partial class frmAllData : Form
    {
        public frmAllData()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=JOSEPH-NOTEBOOK\\SQLEXPRESS;Database=ArsipNilai;Trusted_Connection=true"))
                {
                    //open connection
                    //conn.ConnectionString = "Server=JOSEPH-NOTEBOOK\\SQLEXPRESS;Database=ArsipNilai;Trusted_Connection=true";
                    conn.Open();

                    //Data Reader

                    //Specify the command
                    //the view is also stored on server
                    SqlCommand command = new SqlCommand("SELECT * FROM AllStudents", conn);
                    command.CommandType = CommandType.Text; //optional line


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgvAllData.DataSource = dt;
                    }

                }
            } catch (SqlException sqlEx)
            {
                if(sqlEx.Number == -1)
                {
                    CommonFunctions.InvokeErrorMsg("Failed establishing connection to database. Check if you are granted permission to database or SQL Server Service is running", Application.ProductName);
                }
            }
        }
    }
}

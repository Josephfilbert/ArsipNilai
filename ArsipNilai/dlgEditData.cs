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
    public partial class dlgEditData : Form
    {

        
        

        enum OperationMode
        {
            insert, update
        }

        String relationName;
        String key1, key2, key3;
        OperationMode opMode;

        public dlgEditData()
        {
            InitializeComponent();
        }

        public dlgEditData(String relName, String k1 = null, String k2 = null, String k3 = null)
        {
            InitializeComponent();

            //fill to private data members
            relationName = relName;
            key1 = k1;
            key2 = k2;
            key3 = k3;

            try
            {
                //connect to database
                using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
                {
                    conn.Open();

                    /*
                    //get primary keys and foreign keys
                    List<String> primaryKeys, foreignKeys;

                    //get primary key and foreign keys
                    primaryKeys = new List<string>();
                    foreignKeys = new List<string>();

                    //obtain primary keys and foreign keys of relation
                    using (SqlCommand command = new SqlCommand(String.Format("select CONSTRAINT_TYPE, COLUMN_NAME from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE cc on tc.CONSTRAINT_NAME = cc.CONSTRAINT_NAME and tc.TABLE_NAME = cc.TABLE_NAME where (CONSTRAINT_TYPE = 'PRIMARY KEY' or CONSTRAINT_TYPE = 'FOREIGN KEY') and cc.TABLE_NAME = {0}", relName), conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            //populate the primary keys and foreign keys
                            while(reader.Read())
                            {
                                if(reader.GetString(0) == "PRIMARY KEY")
                                {
                                    primaryKeys.Add(reader.GetString(1));
                                } else
                                {
                                    foreignKeys.Add(reader.GetString(1));
                                }
                            }
                        }
                    }
                    */

                    //we already know the keys in each relation so we can directly specify it

                    //check operation mode
                    if(k1 == null)
                    {
                        //if key1 is null, then it is data insertion mode
                        opMode = OperationMode.insert;

                        //check relation name, it determines number of key fields to be active
                        if(relName == "Student")
                        {
                            //hide the key2 and key3 field
                            lblKey2.Visible = lblKey3.Visible = cboKey2.Visible = cboKey3.Visible = false;

                            //also the Student relation has 3 non-primary key fields so hide the last 2 fields
                            lblField4.Visible = lblField5.Visible = txtField4.Visible = txtField5.Visible = false;

                            //the first key is the new key, disable the dropdown button
                            cboKey1.DropDownStyle = ComboBoxStyle.Simple;

                            //set the attribute levels
                            lblKey1.Text = "NIM :";
                            lblField1.Text = "Name :";
                            lblField2.Text = "Program :";
                            lblField3.Text = "Enroll Year :";
                        }

                        //TODO: Implement for other relations!!!
                        
                    }

                    //TODO: Implement for other relations!!!!

                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Arsip Nilai", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            //check constraints
            if(relationName == "Student")
            {
                //validate NIM
                if(cboKey1.Text.Length != 10 || !CommonFunctions.IsNumeric(cboKey1.Text))
                {
                    CommonFunctions.InvokeErrorMsg("NIM should be numeric and 10 characters length!", Application.ProductName);
                    return;
                }

                //validate not null for the three fields
                if(String.IsNullOrWhiteSpace(txtField1.Text) || String.IsNullOrWhiteSpace(txtField2.Text) || String.IsNullOrWhiteSpace(txtField3.Text))
                {
                    CommonFunctions.InvokeErrorMsg("The fields cannot be empty!", Application.ProductName);
                    return;
                }

                //validate that the EnrollYear should be numeric
                if (!CommonFunctions.IsNumeric(txtField3.Text)) return;


            }

            //insert or update
            if(opMode == OperationMode.insert)
            {

               try {
                    using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
                    {
                        conn.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = conn;
                      
                        
                        if(relationName == "Student")
                        {
                            command.CommandText =  "INSERT INTO Student (NIM, Name, Program, EnrollYear) VALUES (@1, @2, @3, @4)";

                            command.Parameters.Add(new SqlParameter("1", cboKey1.Text)); //NIM
                            command.Parameters.Add(new SqlParameter("2", txtField1.Text)); //Name
                            command.Parameters.Add(new SqlParameter("3", txtField2.Text)); //Program
                            command.Parameters.Add(new SqlParameter("4", short.Parse(txtField3.Text))); //EnrollYear

                            
                        }

                        //TODO: Implement for other relations!

                        //Execute the update command
                        if(command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Insert successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                           
                    }
                } catch (Exception ex)
                {
                    CommonFunctions.InvokeErrorMsg(ex.Message, Application.ProductName);
                }
            }

            //TODO: Do for update mode as well
            else
            {

            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dlgEditData_Load(object sender, EventArgs e)
        {
            
        }

        private void dlgEditData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

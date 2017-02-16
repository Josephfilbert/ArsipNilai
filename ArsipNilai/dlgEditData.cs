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
        /*
         * SQL Error Number List:
         * 2627: No duplicate key (violation of primary key constraint)
         * 547: INSERT conflicted with CHECK constraint
         * 
         */
        
        /*
         * Set ComboBox DropDownStyle
         * Simple : Same as regular TextBox
         * DropDown : allow typing
         * DropDownList : prevent typing
         *
         */

        enum OperationMode
        {
            Insert, Update
        }

        String relationName;
        String key1, key2, key3;
        OperationMode opMode;

        bool ShouldInsertUAPScore; //used for Score insertion

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
            this.Text = relName;

           

        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            #region "Validation"
            //check constraints
            if (relationName == "Student")
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
                    CommonFunctions.InvokeErrorMsg("The attributes cannot be empty!", Application.ProductName);
                    return;
                }

                //validate that the EnrollYear should be numeric
                if (!CommonFunctions.IsNumeric(txtField3.Text))
                {
                    CommonFunctions.InvokeErrorMsg("Enroll Year should be numeric!", Application.ProductName);
                    return;
                }


            }


            //TODO: Implement for other relations!!!
            else if (relationName == "SemesterData")
            {
                //check semester number
                int semester;
                
                if(!int.TryParse(cboKey2.Text, out semester) || semester < 1)
                {
                    CommonFunctions.InvokeErrorMsg("The semester should be numeric and greater than zero", Application.ProductName);
                    return;
                }

                if(!CommonFunctions.IsNumeric(txtField1.Text))
                {
                    CommonFunctions.InvokeErrorMsg("The semester year should be numeric!", Application.ProductName);
                    return;
                }

            }

            else if (relationName == "Courses")
            {
                //check course code
                if(String.IsNullOrWhiteSpace(cboKey1.Text) || !(cboKey1.Text.Length == 8) || CommonFunctions.IsNumeric(cboKey1.Text.Substring(0, 4)) || !CommonFunctions.IsNumeric(cboKey1.Text.Substring(4, 4)))
                {
                    CommonFunctions.InvokeErrorMsg("The format of course code should be AAAA0000", Application.ProductName);
                    return;
                }

                //check other attributes, it shouldn't be empty
                if (string.IsNullOrWhiteSpace(cboKey2.Text) || string.IsNullOrWhiteSpace(cboKey3.Text) || string.IsNullOrWhiteSpace(txtField1.Text) ||
                    string.IsNullOrWhiteSpace(txtField2.Text) || string.IsNullOrWhiteSpace(txtField3.Text) || string.IsNullOrWhiteSpace(txtField4.Text) ||
                    string.IsNullOrWhiteSpace(txtField5.Text))
                {
                    CommonFunctions.InvokeErrorMsg("The attributes cannot be empty!", Application.ProductName);
                    return;
                }
                
                //numeric validation
                if(!CommonFunctions.IsNumeric(txtField2.Text) || !CommonFunctions.IsNumeric(txtField3.Text) || !CommonFunctions.IsNumeric(txtField4.Text) ||
                    !CommonFunctions.IsNumeric(txtField5.Text))
                {
                    CommonFunctions.InvokeErrorMsg("The weight values should be numeric!", Application.ProductName);
                    return;
                } 

            }

            else if(relationName == "Scores")
            {

                //the keys must not be empty
                if(cboKey1.Text == string.Empty || cboKey2.Text == string.Empty || cboKey3.Text == string.Empty)
                {
                    CommonFunctions.InvokeErrorMsg("The keys should not be empty!", Application.ProductName);
                    return;
                }

                //check the textboxes, it should be numeric and in 0..100 range
                foreach(System.Windows.Forms.Control txtBoxes in this.Controls)
                {
                    //only text box should be checked
                    if(txtBoxes.GetType() == typeof(TextBox))
                    {

                        //do not check the class field, it will be handled by table constraint, just check if empty or not
                        if (txtBoxes.Name == "txtField1")
                        {
                            if (String.IsNullOrWhiteSpace(txtBoxes.Text))
                            {
                                CommonFunctions.InvokeErrorMsg("The class field should not be zero", Application.ProductName);
                                return;
                            }
                            else
                                continue;
                        }

                        //check the UAP field, if practicum credit is zero then no need to check
                        if (txtBoxes.Name == "txtField5" && !ShouldInsertUAPScore) continue;

                        //check, it should be numeric
                        short score;
                        if (!short.TryParse(txtBoxes.Text, out score) || score < 0 || score > 100)
                        {
                            CommonFunctions.InvokeErrorMsg("Invalid scores!\nIt should be numeric and between 0..100", Application.ProductName);
                            return;
                        }
                    }
                }
            }

            #endregion

            //insert or update
            if (opMode == OperationMode.Insert)
            {

               try {
                    using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
                    {
                        conn.Open();

                        using (SqlCommand command = new SqlCommand())
                        {
                            command.Connection = conn;


                            if (relationName == "Student")
                            {
                                command.CommandText = "INSERT INTO Student (NIM, Name, Program, EnrollYear) VALUES (@1, @2, @3, @4)";

                                command.Parameters.Add(new SqlParameter("1", cboKey1.Text)); //NIM
                                command.Parameters.Add(new SqlParameter("2", txtField1.Text)); //Name
                                command.Parameters.Add(new SqlParameter("3", txtField2.Text)); //Program
                                command.Parameters.Add(new SqlParameter("4", short.Parse(txtField3.Text))); //EnrollYear


                                try
                                {
                                    //Execute the update command
                                    if (command.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Insert successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }

                                catch (SqlException sqlEx)
                                {

                                    if (sqlEx.Number == 2627)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The NIM already exists!", Application.ProductName);
                                    }

                                    else if (sqlEx.Number == 547)
                                    {
                                        CommonFunctions.InvokeErrorMsg("Enroll year should be lesser than or equal to " + DateTime.Now.Year, Application.ProductName);
                                    }

                                    else
                                    {
                                        CommonFunctions.InvokeErrorMsg(String.Format(
                                        "SQL Error Code : {0}\n" +
                                        "SQL Error Number : {1}\n" +
                                        "SQL Message :\n{2}",
                                            sqlEx.ErrorCode, sqlEx.Number, sqlEx.Message
                                        )
                                        , Application.ProductName);
                                    }

                                }



                            }

                            //TODO: Implement for other relations!
                            else if (relationName == "SemesterData")
                            {
                                command.CommandText = "INSERT INTO SemesterData (NIM, Semester, SemesterYear) VALUES (@1, @2, @3)";

                                command.Parameters.Add(new SqlParameter("1", cboKey1.Text.Substring(0, 10))); //NIM
                                command.Parameters.Add(new SqlParameter("2", short.Parse(cboKey2.Text))); //Semester
                                command.Parameters.Add(new SqlParameter("3", short.Parse(txtField1.Text))); //Semester Year

                                try
                                {
                                    if (command.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Insert successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }
                                catch (SqlException sqlEx)
                                {
                                    if (sqlEx.Number == 2627)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The semester already exists!", Application.ProductName);
                                    }

                                    else if (sqlEx.Number == 547)
                                    {
                                        CommonFunctions.InvokeErrorMsg("Semester Year must be greater or equal to Enroll Year and less than or equal to current year", Application.ProductName);
                                    }
                                    else
                                    {
                                        CommonFunctions.InvokeErrorMsg(String.Format(
                                            "SQL Error Code : {0}\n" +
                                            "SQL Error Number : {1}\n" +
                                            "SQL Message :\n{2}",
                                                sqlEx.ErrorCode, sqlEx.Number, sqlEx.Message
                                            )
                                            , Application.ProductName);
                                    }
                                }

                            }

                            else if(relationName == "Courses")
                            {
                                command.CommandText = "INSERT INTO Courses (CourseCode, CourseName, TheoryCredit, PracticumCredit, TMWeight, UTSWeight, PracticumWeight, UASWeight) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)";

                                command.Parameters.Add(new SqlParameter("1", cboKey1.Text));
                                command.Parameters.Add(new SqlParameter("2", cboKey2.Text));
                                command.Parameters.Add(new SqlParameter("3", short.Parse(cboKey3.Text)));
                                command.Parameters.Add(new SqlParameter("4", short.Parse(txtField1.Text)));
                                command.Parameters.Add(new SqlParameter("5", short.Parse(txtField2.Text)));
                                command.Parameters.Add(new SqlParameter("6", short.Parse(txtField3.Text)));
                                command.Parameters.Add(new SqlParameter("7", short.Parse(txtField4.Text)));
                                command.Parameters.Add(new SqlParameter("8", short.Parse(txtField5.Text)));

                                try
                                {
                                    if(command.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Insert successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }
                                catch (SqlException sqlEx)
                                {
                                    if (sqlEx.Number == 2627)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The course code already exists!", Application.ProductName);
                                    }
                                    else if(sqlEx.Number == 547)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The total weight must be 100!", Application.ProductName);
                                    }
                                    else
                                    {
                                        CommonFunctions.InvokeErrorMsg(String.Format(
                                                "SQL Error Code : {0}\n" +
                                                "SQL Error Number : {1}\n" +
                                                "SQL Message :\n{2}",
                                                    sqlEx.ErrorCode, sqlEx.Number, sqlEx.Message
                                                )
                                                , Application.ProductName);
                                    }
                                }

                            }

                            else if(relationName == "Scores")
                            {
                                command.CommandText = ShouldInsertUAPScore ? 
                                    "INSERT INTO Scores (NIM, Semester, CourseCode, Class, TM, UTS, UAS, UAP) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)"
                                    :
                                    "INSERT INTO Scores (NIM, Semester, CourseCode, Class, TM, UTS, UAS) VALUES (@1, @2, @3, @4, @5, @6, @7)";

                                command.Parameters.Add(new SqlParameter("1", cboKey1.Text.Substring(0, 10)));
                                command.Parameters.Add(new SqlParameter("2", cboKey2.Text));
                                command.Parameters.Add(new SqlParameter("3", cboKey3.Text.Substring(0, 8)));
                                command.Parameters.Add(new SqlParameter("4", txtField1.Text));
                                command.Parameters.Add(new SqlParameter("5", short.Parse(txtField2.Text)));
                                command.Parameters.Add(new SqlParameter("6", short.Parse(txtField3.Text)));
                                command.Parameters.Add(new SqlParameter("7", short.Parse(txtField4.Text)));
                                if(ShouldInsertUAPScore) command.Parameters.Add(new SqlParameter("8", short.Parse(txtField5.Text)));

                                try
                                {
                                    if(command.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Insert successful!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                }
                                catch (SqlException sqlEx)
                                {
                                    if(sqlEx.Number == 2627)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The specified student, semester and course already exists!", Application.ProductName);
                                    }
                                    else if(sqlEx.Number == 547 || sqlEx.Number == 8152)
                                    {
                                        CommonFunctions.InvokeErrorMsg("The class code should be AA00 format", Application.ProductName);
                                    }
                                    else
                                    {
                                        CommonFunctions.InvokeErrorMsg(String.Format(
                                                "SQL Error Code : {0}\n" +
                                                "SQL Error Number : {1}\n" +
                                                "SQL Message :\n{2}",
                                                    sqlEx.ErrorCode, sqlEx.Number, sqlEx.Message
                                                )
                                                , Application.ProductName);
                                    }
                                }

                            }
                        }


                    }
                }

                catch (Exception ex)
                {
                    CommonFunctions.InvokeErrorMsg(ex.Message, Application.ProductName);
                }
            }

            //TODO: Do for update mode as well
            else
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKey1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (relationName != "Scores") return;

            //clear the combo box 2
            cboKey2.Items.Clear();

            //get available semesters, apply the change to cboKey2 (semester select)
            using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    //get semester
                    command.Connection = conn;
                    command.CommandText = "SELECT Semester FROM SemesterData WHERE NIM = @1";
                    command.Parameters.Add(new SqlParameter("1", cboKey1.Text.Substring(0, 10)));

                    SqlDataReader reader = command.ExecuteReader();

                    //do read
                    if(reader.Read())
                    {
                        //add first item 
                        cboKey2.Items.Add(reader["Semester"]);

                        //add the rest
                        while(reader.Read())
                            cboKey2.Items.Add(reader["Semester"]);

                        //enable the control
                        cboKey2.Enabled = true;
                    }
                    else
                    {
                        //if there's no semester data for this student, cancel reading and disable the controls
                        cboKey2.Enabled = false;
                    }

                    
                }
            }
        }

        /*private void cboKey2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (relationName != "Scores") return;

            //clear the cboKey3 list first
            cboKey3.Items.Clear();

            //get available courses
            using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;

                    //do a table join to get CourseCode with CourseName
                    command.CommandText = "SELECT s.CourseCode, CourseName FROM Scores s JOIN Courses c ON s.CourseCode = c.CourseCode WHERE NIM = @1 AND Semester = @2";
                    command.Parameters.Add(new SqlParameter("1", cboKey1.Text.Substring(0, 10)));
                    command.Parameters.Add(new SqlParameter("2", short.Parse(cboKey2.Text)));

                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.Read())
                    {
                        cboKey3.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));

                        while(reader.Read())
                            cboKey3.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));

                        cboKey3.Enabled = true;
                    }
                    else
                    {
                        cboKey3.Enabled = false;
                    }

                    
                }
            }
        }*/

        private void cboKey3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //check if UAP field should be disabled or not

            if (relationName != "Scores") return;

            using (SqlConnection conn = new SqlConnection(frmMain.connectionString))
            {
                conn.Open();

                


                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT PracticumCredit FROM Courses WHERE CourseCode = @1";
                    command.Parameters.Add(new SqlParameter("1", cboKey3.Text.Substring(0, 8)));

                    short prkCredit = (short)command.ExecuteScalar();

                    if (prkCredit > 0)
                    {
                        ShouldInsertUAPScore = true;
                        txtField5.Enabled = true;
                    }
                    else
                    {
                        ShouldInsertUAPScore = false;
                        txtField5.Enabled = false;
                        txtField5.Clear();
                    }
                }
            }
        }

        private void dlgEditData_Load(object sender, EventArgs e)
        {
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

                    #region "UI Processing"
                    //check operation mode
                    if (key1 == null)
                    {
                        //if key1 is null, then it is data insertion mode
                        opMode = OperationMode.Insert;
                        this.Text = "Insert into " + this.Text;

                        //check relation name, it determines number of key fields to be active
                        if (relationName == "Student")
                        {
                            //hide the key2 and key3 field
                            lblKey2.Visible = lblKey3.Visible = cboKey2.Visible = cboKey2.Enabled = cboKey3.Visible = cboKey3.Enabled = false;

                            //also the Student relation has 3 non-primary key fields so hide the last 2 fields
                            lblField4.Visible = lblField5.Visible = txtField4.Visible = txtField5.Visible = false;

                            //the first key is the new key, disable the dropdown button
                            cboKey1.DropDownStyle = ComboBoxStyle.Simple;

                            //set the attribute labels
                            lblKey1.Text = "NIM :";
                            lblField1.Text = "Name :";
                            lblField2.Text = "Program :";
                            lblField3.Text = "Enroll Year :";
                        }

                        //TODO: Implement for other relations!!!
                        else if (relationName == "SemesterData")
                        {
                            //only 2 keys required
                            lblKey3.Visible = cboKey3.Visible = cboKey3.Enabled = false;

                            //used to insert new semester
                            cboKey2.DropDownStyle = ComboBoxStyle.Simple;

                            //only 1 field required
                            lblField2.Visible = lblField3.Visible = lblField4.Visible = lblField5.Visible = false;
                            txtField2.Visible = txtField3.Visible = txtField4.Visible = txtField5.Visible = false;
                            txtField2.Enabled = txtField3.Enabled = txtField4.Enabled = txtField5.Enabled = false;

                            //get available Students
                            using (SqlCommand cmdGetStudent = new SqlCommand("SELECT NIM, Name FROM Student ORDER BY NIM ASC", conn))
                            {

                                using (SqlDataReader reader = cmdGetStudent.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        cboKey1.Items.Add(reader["NIM"] + " - " + reader["Name"]);
                                        while (reader.Read())
                                        {
                                            cboKey1.Items.Add(reader["NIM"] + " - " + reader["Name"]);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Students available", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }

                            //make it drop down only and set first item as default
                            //cboKey1.DropDownStyle = ComboBoxStyle.DropDownList;
                            cboKey1.SelectedIndex = 0;

                            //set the labels
                            lblKey1.Text = "NIM :";
                            lblKey2.Text = "Semester :";
                            lblField1.Text = "Semester Year :";
                        }

                        else if (relationName == "Courses")
                        {
                            //all fields used, change all combo box to Text Box mode
                            cboKey1.DropDownStyle = cboKey2.DropDownStyle = cboKey3.DropDownStyle = ComboBoxStyle.Simple;

                            //set the labels
                            lblKey1.Text = "Course Code :";
                            lblKey2.Text = "Course Name :";
                            lblKey3.Text = "Theory Credit :";
                            lblField1.Text = "Practicum Credit :";
                            lblField2.Text = "TM Weight :";
                            lblField3.Text = "UTS Weight :";
                            lblField4.Text = "Practicum Weight :";
                            lblField5.Text = "UAS Weight :";
                        }

                        else if (relationName == "Scores")
                        {
                            //set the labels
                            lblKey1.Text = "NIM :";
                            lblKey2.Text = "Semester :";
                            lblKey3.Text = "Course Code :";
                            lblField1.Text = "Class :";
                            lblField2.Text = "TM :";
                            lblField3.Text = "UTS :";
                            lblField4.Text = "UAS :";
                            lblField5.Text = "UAP :";

                            //key 2 and key 3 field will be disabled by default until the a student is selected

                            //get available Students
                            using (SqlCommand cmdGetStudent = new SqlCommand("SELECT NIM, Name FROM Student ORDER BY NIM ASC", conn))
                            {

                                using (SqlDataReader reader = cmdGetStudent.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        cboKey1.Items.Add(reader["NIM"] + " - " + reader["Name"]);
                                        while (reader.Read())
                                        {
                                            cboKey1.Items.Add(reader["NIM"] + " - " + reader["Name"]);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Students available", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        this.Close();
                                    }
                                }
                            }

                            //disable combo box 2 because combo box 1 currently selected to nothing
                            cboKey2.Enabled = false;

                            //read available courses
                            using (SqlCommand command = new SqlCommand("SELECT CourseCode, CourseName FROM Courses", conn))
                            {
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    cboKey3.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));

                                    while (reader.Read())
                                        cboKey3.Items.Add(reader.GetString(0) + " - " + reader.GetString(1));

                                }
                                else
                                {
                                    //no courses available, cancel insertion
                                    MessageBox.Show("No courses available!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.Close();
                                }
                            }
                        }
                    }

                    

                    //TODO: Implement for other relations!!!!

                    #endregion
                }
            }

            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == -1)
                {
                    CommonFunctions.InvokeErrorMsg("Failed establishing connection to database. Check if you are granted permission to database or SQL Server Service is running", Application.ProductName);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Arsip Nilai", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dlgEditData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}

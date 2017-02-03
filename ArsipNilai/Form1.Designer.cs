namespace ArsipNilai
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.btnShowAllData = new System.Windows.Forms.Button();
            this.tabManipulation = new System.Windows.Forms.TabPage();
            this.grpDataSemester = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSelectedRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActiveRelation = new System.Windows.Forms.Label();
            this.dgvAnyData = new System.Windows.Forms.DataGridView();
            this.grpMahasiswa = new System.Windows.Forms.GroupBox();
            this.btnTampilMahasiswa = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tabManipulation.SuspendLayout();
            this.grpDataSemester.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnyData)).BeginInit();
            this.grpMahasiswa.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabQuery);
            this.tabControl1.Controls.Add(this.tabManipulation);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.btnShowAllData);
            this.tabQuery.Location = new System.Drawing.Point(4, 22);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(1031, 474);
            this.tabQuery.TabIndex = 0;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // btnShowAllData
            // 
            this.btnShowAllData.Location = new System.Drawing.Point(12, 13);
            this.btnShowAllData.Name = "btnShowAllData";
            this.btnShowAllData.Size = new System.Drawing.Size(196, 34);
            this.btnShowAllData.TabIndex = 0;
            this.btnShowAllData.Text = "TAMPILKAN SELURUH DATA";
            this.btnShowAllData.UseVisualStyleBackColor = true;
            this.btnShowAllData.Click += new System.EventHandler(this.btnShowAllData_Click);
            // 
            // tabManipulation
            // 
            this.tabManipulation.Controls.Add(this.grpDataSemester);
            this.tabManipulation.Controls.Add(this.statusStrip1);
            this.tabManipulation.Controls.Add(this.label1);
            this.tabManipulation.Controls.Add(this.lblActiveRelation);
            this.tabManipulation.Controls.Add(this.dgvAnyData);
            this.tabManipulation.Controls.Add(this.grpMahasiswa);
            this.tabManipulation.Location = new System.Drawing.Point(4, 22);
            this.tabManipulation.Name = "tabManipulation";
            this.tabManipulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabManipulation.Size = new System.Drawing.Size(1031, 474);
            this.tabManipulation.TabIndex = 1;
            this.tabManipulation.Text = "Data Manipulation";
            this.tabManipulation.UseVisualStyleBackColor = true;
            // 
            // grpDataSemester
            // 
            this.grpDataSemester.Controls.Add(this.button1);
            this.grpDataSemester.Location = new System.Drawing.Point(307, 6);
            this.grpDataSemester.Name = "grpDataSemester";
            this.grpDataSemester.Size = new System.Drawing.Size(289, 99);
            this.grpDataSemester.TabIndex = 1;
            this.grpDataSemester.TabStop = false;
            this.grpDataSemester.Text = "Data Semester";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tampilkan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelectedRow});
            this.statusStrip1.Location = new System.Drawing.Point(3, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1025, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblSelectedRow
            // 
            this.lblSelectedRow.Name = "lblSelectedRow";
            this.lblSelectedRow.Size = new System.Drawing.Size(39, 17);
            this.lblSelectedRow.Text = "Ready";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Right click on a tuple to edit or delete ";
            // 
            // lblActiveRelation
            // 
            this.lblActiveRelation.AutoSize = true;
            this.lblActiveRelation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveRelation.Location = new System.Drawing.Point(9, 223);
            this.lblActiveRelation.Name = "lblActiveRelation";
            this.lblActiveRelation.Size = new System.Drawing.Size(232, 26);
            this.lblActiveRelation.TabIndex = 2;
            this.lblActiveRelation.Text = "Showing contents for relation : Relation\r\nName";
            // 
            // dgvAnyData
            // 
            this.dgvAnyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnyData.Location = new System.Drawing.Point(0, 259);
            this.dgvAnyData.Name = "dgvAnyData";
            this.dgvAnyData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnyData.Size = new System.Drawing.Size(1031, 219);
            this.dgvAnyData.TabIndex = 1;
            // 
            // grpMahasiswa
            // 
            this.grpMahasiswa.Controls.Add(this.btnTampilMahasiswa);
            this.grpMahasiswa.Location = new System.Drawing.Point(12, 6);
            this.grpMahasiswa.Name = "grpMahasiswa";
            this.grpMahasiswa.Size = new System.Drawing.Size(289, 99);
            this.grpMahasiswa.TabIndex = 0;
            this.grpMahasiswa.TabStop = false;
            this.grpMahasiswa.Text = "Data Mahasiswa";
            // 
            // btnTampilMahasiswa
            // 
            this.btnTampilMahasiswa.Location = new System.Drawing.Point(11, 28);
            this.btnTampilMahasiswa.Name = "btnTampilMahasiswa";
            this.btnTampilMahasiswa.Size = new System.Drawing.Size(106, 33);
            this.btnTampilMahasiswa.TabIndex = 0;
            this.btnTampilMahasiswa.Text = "Tampilkan";
            this.btnTampilMahasiswa.UseVisualStyleBackColor = true;
            this.btnTampilMahasiswa.Click += new System.EventHandler(this.btnTampilMahasiswa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Arsip Nilai";
            this.tabControl1.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabManipulation.ResumeLayout(false);
            this.tabManipulation.PerformLayout();
            this.grpDataSemester.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnyData)).EndInit();
            this.grpMahasiswa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.Button btnShowAllData;
        private System.Windows.Forms.TabPage tabManipulation;
        private System.Windows.Forms.GroupBox grpMahasiswa;
        private System.Windows.Forms.Button btnTampilMahasiswa;
        private System.Windows.Forms.DataGridView dgvAnyData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActiveRelation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedRow;
        private System.Windows.Forms.GroupBox grpDataSemester;
        private System.Windows.Forms.Button button1;
    }
}


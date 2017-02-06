namespace ArsipNilai
{
    partial class frmMain
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
            this.btnTambahSemester = new System.Windows.Forms.TabPage();
            this.grpDataNilai = new System.Windows.Forms.GroupBox();
            this.btnTampilDataNilai = new System.Windows.Forms.Button();
            this.grpDataMataKuliah = new System.Windows.Forms.GroupBox();
            this.btnTampilDataMataKuliah = new System.Windows.Forms.Button();
            this.grpDataSemester = new System.Windows.Forms.GroupBox();
            this.btnTampilDataSemester = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSelectedRow = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblActiveRelation = new System.Windows.Forms.Label();
            this.dgvAnyData = new System.Windows.Forms.DataGridView();
            this.grpMahasiswa = new System.Windows.Forms.GroupBox();
            this.btnTambahMahasiswa = new System.Windows.Forms.Button();
            this.btnTampilMahasiswa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.btnTambahSemester.SuspendLayout();
            this.grpDataNilai.SuspendLayout();
            this.grpDataMataKuliah.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.btnTambahSemester);
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
            // btnTambahSemester
            // 
            this.btnTambahSemester.Controls.Add(this.grpDataNilai);
            this.btnTambahSemester.Controls.Add(this.grpDataMataKuliah);
            this.btnTambahSemester.Controls.Add(this.grpDataSemester);
            this.btnTambahSemester.Controls.Add(this.statusStrip1);
            this.btnTambahSemester.Controls.Add(this.label1);
            this.btnTambahSemester.Controls.Add(this.lblActiveRelation);
            this.btnTambahSemester.Controls.Add(this.dgvAnyData);
            this.btnTambahSemester.Controls.Add(this.grpMahasiswa);
            this.btnTambahSemester.Location = new System.Drawing.Point(4, 22);
            this.btnTambahSemester.Name = "btnTambahSemester";
            this.btnTambahSemester.Padding = new System.Windows.Forms.Padding(3);
            this.btnTambahSemester.Size = new System.Drawing.Size(1031, 474);
            this.btnTambahSemester.TabIndex = 1;
            this.btnTambahSemester.Text = "Data Manipulation";
            this.btnTambahSemester.UseVisualStyleBackColor = true;
            // 
            // grpDataNilai
            // 
            this.grpDataNilai.Controls.Add(this.btnTampilDataNilai);
            this.grpDataNilai.Location = new System.Drawing.Point(441, 6);
            this.grpDataNilai.Name = "grpDataNilai";
            this.grpDataNilai.Size = new System.Drawing.Size(137, 113);
            this.grpDataNilai.TabIndex = 6;
            this.grpDataNilai.TabStop = false;
            this.grpDataNilai.Text = "Data Nilai";
            // 
            // btnTampilDataNilai
            // 
            this.btnTampilDataNilai.Location = new System.Drawing.Point(11, 28);
            this.btnTampilDataNilai.Name = "btnTampilDataNilai";
            this.btnTampilDataNilai.Size = new System.Drawing.Size(106, 33);
            this.btnTampilDataNilai.TabIndex = 0;
            this.btnTampilDataNilai.Text = "Tampilkan";
            this.btnTampilDataNilai.UseVisualStyleBackColor = true;
            this.btnTampilDataNilai.Click += new System.EventHandler(this.btnTampilDataNilai_Click);
            // 
            // grpDataMataKuliah
            // 
            this.grpDataMataKuliah.Controls.Add(this.btnTampilDataMataKuliah);
            this.grpDataMataKuliah.Location = new System.Drawing.Point(298, 6);
            this.grpDataMataKuliah.Name = "grpDataMataKuliah";
            this.grpDataMataKuliah.Size = new System.Drawing.Size(137, 113);
            this.grpDataMataKuliah.TabIndex = 5;
            this.grpDataMataKuliah.TabStop = false;
            this.grpDataMataKuliah.Text = "Data Mata Kuliah";
            // 
            // btnTampilDataMataKuliah
            // 
            this.btnTampilDataMataKuliah.Location = new System.Drawing.Point(11, 28);
            this.btnTampilDataMataKuliah.Name = "btnTampilDataMataKuliah";
            this.btnTampilDataMataKuliah.Size = new System.Drawing.Size(106, 33);
            this.btnTampilDataMataKuliah.TabIndex = 0;
            this.btnTampilDataMataKuliah.Text = "Tampilkan";
            this.btnTampilDataMataKuliah.UseVisualStyleBackColor = true;
            this.btnTampilDataMataKuliah.Click += new System.EventHandler(this.btnTampilDataMataKuliah_Click);
            // 
            // grpDataSemester
            // 
            this.grpDataSemester.Controls.Add(this.button1);
            this.grpDataSemester.Controls.Add(this.btnTampilDataSemester);
            this.grpDataSemester.Location = new System.Drawing.Point(155, 6);
            this.grpDataSemester.Name = "grpDataSemester";
            this.grpDataSemester.Size = new System.Drawing.Size(137, 113);
            this.grpDataSemester.TabIndex = 1;
            this.grpDataSemester.TabStop = false;
            this.grpDataSemester.Text = "Data Semester";
            // 
            // btnTampilDataSemester
            // 
            this.btnTampilDataSemester.Location = new System.Drawing.Point(11, 28);
            this.btnTampilDataSemester.Name = "btnTampilDataSemester";
            this.btnTampilDataSemester.Size = new System.Drawing.Size(106, 33);
            this.btnTampilDataSemester.TabIndex = 0;
            this.btnTampilDataSemester.Text = "Tampilkan";
            this.btnTampilDataSemester.UseVisualStyleBackColor = true;
            this.btnTampilDataSemester.Click += new System.EventHandler(this.btnTampilDataSemester_Click);
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
            this.lblActiveRelation.Size = new System.Drawing.Size(185, 13);
            this.lblActiveRelation.TabIndex = 2;
            this.lblActiveRelation.Text = "Showing contents for relation : ";
            // 
            // dgvAnyData
            // 
            this.dgvAnyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnyData.Location = new System.Drawing.Point(0, 259);
            this.dgvAnyData.Name = "dgvAnyData";
            this.dgvAnyData.ReadOnly = true;
            this.dgvAnyData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnyData.Size = new System.Drawing.Size(1031, 219);
            this.dgvAnyData.TabIndex = 1;
            // 
            // grpMahasiswa
            // 
            this.grpMahasiswa.Controls.Add(this.btnTambahMahasiswa);
            this.grpMahasiswa.Controls.Add(this.btnTampilMahasiswa);
            this.grpMahasiswa.Location = new System.Drawing.Point(12, 6);
            this.grpMahasiswa.Name = "grpMahasiswa";
            this.grpMahasiswa.Size = new System.Drawing.Size(137, 113);
            this.grpMahasiswa.TabIndex = 0;
            this.grpMahasiswa.TabStop = false;
            this.grpMahasiswa.Text = "Data Mahasiswa";
            // 
            // btnTambahMahasiswa
            // 
            this.btnTambahMahasiswa.Location = new System.Drawing.Point(11, 67);
            this.btnTambahMahasiswa.Name = "btnTambahMahasiswa";
            this.btnTambahMahasiswa.Size = new System.Drawing.Size(106, 33);
            this.btnTambahMahasiswa.TabIndex = 1;
            this.btnTambahMahasiswa.Text = "Tambah";
            this.btnTambahMahasiswa.UseVisualStyleBackColor = true;
            this.btnTambahMahasiswa.Click += new System.EventHandler(this.btnTambahMahasiswa_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Tambah";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 501);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Arsip Nilai";
            this.tabControl1.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.btnTambahSemester.ResumeLayout(false);
            this.btnTambahSemester.PerformLayout();
            this.grpDataNilai.ResumeLayout(false);
            this.grpDataMataKuliah.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage btnTambahSemester;
        private System.Windows.Forms.GroupBox grpMahasiswa;
        private System.Windows.Forms.Button btnTampilMahasiswa;
        private System.Windows.Forms.DataGridView dgvAnyData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActiveRelation;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedRow;
        private System.Windows.Forms.GroupBox grpDataSemester;
        private System.Windows.Forms.Button btnTampilDataSemester;
        private System.Windows.Forms.GroupBox grpDataMataKuliah;
        private System.Windows.Forms.Button btnTampilDataMataKuliah;
        private System.Windows.Forms.GroupBox grpDataNilai;
        private System.Windows.Forms.Button btnTampilDataNilai;
        private System.Windows.Forms.Button btnTambahMahasiswa;
        private System.Windows.Forms.Button button1;
    }
}


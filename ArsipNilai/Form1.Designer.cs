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
            this.grpMahasiswa = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tabManipulation.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(892, 446);
            this.tabControl1.TabIndex = 0;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.btnShowAllData);
            this.tabQuery.Location = new System.Drawing.Point(4, 22);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(579, 229);
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
            this.tabManipulation.Controls.Add(this.grpMahasiswa);
            this.tabManipulation.Location = new System.Drawing.Point(4, 22);
            this.tabManipulation.Name = "tabManipulation";
            this.tabManipulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabManipulation.Size = new System.Drawing.Size(884, 420);
            this.tabManipulation.TabIndex = 1;
            this.tabManipulation.Text = "Data Manipulation";
            this.tabManipulation.UseVisualStyleBackColor = true;
            // 
            // grpMahasiswa
            // 
            this.grpMahasiswa.Location = new System.Drawing.Point(12, 11);
            this.grpMahasiswa.Name = "grpMahasiswa";
            this.grpMahasiswa.Size = new System.Drawing.Size(332, 125);
            this.grpMahasiswa.TabIndex = 0;
            this.grpMahasiswa.TabStop = false;
            this.grpMahasiswa.Text = "Data Mahasiswa";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 447);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Arsip Nilai";
            this.tabControl1.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabManipulation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.Button btnShowAllData;
        private System.Windows.Forms.TabPage tabManipulation;
        private System.Windows.Forms.GroupBox grpMahasiswa;
    }
}


namespace AuthForm
{
    partial class SiswaAdminControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tableUser = new System.Windows.Forms.DataGridView();
            this.Selects = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Siswa - Master Data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableUser
            // 
            this.tableUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selects,
            this.Edit});
            this.tableUser.Location = new System.Drawing.Point(84, 196);
            this.tableUser.Name = "tableUser";
            this.tableUser.RowHeadersVisible = false;
            this.tableUser.RowHeadersWidth = 51;
            this.tableUser.RowTemplate.Height = 24;
            this.tableUser.Size = new System.Drawing.Size(777, 355);
            this.tableUser.TabIndex = 1;
            this.tableUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableUser_CellContentClick_1);
            // 
            // Selects
            // 
            this.Selects.HeaderText = "";
            this.Selects.MinimumWidth = 6;
            this.Selects.Name = "Selects";
            this.Selects.Width = 125;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.HeaderText = "Edit";
            this.Edit.MinimumWidth = 6;
            this.Edit.Name = "Edit";
            // 
            // SiswaAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableUser);
            this.Controls.Add(this.label1);
            this.Name = "SiswaAdminControl";
            this.Size = new System.Drawing.Size(922, 608);
            ((System.ComponentModel.ISupportInitialize)(this.tableUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableUser;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selects;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit;
    }
}

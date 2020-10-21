namespace Session2
{
    partial class FormEMMAdmin
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvRequestList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestList)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(11, 655);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(257, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Manage Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvRequestList
            // 
            this.dgvRequestList.AllowUserToAddRows = false;
            this.dgvRequestList.AllowUserToDeleteRows = false;
            this.dgvRequestList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequestList.Location = new System.Drawing.Point(11, 54);
            this.dgvRequestList.MultiSelect = false;
            this.dgvRequestList.Name = "dgvRequestList";
            this.dgvRequestList.RowHeadersWidth = 51;
            this.dgvRequestList.RowTemplate.Height = 24;
            this.dgvRequestList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequestList.Size = new System.Drawing.Size(1316, 579);
            this.dgvRequestList.TabIndex = 4;
            this.dgvRequestList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRequestList_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "List of Asset Requesting EM:";
            // 
            // FormEMMAdmin
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRequestList);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEMMAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEMMAdmin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClose);
            this.Load += new System.EventHandler(this.FormEMMAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequestList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvRequestList;
        private System.Windows.Forms.Label label1;
    }
}
namespace Session2
{
    partial class FormEMMAccountableParty
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAvailableAsset = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Asset:";
            // 
            // dgvAvailableAsset
            // 
            this.dgvAvailableAsset.AllowUserToAddRows = false;
            this.dgvAvailableAsset.AllowUserToDeleteRows = false;
            this.dgvAvailableAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableAsset.Location = new System.Drawing.Point(12, 55);
            this.dgvAvailableAsset.MultiSelect = false;
            this.dgvAvailableAsset.Name = "dgvAvailableAsset";
            this.dgvAvailableAsset.ReadOnly = true;
            this.dgvAvailableAsset.RowHeadersWidth = 51;
            this.dgvAvailableAsset.RowTemplate.Height = 24;
            this.dgvAvailableAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableAsset.Size = new System.Drawing.Size(1074, 494);
            this.dgvAvailableAsset.TabIndex = 1;
            this.dgvAvailableAsset.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FormEMMAccountabelParty_CellMouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 571);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(373, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Emergency Maintenance Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormEMMAccountableParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 625);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvAvailableAsset);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEMMAccountableParty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emergency Maintenance Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClose);
            this.Load += new System.EventHandler(this.FormEMMAccountableParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableAsset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAvailableAsset;
        private System.Windows.Forms.Button button1;
    }
}
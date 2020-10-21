using System;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class FormEMRequestDetails : Form
    {
        private readonly DateTime reportDate = FormEMMAdmin.reportDate;
        private long partID;

        public FormEMRequestDetails()
        {
            InitializeComponent();

            lblAssetSN.Text = FormEMMAdmin.assetSN;
            lblAssetName.Text = FormEMMAdmin.assetName;
            lblDepartment.Text = FormEMMAdmin.departmentName;
            cmbPartName.DataSource = (from p in Connect.db.Parts
                                      select p.Name).ToList();
        }

        private void FormEMRequestDetails_Load(object sender, EventArgs e)
        {
            DataGridViewLinkColumn links = new DataGridViewLinkColumn();

            links.UseColumnTextForLinkValue = true;
            links.HeaderText = "Action";
            links.Text = "Remove";
            links.LinkBehavior = LinkBehavior.SystemDefault;
            links.LinkColor = Color.Blue;

            dgvReplacement.Columns.Add(links);

            dtpStart.Text = (from a in Connect.db.EmergencyMaintenances
                             where a.ID == FormEMMAdmin.emID
                             select a.EMStartDate).FirstOrDefault().ToString();
        }

        private void btnAddtoList_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount) && string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("Amount is invalid!", "Error");
            }
            else
            {
                try
                {
                    if (decimal.Parse(txtAmount.Text) > 0)
                    {
                        partID = Connect.db.Parts.Where(p => p.Name == cmbPartName.Text).Select(p => p.ID).FirstOrDefault();
                        dgvReplacement.Rows.Add(partID, cmbPartName.Text, txtAmount.Text);
                        txtAmount.Text = "";
                    }
                }
                catch(Exception x)
                {
                    MessageBox.Show("Amount is invalid!", "Error");
                    throw x;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTechnicianNote.Text))
            {
                MessageBox.Show("Technician note can't be empty!", "Error");
            }
            else
            {
                if(reportDate > dtpStart.Value)
                {
                    MessageBox.Show("Start Date can't before Report Date!", "Error");
                }
                else
                {
                    if(dtpEnd.Value < dtpStart.Value)
                    {
                        MessageBox.Show("End Date can't before Start Date!", "Error");
                    }
                    else
                    {
                        try
                        {
                            var em = Connect.db.EmergencyMaintenances.FirstOrDefault(x => x.ID == FormEMMAdmin.emID);
                            em.EMStartDate = dtpStart.Value;
                            em.EMEndDate = dtpEnd.Value;
                            em.EMTechnicianNote = txtTechnicianNote.Text;
                            Connect.db.EmergencyMaintenances.AddOrUpdate(em);
                           
                            for (int i = 0; i < dgvReplacement.Rows.Count - 1; i++)
                            {
                                ChangedPart c = new ChangedPart();
                                c.EmergencyMaintenanceID = em.ID;
                                c.PartID = long.Parse(dgvReplacement.Rows[i].Cells[0].Value.ToString());
                                c.Amount = decimal.Parse(dgvReplacement.Rows[i].Cells[2].Value.ToString());
                                Connect.db.ChangedParts.Add(c);                                
                            }

                            Connect.db.SaveChanges();
                            MessageBox.Show("Update Emergency Maintenance successfully!", "Notify");
                        }
                        catch(Exception x)
                        {
                            MessageBox.Show("Undetected error: " + x.Message.ToString(), "Error");                            
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to quit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close(); 
            }
        }

        private void dgvReplacement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                DialogResult result = MessageBox.Show("Are you sure want to delete this part?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    dgvReplacement.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}

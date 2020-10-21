using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class FormEMRequest : Form
    {
        private readonly string assetSN = FormEMMAccountableParty.assetSN;
        private readonly string assetName = FormEMMAccountableParty.assetName;
        public long assetID;
        private long prioriryID;

        public FormEMRequest()
        {
            InitializeComponent();
        }

        private void FormEMRequest_Load(object sender, EventArgs e)
        {
            lblAssetSN.Text = assetSN;
            lblAssetName.Text = assetName;
            lblDepartment.Text = Connect.db.Assets
                .Where(a => a.AssetSN == FormEMMAccountableParty.assetSN)
                .Select(d => d.DepartmentLocation.Department.Name).FirstOrDefault().ToString();

            cmbPriority.DataSource = (from p in Connect.db.Priorities
                                      select p.Name).ToList();
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            prioriryID = long.Parse(Connect.db.Priorities
                .Where(p => p.Name == cmbPriority.Text.ToString())
                .Select(p => p.ID).FirstOrDefault().ToString());
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDescription.Text) && string.IsNullOrEmpty(txtConsiderations.Text))
            {
                MessageBox.Show("All fields need to be fill!", "Error");
            }
            else
            {
                assetID = long.Parse((from a in Connect.db.Assets 
                                      where a.AssetSN == assetSN 
                                      select a.ID).FirstOrDefault().ToString());

                if (Connect.db.EmergencyMaintenances.Count(x => x.AssetID == assetID && x.EMEndDate != null) == 0)
                {
                    EmergencyMaintenance em = new EmergencyMaintenance();
                    em.AssetID = assetID;
                    em.PriorityID = prioriryID;
                    em.DescriptionEmergency = txtDescription.Text;
                    em.OtherConsiderations = txtConsiderations.Text;
                    em.EMReportDate = DateTime.Now;
                    Connect.db.EmergencyMaintenances.Add(em);
                    Connect.db.SaveChanges();
                    MessageBox.Show("Add Emergency Maintenance request successfully!");
                }
                else
                    MessageBox.Show("Asset is opening request, please try again later!", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to quit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }  
        }
    }
}

using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class FormEMMAccountableParty : Form
    {
        public static string assetSN;
        public static string assetName;

        public FormEMMAccountableParty()
        {
            InitializeComponent();
        }

        private void FormEMMAccountableParty_Load(object sender, EventArgs e)
        {
            dgvAvailableAsset.DataSource = (from a in Connect.db.Assets
                                            join emp in Connect.db.Employees on a.EmployeeID equals emp.ID
                                            join em in Connect.db.EmergencyMaintenances on a.ID equals em.AssetID
                                            where emp.ID == FormLogin.id
                                            select new
                                            {
                                                a.AssetSN,
                                                a.AssetName,
                                                LastClosedEM = em.EMEndDate,
                                                NumberofEMs = em.ChangedParts.Count(x => x.EmergencyMaintenanceID == em.ID)
                                            }).ToList();
            dgvAvailableAsset.Columns[0].HeaderText = "AssetSN";
            dgvAvailableAsset.Columns[1].HeaderText = "Asset Name";
            dgvAvailableAsset.Columns[2].HeaderText = "Last Closed EM";
            dgvAvailableAsset.Columns[3].HeaderText = "Number of EMs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEMRequest form = new FormEMRequest();
            form.ShowDialog();
        }

        private void frmClose(object sender, FormClosedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void FormEMMAccountabelParty_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                assetSN = dgvAvailableAsset.Rows[e.RowIndex].Cells[0].Value.ToString();
                assetName = dgvAvailableAsset.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (assetSN != "")
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }

                if (Convert.ToString(dgvAvailableAsset.Rows[e.RowIndex].Cells[2].Value) == string.Empty)
                {
                    dgvAvailableAsset.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
                }
            }
        }
    }
}

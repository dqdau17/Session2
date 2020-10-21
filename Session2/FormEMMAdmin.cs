using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class FormEMMAdmin : Form
    {
        public static long emID;
        public static string assetSN, assetName, departmentName;
        public static DateTime reportDate;

        public FormEMMAdmin()
        {
            InitializeComponent();
        }

        private void FormEMMAdmin_Load(object sender, EventArgs e)
        {
            dgvRequestList.DataSource = Connect.db.EmergencyMaintenances
                .Where(c => c.EMEndDate == null)
                .Select(c => new
                {
                    c.ID,
                    c.Asset.AssetSN,
                    c.Asset.AssetName,
                    RequestDate = c.EMReportDate,
                    FullName = c.Asset.Employee.FirstName + " " + c.Asset.Employee.LastName,
                    DepartmentName = c.Asset.DepartmentLocation.Department.Name,
                    c.PriorityID
                }).OrderBy(c => c.RequestDate).ThenByDescending(c => c.PriorityID).ToList();
            dgvRequestList.Columns[0].HeaderText = "ID";
            dgvRequestList.Columns[0].Visible = false;
            dgvRequestList.Columns[1].HeaderText = "Asset SN";
            dgvRequestList.Columns[2].HeaderText = "Asset Name";
            dgvRequestList.Columns[3].HeaderText = "Request Date";
            dgvRequestList.Columns[4].HeaderText = "Employee Full Name";
            dgvRequestList.Columns[5].HeaderText = "Department";
            dgvRequestList.Columns[6].HeaderText = "Priority";
            dgvRequestList.Columns[6].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {                   
            if(assetSN != null)
            {
                FormEMRequestDetails form = new FormEMRequestDetails();
                form.ShowDialog();                
            }
            else
                MessageBox.Show("You need to choose 1 request to continue");
        }

        private void frmClose(object sender, FormClosedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void dgvRequestList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                emID = long.Parse(dgvRequestList.Rows[e.RowIndex].Cells[0].Value.ToString());
                assetSN = dgvRequestList.Rows[e.RowIndex].Cells[1].Value.ToString();
                assetName = dgvRequestList.Rows[e.RowIndex].Cells[2].Value.ToString();
                departmentName = dgvRequestList.Rows[e.RowIndex].Cells[5].Value.ToString();
                reportDate = Convert.ToDateTime(dgvRequestList.Rows[e.RowIndex].Cells[3].Value.ToString());
                if (assetSN != "")
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class FormLogin : Form
    {
        public static int type;
        public static long id;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        { 
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                var result = Connect.db.Employees.FirstOrDefault(q => q.Username == txtUsername.Text && q.Password == txtPassword.Text);
                if (result == null)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Your username doesn't exist!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    type = result.isAdmin == true ? 1 : 0;
                    switch (type)
                    {
                        case 0:
                            id = result.ID;
                            FormEMMAccountableParty frmAP = new FormEMMAccountableParty();
                            frmAP.Show();
                            break;
                        case 1:
                            id = result.ID;
                            FormEMMAdmin frmAdmin = new FormEMMAdmin();
                            frmAdmin.Show();
                            break;
                        default:
                            MessageBox.Show("Error!", "Error", MessageBoxButtons.OK);
                            break;
                    }
                    txtUsername.Clear();
                    txtPassword.Clear();
                    Hide();
                }
            }   
            else
            {
                MessageBox.Show("Username or password is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

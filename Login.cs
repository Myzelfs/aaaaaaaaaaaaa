using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txbusername.Text = "Myzelf";
            txbpassword.Text = "plopkoek33";
            lblOutput.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=AH-DB\PASSQL;Initial Catalog=Prj-Ticket2018;Integrated Security=True");
            SqlCommand login = new SqlCommand(@"SELECT username, ID, Level_ID, naam FROM client WHERE username = '" + txbusername.Text + "' AND passw = '" + txbpassword.Text + "'", conn);
            conn.Open();
            SqlDataReader reader = login.ExecuteReader();

            if (reader.HasRows)
            {
                lblOutput.Text = "U bent succesfull ingelogd";
                Hide();
                Homepage Redirect = new Homepage();
                Redirect.ShowDialog();
                conn.Close();
            }
            else
            {
                lblOutput.Text = "Uw inloggegevens zijn fout , probeer opnieuw";
                conn.Close();
                lblOutput.Show();
            }
        }

        private void onchange(object sender, EventArgs e)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class DangNhapSQL : Form
    {
        KetNoi kn = new KetNoi();

        public DangNhapSQL()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        public static SqlConnection connsql;

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                connsql = new SqlConnection(@"Data Source=" + txtServer.Text + "; Initial Catalog=TIEUDUONG;User ID = " + txtID.Text + ";Password=" + txtPass.Text + "");
            }
            else
            {
                connsql = new SqlConnection(@"Data Source=" + txtServer.Text + "; Initial Catalog=TIEUDUONG;Integrated Security=True");
            }
            try
            {
                connsql.Open();
                this.Hide();
                DuDoan duDoan = new DuDoan();
                duDoan.Show();
                connsql.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại là non");
                connsql.Close();
            }
        }
    }
}

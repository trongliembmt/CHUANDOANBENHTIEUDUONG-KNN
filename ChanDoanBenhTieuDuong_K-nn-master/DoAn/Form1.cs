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
    public partial class Form1 : Form
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();

            kn.ketNoiUser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                kn.moKetNoi();
                string commandString;
                if (comboBox1.SelectedItem.ToString() == "Tất cả")
                {
                    commandString = "select * from dbo.tieu_duong";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    commandString = "select * from dbo.tieu_duong where KQ = 'True'";
                }
                else
                {
                    commandString = "select * from dbo.tieu_duong where KQ = 'False'";
                }

                cmd = new SqlCommand(commandString, kn.connsql);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(new[] { rd["LAN_MANG_THAI"].ToString(), rd["NONG_DO_DUONG_HUYET"].ToString(), rd["HUYET_AP_TAM_TRUONG"].ToString(), rd["DO_DAY_NEP_GAP_DA"].ToString(), rd["Insulin_HUYET_THANH"].ToString(), rd["CHI_SO_KHOI_CO_THE"].ToString(), rd["PHA_HE_BENH_TIEU_DUONG"].ToString(), rd["TUOI"].ToString(), rd["KQ"].ToString() });
                    listView1.Items.Add(item);
                }

                rd.Close();

                kn.dongKetNoi();
            }
            catch
            {
                MessageBox.Show("Vui long chon du lieu can loc");
            }
            finally
            {
                kn.dongKetNoi();
            }
        }
    }
}

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
    public partial class DuDoan : Form
    {
        KetNoi kn = new KetNoi();
        SqlCommand cmd;
        TrungDiemTieuDuong TDTrue, TDFalse;
        int demFalse, demTrue;
        public double LanMangThai, NongDoDuongHuyet, HuyetApTamTruong, DoDayNepGapDa, insulin, ChiSoCoThe, PhaHeTieuDuong, Tuoi;
        public bool kq;

        public DuDoan()
        {
            InitializeComponent();

            kn.ketNoiUser();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedItem.ToString() == "Nam")
            {
                txtSoLanMangThai.Text = "0";
                txtSoLanMangThai.Enabled = false;
            }
            else
            {
                txtSoLanMangThai.Text = "";
                txtSoLanMangThai.Enabled = true;
            }
        }

        private void DuDoan_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        bool kiemTraDuLieu()
        {
            if (txtKhoiLuong.Text.Trim().Length == 0 || txtChieuCao.Text.Trim().Length == 0 || txtDoDayNepGapDa.Text.Trim().Length == 0 || txtHuyetApTamTruong.Text.Trim().Length == 0 || txtInsulinHuyetThanh.Text.Trim().Length == 0 || txtNongDoDuongHuyet.Text.Trim().Length == 0 || txtPhaHe.Text.Trim().Length == 0 || txtSoLanMangThai.Text.Trim().Length == 0)
                return false;
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!kiemTraDuLieu())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {
                TDFalse = new TrungDiemTieuDuong();
                TDTrue = new TrungDiemTieuDuong();
                demFalse = 0; demTrue = 0;
                LanMangThai = Convert.ToDouble(txtSoLanMangThai.Text);
                NongDoDuongHuyet = Convert.ToDouble(txtNongDoDuongHuyet.Text);
                HuyetApTamTruong = Convert.ToDouble(txtHuyetApTamTruong.Text);
                DoDayNepGapDa = Convert.ToDouble(txtDoDayNepGapDa.Text);
                insulin = Convert.ToDouble(txtInsulinHuyetThanh.Text);
                ChiSoCoThe = Convert.ToDouble(txtKhoiLuong.Text) / Math.Pow(Convert.ToDouble(txtChieuCao.Text),2);
                PhaHeTieuDuong = Convert.ToDouble(txtPhaHe.Text);
                Tuoi = Convert.ToDouble(DateTime.Now.Year - textBox4.Value.Year);
                bool kq;

                kn.moKetNoi();
                string stringcmd = "select * from dbo.tieu_duong";

                cmd = new SqlCommand(stringcmd, kn.connsql);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if (rd["KQ"].ToString() == "True")
                    {
                        TDTrue.LAN_MANG_THAI += Convert.ToDouble(rd["LAN_MANG_THAI"].ToString());
                        TDTrue.NONG_DO_DUONG_HUYET += Convert.ToDouble(rd["NONG_DO_DUONG_HUYET"].ToString());
                        TDTrue.HUYET_AP_TAM_TRUONG += Convert.ToDouble(rd["HUYET_AP_TAM_TRUONG"].ToString());
                        TDTrue.DO_DAY_NEP_GAP_DA += Convert.ToDouble(rd["DO_DAY_NEP_GAP_DA"].ToString());
                        TDTrue.Insulin_HUYET_THANH += Convert.ToDouble(rd["Insulin_HUYET_THANH"].ToString());
                        TDTrue.CHI_SO_KHOI_CO_THE += Convert.ToDouble(rd["CHI_SO_KHOI_CO_THE"].ToString());
                        TDTrue.PHA_HE_BENH_TIEU_DUONG += Convert.ToDouble(rd["PHA_HE_BENH_TIEU_DUONG"].ToString());
                        TDTrue.TUOI += Convert.ToDouble(rd["TUOI"].ToString());
                        demTrue++;
                    }
                    else
                    {
                        TDFalse.LAN_MANG_THAI += Convert.ToDouble(rd["LAN_MANG_THAI"].ToString());
                        TDFalse.NONG_DO_DUONG_HUYET += Convert.ToDouble(rd["NONG_DO_DUONG_HUYET"].ToString());
                        TDFalse.HUYET_AP_TAM_TRUONG += Convert.ToDouble(rd["HUYET_AP_TAM_TRUONG"].ToString());
                        TDFalse.DO_DAY_NEP_GAP_DA += Convert.ToDouble(rd["DO_DAY_NEP_GAP_DA"].ToString());
                        TDFalse.Insulin_HUYET_THANH += Convert.ToDouble(rd["Insulin_HUYET_THANH"].ToString());
                        TDFalse.CHI_SO_KHOI_CO_THE += Convert.ToDouble(rd["CHI_SO_KHOI_CO_THE"].ToString());
                        TDFalse.PHA_HE_BENH_TIEU_DUONG += Convert.ToDouble(rd["PHA_HE_BENH_TIEU_DUONG"].ToString());
                        TDFalse.TUOI += Convert.ToDouble(rd["TUOI"].ToString());
                        demFalse++;
                    }
                }
                rd.Close();


                TDTrue.LAN_MANG_THAI = TDTrue.LAN_MANG_THAI / demTrue;
                TDTrue.NONG_DO_DUONG_HUYET = TDTrue.NONG_DO_DUONG_HUYET / demTrue;
                TDTrue.HUYET_AP_TAM_TRUONG = TDTrue.HUYET_AP_TAM_TRUONG / demTrue;
                TDTrue.DO_DAY_NEP_GAP_DA = TDTrue.DO_DAY_NEP_GAP_DA / demTrue;
                TDTrue.Insulin_HUYET_THANH = TDTrue.Insulin_HUYET_THANH / demTrue;
                TDTrue.CHI_SO_KHOI_CO_THE = TDTrue.CHI_SO_KHOI_CO_THE / demTrue;
                TDTrue.PHA_HE_BENH_TIEU_DUONG = TDTrue.PHA_HE_BENH_TIEU_DUONG / demTrue;
                TDTrue.TUOI = TDTrue.TUOI / demTrue;

                TDFalse.LAN_MANG_THAI = TDFalse.LAN_MANG_THAI / demFalse;
                TDFalse.NONG_DO_DUONG_HUYET = TDFalse.NONG_DO_DUONG_HUYET / demFalse;
                TDFalse.HUYET_AP_TAM_TRUONG = TDFalse.HUYET_AP_TAM_TRUONG / demFalse;
                TDFalse.DO_DAY_NEP_GAP_DA = TDFalse.DO_DAY_NEP_GAP_DA / demFalse;
                TDFalse.Insulin_HUYET_THANH = TDFalse.Insulin_HUYET_THANH / demFalse;
                TDFalse.CHI_SO_KHOI_CO_THE = TDFalse.CHI_SO_KHOI_CO_THE / demFalse;
                TDFalse.PHA_HE_BENH_TIEU_DUONG = TDFalse.PHA_HE_BENH_TIEU_DUONG / demFalse;
                TDFalse.TUOI = TDFalse.TUOI / demFalse;

                double kcTrue, kcFalse;
                kcTrue = Math.Sqrt((Math.Pow(LanMangThai - TDTrue.LAN_MANG_THAI, 2)) + 
                    (Math.Pow(NongDoDuongHuyet - TDTrue.NONG_DO_DUONG_HUYET, 2)) + 
                    (Math.Pow(HuyetApTamTruong - TDTrue.HUYET_AP_TAM_TRUONG, 2)) + 
                    (Math.Pow(DoDayNepGapDa - TDTrue.DO_DAY_NEP_GAP_DA, 2)) + 
                    (Math.Pow(insulin - TDTrue.Insulin_HUYET_THANH, 2)) + 
                    (Math.Pow(ChiSoCoThe - TDTrue.CHI_SO_KHOI_CO_THE, 2)) + 
                    (Math.Pow(Tuoi - TDTrue.TUOI, 2)));

                kcFalse = Math.Sqrt((Math.Pow(LanMangThai - TDFalse.LAN_MANG_THAI, 2)) + 
                    (Math.Pow(NongDoDuongHuyet - TDFalse.NONG_DO_DUONG_HUYET, 2)) +
                    (Math.Pow(HuyetApTamTruong - TDFalse.HUYET_AP_TAM_TRUONG, 2)) + 
                    (Math.Pow(DoDayNepGapDa - TDFalse.DO_DAY_NEP_GAP_DA, 2)) + 
                    (Math.Pow(insulin - TDFalse.Insulin_HUYET_THANH, 2)) + 
                    (Math.Pow(ChiSoCoThe - TDFalse.CHI_SO_KHOI_CO_THE, 2)) + 
                    (Math.Pow(Tuoi - TDFalse.TUOI, 2)));

                Console.WriteLine("kcTrue: " + kcTrue.ToString());
                Console.WriteLine("kcFalse: " + kcFalse.ToString());
                if (kcTrue <= kcFalse)
                {
                    kq = true;
                }
                else
                {
                    kq = false;
                }

                string insertString = "insert into tieu_duong values (" + Convert.ToInt32(LanMangThai) + "," + NongDoDuongHuyet + "," + HuyetApTamTruong + "," + DoDayNepGapDa + "," + insulin + "," + ChiSoCoThe + "," + PhaHeTieuDuong + "," + Convert.ToInt32(Tuoi) + ",'" + kq + "')";
                cmd = new SqlCommand(insertString, kn.connsql);
                cmd.ExecuteNonQuery();


                kn.dongKetNoi();

                VanBan frm = new VanBan(textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text, textBox4.Value.ToString(), LanMangThai, NongDoDuongHuyet, DoDayNepGapDa, insulin, PhaHeTieuDuong, HuyetApTamTruong, ChiSoCoThe, kq);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại là non");

            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //giới hạn số được nhập
            textBox2.MaxLength = 12; ;//nhập được 4 số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSoLanMangThai_KeyPress(object sender, KeyPressEventArgs e)
        {
            //này không cần dấu phẩy
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNongDoDuongHuyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            //giới hạn số được nhập
            //txtNongDoDuongHuyet.MaxLength = 4;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // cho phép có dấu phẩy 1 lần
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDoDayNepGapDa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // cho phép có dấu phẩy 1 lần
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtInsulinHuyetThanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // cho phép có dấu phẩy 1 lần
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtChiSoCoThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // cho phép có dấu phẩy 1 lần
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPhaHe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // cho phép có dấu phẩy 1 lần
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fmnew = new Form1();
            

            fmnew.Show();

   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtChieuCao.Clear();
            txtDoDayNepGapDa.Clear();
            txtHuyetApTamTruong.Clear();
            txtInsulinHuyetThanh.Clear();
            txtKhoiLuong.Clear();
            txtNongDoDuongHuyet.Clear();
            txtPhaHe.Clear();
            txtSoLanMangThai.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Value = DateTime.Today;
            comboBox1.Text = "";
        }
    }
}

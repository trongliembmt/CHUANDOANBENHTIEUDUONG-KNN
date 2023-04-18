using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class VanBan : Form
    {

        public VanBan()
        {
            InitializeComponent();
        }

        public VanBan(string hoTen, string gioiTinh, string sdt, string noio, string namsinh, double lanMangThai, double duongHuyet, double nepGapDa, double Insulin, double phaHe, double huyetAp, double chiSoCoThe, bool kq)
            : this()
        {
            lbHoTen.Text = hoTen;
            if (gioiTinh == "Nam")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            lbSDT.Text = sdt;
            lbNoiO.Text = noio;
            lbNamSinh.Text = namsinh;
            lbSoLanMangThai.Text = lanMangThai.ToString();
            lbDuongHuyet.Text = duongHuyet.ToString();
            lbDoDayGapDa.Text = nepGapDa.ToString();
            lbChiSoCoThe.Text = chiSoCoThe.ToString();
            lbInsulin.Text = Insulin.ToString();
            lbPhaHe.Text = phaHe.ToString();
            lbHuyetAp.Text = huyetAp.ToString();
            if (kq == true)
                lbKQ.Text = "Kết quả chẩn đoán cho thấy bạn đã bị bệnh tiểu đường!";
            else
                lbKQ.Text = "Kết quả chẩn đoán cho thấy bạn không bị bệnh tiểu đường!";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}

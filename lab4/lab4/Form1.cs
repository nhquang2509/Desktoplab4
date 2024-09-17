using Lab_4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;

            sv.MaSo = this.txtMSSV.Text;
            sv.HoTen = this.txtTen.Text;
            if (rdbNu.Checked)
                gt = false;
            sv.GioiTinh = gt;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbLop.Text;
            sv.DienThoai = this.txtSdt.Text;
            sv.Email = this.txtEmail.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Hinh = this.txtHinh.Text;

            return sv;
        }
        //Lấy thông tin sinh viên từ dòng item của ListView
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[2].Text == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.DienThoai = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DienThoai = lvitem.SubItems[7].Text;
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }
        //Thiết lập các thông tin lên controls sinh viên
        private void ThietLapThongTin(SinhVien sv)
        {
            this.txtMSSV.Text = sv.MaSo;
            this.txtTen.Text = sv.HoTen;
            if (sv.GioiTinh)
                this.rdbNam.Checked = true;
            else
                this.rdbNu.Checked = true;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbLop.Text = sv.Lop;
            this.txtSdt.Text = sv.DienThoai;
            this.txtEmail.Text = sv.Email;
            this.txtDiaChi.Text = sv.DiaChi;
            this.txtHinh.Text = sv.Hinh;
            this.ptbHinh.ImageLocation = sv.Hinh;
        }

        //Thêm sinh viên vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.DienThoai);
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);

            lvitem.SubItems.Add(sv.Hinh);
            this.lvSinhVien.Items.Add(lvitem);

        }
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();

            foreach (SinhVien sv in qlsv.DanhSach)
            {
                ThemSV(sv);
            }

        }

        #region Các sự kiện
        //sự kiện Load form
        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }

        #endregion
    }
}

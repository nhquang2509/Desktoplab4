using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class SinhVien
    {
        //Các thuộc tính của lớp sinh viên
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public string Hinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DienThoai { get; set; }

        public SinhVien()
        {
        }
        //Phương thức tạo lập có tham số
        public SinhVien(string ms, string ht, bool gt, DateTime ngay,
         string lop, string sdt, string email, string dc, string hinh)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.GioiTinh = gt;
            this.NgaySinh = ngay;
            this.Lop = lop;
            this.DienThoai = sdt;
            this.Email = email;
            this.DiaChi = dc;
            this.Hinh = hinh;

        }
    }
}

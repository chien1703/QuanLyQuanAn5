using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string taiKhoanDung = "dta"; // Thay thế bằng tài khoản đúng
            string matKhauDung = "1";    // Thay thế bằng mật khẩu đúng

            string nhapTaiKhoan = tbtaikhoan.Text;
            string nhapMatKhau = tbmatkhau.Text;

            if (nhapTaiKhoan == taiKhoanDung && nhapMatKhau == matKhauDung)
            {
                // Tài khoản và mật khẩu đúng, mở form mới
                fhome f = new fhome();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                // Tài khoản hoặc mật khẩu sai, hiển thị thông báo
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có thật sự muốn thoát chương trình ?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}

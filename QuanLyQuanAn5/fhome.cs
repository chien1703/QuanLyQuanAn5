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
using System.Diagnostics;

namespace QuanLyQuanAn5
{
    public partial class fhome : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-DFVUFD44;Initial Catalog=QuanLyQuanAn5;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from monan ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }
        void loaddata1()
        {
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from ban ";
            adapter1.SelectCommand = command;
            table1.Clear();
            adapter1.Fill(table1);
            dgv2.DataSource = table1;
        }
        void loaddata2()
        {
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable table2 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from nhanvien ";
            adapter2.SelectCommand = command;
            table2.Clear();
            adapter2.Fill(table2);
            dgv3.DataSource = table2;
        }
        void loaddata3()
        {
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            DataTable table3 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon1";
            adapter3.SelectCommand = command;
            table3.Clear();
            adapter3.Fill(table3);
            dgv4.DataSource = table3;
        }
        void loaddata4()
        {
            SqlDataAdapter adapter4 = new SqlDataAdapter();
            DataTable table4 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from donhang";
            adapter4.SelectCommand = command;
            table4.Clear();
            adapter4.Fill(table4);
            dgv.DataSource = table4;
        }
        void loaddata5()
        {
            SqlDataAdapter adapter5 = new SqlDataAdapter();
            DataTable table5 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from monan";
            adapter5.SelectCommand = command;
            table5.Clear();
            adapter5.Fill(table5);
            dgv5.DataSource = table5;
        }
        void loaddata6()
        {
            SqlDataAdapter adapter6 = new SqlDataAdapter();
            DataTable table6 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon2";
            adapter6.SelectCommand = command;
            table6.Clear();
            adapter6.Fill(table6);
            dgv4.DataSource = table6;
        }
        void loaddata7()
        {
            SqlDataAdapter adapter7 = new SqlDataAdapter();
            DataTable table7 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon3";
            adapter7.SelectCommand = command;
            table7.Clear();
            adapter7.Fill(table7);
            dgv4.DataSource = table7;
        }
        void loaddata8()
        {
            SqlDataAdapter adapter8 = new SqlDataAdapter();
            DataTable table8 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon4";
            adapter8.SelectCommand = command;
            table8.Clear();
            adapter8.Fill(table8);
            dgv4.DataSource = table8;
        }
        void loaddata9()
        {
            SqlDataAdapter adapter9 = new SqlDataAdapter();
            DataTable table9 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon5";
            adapter9.SelectCommand = command;
            table9.Clear();
            adapter9.Fill(table9);
            dgv4.DataSource = table9;
        }
        void loaddata10()
        {
            SqlDataAdapter adapter10 = new SqlDataAdapter();
            DataTable table10 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select * from hoadon6";
            adapter10.SelectCommand = command;
            table10.Clear();
            adapter10.Fill(table10);
            dgv4.DataSource = table10;
        }
        public fhome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnhome_Click(object sender, EventArgs e)
        {
        
            tabControl1.SelectedTab = tabPage1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void fhome_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            loaddata1();
            loaddata2();
            loaddata4();
            loaddata5();
        }
        private int GetPriceByItemID(string itemID)
        {
         

            command = connection.CreateCommand();
            command.CommandText = "SELECT Gia FROM monan WHERE MaMonAn= @mamonan";
            command.Parameters.AddWithValue("@mamonan", itemID);

            int price = (int)command.ExecuteScalar();

       
            return price;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {

                int price = GetPriceByItemID(tbmamon.Text);
                tbthanhtien.Text = price.ToString();
                command = connection.CreateCommand();
                command.CommandText = "Insert into donhang values(@madon, @mabill, @mamonan, @soluong, @thanhtien, @trangthai)";
                command.Parameters.AddWithValue("@madon", tbmadon.Text);
                command.Parameters.AddWithValue("@mabill", tbmabill.Text);
                command.Parameters.AddWithValue("@mamonan", tbmamon.Text);
                command.Parameters.AddWithValue("@soluong", tbsoluong.Text);
                command.Parameters.AddWithValue("@thanhtien", price );
                command.Parameters.AddWithValue("@trangthai", tbtrangthai.Text);
                command.ExecuteNonQuery();
                loaddata4();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from donhang where MaDon = @madon";
            command.Parameters.AddWithValue("@madon", tbmadon.Text);
            command.ExecuteNonQuery();
            loaddata4();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv.CurrentRow.Index;
            tbmadon.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tbmabill.Text = dgv.Rows[i].Cells[1].Value.ToString();
            tbmamon.Text = dgv.Rows[i].Cells[2].Value.ToString();
            tbsoluong.Text = dgv.Rows[i].Cells[3].Value.ToString();
            tbthanhtien.Text = dgv.Rows[i].Cells[4].Value.ToString();
            tbtrangthai.Text = dgv.Rows[i].Cells[5].Value.ToString();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv.CurrentRow.Index;
            tbmadon.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tbmabill.Text = dgv.Rows[i].Cells[1].Value.ToString();
            tbmamon.Text = dgv.Rows[i].Cells[2].Value.ToString();
            tbsoluong.Text = dgv.Rows[i].Cells[3].Value.ToString();
            tbthanhtien.Text = dgv.Rows[i].Cells[4].Value.ToString();
            tbtrangthai.Text = dgv.Rows[i].Cells[5].Value.ToString();
        }
        string currentTableType;
        private void btnban1_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon1";
            loaddata3();
            UpdateTotalPrice();
        }

        private void btnban2_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon2";
            loaddata6();
            UpdateTotalPrice();
        }

        private void btnthem1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void dgv5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv5.CurrentRow.Index;
            string MaMonAn0= dgv5.Rows[i].Cells[0].Value.ToString();
            string Gia0= dgv5.Rows[i].Cells[2].Value.ToString();
            int Gia1;
            int.TryParse(Gia0, out Gia1);


            if (currentTableType == "hoadon1")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon1 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata3();
                UpdateTotalPrice();
            }
            else if (currentTableType == "hoadon2")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon2 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata6();
                UpdateTotalPrice();
            }
            else if (currentTableType == "hoadon3")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon3 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata7();
                UpdateTotalPrice();
            }
            else if (currentTableType == "hoadon4")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon4 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata8();
                UpdateTotalPrice();
            }
            else if (currentTableType == "hoadon5")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon5 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata9();
                UpdateTotalPrice();
            }
            else if (currentTableType == "hoadon6")
            {
                command = connection.CreateCommand();
                command.CommandText = "Insert into hoadon6 values(@mamonan, @gia )";
                command.Parameters.AddWithValue("@mamonan", MaMonAn0);
                command.Parameters.AddWithValue("@gia", Gia1);
                command.ExecuteNonQuery();
                loaddata10();
                UpdateTotalPrice();
            }


        }

        private void dgv4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv4.CurrentRow.Index;
        }

        private void btnxoa1_Click(object sender, EventArgs e)
        {
            if (currentTableType == "hoadon1")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon1\r\nWHERE id = (SELECT TOP 1 id FROM hoadon1 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata3();
            }
            else if (currentTableType == "hoadon2")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon2\r\nWHERE id = (SELECT TOP 1 id FROM hoadon2 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata6();
            }
            else if (currentTableType == "hoadon3")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon3\r\nWHERE id = (SELECT TOP 1 id FROM hoadon3 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata7();
            }
            else if (currentTableType == "hoadon4")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon4\r\nWHERE id = (SELECT TOP 1 id FROM hoadon4 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata8();
            }
            else if (currentTableType == "hoadon5")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon5\r\nWHERE id = (SELECT TOP 1 id FROM hoadon5 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata9();
            }
            else if (currentTableType == "hoadon6")
            {
                command = connection.CreateCommand();
                command.CommandText = "DELETE FROM hoadon6\r\nWHERE id = (SELECT TOP 1 id FROM hoadon6 ORDER BY id DESC)";
                command.ExecuteNonQuery();
                loaddata10();
            }

            UpdateTotalPrice();



        }

        private void btnban3_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon3";
            loaddata7();
            UpdateTotalPrice();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into monan values(@mamonan,@tenmonan, @gia )";
            command.Parameters.AddWithValue("@mamonan", tbmamonan.Text);
            command.Parameters.AddWithValue("@tenmonan",tbtenmon.Text );
            command.Parameters.AddWithValue("@gia", tbgiamon.Text);
            command.ExecuteNonQuery();
            loaddata();
            loaddata5();
        }

        private void btnsuamon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update monan set MaMonAn= @mamonan,TenMonAn=@tenmonan,Gia= @gia where MaMonAn= @mamonan";
            command.Parameters.AddWithValue("@mamonan", tbmamonan.Text);
            command.Parameters.AddWithValue("@tenmonan", tbtenmon.Text);
            command.Parameters.AddWithValue("@gia", tbgiamon.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnxoamon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from monan where MaMonAn = @mamonan";
            command.Parameters.AddWithValue("@mamonan", tbmamonan.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dgv1.CurrentRow.Index;
            tbmamonan.Text = dgv1.Rows[i].Cells[0].Value.ToString();
            tbtenmon.Text = dgv1.Rows[i].Cells[1].Value.ToString();
            tbgiamon.Text = dgv1.Rows[i].Cells[2].Value.ToString();
        }

        private void btntimkiemmon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from monan where TenMonAn like '%" + tbtimkiemmon.Text + "%' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }

        private void btnhienthimon_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void tbtimkiemmon_TextChanged(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from monan where TenMonAn like '%" + tbtimkiemmon.Text + "%' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv1.DataSource = table;
        }
        private int CalculateTotalPrice()
        {
            int totalPrice = 0; // Khởi tạo giá trị mặc định

            if (currentTableType == "hoadon1")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon1";
            }
            else if (currentTableType == "hoadon2")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon2";
            }
            else if (currentTableType == "hoadon3")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon3";
            }
            else if (currentTableType == "hoadon4")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon4";
            }
            else if (currentTableType == "hoadon5")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon5";
            }
            else if (currentTableType == "hoadon6")
            {
                command = connection.CreateCommand();
                command.CommandText = "SELECT SUM(ISNULL(Gia, 0)) FROM hoadon6";
            }
            else
            {
                return totalPrice; // Trả về giá trị mặc định nếu không phải các loại trên
            }

            // ExecuteScalar returns null if there are no records or the result is null
            object result = command.ExecuteScalar();

            // If the result is not null, parse the result
            if (result != null && result != DBNull.Value)
            {
                totalPrice = Convert.ToInt32(result);
            }

            return totalPrice;


        }
        private void UpdateTotalPrice()
        {
            int totalPrice = CalculateTotalPrice();
            tbtongtien.Text = totalPrice.ToString();
        }

        private void btnban4_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon4";
            loaddata8();
            UpdateTotalPrice();
        }

        private void btnban5_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon5";
            loaddata9();
            UpdateTotalPrice();
        }

        private void btnban6_Click(object sender, EventArgs e)
        {
            currentTableType = "hoadon6";
            loaddata10();
            UpdateTotalPrice();
        }
    }
}

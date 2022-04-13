using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNS
{
    public partial class frmDangKy : Form
    {
        Clsdatabase cls = new Clsdatabase();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " MM / dd / yyyy ";
            cls.loaddatagridview(dataGridView1, "select * from tbuser");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public void Resetvalues()
        {
            foreach (Control ctr in this.groupBox1.Controls)
            {
                if ((ctr is TextBox) || (ctr is DateTimePicker) || (ctr is ComboBox))
                {
                    ctr.Text = "";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "MM/dd/yyyy";
                string insert = "insert into tbuser values(N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox4.Text + "',N'" + textBox3.Text + "','" + dateTimePicker1.Text + "')";
                if (cls.kttrungkhoa(textBox1.Text, "select * from tbuser") == true)
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Bạn có thể thử tên khác");
                //else if (textBox1.Text.Trim() == "Admin")
                //{
                //    MessageBox.Show("Không thể doi người dùng này");
                //}    
                else
                {
                    cls.thucthiketnoi(insert);
                    MessageBox.Show("Chúc mừng bạn đã đăng kí thành công");
                    cls.loaddatagridview(dataGridView1, "select * from tbuser");
                  
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // chưa sửa không cho đổi mật khẩu
                string update = "update tbuser set Username=N'" + textBox1.Text + "',Pass=N'" + textBox2.Text + "',Quyen=N'" + textBox4.Text + "',Ten=N'" + textBox3.Text + "',Ngaysinh='" + dateTimePicker1.Text + "' where Username='" + textBox1.Text + "'";
                cls.thucthiketnoi(update);
                cls.loaddatagridview(dataGridView1, "select * from tbuser");
                MessageBox.Show("Sửa thành công");
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string delete = "delete from tbuser where Username=N'" + textBox1.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(dataGridView1, "select * from tbuser");
            }
            MessageBox.Show("Đã xóa dữ liệu ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                textBox1.Text = dataGridView1.Rows[hang].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[hang].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[hang].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[hang].Cells[2].Value.ToString();


                dateTimePicker1.Text = dataGridView1.Rows[hang].Cells[4].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("");
            }
        }
    }
}

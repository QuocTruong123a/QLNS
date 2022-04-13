 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace QLNS
{
    public partial class frmdangnhap : Form
    {
        Clsdatabase cls = new Clsdatabase();
        private SqlConnection Con = null;
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    ////MessageBox.Show( cls.thu(textBox2.Text, "select pass from tbuser").ToString());
        //    if ((cls.kt(textBox1.Text, "select * from tbuser", 0) == true) && (cls.kt(textBox2.Text, "select * from tbuser", 1) == true))
        //    {
        //        //string sql = "select Quyen from tbuser ";
        //        //if (cls.kt("Admin", "select * from tbuser", 2) == true)
        //        //{

        //            this.Hide();
        //            //Global.frmmain.k = 4;
        //            //Global.frmmain.Refresh();
        //            //Global.frmmain.truyen();

        //            //Global.frmmain.ShowDialog();
        //            MessageBox.Show("Bạn đã đăng nhập thành công");
        //            FrmMain.quyen = "Admin";

        //            this.Hide();
        //            FrmMain fm = new FrmMain();
        //            //fm.k = 4;
        //            fm.truyen();
        //            MessageBox.Show("Bạn đã đăng nhập thành công quyen admin");
        //            fm.ShowDialog();
        //            this.Close();
        //        }
                //else //if (sql == "Client")
                //{
                // t thuwr roi k dc
                //FrmMain.quyen = "Member";
                //this.Hide();
                //FrmMain fm = new FrmMain();
                ////fm.k = 5;
                //fm.truyen();
                //MessageBox.Show("Bạn đã đăng nhập thành công quyền user");
                //fm.ShowDialog();
                //sửa đi
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=LAPTOP-IOOVFC6V;Initial Catalog=QLNS;Integrated Security=True";
            Con.Open();
            string select = "Select * From tbuser where Username='" + textBox1.Text + "' and Pass='" + textBox2.Text + "' and Quyen='Admin'";
            SqlCommand cmd = new SqlCommand(select, Con);
            SqlDataReader reader = cmd.ExecuteReader();
         
                if (textBox1.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa nhập tên đăng nhâp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                return;
                }
                if (textBox2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                      return;
            }

                if (reader.Read())
                {
                    reader.Read();
                    MessageBox.Show("Đăng nhập vào hệ thống (Quyền Admin) !", "Thông báo !");
                    FrmMain.quyen = "Admin";
                    this.Hide();

                FrmMain frm = new FrmMain();
                frm.ShowDialog();
                cmd.Dispose();
                reader.Close();
                reader.Dispose();
            }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khâu không đúng !");
                     textBox1.Focus();
                return;
                }          
            }

        }

               // else MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        
//    }
//}

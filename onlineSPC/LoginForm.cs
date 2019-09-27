using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;

namespace onlineSPC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();
        RegexClass regexclass = new RegexClass();
        public bool Form_OK = false;
        public string name;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                SQL_Class.getcon();       //连接数据库
            }
            catch
            {
                //当连接数据库失败时，显示错误信息
                MessageBox.Show("数据库连接失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();       //关闭整个工程
            }
        }

        private void txt_username_Enter(object sender, EventArgs e)
        {
            if (txt_username.Text == "请输入用户名")
            {
                txt_username.Text = "";
                txt_username.ForeColor = Color.Black;
            }
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                txt_username.Text = "请输入用户名";
                txt_username.ForeColor = Color.Gray;
            }
            else
            {
                txt_username.ForeColor = Color.Black;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == "请输入密码")
            {
                txt_password.PasswordChar = '*';
                txt_password.Text = "";
                txt_password.ForeColor = Color.Black;
            }
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            if (txt_password.Text == "" || txt_password.Text == "请输入密码")
            {
                txt_password.PasswordChar = Convert.ToChar(0);
                txt_password.Text = "请输入密码";
                txt_password.ForeColor = Color.Gray;
            }
            else
            {
                txt_password.ForeColor = Color.Black;
            }
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            lab_message.Text = "正在尝试登陆，请稍后......";
            if (regexclass.IsNumAndEnCh(txt_username.Text) && txt_username.Text != "请输入用户名")
            {
                if (txt_password.Text != "请输入密码")
                {
                    if (txt_username.Text != null && txt_password.Text != null)
                    {
                        DataSet DSet = SQLClass.getDataSet("select admin_name,admin_username,admin_password from admin where admin_username = '" + txt_username.Text.Trim() + "' and admin_password = '" + txt_password.Text.Trim() + "'", "员工信息表");
                        DataTable dt = DSet.Tables["员工信息表"];
                        if (dt.Rows.Count > 0)
                        {
                            Form_OK = true;
                            name = dt.Rows[0][0].ToString();
                            lab_message.Text = "登陆成功！";
                            lab_message.ForeColor = Color.Black;
                            MessageBox.Show(dt.Rows[0][0] + "，欢迎回来！！", "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            lab_message.Text = "用户名或密码不正确！";
                        }

                    }
                    else
                    {
                        lab_message.Text = "请检查您的用户名是否正确。";
                    }
                }
                else
                {
                    lab_message.Text = "请输入正确的密码。";
                }
            }
            else
            {
                lab_message.Text = "请输入正确的用户名。";
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

        }
    }
}

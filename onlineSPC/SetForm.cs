using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace onlineSPC
{
    public partial class SetForm : Form
    {
        public SetForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();

        private void SetForm_Load(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select v_vid,v_static,v_text from v", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if(dt.Rows.Count >= 8)
            {
                checkBox1.Tag = dt.Rows[0][0].ToString();
                if(dt.Rows[0][1].ToString() == "true")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                checkBox1.Text = dt.Rows[0][2].ToString();

                checkBox2.Tag = dt.Rows[1][0].ToString();
                if (dt.Rows[1][1].ToString() == "true")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                checkBox2.Text = dt.Rows[1][2].ToString();

                checkBox3.Tag = dt.Rows[2][0].ToString();
                if (dt.Rows[2][1].ToString() == "true")
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                checkBox3.Text = dt.Rows[2][2].ToString();

                checkBox4.Tag = dt.Rows[3][0].ToString();
                if (dt.Rows[3][1].ToString() == "true")
                {
                    checkBox4.Checked = true;
                }
                else
                {
                    checkBox4.Checked = false;
                }
                checkBox4.Text = dt.Rows[3][2].ToString();

                checkBox5.Tag = dt.Rows[4][0].ToString();
                if (dt.Rows[4][1].ToString() == "true")
                {
                    checkBox5.Checked = true;
                }
                else
                {
                    checkBox5.Checked = false;
                }
                checkBox5.Text = dt.Rows[4][2].ToString();

                checkBox6.Tag = dt.Rows[5][0].ToString();
                if (dt.Rows[5][1].ToString() == "true")
                {
                    checkBox6.Checked = true;
                }
                else
                {
                    checkBox6.Checked = false;
                }
                checkBox6.Text = dt.Rows[5][2].ToString();

                checkBox7.Tag = dt.Rows[6][0].ToString();
                if (dt.Rows[6][1].ToString() == "true")
                {
                    checkBox7.Checked = true;
                }
                else
                {
                    checkBox7.Checked = false;
                }
                checkBox7.Text = dt.Rows[6][2].ToString();

                checkBox8.Tag = dt.Rows[7][0].ToString();
                if (dt.Rows[7][1].ToString() == "true")
                {
                    checkBox8.Checked = true;
                }
                else
                {
                    checkBox8.Checked = false;
                }
                checkBox8.Text = dt.Rows[7][2].ToString();
            }
            else
            {
                MessageBox.Show("八大判异规则数据库数据不齐全！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            upDate(checkBox1);
            upDate(checkBox2);
            upDate(checkBox3);
            upDate(checkBox4);
            upDate(checkBox5);
            upDate(checkBox6);
            upDate(checkBox7);
            upDate(checkBox8);

            this.Close();
        }

        private void upDate(CheckBox checkbox)
        {
            if (checkbox.Checked)
            {
                SQLClass.getsqlcom("update v set v_static = 'true' where v_vid = '" + checkbox.Tag + "'");
            }
            else
            {
                SQLClass.getsqlcom("update v set v_static = 'false' where v_vid = '" + checkbox.Tag + "'");
            }
        }

    }
}

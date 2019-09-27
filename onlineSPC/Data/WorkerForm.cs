using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace onlineSPC.Data
{
    public partial class WorkerForm : Form
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        public void checkForm()
        {
            if (txt_worker_name.Text != "" && txt_worker_num.Text != "")
            {
                txt_worker_name.Tag = "1";
                txt_worker_num.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_worker_name.Tag = "0";
                txt_worker_num.Tag = "0";
                lab_message.Text = "员工姓名、工号不能为空！";
            }
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            if (Form_Type != 0)
            {
                DataSet DSet = SQLClass.getDataSet("select worker_id,worker_name,worker_num from worker where worker_id = '" + data_id + "'", "数据库信息表");
                DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
                if (dt.Rows.Count > 0)
                {
                    txt_worker_name.Text = dt.Rows[0][1].ToString();
                    txt_worker_name.Tag = "1";
                    txt_worker_num.Text = dt.Rows[0][2].ToString();
                    txt_worker_num.Tag = "1";
                }
                else
                {
                    MessageBox.Show("查询不到数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    txt_worker_name.ReadOnly = true;
                    txt_worker_num.ReadOnly = true;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_worker_name_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void txt_worker_num_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_worker_name.Tag) == "1" && Convert.ToString(txt_worker_num.Tag) == "1")
            {
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into worker values ('" + txt_worker_name.Text.ToString().Trim() + "','" + txt_worker_num.Text.ToString().Trim() + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update worker set worker_name = '" + txt_worker_name.Text.ToString().Trim() + "', worker_num = '" + txt_worker_num.Text.ToString().Trim() + "' where worker_id = '" + data_id + "'");
                        break;
                    case 2:
                        break;
                }
                Form_OK = 1;
                this.Close();
            }
            else
            {

            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_worker_name.Text = "";
            txt_worker_name.Tag = "0";
            txt_worker_num.Text = "";
            txt_worker_num.Tag = "0";
            checkForm();
        }

    }
}

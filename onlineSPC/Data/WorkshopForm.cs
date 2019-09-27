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
    public partial class WorkshopForm : Form
    {
        public WorkshopForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        public void checkForm()
        {
            if (txt_workshop_name.Text != "")
            {
                txt_workshop_name.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_workshop_name.Tag = "0";
                lab_message.Text = "车间名称不能为空！";
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_workshop_name.Text = "";
            txt_workshop_name.Tag = "0";
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_workshop_name.Tag) == "1")
            {
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into workshop values ('" + txt_workshop_name.Text.ToString().Trim() + "','" + cBox_workshop_worker.Tag.ToString() + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update workshop set workshop_name = '" + txt_workshop_name.Text.ToString().Trim() + "', workshop_worker = '" + cBox_workshop_worker.Tag.ToString() + "' where workshop_id = '" + data_id + "'");
                        break;
                    case 2:
                        break;
                }
                Form_OK = 1;
                this.Close();
            }
        }

        private void WorkshopForm_Load(object sender, EventArgs e)
        {
            int num = 0;
            DataSet DSet = SQLClass.getDataSet("select workshop_id,workshop_name,workshop_worker from workshop where workshop_id = '" + data_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet sDSet = SQLClass.getDataSet("select worker_id,worker_name from worker", "数据库信息表");
            DataTable sdt = sDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (sdt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    txt_workshop_name.Text = dt.Rows[0][1].ToString();
                    txt_workshop_name.Tag = "1";
                    cBox_workshop_worker.Tag = dt.Rows[0][2].ToString();
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][2].ToString() == sdt.Rows[i][0].ToString())
                        {
                            num = i;
                        }
                        cBox_workshop_worker.Items.Add(sdt.Rows[i][1].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        cBox_workshop_worker.Items.Add(sdt.Rows[i][1].ToString());
                    }
                }
                cBox_workshop_worker.SelectedIndex = num;
            }
            else
            {
                MessageBox.Show("还没有员工信息，请先添加！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    txt_workshop_name.ReadOnly = true;
                    cBox_workshop_worker.Enabled = false;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_workshop_name_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void cBox_workshop_worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select worker_id from worker where worker_name = '" + cBox_workshop_worker.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_workshop_worker.Tag = dt.Rows[0][0].ToString();
            }
        }

    }
}

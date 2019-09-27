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
    public partial class MachineForm : Form
    {
        public MachineForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        public void checkForm()
        {
            if (txt_machine_name.Text != "")
            {
                txt_machine_name.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_machine_name.Tag = "0";
                lab_message.Text = "机床名称不能为空！";
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_machine_name.Text = "";
            txt_machine_name.Tag = "0";
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_machine_name.Tag) == "1")
            {
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into machine values ('" + txt_machine_name.Text.ToString().Trim() + "','" + cBox_machine_worker.Tag.ToString() + "','" + cBox_machine_workshop.Tag.ToString() + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update machine set machine_name = '" + txt_machine_name.Text.ToString().Trim() + "', machine_worker = '" + cBox_machine_worker.Tag.ToString() + "', machine_workshop = '" + cBox_machine_workshop.Tag.ToString() + "' where machine_id = '" + data_id + "'");
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
            int worker_num = 0;
            int workshop_num = 0;
            DataSet DSet = SQLClass.getDataSet("select machine_id,machine_name,machine_worker,machine_workshop from machine where machine_id = '" + data_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet workerDSet = SQLClass.getDataSet("select worker_id,worker_name from worker", "数据库信息表");
            DataTable workerdt = workerDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet workshopDSet = SQLClass.getDataSet("select workshop_id,workshop_name from workshop", "数据库信息表");
            DataTable workshopdt = workshopDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (workerdt.Rows.Count > 0 && workshopdt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    txt_machine_name.Text = dt.Rows[0][1].ToString();
                    txt_machine_name.Tag = "1";
                    cBox_machine_worker.Tag = dt.Rows[0][2].ToString();
                    cBox_machine_workshop.Tag = dt.Rows[0][3].ToString();
                    for (int i = 0; i < workerdt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][2].ToString() == workerdt.Rows[i][0].ToString())
                        {
                            worker_num = i;
                        }
                        cBox_machine_worker.Items.Add(workerdt.Rows[i][1].ToString());
                    }
                    for (int i = 0; i < workshopdt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][3].ToString() == workshopdt.Rows[i][0].ToString())
                        {
                            workshop_num = i;
                        }
                        cBox_machine_workshop.Items.Add(workshopdt.Rows[i][1].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < workerdt.Rows.Count; i++)
                    {
                        cBox_machine_worker.Items.Add(workerdt.Rows[i][1].ToString());
                    }
                    for (int i = 0; i < workshopdt.Rows.Count; i++)
                    {
                        cBox_machine_workshop.Items.Add(workshopdt.Rows[i][1].ToString());
                    }
                }
                cBox_machine_worker.SelectedIndex = worker_num;
                cBox_machine_workshop.SelectedIndex = workshop_num;
            }
            else
            {
                MessageBox.Show("还没有员工或车间信息，请先添加！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    txt_machine_name.ReadOnly = true;
                    cBox_machine_worker.Enabled = false;
                    cBox_machine_workshop.Enabled = false;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_machine_name_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void cBox_machine_worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select worker_id from worker where worker_name = '" + cBox_machine_worker.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_machine_worker.Tag = dt.Rows[0][0].ToString();
            }
        }

        private void cBox_machine_workshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select workshop_id from workshop where workshop_name = '" + cBox_machine_workshop.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_machine_workshop.Tag = dt.Rows[0][0].ToString();
            }
        }

    }
}

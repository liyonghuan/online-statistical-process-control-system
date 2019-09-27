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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        public string sql;
        public bool Form_OK;

        string tempproduct;
        string tempworkshop;
        string tempmachine;
        string tempworker;
        string tempprocess;

        SQL_Class SQLClass = new SQL_Class();

        private void button2_Click(object sender, EventArgs e)
        {
            Form_OK = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_OK = true;
            this.Close();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            DataSet DSet1 = SQLClass.getDataSet("select product_name from product", "数据库信息表");
            DataTable dt1 = DSet1.Tables["数据库信息表"];        //创建一个DataTable对象
            cBox_product.Items.Add("全部");
            cBox_product.SelectedIndex = 0;
            if(dt1.Rows.Count > 0)
            {
                for(int i = 0; i < dt1.Rows.Count ; i++)
                {
                    cBox_product.Items.Add(dt1.Rows[i][0]);
                }
                
            }
            else
            {
                
            }

            DataSet DSet2 = SQLClass.getDataSet("select workshop_name from workshop", "数据库信息表");
            DataTable dt2 = DSet2.Tables["数据库信息表"];        //创建一个DataTable对象
            cBox_workshop.Items.Add("全部");
            cBox_workshop.SelectedIndex = 0;
            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    cBox_workshop.Items.Add(dt2.Rows[i][0]);
                }

            }
            else
            {

            }

            DataSet DSet3 = SQLClass.getDataSet("select machine_name from machine", "数据库信息表");
            DataTable dt3 = DSet3.Tables["数据库信息表"];        //创建一个DataTable对象
            cBox_machine.Items.Add("全部");
            cBox_machine.SelectedIndex = 0;
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    cBox_machine.Items.Add(dt3.Rows[i][0]);
                }

            }
            else
            {

            }

            DataSet DSet4 = SQLClass.getDataSet("select worker_name from worker", "数据库信息表");
            DataTable dt4 = DSet4.Tables["数据库信息表"];        //创建一个DataTable对象
            cBox_worker.Items.Add("全部");
            cBox_worker.SelectedIndex = 0;
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    cBox_worker.Items.Add(dt4.Rows[i][0]);
                }

            }
            else
            {

            }

            DataSet DSet5 = SQLClass.getDataSet("select process_name from process", "数据库信息表");
            DataTable dt5 = DSet5.Tables["数据库信息表"];        //创建一个DataTable对象
            cBox_process.Items.Add("全部");
            cBox_process.SelectedIndex = 0;
            if (dt4.Rows.Count > 0)
            {
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    cBox_process.Items.Add(dt5.Rows[i][0]);
                }

            }
            else
            {

            }

        }

        private void cBox_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select product_id from product where product_name = '" + cBox_product.Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if(dt.Rows.Count > 0)
            {
                cBox_product.Tag = dt.Rows[0][0];
            }
            commonFunction();
        }

        private void cBox_workshop_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select workshop_id from workshop where workshop_name = '" + cBox_workshop.Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_workshop.Tag = dt.Rows[0][0];
            }
            commonFunction();
        }

        private void cBox_machine_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select machine_id from machine where machine_name = '" + cBox_machine.Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_machine.Tag = dt.Rows[0][0];
            }
            commonFunction();
        }

        private void cBox_worker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select worker_id from worker where worker_name = '" + cBox_worker.Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_worker.Tag = dt.Rows[0][0];
            }
            commonFunction();
        }

        private void cBox_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select process_id from process where process_name = '" + cBox_process.Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_process.Tag = dt.Rows[0][0];
            }
            commonFunction();
        }


        private void commonFunction()
        {
            if (cBox_product.Text == "全部")
            {
                tempproduct = "";
            }
            else
            {
                tempproduct = " and product_id = '" + cBox_product.Tag + "'";
            }

            if (cBox_workshop.Text == "全部")
            {
                tempworkshop = "";
            }
            else
            {
                tempworkshop = " and workshop_id = '" + cBox_workshop.Tag + "'";
            }

            if (cBox_machine.Text == "全部")
            {
                tempmachine = "";
            }
            else
            {
                tempmachine = " and machine_id = '" + cBox_machine.Tag + "'";
            }

            if (cBox_worker.Text == "全部")
            {
                tempworker = "";
            }
            else
            {
                tempworker = " and worker_id = '" + cBox_worker.Tag + "'";
            }

            if (cBox_process.Text == "全部")
            {
                tempprocess = "";
            }
            else
            {
                tempprocess = " and process_id = '" + cBox_process.Tag + "'";
            }

            sql = "select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id " + tempproduct + tempworkshop + tempmachine + tempworker + tempprocess + "";

            DataSet DSet = SQLClass.getDataSet(sql, "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象

            lab_message.Text = "共有" + dt.Rows.Count + "条记录！";
        }

    }
}

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
    public partial class MeasureForm : Form
    {
        public MeasureForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();
        RegexClass regexclass = new RegexClass();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        public void checkForm()
        {
            if (txt_measure_data.Text != "" && regexclass.IsFloat(txt_measure_data.Text))
            {
                txt_measure_data.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_measure_data.Tag = "0";
                lab_message.Text = "测量数据不能为空，且需要为数值！";
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_measure_data.Text = "";
            txt_measure_data.Tag = "0";
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_measure_data.Tag) == "1")
            {
                StateClass stateclass = new StateClass();
                int state = stateclass.UpdateMeasure(Convert.ToSingle(txt_measure_data.Text), Convert.ToInt32(cBox_measure_process.Tag));
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into measure values ('" + txt_measure_data.Text.ToString().Trim() + "','" + cBox_measure_machine.Tag.ToString() + "','" + cBox_measure_process.Tag.ToString() + "','" + state + "','','" + DateTime.Now + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update measure set measure_data = '" + txt_measure_data.Text.ToString().Trim() + "', measure_machine = '" + cBox_measure_machine.Tag.ToString() + "', measure_process = '" + cBox_measure_process.Tag.ToString() + "', measure_state = '" + state + "' where measure_id = '" + data_id + "'");
                        break;
                    case 2:
                        break;
                }
                Form_OK = 1;
                this.Close();
            }
        }

        private void MeasureForm_Load(object sender, EventArgs e)
        {
            int machine_num = 0;
            int process_num = 0;
            DataSet DSet = SQLClass.getDataSet("select measure_id,measure_data,measure_machine,measure_process from measure where measure_id = '" + data_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet machineDSet = SQLClass.getDataSet("select machine_id,machine_name from machine", "数据库信息表");
            DataTable machinedt = machineDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet processDSet = SQLClass.getDataSet("select process_id,process_name from process", "数据库信息表");
            DataTable processdt = processDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (machinedt.Rows.Count > 0 && processdt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    txt_measure_data.Text = dt.Rows[0][1].ToString();
                    txt_measure_data.Tag = "1";
                    cBox_measure_machine.Tag = dt.Rows[0][2].ToString();
                    cBox_measure_process.Tag = dt.Rows[0][3].ToString();
                    for (int i = 0; i < machinedt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][2].ToString() == machinedt.Rows[i][0].ToString())
                        {
                            machine_num = i;
                        }
                        cBox_measure_machine.Items.Add(machinedt.Rows[i][1].ToString());
                    }
                    for (int i = 0; i < processdt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][3].ToString() == processdt.Rows[i][0].ToString())
                        {
                            process_num = i;
                        }
                        cBox_measure_process.Items.Add(processdt.Rows[i][1].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < machinedt.Rows.Count; i++)
                    {
                        cBox_measure_machine.Items.Add(machinedt.Rows[i][1].ToString());
                    }
                    for (int i = 0; i < processdt.Rows.Count; i++)
                    {
                        cBox_measure_process.Items.Add(processdt.Rows[i][1].ToString());
                    }
                }
                cBox_measure_machine.SelectedIndex = machine_num;
                cBox_measure_process.SelectedIndex = process_num;
            }
            else
            {
                MessageBox.Show("还没有机床或工序信息，请先添加！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    txt_measure_data.ReadOnly = true;
                    cBox_measure_machine.Enabled = false;
                    cBox_measure_process.Enabled = false;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_measure_data_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void cBox_measure_machine_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select machine_id from machine where machine_name = '" + cBox_measure_machine.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_measure_machine.Tag = dt.Rows[0][0].ToString();
            }
        }

        private void cBox_measure_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select process_id from process where process_name = '" + cBox_measure_process.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_measure_process.Tag = dt.Rows[0][0].ToString();
            }
        }
    }
}

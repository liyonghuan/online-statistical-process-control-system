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
    public partial class ProcessForm : Form
    {
        public ProcessForm()
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
            if (txt_process_name.Text != "")
            {
                txt_process_name.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_process_name.Tag = "0";
                lab_message.Text = "工序名称不能为空！没有上下限则留空！";
            }

            if(regexclass.IsFloat(txt_process_ucl.Text) || txt_process_ucl.Text == "")
            {
                if(txt_process_ucl.Text != "" && txt_process_lcl.Text != "")
                {
                    if(Convert.ToSingle(txt_process_lcl.Text) <= Convert.ToSingle(txt_process_ucl.Text))
                    {
                        txt_process_ucl.Tag = "1";
                    }
                    else
                    {
                        txt_process_ucl.Tag = "0";
                        lab_message.Text = "上界限必须大于或等于下界限！";
                    }
                }
                else
                {
                    txt_process_ucl.Tag = "1";
                }
            }
            else
            {
                txt_process_ucl.Tag = "0";
                lab_message.Text = "工序名称不能为空！没有上下限则留空！";
            }

            if (regexclass.IsFloat(txt_process_lcl.Text) || txt_process_lcl.Text == "")
            {
                if (txt_process_ucl.Text != "" && txt_process_lcl.Text != "")
                {
                    if (Convert.ToSingle(txt_process_lcl.Text) <= Convert.ToSingle(txt_process_ucl.Text))
                    {
                        txt_process_lcl.Tag = "1";
                    }
                    else
                    {
                        txt_process_lcl.Tag = "0";
                        lab_message.Text = "上界限必须大于或等于下界限！";
                    }
                }
                else
                {
                    txt_process_lcl.Tag = "1";
                }
            }
            else
            {
                txt_process_lcl.Tag = "0";
                lab_message.Text = "工序名称不能为空！没有上下限则留空！";
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_process_name.Text = "";
            txt_process_name.Tag = "0";
            txt_process_ucl.Text = "";
            txt_process_ucl.Tag = "0";
            txt_process_lcl.Text = "";
            txt_process_lcl.Tag = "0";
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_process_name.Tag) == "1" && Convert.ToString(txt_process_ucl.Tag) == "1" && Convert.ToString(txt_process_lcl.Tag) == "1")
            {
                string ucl;
                string lcl;
                if(txt_process_ucl.Text == "")
                {
                    ucl = "absoluteness";
                }
                else
                {
                    ucl = txt_process_ucl.Text;
                }
                if(txt_process_lcl.Text == "")
                {
                    lcl = "absoluteness";
                }
                else
                {
                    lcl = txt_process_lcl.Text;
                }
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into process values ('" + txt_process_name.Text.ToString().Trim() + "','" + cBox_process_product.Tag.ToString() + "','" + ucl + "','" + lcl + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update process set process_name = '" + txt_process_name.Text.ToString().Trim() + "', process_product = '" + cBox_process_product.Tag.ToString() + "', process_ucl = '" + ucl + "', process_lcl = '" + lcl + "' where process_id = '" + data_id + "'");
                        break;
                    case 2:
                        break;
                }

                StateClass stateclass = new StateClass();
                DataSet DSet = SQLClass.getDataSet("select measure_id,measure_data from measure where measure_process = '" + data_id + "'", "数据库信息表");
                DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
                if(dt.Rows.Count > 0)
                {
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        int measure_id = Convert.ToInt32(dt.Rows[i][0]);
                        float measure_data = Convert.ToSingle(dt.Rows[i][1]);
                        stateclass.UpdateProcess(measure_id, measure_data, txt_process_ucl.Text, txt_process_lcl.Text);
                    }
                }

                Form_OK = 1;
                this.Close();
            }
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            int num = 0;
            DataSet DSet = SQLClass.getDataSet("select process_id,process_name,process_product,process_ucl,process_lcl from process where process_id = '" + data_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            DataSet sDSet = SQLClass.getDataSet("select product_id,product_name from product", "数据库信息表");
            DataTable sdt = sDSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (sdt.Rows.Count > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    txt_process_name.Text = dt.Rows[0][1].ToString();
                    txt_process_name.Tag = "1";
                    cBox_process_product.Tag = dt.Rows[0][2].ToString();
                    if (dt.Rows[0][3].ToString() == "absoluteness")
                    {
                        txt_process_ucl.Text = "";
                    }
                    else
                    {
                        txt_process_ucl.Text = dt.Rows[0][3].ToString();
                    }

                    if (dt.Rows[0][4].ToString() == "absoluteness")
                    {
                        txt_process_lcl.Text = "";
                    }
                    else
                    {
                        txt_process_lcl.Text = dt.Rows[0][4].ToString();
                    }
                    
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        if (dt.Rows[0][2].ToString() == sdt.Rows[i][0].ToString())
                        {
                            num = i;
                        }
                        cBox_process_product.Items.Add(sdt.Rows[i][1].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < sdt.Rows.Count; i++)
                    {
                        cBox_process_product.Items.Add(sdt.Rows[i][1].ToString());
                    }
                }
                cBox_process_product.SelectedIndex = num;
            }
            else
            {
                MessageBox.Show("还没有产品信息，请先添加！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    txt_process_name.ReadOnly = true;
                    cBox_process_product.Enabled = false;
                    txt_process_ucl.ReadOnly = true;
                    txt_process_lcl.ReadOnly = true;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_process_name_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void cBox_process_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select product_id from product where product_name = '" + cBox_process_product.SelectedItem.ToString() + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                cBox_process_product.Tag = dt.Rows[0][0].ToString();
            }
        }

        private void txt_process_ucl_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void txt_process_lcl_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

    }
}

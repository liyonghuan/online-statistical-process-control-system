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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        SQL_Class SQLClass = new SQL_Class();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        public void checkForm()
        {
            if(txt_product_name.Text != "" && txt_product_model.Text != "" && txt_product_batch.Text != "")
            {
                txt_product_name.Tag = "1";
                txt_product_model.Tag = "1";
                txt_product_batch.Tag = "1";
                lab_message.Text = "";
            }
            else
            {
                txt_product_name.Tag = "0";
                txt_product_model.Tag = "0";
                txt_product_batch.Tag = "0";
                lab_message.Text = "产品名称、型号、批次不能为空！";
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            if (Form_Type != 0)
            {
                DataSet DSet = SQLClass.getDataSet("select product_id,product_name,product_model,product_batch,product_text from product where product_id = '" + data_id + "'", "数据库信息表");
                DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
                if (dt.Rows.Count > 0)
                {
                    txt_product_name.Text = dt.Rows[0][1].ToString();
                    txt_product_name.Tag = "1";
                    txt_product_model.Text = dt.Rows[0][2].ToString();
                    txt_product_model.Tag = "1";
                    txt_product_batch.Text = dt.Rows[0][3].ToString();
                    txt_product_batch.Tag = "1";
                    txt_product_text.Text = dt.Rows[0][4].ToString();
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
                    txt_product_name.ReadOnly = true;
                    txt_product_model.ReadOnly = true;
                    txt_product_batch.ReadOnly = true;
                    txt_product_text.ReadOnly = true;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
            checkForm();
        }

        private void txt_product_name_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void txt_product_model_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void txt_product_batch_TextChanged(object sender, EventArgs e)
        {
            checkForm();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(txt_product_name.Tag) == "1" && Convert.ToString(txt_product_model.Tag) == "1" && Convert.ToString(txt_product_batch.Tag) == "1")
            {
                switch (Form_Type)
                {
                    case 0:
                        SQLClass.getsqlcom("insert into product values ('" + txt_product_name.Text.ToString().Trim() + "','" + txt_product_model.Text.ToString().Trim() + "','" + txt_product_batch.Text.ToString().Trim() + "','" + txt_product_text.Text.ToString().Trim() + "')");
                        break;
                    case 1:
                        SQLClass.getsqlcom("update product set product_name = '" + txt_product_name.Text.ToString().Trim() + "', product_model = '" + txt_product_model.Text.ToString().Trim() + "', product_batch = '" + txt_product_batch.Text.ToString().Trim() + "', product_text = '" + txt_product_text.Text.ToString().Trim() + "' where product_id = '" + data_id + "'");
                        break;
                    case 2:
                        break;
                }
                Form_OK = 1;
                this.Close();
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_product_name.Text = "";
            txt_product_name.Tag = "0";
            txt_product_model.Text = "";
            txt_product_model.Tag = "0";
            txt_product_batch.Text = "";
            txt_product_batch.Tag = "0";
            txt_product_text.Text = "";
            checkForm();
        }
    }
}

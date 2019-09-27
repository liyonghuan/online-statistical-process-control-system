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
    public partial class TextForm : Form
    {
        public TextForm()
        {
            InitializeComponent();
        }


        SQL_Class SQLClass = new SQL_Class();

        public int Form_Type;
        public int Form_OK;
        public int data_id;

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_measure_text.Text = "";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            switch (Form_Type)
            {
                case 0:
                    SQLClass.getsqlcom("update measure set measure_text = '" + txt_measure_text.Text.ToString().Trim() + "' where measure_id = '" + data_id + "'");

                    break;
                case 1:
                    SQLClass.getsqlcom("update measure set measure_text = '" + txt_measure_text.Text.ToString().Trim() + "', measure_state = '2' where measure_id = '" + data_id + "'");
                    break;
                case 2:
                    break;
            }
            Form_OK = 1;
            this.Close();
        }

        private void TextForm_Load(object sender, EventArgs e)
        {
            DataSet DSet = SQLClass.getDataSet("select measure_id,measure_text from measure where measure_id = '" + data_id + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                txt_measure_text.Text = dt.Rows[0][1].ToString();
            }
            switch (Form_Type)
            {
                case 0:
                    break;
                case 1:

                    break;
                case 2:
                    txt_measure_text.ReadOnly = true;
                    btn_reset.Visible = false;
                    btn_ok.Visible = false;
                    break;
            }
        }
    }
}

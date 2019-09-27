using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;
using System.Data.OleDb;

namespace onlineSPC
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        static string chartname;
        //static int checkxnum = 0;       //控制图中记录连续X值

        static int groupn = 2;      //设置控制图的分组

        static int ymax = 0;    //横、纵坐标轴的最大、最小值
        static int ymin = 0;
        static int xmax = 0;
        static int xmin = 0;

        public string name;

        TreeNode SelectNode = new TreeNode();       //创建一个TreeNode对象SelectNode，用以存储被选中的树节点
        SQL_Class SQLClass = new SQL_Class();       //创建一个SQL_Class对象SQLClass，用以调用SQL_Class类中的函数
        CommonClass commonclass = new CommonClass();        //创建一个CommonClass，共同函数，包含常用的算法

        private void MainFrom_Load(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode("全部", 1, 2);
            node.Name = "0";
            treeview_left.Nodes.Add(node);
            addTreeViewNode("产品", "1");
            addTreeViewNode("车间", "2");
            addTreeViewNode("设备", "3");
            addTreeViewNode("员工", "4");
            addTreeViewNode("工序", "5");
            listview_columns();

            this.Text += "(当前用户：" + name + ")";

            cBoxChart.SelectedIndex = 0;
            cBoxGroup.SelectedIndex = 9;

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 产品参数PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.ProductForm product = new Data.ProductForm();
            product.Form_Type = 0;
            product.Text = "添加产品信息";
            product.ShowDialog();
            if (product.Form_OK == 1)
            {
                MessageBox.Show("添加产品信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateTreeview("1");
            UpdateListview("all");
        }

        private void 车间信息WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.WorkshopForm workshop = new Data.WorkshopForm();
            workshop.Form_Type = 0;
            workshop.Text = "添加车间信息";
            workshop.ShowDialog();
            if (workshop.Form_OK == 1)
            {
                MessageBox.Show("添加车间信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateTreeview("2");
            UpdateListview("all");
        }

        private void 设备信息MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.MachineForm machine = new Data.MachineForm();
            machine.Form_Type = 0;
            machine.Text = "添加设备信息";
            machine.ShowDialog();
            if (machine.Form_OK == 1)
            {
                MessageBox.Show("添加设备信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateTreeview("3");
            UpdateListview("all");
        }

        private void 人员信息HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.WorkerForm worker = new Data.WorkerForm();
            worker.Form_Type = 0;
            worker.Text = "添加员工信息";
            worker.ShowDialog();
            if (worker.Form_OK == 1)
            {
                MessageBox.Show("添加员工信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateTreeview("4");
            UpdateListview("all");
        }

        private void 工序信息TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.ProcessForm process = new Data.ProcessForm();
            process.Form_Type = 0;
            process.Text = "添加工序信息";
            process.ShowDialog();
            if (process.Form_OK == 1)
            {
                MessageBox.Show("添加工序信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateTreeview("5");
            UpdateListview("all");
        }

        //以下为重点代码--------------------------------------------------------------------
        public void listview_columns()     //列表的列项添加
        {
            listview_right.Columns.Clear();
            listview_right.Items.Clear();
            listview_right.Columns.Add("0", "序号", 50);
            listview_right.Columns.Add("1", "数据编号", 70);
            listview_right.Columns.Add("2", "测量数据", 80);
            listview_right.Columns.Add("3", "产品名称", 80);
            listview_right.Columns.Add("4", "工序名称", 80);
            listview_right.Columns.Add("5", "设备名称", 80);
            listview_right.Columns.Add("6", "加工员工", 70);
            listview_right.Columns.Add("7", "车间名称", 80);
            listview_right.Columns.Add("8", "状态", 50);
            listview_right.Columns.Add("9", "备注", 50);
        }

        public void addTreeViewNode(string text,string name)
        {
            TreeNode node = new TreeNode(text, 1, 2);
            node.Name = name;
            treeview_left.Nodes[0].Nodes.Add(node);
            UpdateTreeview(name);
        }

        public string dataFrom(string selectnode)
        {
            string datafrom = "product";
            switch (selectnode)
            {
                case "1":
                    datafrom = "product";
                    break;
                case "2":
                    datafrom = "workshop";
                    break;
                case "3":
                    datafrom = "machine";
                    break;
                case "4":
                    datafrom = "worker";
                    break;
                case "5":
                    datafrom = "process";
                    break;
            }
            return datafrom;
        }

        //更新树节点------------------------------------------
        private void UpdateTreeview(string selectnode)       //加载treeview根节点下面的子节点
        {
            treeview_left.Nodes[0].Nodes[selectnode].Nodes.Clear();
            //创建一个TreeNode对象，并对node的属性进行赋值
            string datafrom = dataFrom(selectnode);
            DataSet sonTreeSet = SQLClass.getDataSet("Select " + datafrom + "_id," + datafrom + "_name from " + datafrom + "", "基础信息表");
            DataTable sontreedt = sonTreeSet.Tables["基础信息表"];
            if (sontreedt.Rows.Count > 0)
            {
                for (int i = 0; i < sontreedt.Rows.Count; i++)
                {
                    TreeNode sonnode = new TreeNode(sontreedt.Rows[i][1].ToString(), 1, 2);
                    sonnode.Name = sontreedt.Rows[i][0].ToString();
                    treeview_left.Nodes[0].Nodes[selectnode].Nodes.Add(sonnode);
                }
            }
        }

        //更新列表--------------------------
        private void UpdateListview(string sql)     //加载listview中的数据，其中sql参数表示传递的SQL的语句
        {
            if (sql == "all")
            {
                sql = "select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id";
            }
            listview_right.Items.Clear();
            DataSet DSet = SQLClass.getDataSet(sql, "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if (dt.Rows.Count > 0)
            {
                string state;       //测量数据的状态
                string text;        //测量数据是否有备注

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //设置测量数据的状态
                    if(dt.Rows[i][7].ToString() == "0")
                    {
                        state = "失控";
                    }
                    else if(dt.Rows[i][7].ToString() == "1")
                    {
                        state = "已受理";
                    }
                    else if(dt.Rows[i][7].ToString() == "2")
                    {
                        state = "已处理";
                    }
                    else
                    {
                        state = "正常";
                    }

                    //判断是否含有备注
                    if (dt.Rows[i][8].ToString() == ""){
                        text = "无";
                    }
                    else
                    {
                        text = "有";
                    }

                    //定义一个string数组item，按listview中列的顺序存放数据
                    string[] item = { Convert.ToString(i + 1), dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), dt.Rows[i][4].ToString(), dt.Rows[i][5].ToString(), dt.Rows[i][6].ToString(), state, text };
                    //创建一个ListView对象newitem，并对newitem的属性进行赋值
                    ListViewItem newitem = new ListViewItem(item);
                    newitem.StateImageIndex = Convert.ToInt32(dt.Rows[i][7]);       //设置数据行的图标
                    if(dt.Rows[i][7].ToString() == "0")
                    {
                        newitem.ForeColor = Color.Red;
                    }
                    else if(dt.Rows[i][7].ToString() == "1")
                    {
                        newitem.ForeColor = Color.Blue;
                    }
                    else if(dt.Rows[i][7].ToString() == "2")
                    {
                        newitem.ForeColor = Color.Green;
                    }
                    else
                    {

                    }
                    listview_right.Items.Add(newitem);      //把newitem添加到listview中
                }
            }
        }

        //选中------------------TreeView
        private void treeview_left_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeview_left.SelectedNode == null)      //判断是否选中了树节点
            {
                UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id");
            }
            else if(treeview_left.SelectedNode.Text  == "全部"){
                UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id");
            }
            else if (treeview_left.SelectedNode.Parent.Text == "全部")
            {
                UpdateTreeview(treeview_left.SelectedNode.Name);
                UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id");
            }
            else if (treeview_left.SelectedNode.Parent.Parent.Text == "全部")
            {
                SelectNode = treeview_left.SelectedNode;        //把当前选中的节点赋值给SelectNode
                treeview_left.MouseDown += new MouseEventHandler(treeview_left_MouseDown);      //当鼠标位于控件treeView上并按下鼠标键时，加载treeview_MouseDown的函数
                UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and " + dataFrom(treeview_left.SelectedNode.Parent.Name) + "_id = " + treeview_left.SelectedNode.Name + "");
            }
            else
            {
                switch(treeview_left.SelectedNode.Parent.Parent.Text)
                {
                    case "产品":
                        SelectNode = treeview_left.SelectedNode;        //把当前选中的节点赋值给SelectNode
                        treeview_left.MouseDown += new MouseEventHandler(treeview_left_MouseDown);      //当鼠标位于控件treeView上并按下鼠标键时，加载treeview_MouseDown的函数
                        UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and " + dataFrom(treeview_left.SelectedNode.Parent.Parent.Name) + "_id = '" + treeview_left.SelectedNode.Parent.Name + "' and process_id = '" + treeview_left.SelectedNode.Name + "'");
                        break;
                }
            }
            //this.Text = treeview_left.SelectedNode.Name;
        }

        //鼠标按钮动作-----------------------------
        private void treeview_left_MouseDown(object sender, MouseEventArgs e)
        {
            this.treeview_left.ContextMenuStrip = contextMenuStrip_TreeView;
            contextMenuStrip_TreeView.Items.Clear();
            //创建一个矩形Rect，对初始化Rect的位置和大小
            Rectangle Rect = new Rectangle(SelectNode.Bounds.X, SelectNode.Bounds.Y, SelectNode.Bounds.Width, SelectNode.Bounds.Height);
            if (Rect.Contains(e.X, e.Y))     //如果鼠标停留在矩形内
            {
                ToolStripMenuItem revisemessage = new ToolStripMenuItem("修改信息");
                ToolStripMenuItem lookmessage = new ToolStripMenuItem("查看信息");
                ToolStripMenuItem deletemessage = new ToolStripMenuItem("删除信息");
                revisemessage.Click += new EventHandler(修改信息toolStripMenuItem_Click);
                lookmessage.Click += new EventHandler(查看信息toolStripMenuItem_Click);
                deletemessage.Click += new EventHandler(删除信息toolStripMenuItem_Click);
                contextMenuStrip_TreeView.Items.Add(revisemessage);
                contextMenuStrip_TreeView.Items.Add(lookmessage);
                contextMenuStrip_TreeView.Items.Add(deletemessage);
            }
        }

        private void 修改信息toolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeview_left.SelectedNode.Parent.Name)
            {
                case "1":       //产品
                    Data.ProductForm productform = new Data.ProductForm();
                    productform.Form_Type = 1;
                    productform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    productform.Text = "修改产品信息";
                    productform.ShowDialog();
                    if (productform.Form_OK == 1)
                    {
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("修改产品信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "2":       //车间
                    Data.WorkshopForm workshopform = new Data.WorkshopForm();
                    workshopform.Form_Type = 1;
                    workshopform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    workshopform.Text = "修改车间信息";
                    workshopform.ShowDialog();
                    if (workshopform.Form_OK == 1)
                    {
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("修改车间信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "3":       //机床
                    Data.MachineForm machineform = new Data.MachineForm();
                    machineform.Form_Type = 1;
                    machineform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    machineform.Text = "修改机床信息";
                    machineform.ShowDialog();
                    if (machineform.Form_OK == 1)
                    {
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("修改机床信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "4":       //员工
                    Data.WorkerForm workerform = new Data.WorkerForm();
                    workerform.Form_Type = 1;
                    workerform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    workerform.Text = "修改员工信息";
                    workerform.ShowDialog();
                    if (workerform.Form_OK == 1)
                    {
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("修改员工信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "5":       //工序
                    Data.ProcessForm processform = new Data.ProcessForm();
                    processform.Form_Type = 1;
                    processform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    processform.Text = "修改工序信息";
                    processform.ShowDialog();
                    if (processform.Form_OK == 1)
                    {
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("修改工序信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            UpdateListview("all");
        }

        private void 查看信息toolStripMenuItem_Click(object sender,EventArgs e)
        {
            switch (treeview_left.SelectedNode.Parent.Name)
            {
                case "1":       //产品
                    Data.ProductForm productform = new Data.ProductForm();
                    productform.Form_Type = 2;
                    productform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    productform.Text = "查看产品信息";
                    productform.ShowDialog();
                    break;
                case "2":       //车间
                    Data.WorkshopForm workshopform = new Data.WorkshopForm();
                    workshopform.Form_Type = 2;
                    workshopform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    workshopform.Text = "查看车间信息";
                    workshopform.ShowDialog();
                    break;
                case "3":       //机床
                    Data.MachineForm machineform = new Data.MachineForm();
                    machineform.Form_Type = 2;
                    machineform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    machineform.Text = "查看机床信息";
                    machineform.ShowDialog();
                    break;
                case "4":       //员工
                    Data.WorkerForm workerform = new Data.WorkerForm();
                    workerform.Form_Type = 2;
                    workerform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    workerform.Text = "查看员工信息";
                    workerform.ShowDialog();
                    break;
                case "5":       //工序
                    Data.ProcessForm processform = new Data.ProcessForm();
                    processform.Form_Type = 2;
                    processform.data_id = Convert.ToInt32(treeview_left.SelectedNode.Name);
                    processform.Text = "查看工序信息";
                    processform.ShowDialog();
                    break;
            }
        }

        private void 删除信息toolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeview_left.SelectedNode.Parent.Name)
            {
                case "1":       //产品
                    SqlDataReader productDR = SQLClass.getcom("select process_id from process where process_product = '" + treeview_left.SelectedNode.Name + "'");
                    bool productifcom = productDR.Read();
                    if (productifcom)
                    {
                        MessageBox.Show("工序中引用了该产品，请先删除相关工序后再尝试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("delete from product where product_id = '" + treeview_left.SelectedNode.Name + "'");
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("删除产品信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "2":       //车间
                    SqlDataReader workshopDR = SQLClass.getcom("select machine_id from machine where machine_workshop = '" + treeview_left.SelectedNode.Name + "'");
                    bool workshopifcom = workshopDR.Read();
                    if (workshopifcom)
                    {
                        MessageBox.Show("机床中引用了该车间，请先删除相关机床后再尝试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("delete from workshop where workshop_id = '" + treeview_left.SelectedNode.Name + "'");
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("删除车间信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "3":       //机床
                    SqlDataReader machineDR = SQLClass.getcom("select measure_id from measure where measure_machine = '" + treeview_left.SelectedNode.Name + "'");
                    bool machineifcom = machineDR.Read();
                    if (machineifcom)
                    {
                        MessageBox.Show("测量数据中引用了该机床，请先删除相关测量数据后再尝试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("delete from machine where machine_id = '" + treeview_left.SelectedNode.Name + "'");
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("删除机床信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "4":       //员工
                    SqlDataReader worker_machineDR = SQLClass.getcom("select machine_id from machine where machine_worker = '" + treeview_left.SelectedNode.Name + "'");
                    bool worker_machineifcom = worker_machineDR.Read();
                    SqlDataReader worker_workshopDR = SQLClass.getcom("select workshop_id from workshop where workshop_worker = '" + treeview_left.SelectedNode.Name + "'");
                    bool worker_workshopifcom = worker_workshopDR.Read();
                    if (worker_machineifcom || worker_workshopifcom)
                    {
                        MessageBox.Show("机床或车间中引用了该员工，请先删除相关数据后再尝试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("delete from worker where worker_id = '" + treeview_left.SelectedNode.Name + "'");
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("删除员工信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "5":       //工序
                    SqlDataReader processDR = SQLClass.getcom("select measure_id from measure where measure_process = '" + treeview_left.SelectedNode.Name + "'");
                    bool processifcom = processDR.Read();
                    if (processifcom)
                    {
                        MessageBox.Show("测量数据中引用了该工序，请先删除相关测量数据后再尝试！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("delete from process where process_id = '" + treeview_left.SelectedNode.Name + "'");
                        UpdateTreeview(treeview_left.SelectedNode.Parent.Name);       //更新树节点
                        MessageBox.Show("删除工序信息成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
            UpdateListview("all");
        }

        private void tStripBtn_add_measure_Click(object sender, EventArgs e)
        {
            MeasureForm measure = new MeasureForm();
            measure.Form_Type = 0;
            measure.Text = "添加测量数据";
            measure.ShowDialog();
            if (measure.Form_OK == 1)
            {
                MessageBox.Show("添加测量数据成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            UpdateListview("all");
        }

        private void tStripBtn_rep_measure_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (listview_right.SelectedItems.Count == 1)
            {
                MeasureForm measureform = new MeasureForm();
                measureform.Form_Type = 1;
                measureform.data_id = Convert.ToInt32(listview_right.SelectedItems[0].SubItems[1].Text);
                measureform.Text = "修改测量数据";
                measureform.ShowDialog();
                if (measureform.Form_OK == 1)
                {
                    MessageBox.Show("修改测量数据成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                UpdateListview("all");
            }
            else
            {
                MessageBox.Show("一次只能修改一条数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tStripBtn_del_measure_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("确定删除所选的所有信息吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    for (int i = 0; i < listview_right.SelectedItems.Count; i++)
                    {
                        SQLClass.getsqlcom("delete from measure where measure_id = '" + listview_right.SelectedItems[i].SubItems[1].Text + "'");
                    }
                    MessageBox.Show("共删除了" + listview_right.SelectedItems.Count + "条记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateListview("all");
                }
                else
                {
                    MessageBox.Show("删除操作已取消！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tStripBtn_0_measure_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int errornum = 0;
                for (int i = 0; i < listview_right.SelectedItems.Count; i++)
                {
                    if (listview_right.SelectedItems[i].SubItems[8].Text == "正常")
                    {
                        errornum++;
                        //MessageBox.Show("测量数据处于正常状态，设置被强制终止！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("update measure set measure_state = '0' where measure_id = '" + listview_right.SelectedItems[i].SubItems[1].Text + "'");
                    }
                }
                MessageBox.Show("共有" + listview_right.SelectedItems.Count + "条记录，其中有" + errornum + "条记录设置失败！如果出现失败可能是由于数据处于正常状态！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateListview("all");
            }
        }

        private void tStripBtn_1_measure_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int errornum = 0;
                for (int i = 0; i < listview_right.SelectedItems.Count; i++)
                {
                    if (listview_right.SelectedItems[i].SubItems[8].Text == "正常")
                    {
                        errornum++;
                        //MessageBox.Show("测量数据处于正常状态，设置被强制终止！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SQLClass.getsqlcom("update measure set measure_state = '1' where measure_id = '" + listview_right.SelectedItems[i].SubItems[1].Text + "'");
                    }
                }
                MessageBox.Show("共有" + listview_right.SelectedItems.Count + "条记录，其中有" + errornum + "条记录设置失败！如果出现失败可能是由于数据处于正常状态！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateListview("all");
            }
        }

        private void tStripBtn_2_measure_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (listview_right.SelectedItems.Count == 1)
            {
                if(listview_right.SelectedItems[0].SubItems[8].Text == "正常")
                {
                    MessageBox.Show("测量数据处于正常状态，设置被强制终止！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    TextForm textform = new TextForm();
                    textform.Form_Type = 1;
                    textform.data_id = Convert.ToInt32(listview_right.SelectedItems[0].SubItems[1].Text);
                    textform.Text = "添加测量数据备注";
                    textform.ShowDialog();
                    if (textform.Form_OK == 1)
                    {
                        MessageBox.Show("添加测量数据备注成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateListview("all");
                }
            }
            else
            {
                MessageBox.Show("一次只能设置一条测量数据的状态！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tStripBtn_add_measure_text_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (listview_right.SelectedItems.Count == 1)
            {
                    TextForm textform = new TextForm();
                    textform.Form_Type = 0;
                    textform.data_id = Convert.ToInt32(listview_right.SelectedItems[0].SubItems[1].Text);
                    textform.Text = "添加测量数据备注";
                    textform.ShowDialog();
                    if (textform.Form_OK == 1)
                    {
                        MessageBox.Show("添加测量数据备注成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    UpdateListview("all");
            }
            else
            {
                MessageBox.Show("一次只能为一条测量数据添加备注！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tStripBtn_view_measure_text_Click(object sender, EventArgs e)
        {
            if (listview_right.SelectedItems.Count <= 0 || listview_right.SelectedItems[0].SubItems[1].Text == "")
            {
                MessageBox.Show("未选中任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (listview_right.SelectedItems.Count == 1)
            {
                TextForm textform = new TextForm();
                textform.Form_Type = 2;
                textform.data_id = Convert.ToInt32(listview_right.SelectedItems[0].SubItems[1].Text);
                textform.Text = "查看测量数据备注";
                textform.ShowDialog();
            }
            else
            {
                MessageBox.Show("一次只能查看一条测量数据备注！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 全部数据AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("all");
        }

        private void 正常点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and measure_state = '3'");
        }

        private void 历史失控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and (measure_state = '0' or measure_state = '1' or measure_state = '2')");
        }

        private void 失控点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and measure_state = '0'");
        }

        private void 已受理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and measure_state = '1'");
        }

        private void 已处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateListview("select measure_id,measure_data,product_name,process_name,machine_name,worker_name,workshop_name,measure_state,measure_text from measure,product,process,machine,worker,workshop where measure_process = process_id and measure_machine = machine_id and machine_worker = worker_id and machine_workshop = workshop_id and process_product = product_id and measure_state = '2'");
        }

        public void commonChart(string[] linename)
        {
            lab_message.Text = "";

            float[] xarr = convertFloat();

            ChartClass chartclass = new ChartClass(xarr, cBoxChart.Tag.ToString(), groupn);

            switch(cBoxChart.Tag.ToString())
            {
                case "X":
                    lab_message.Text += "基本信息\n平均数：" + chartclass.xbar + "\n标准差：" + chartclass.svalue + "\nX最大值：" + chartclass.xmax + "\nX最小值：" + chartclass.xmin + "\n";
                    lab_message.Text += "\nX控制图\nCL：" + chartclass.xcl + "\nUCL：" + chartclass.xucl + "\nLCL：" + chartclass.xlcl + "\n";
                    break;
                case "Xbar-R":
                    lab_message.Text += "基本信息\n平均数：" + chartclass.xbarbar + "\nX最大值：" + chartclass.xmax + "\nX最小值：" + chartclass.xmin + "\nR最大值：" + chartclass.rmax + "\nR最小值：" + chartclass.rmin + "\n";
                    lab_message.Text += "\nXbar控制图\nCL：" + chartclass.xcl + "\nUCL：" + chartclass.xucl + "\nLCL：" + chartclass.xlcl + "\n";
                    lab_message.Text += "\nR控制图\nCL：" + chartclass.rcl + "\nUCL：" + chartclass.rucl + "\n";
                    if (groupn > 6)
                    {
                        lab_message.Text += "LCL：" + chartclass.rlcl + "\n";
                    }
                    break;
                case "Xmedian-R":
                    lab_message.Text += "基本信息\n平均数：" + chartclass.xmedianbar + "\nX最大值：" + chartclass.xmax + "\nX最小值：" + chartclass.xmin + "\nR最大值：" + chartclass.rmax + "\nR最小值：" + chartclass.rmin + "\n";
                    lab_message.Text += "\nXmedian控制图\nCL：" + chartclass.xcl + "\nUCL：" + chartclass.xucl + "\nLCL：" + chartclass.xlcl + "\n";
                    lab_message.Text += "\nR控制图\nCL：" + chartclass.rcl + "\nUCL：" + chartclass.rucl + "\n";
                    if(groupn > 6)
                    {
                        lab_message.Text += "LCL：" + chartclass.rlcl + "\n";
                    }
                    break;
                case "X-Rs":
                    lab_message.Text += "基本信息\n平均数：" + chartclass.xbar + "\nX最大值：" + chartclass.xmax + "\nX最小值：" + chartclass.xmin + "\nR最大值：" + chartclass.rmax + "\nR最小值：" + chartclass.rmin + "\n";
                    lab_message.Text += "\nX控制图\nCL：" + chartclass.xcl + "\nUCL：" + chartclass.xucl + "\nLCL：" + chartclass.xlcl + "\n";
                    lab_message.Text += "\nRs控制图\nCL：" + chartclass.rcl + "\nUCL：" + chartclass.rucl + "\n";
                    break;
            }

            //由于chartname是静态变量，因此命名需要一个图形到一个图形。
            addSeries(chartname, SeriesChartType.Line, MarkerStyle.Star6);
            addChartArea(chartname);
            SimpleChart.ChartAreas[chartname].AxisX.Title = "样本组";
            SimpleChart.ChartAreas[chartname].AxisY.Title = "样本组值";
            SimpleChart.Series[chartname].ChartArea = chartname;
            SimpleChart.Series[chartname].Label = "#VAL";

            DataSet DSet = SQLClass.getDataSet("select process_ucl,process_lcl from process where process_name = '" + listview_right.SelectedItems[0].SubItems[4].Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象

            if (dt.Rows.Count > 0)
            {
                if(radioBtn1.Checked)
                {
                    if (chartclass.xmax >= chartclass.xucl)       //判断最大值与Xbar控制上限大小
                    {
                        ymax = Convert.ToInt32(chartclass.xmax);
                    }
                    else
                    {
                        ymax = Convert.ToInt32(chartclass.xucl);
                    }

                    if (chartclass.xmin <= chartclass.xlcl)       //判断最小值和Xbar控制下限大小
                    {
                        ymin = Convert.ToInt32(chartclass.xmin);
                    }
                    else
                    {
                        ymin = Convert.ToInt32(chartclass.xlcl);
                    }

                    SimpleChart.ChartAreas[chartname].AxisX.Maximum = chartclass.xlist.Count() + 1;
                }
                else
                {
                    if (chartclass.rmax >= chartclass.rucl)      //判断最大值与R控制上限大小
                    {
                        ymax = Convert.ToInt32(chartclass.rmax);
                    }
                    else
                    {
                        ymax = Convert.ToInt32(chartclass.rucl);
                    }

                    if (chartclass.rmin <= chartclass.rlcl)       //判断最小值与R控制图下限大小
                    {
                        ymin = Convert.ToInt32(chartclass.rmin);
                    }
                    else
                    {
                        ymin = Convert.ToInt32(chartclass.rlcl);
                    }

                    SimpleChart.ChartAreas[chartname].AxisX.Maximum = chartclass.rlist.Count() + 1;
                }

                ymin -= ((ymin / 10));
                SimpleChart.ChartAreas[chartname].AxisY.Minimum = ymin;
                SimpleChart.ChartAreas[chartname].AxisX.Minimum = 0;

                if(radioBtn1.Checked)
                {
                    addSeries(linename[0], SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit(linename[0], chartclass.xcl, Color.Black, ChartDashStyle.Solid, 2);

                    addSeries(linename[1], SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit(linename[1], chartclass.xucl, Color.Red, ChartDashStyle.Dash, 1);

                    addSeries(linename[2], SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit(linename[2], chartclass.xlcl, Color.Red, ChartDashStyle.Dash, 1);

                    for (int i = 0; i < chartclass.xlist.Count(); i++)
                    {
                        SimpleChart.Series[chartname].Points.AddXY((i + 1), string.Format("{0:0.000}", chartclass.xlist[i]));
                        if(chartclass.xlist[i] > chartclass.xucl || chartclass.xlist[i] < chartclass.xlcl)
                        {
                            SimpleChart.Series[chartname].Points[i].Color = Color.Red;
                        }
                    }
                    if (20 < chartclass.xlist.Count())
                    {
                        SimpleChart.ChartAreas[chartname].AxisX.ScaleView.Zoom(0, 20);
                    }
                    setv(chartclass.xlist,chartclass.xcl,chartclass.xucl,chartclass.xlcl,"X");
                }
                else
                {
                    addSeries(linename[0], SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit(linename[0], chartclass.rcl, Color.Black, ChartDashStyle.Solid, 2);

                    addSeries(linename[1], SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit(linename[1], chartclass.rucl, Color.Red, ChartDashStyle.Dash, 1);

                    if (groupn > 6)
                    {
                        addSeries(linename[2], SeriesChartType.Line, MarkerStyle.None, false);
                        lineLimit(linename[2], chartclass.rlcl, Color.Red, ChartDashStyle.Dash, 1);
                    }

                    for (int i = 0; i < chartclass.rlist.Count(); i++)
                    {
                        SimpleChart.Series[chartname].Points.AddXY((i + 1), string.Format("{0:0.000}", chartclass.rlist[i]));

                        if (chartclass.rlist[i] > chartclass.rucl)
                        {
                            SimpleChart.Series[chartname].Points[i].Color = Color.Red;
                        }

                        if (groupn > 6)
                        {
                            if (chartclass.rlist[i] < chartclass.rlcl)
                            {
                                SimpleChart.Series[chartname].Points[i].Color = Color.Red;
                            }
                        }
                    }

                    if (20 < chartclass.rlist.Count())
                    {
                        SimpleChart.ChartAreas[chartname].AxisX.ScaleView.Zoom(0, 20);
                    }
                    setv(chartclass.rlist,chartclass.rcl,chartclass.rucl,chartclass.rlcl, "R");
                }

            }
        }

        private void setv(float[] list,float cl,float ucl, float lcl, string type)
        {
            string mistake = "";
            float uclb = cl + (ucl - cl) / 3;
            float ucla = cl + ((ucl - cl) / 3) * 2;
            float lclb = cl - (cl - lcl) / 3;
            float lcla = cl - ((cl - lcl) / 3) * 2;
            //注意points的下标是从1开始。
            for(int i = 1;i <= 8; i++)
            {
                bool is_mistake = false;
                int a = 0;      //记录数据达到要求次数
                string b = "--";        //记录上一次达到要求
                int aaa = 0;
                int bbb = 0;
                DataSet DSet = SQLClass.getDataSet("select v_static,v_message from v where v_vid = '" + i + "'", "数据库信息表");
                DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
                if(dt.Rows.Count > 0)
                {
                    if(dt.Rows[0][0].ToString() == "true")
                    {
                        switch(i)
                        {
                            case 1:
                                if(type == "X")
                                {
                                    //X
                                    for(int j = 0; j < list.Count();j++)
                                    {
                                        if (list[j] > ucl || list[j] < lcl)
                                        {
                                            is_mistake = true;
                                        }
                                    }
                                    if(is_mistake)
                                    {
                                        mistake += "第一类异常：" + dt.Rows[0][1].ToString() + "\n";
                                    }
                                }
                                else
                                {
                                    //R
                                    if(groupn > 6)
                                    {
                                        for (int j = 0; j < list.Count(); j++)
                                        {
                                            if (list[j] > ucl || list[j] < lcl)
                                            {
                                                is_mistake = true;
                                                SimpleChart.Series[chartname].Points[j + 1].Color = Color.Red;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int j = 0; j < list.Count(); j++)
                                        {
                                            if (list[j] > ucl)
                                            {
                                                is_mistake = true;
                                                SimpleChart.Series[chartname].Points[j + 1].Color = Color.Red;
                                            }
                                        }
                                    }
                                }
                                if (is_mistake)
                                {
                                    mistake += "第1类异常：" + dt.Rows[0][1].ToString() + "\n";
                                }
                                break;
                            case 2:
                                for (int k = 0; k < list.Count() - 8; k++)
                                {
                                    for (int j = 0; j < 9; j++)
                                    {
                                        if (list[k + j] >= cl && list[k + j + 1] >= cl)
                                        {
                                            is_mistake = true;
                                        }
                                        else if (list[k + j] <= cl && list[k + j + 1] <= cl)
                                        {
                                            is_mistake = true;
                                        }
                                        else
                                        {
                                            k = k + j;
                                            is_mistake = false;
                                            break;
                                        }
                                    }
                                    if (is_mistake)
                                    {
                                        mistake += "第2类异常：" + dt.Rows[0][1].ToString() + "\n";
                                        break;
                                    }
                                }
                                break;
                            case 3:
                                for (int k = 0; k < list.Count() - 5; k++ )
                                {
                                    for(int j = 0; j < 5; j++)
                                    {
                                        if(list[k + j] > list[k + j + 1])
                                        {
                                            if(b == "--")
                                            {
                                                b = "Down";
                                            }
                                            else if(b == "Down")
                                            {
                                                b = "Down";
                                            }
                                            else
                                            {
                                                k = k + j;
                                                is_mistake = false;
                                                break;
                                            }
                                            is_mistake = true;
                                        }
                                        else if(list[k + j] < list[k + j + 1])
                                        {
                                            if (b == "--")
                                            {
                                                b = "Up";
                                            }
                                            else if (b == "Up")
                                            {
                                                b = "Up";
                                            }
                                            else
                                            {
                                                k = k + j;
                                                is_mistake = false;
                                                break;
                                            }
                                            is_mistake = true;
                                        }
                                        else
                                        {
                                            k = k + j;
                                            is_mistake = false;
                                            break;
                                        }
                                    }
                                    if (is_mistake)
                                    {
                                        mistake += "第3类异常：" + dt.Rows[0][1].ToString() + "\n";
                                    }
                                }
                                break;
                            case 4:
								for(int k = 0; k < list.Count() - 13; k++)
								{
									for(int j = 0; j < 13; j++)
									{
										if(list[k + j] > list[k + j + 1])
										{
											if(b == "Down")
											{
												k = k + j;
												is_mistake = false;
												break;
											}
											else
											{
												b = "Down";
											}
										}
										else if(list[k + j] < list[k + j + 1])
										{
											if(b == "Up")
											{
												k = k + j;
												is_mistake = false;
												break;
											}
											else
											{
												b = "Up";
											}
										}
										else
										{
											k = k + j;
											is_mistake = false;
											break;
										}
										is_mistake = true;
									}
									if (is_mistake)
									{
										mistake += "第4类异常：" + dt.Rows[0][1].ToString() + "\n";
										break;
									}
								}
                                break;
                            case 5:
                                if(type == "X")
                                {
                                    //X
                                    for(int k = 0; k < list.Count() - 2; k++)
									{
                                        aaa = 0;
                                        bbb = 0;
										for(int j = 0; j < 3; j++)
										{
											if(list[k + j] >= ucla)
											{
                                                aaa++;
                                                b = "ucl";
											}
											else if(list[k + j] <= lcla)
											{
                                                bbb++;
                                                b = "lcl";
											}
											else
											{
												if(b == "--")
												{
													k = k + j;
													is_mistake = false;
													break;
												}
											}
											if(aaa >= 2 || bbb >= 2)
                                            {
                                                is_mistake = true;
                                            }
										}
										if(is_mistake)
										{
											mistake += "第5类异常：" + dt.Rows[0][1].ToString() + "\n";
											break;
										}
									}
                                }
                                else
                                {
                                    //R
                                    if(groupn > 6)
                                    {
                                        for (int k = 0; k < list.Count() - 2; k++)
                                        {
                                            aaa = 0;
                                            bbb = 0;
                                            for (int j = 0; j < 3; j++)
                                            {
                                                if (list[k + j] >= ucla)
                                                {
                                                    aaa++;
                                                    b = "ucl";
                                                }
                                                else
                                                {
                                                    if (b == "--")
                                                    {
                                                        k = k + j;
                                                        is_mistake = false;
                                                        break;
                                                    }
                                                }
                                                if (aaa >= 2 || bbb >= 2)
                                                {
                                                    is_mistake = true;
                                                }
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第5类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int k = 0; k < list.Count() - 2; k++)
                                        {
                                            aaa = 0;
                                            bbb = 0;
                                            for (int j = 0; j < 3; j++)
                                            {
                                                if (list[k + j] >= ucla)
                                                {
                                                    aaa++;
                                                    b = "ucl";
                                                }
                                                else if (list[k + j] <= lcla)
                                                {
                                                    bbb++;
                                                    b = "lcl";
                                                }
                                                else
                                                {
                                                    if (b == "--")
                                                    {
                                                        k = k + j;
                                                        is_mistake = false;
                                                        break;
                                                    }
                                                }
                                                if (aaa >= 2 || bbb >= 2)
                                                {
                                                    is_mistake = true;
                                                }
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第5类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 6:
								if(type == "X")
                                {
                                    //X
                                    for(int k = 0; k < list.Count() - 4; k++)
									{
                                        aaa = 0;
                                        bbb = 0;
										for(int j = 0; j < 5; j++)
										{
                                            if (list[k + j] >= uclb)
                                            {
                                                aaa++;
                                                b = "ucl";
                                            }
                                            else if (list[k + j] <= lclb)
                                            {
                                                bbb++;
                                                b = "lcl";
                                            }
                                            else
                                            {
                                                if (b == "--")
                                                {
                                                    k = k + j;
                                                    is_mistake = false;
                                                    break;
                                                }
                                            }
                                            if (aaa >= 4 || bbb >= 4)
                                            {
                                                is_mistake = true;
                                            }
										}
										if(is_mistake)
										{
											mistake += "第6类异常：" + dt.Rows[0][1].ToString() + "\n";
											break;
										}
									}
                                }
                                else
                                {
                                    //R
                                    if(groupn > 6)
                                    {
                                        for (int k = 0; k < list.Count() - 4; k++)
                                        {
                                            aaa = 0;
                                            bbb = 0;
                                            for (int j = 0; j < 5; j++)
                                            {
                                                if (list[k + j] >= uclb)
                                                {
                                                    aaa++;
                                                    b = "ucl";
                                                }
                                                else
                                                {
                                                    if (b == "--")
                                                    {
                                                        k = k + j;
                                                        is_mistake = false;
                                                        break;
                                                    }
                                                }
                                                if (aaa >= 4 || bbb >= 4)
                                                {
                                                    is_mistake = true;
                                                }
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第6类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int k = 0; k < list.Count() - 4; k++)
                                        {
                                            aaa = 0;
                                            bbb = 0;
                                            for (int j = 0; j < 5; j++)
                                            {
                                                if (list[k + j] >= uclb)
                                                {
                                                    aaa++;
                                                    b = "ucl";
                                                }
                                                else if (list[k + j] <= lclb)
                                                {
                                                    bbb++;
                                                    b = "lcl";
                                                }
                                                else
                                                {
                                                    if (b == "--")
                                                    {
                                                        k = k + j;
                                                        is_mistake = false;
                                                        break;
                                                    }
                                                }
                                                if (aaa >= 4 || bbb >= 4)
                                                {
                                                    is_mistake = true;
                                                }
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第6类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 7:
                                if (type == "X")
                                {
                                    //X
                                    for(int k = 0; k < list.Count() - 14;k ++)
                                    {
                                        for (int j = 0; j < 15; j++)
                                        {
                                            if(list[i + j] <= uclb && list[i + j] >= lclb)
                                            {
                                                
                                            }
                                            else
                                            {
                                                k = k + j;
                                                is_mistake = false;
                                                break;
                                            }
                                            is_mistake = true;
                                        }
                                        if (is_mistake)
                                        {
                                            mistake += "第7类异常：" + dt.Rows[0][1].ToString() + "\n";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    //R
                                    if (groupn > 6)
                                    {
                                        for (int k = 0; k < list.Count() - 14; k++)
                                        {
                                            for (int j = 0; j < 15; j++)
                                            {
                                                if (list[i + j] <= uclb)     //当为单侧时，位于另一侧的全部点都计入。
                                                {

                                                }
                                                else
                                                {
                                                    k = k + j;
                                                    is_mistake = false;
                                                    break;
                                                }
                                                is_mistake = true;
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第7类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int k = 0; k < list.Count() - 14; k++)
                                        {
                                            for (int j = 0; j < 15; j++)
                                            {
                                                if (list[i + j] <= uclb && list[i + j] >= lclb)
                                                {

                                                }
                                                else
                                                {
                                                    k = k + j;
                                                    is_mistake = false;
                                                    break;
                                                }
                                                is_mistake = true;
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第7类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                            case 8:
                                if (type == "X")
                                {
                                    //X
                                    for (int k = 0; k < list.Count() - 7; k++)
                                    {
                                        for (int j = 0; j < 8; j++)
                                        {
                                            if (list[i + j] >= uclb && list[i + j] <= lclb)
                                            {

                                            }
                                            else
                                            {
                                                k = k + j;
                                                is_mistake = false;
                                                break;
                                            }
                                            is_mistake = true;
                                        }
                                        if (is_mistake)
                                        {
                                            mistake += "第8类异常：" + dt.Rows[0][1].ToString() + "\n";
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    //R
                                    if (groupn > 6)
                                    {
                                        for (int k = 0; k < list.Count() - 7; k++)
                                        {
                                            for (int j = 0; j < 8; j++)
                                            {
                                                if (list[i + j] >= uclb && list[i + j] <= lclb)
                                                {

                                                }
                                                else
                                                {
                                                    k = k + j;
                                                    is_mistake = false;
                                                    break;
                                                }
                                                is_mistake = true;
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第8类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        for (int k = 0; k < list.Count() - 7; k++)
                                        {
                                            for (int j = 0; j < 8; j++)
                                            {
                                                if (list[i + j] >= uclb)
                                                {

                                                }
                                                else
                                                {
                                                    k = k + j;
                                                    is_mistake = false;
                                                    break;
                                                }
                                                is_mistake = true;
                                            }
                                            if (is_mistake)
                                            {
                                                mistake += "第8类异常：" + dt.Rows[0][1].ToString() + "\n";
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            if(mistake != "")
            {
                MessageBox.Show("异常原因：\n" + mistake + "", "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Histogram()
        {
            lab_message.Text = "";
            float[] xarr = convertFloat();      //将listview中选中的数据赋予xarr数组
            ValueClass valueclass = new ValueClass(xarr, groupn);        //定义新的直方图计算类

            lab_message.Text = "最大值：" + valueclass.xmax + "\n最小值：" + valueclass.xmin + "\n组距：" + valueclass.h + "\n简化中心值：" + valueclass.simplex + "\n标准公式平均值：" + valueclass.xave + "\n简化公式平均值：" + valueclass.xx + "\n标准公式标准偏差：" + valueclass.snum + "\n简化公式标准偏差：" + valueclass.xs;

            //由于chartname是静态变量，因此命名需要一个图形到一个图形。
            addSeries(chartname, SeriesChartType.Column, MarkerStyle.None);
            addChartArea(chartname);
            SimpleChart.ChartAreas[chartname].AxisX.Title = "分组区间";
            SimpleChart.ChartAreas[chartname].AxisY.Title = "样本频数";
            SimpleChart.Series[chartname].ChartArea = chartname;
            SimpleChart.Series[chartname].BorderColor = Color.Black;
            SimpleChart.Series[chartname].Label = "#VAL";
            SimpleChart.Series[chartname].CustomProperties = "PointWidth = 1";

            DataSet DSet = SQLClass.getDataSet("select process_ucl,process_lcl from process where process_name = '" + listview_right.SelectedItems[0].SubItems[4].Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "absoluteness")
                {
                    xmax = Convert.ToInt32(valueclass.xmax);
                }
                else
                {
                    addSeries("Tucl", SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit("Tucl", Convert.ToSingle(dt.Rows[0][0]), Color.Red, ChartDashStyle.Solid, 2, "X");
                    if (valueclass.xmax >= Convert.ToSingle(dt.Rows[0][0]))       //判断最大值与Xbar控制上限大小
                    {
                        xmax = Convert.ToInt32(valueclass.xmax);
                    }
                    else
                    {
                        xmax = Convert.ToInt32(dt.Rows[0][0]);
                    }
                }


                if (dt.Rows[0][1].ToString() == "" || dt.Rows[0][1].ToString() == "absoluteness")
                {
                    xmin = Convert.ToInt32(valueclass.xmin);
                }
                else
                {
                    addSeries("Tlcl", SeriesChartType.Line, MarkerStyle.None, false);
                    lineLimit("Tlcl", Convert.ToSingle(dt.Rows[0][1]), Color.Red, ChartDashStyle.Solid, 2, "X");
                    if (valueclass.xmin <= Convert.ToSingle(dt.Rows[0][1]))       //判断最小值和Xbar控制下限大小
                    {
                        xmin = Convert.ToInt32(valueclass.xmin);
                    }
                    else
                    {
                        xmin = Convert.ToInt32(dt.Rows[0][1]);
                    }
                }
            }

            //xmin -= ((xmin / 10) + 1);
            //SimpleChart.ChartAreas[chartname].AxisX.Minimum = xmin;
            float[] tempfnum = new float[valueclass.fnum.Count()];
            for (int i = 0; i < valueclass.fnum.Count(); i++)
            {
                tempfnum[i] = valueclass.fnum[i];
            }
            SimpleChart.ChartAreas[chartname].AxisY.Maximum = (commonclass.maxTomin(tempfnum)[0] + (commonclass.maxTomin(tempfnum)[0] / 10) + 1);
            SimpleChart.ChartAreas[chartname].AxisY.Minimum = 0;
            SimpleChart.ChartAreas[chartname].AxisY.LabelStyle.Format = "0";

            for (int i = 0; i < valueclass.cennum.Count(); i++)
            {
                SimpleChart.Series[chartname].Points.AddXY(string.Format("{0:0.000}", valueclass.cennum[i]), valueclass.fnum[i]);
            }
            //if (20 < valueclass.cennum.Count())
            //{
            //    SimpleChart.ChartAreas[chartname].AxisX.ScaleView.Zoom(0, 20);
            //}
        }

        public void Cpk()
        {
            if (groupn < 4)
            {
                MessageBox.Show("分组数量不能小于4！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lab_message.Text = "";
            float[] xarr = convertFloat();

            float[] cpknum = new float[(xarr.Count() + 1 - groupn)];

            DataSet DSet = SQLClass.getDataSet("select process_ucl,process_lcl from process where process_name = '" + listview_right.SelectedItems[0].SubItems[4].Text + "'", "数据库信息表");
            DataTable dt = DSet.Tables["数据库信息表"];        //创建一个DataTable对象
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < cpknum.Count(); i++)
                {
                    float[] tempx = new float[groupn];
                    for(int j = 0; j < groupn; j++)
                    {
                        tempx[j] = xarr[i + j];
                    }
                    float xave = commonclass.xBar(tempx);
                    float snum = commonclass.sDeviation(tempx);
                
                    CpkClass cpkclass = new CpkClass(xave,snum,dt.Rows[0][0].ToString(),dt.Rows[0][1].ToString());

                    cpknum[i] = cpkclass.Cpk;
                }

                //for (int i = 0; i < cpknum.Count(); i++)
                //{
                //    this.Text += cpknum[i];
                //}

                //由于chartname是静态变量，因此命名需要一个图形到一个图形。
                addSeries(chartname, SeriesChartType.Line, MarkerStyle.Star6);
                addChartArea(chartname);
                SimpleChart.ChartAreas[chartname].AxisX.Title = "样本组";
                SimpleChart.ChartAreas[chartname].AxisY.Title = "过程能力指数";
                SimpleChart.Series[chartname].ChartArea = chartname;
                SimpleChart.Series[chartname].Label = "#VAL";

                float[] tempcpk = new float[cpknum.Count()];
                for (int i = 0; i < cpknum.Count(); i++)
                {
                    tempcpk[i] = cpknum[i];
                }
                tempcpk = commonclass.maxTomin(tempcpk);

                //if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == "absoluteness")
                //{
                //    ymax = Convert.ToInt32(tempcpk[0]);
                //}
                //else
                //{
                //    if (tempcpk[0] >= Convert.ToSingle(dt.Rows[0][0]))       //判断最大值与Xbar控制上限大小
                //    {
                //        ymax = Convert.ToInt32(tempcpk[0]);
                //    }
                //    else
                //    {
                //        ymax = Convert.ToInt32(dt.Rows[0][0]);
                //    }
                //}

                if (dt.Rows[0][1].ToString() == "" || dt.Rows[0][1].ToString() == "absoluteness")
                {
                    ymin = Convert.ToInt32(tempcpk[tempcpk.Count() - 1]);
                }
                else
                {
                    if (tempcpk[tempcpk.Count() - 1] <= Convert.ToSingle(dt.Rows[0][1]))       //判断最小值和Xbar控制下限大小
                    {
                        ymin = Convert.ToInt32(tempcpk[tempcpk.Count() - 1]);
                    }
                    else
                    {
                        ymin = Convert.ToInt32(dt.Rows[0][1]);
                    }
                }

                SimpleChart.ChartAreas[chartname].AxisX.Maximum = cpknum.Count() + 1;

                ymin -= ((ymin / 10) + 1);
                //SimpleChart.ChartAreas[chartname].AxisY.Minimum = ymin;
                SimpleChart.ChartAreas[chartname].AxisX.Minimum = 0;

                addSeries("10σ", SeriesChartType.Line, MarkerStyle.None, false);
                lineLimit("10σ", 1.67F, Color.Yellow, ChartDashStyle.Dash, 1);

                addSeries("8σ", SeriesChartType.Line, MarkerStyle.None, false);
                lineLimit("8σ", 1.33F, Color.Black, ChartDashStyle.Dash, 1);

                addSeries("6σ", SeriesChartType.Line, MarkerStyle.None, false);
                lineLimit("6σ", 1F, Color.Red, ChartDashStyle.Dash, 1);

                addSeries("4σ", SeriesChartType.Line, MarkerStyle.None, false);
                lineLimit("4σ", 0.67F, Color.Red, ChartDashStyle.Dash, 2);

                for (int i = 0; i < cpknum.Count(); i++)
                {
                    SimpleChart.Series[chartname].Points.AddXY((i + 1), string.Format("{0:0.000}", cpknum[i]));
                    if(cpknum[i] < 0.67F)
                    {
                        SimpleChart.Series[chartname].Points[i].Color = Color.Red;
                    }
                    else if(cpknum[i] < 1F)
                    {
                        SimpleChart.Series[chartname].Points[i].Color = Color.Yellow;
                    }
                    else if(cpknum[i] < 1.33F)
                    {
                        SimpleChart.Series[chartname].Points[i].Color = Color.Black;
                    }
                    else if(cpknum[i] < 1.67F)
                    {
                        SimpleChart.Series[chartname].Points[i].Color = Color.Black;
                    }
                    else
                    {
                        SimpleChart.Series[chartname].Points[i].Color = Color.Yellow;
                    }
                }
                if (20 < cpknum.Count())
                {
                    SimpleChart.ChartAreas[chartname].AxisX.ScaleView.Zoom(0, 20);
                }
            }
            else
            {
                MessageBox.Show("未知错误，可能是没有该工序信息！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool checkData(int n)        //检查选中的数据是否为n个，并且工序是否一致。返回值为bool型
        {
            if (listview_right.SelectedItems == null ||  listview_right.SelectedItems.Count <= 0)
            {
                MessageBox.Show("还未选择任何数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (0 == listview_right.SelectedItems.Count % n)
                {
                    for (int i = 0; i < listview_right.SelectedItems.Count; i++)
                    {
                        if (listview_right.SelectedItems[i].SubItems[4].Text != listview_right.SelectedItems[0].SubItems[4].Text)
                        {
                            MessageBox.Show("选择的数据是同一道工序不能绘图！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    if(chartname == "Cpk")
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("选择的图表类型数据需要为" + n + "的整数个！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return true;
            }
        }

        public float[] convertFloat()       //将ListView中选中的数据进行转化为Float类型
        {
            float[] temp = new float[listview_right.SelectedItems.Count];
            for(int i = 0; i < listview_right.SelectedItems.Count; i++)
            {
                temp[i] = Convert.ToSingle(listview_right.SelectedItems[i].SubItems[2].Text);
            }
            return temp;
        }

        public void addSeries(string name, SeriesChartType charttype, MarkerStyle markerstyle = MarkerStyle.None,bool is_new = true)
        {
            if(is_new)
            {
                SimpleChart.Series.Clear();
            }
            else
            {
                
            }
            SimpleChart.Series.Add(name);
            SimpleChart.Series[name].ChartType = charttype;
            SimpleChart.Series[name].MarkerStyle = markerstyle;
            SimpleChart.Series[name].MarkerSize = 15;
        }

        public void addChartArea(string name, bool is_new = true)
        {
            if (is_new)
            {
                SimpleChart.ChartAreas.Clear();
            }
            else
            {
               
            }

            SimpleChart.ChartAreas.Add(name);
            SimpleChart.ChartAreas[name].AxisX.MajorGrid.Enabled = false;
            SimpleChart.ChartAreas[name].AxisY.MajorGrid.Enabled = false;


            bool is_on = true;     //选择是否开启图表缩放？有可能会出错。
            if (is_on)
            {
                // Zoom into the X axis
                //SimpleChart.ChartAreas[0].AxisX.ScaleView.Zoom(1, 1);
                // Enable range selection and zooming end user interface
                SimpleChart.ChartAreas[name].CursorX.IsUserEnabled = true;
                SimpleChart.ChartAreas[name].CursorX.IsUserSelectionEnabled = true;
                SimpleChart.ChartAreas[name].AxisX.ScaleView.Zoomable = true;
                SimpleChart.ChartAreas[name].CursorY.IsUserEnabled = true;
                SimpleChart.ChartAreas[name].CursorY.IsUserSelectionEnabled = true;
                SimpleChart.ChartAreas[name].AxisY.ScaleView.Zoomable = true;
                //将滚动内嵌到坐标轴中
                SimpleChart.ChartAreas[name].AxisX.ScrollBar.IsPositionedInside = true;
                SimpleChart.ChartAreas[name].AxisY.ScrollBar.IsPositionedInside = true;
                // 设置滚动条的大小
                SimpleChart.ChartAreas[name].AxisX.ScrollBar.Size = 10;
                SimpleChart.ChartAreas[name].AxisY.ScrollBar.Size = 10;
                // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
                SimpleChart.ChartAreas[name].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                SimpleChart.ChartAreas[name].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
                // 设置自动放大与缩小的最小量
                SimpleChart.ChartAreas[name].AxisX.ScaleView.SmallScrollSize = double.NaN;
                SimpleChart.ChartAreas[name].AxisX.ScaleView.SmallScrollMinSize = 1;
                SimpleChart.ChartAreas[name].AxisY.ScaleView.SmallScrollSize = double.NaN;
                SimpleChart.ChartAreas[name].AxisY.ScaleView.SmallScrollMinSize = 1;
            }
            
        }

        public void lineLimit(string name,float y, Color color, ChartDashStyle type, int width, string xy = "Y")
        {
            switch(xy)
            {
                case "X":
                    //SimpleChart.Series[name].Points.AddXY(y, 5);
                    ////SimpleChart.Series[name].Points.AddXY(y, 1);
                    //SimpleChart.Series[name].Points.AddXY(y, 0);
                    SimpleChart.Series[name].BorderColor = color;
                    SimpleChart.Series[name].BorderDashStyle = type;
                    SimpleChart.Series[name].BorderWidth = width;
                    SimpleChart.Series[name].Label = name + ":" + string.Format("{0:0.000}", y);
                    break;
                case "Y":
                    SimpleChart.Series[name].Points.AddXY(-10000, y);
                    SimpleChart.Series[name].Points.AddXY(1, y);
                    SimpleChart.Series[name].Points.AddXY(10000, y);
                    SimpleChart.Series[name].BorderColor = color;
                    SimpleChart.Series[name].BorderDashStyle = type;
                    SimpleChart.Series[name].BorderWidth = width;
                    SimpleChart.Series[name].Label = name + ":" + string.Format("{0:0.000}",y);
                    break;
            }
        }

        private void cBoxChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBoxGroup.Enabled = true;       //默认开启，在特定细节中根据需要关闭
            radioBtn1.Enabled = false;      //默认关闭，在特定细节中根据需要开启
            radioBtn2.Enabled = false;      //默认关闭，在特定细节中根据需要开启
            radioBtn1.Checked = true;       //默认选中radioBtn1控件
            switch(cBoxChart.Text)
            {
                case "直方图":
                    cBoxChart.Tag = "Histogram";
                    radioBtn1.Checked = true;
                    break;
                case "散布图":
                    cBoxGroup.Enabled = false;
                    break;
                case "均值图":
                    cBoxGroup.Enabled = false;
                    break;
                case "Cpk趋势图":
                    cBoxChart.Tag = "Cpk";
                    radioBtn1.Checked = true;
                    break;
                case "X控制图":
                    cBoxChart.Tag = "X";
                    cBoxGroup.Enabled = false;
                    radioBtn1.Checked = true;
                    break;
                case "Xbar-R控制图":
                    cBoxChart.Tag = "Xbar-R";
                    radioBtn1.Text = "Xbar控制图";
                    radioBtn1.Enabled = true;
                    radioBtn2.Text = "R控制图";
                    radioBtn2.Enabled = true;
                    break;
                case "Xmedian-R控制图":
                    cBoxChart.Tag = "Xmedian-R";
                    radioBtn1.Text = "Xmedian控制图";
                    radioBtn1.Enabled = true;
                    radioBtn2.Text = "R控制图";
                    radioBtn2.Enabled = true;
                    break;
                case "X-Rs控制图":
                    cBoxChart.Tag = "X-Rs";
                    radioBtn1.Text = "X控制图";
                    radioBtn1.Enabled = true;
                    radioBtn2.Text = "Rs控制图";
                    radioBtn2.Enabled = true;
                    cBoxGroup.Enabled = false;
                    break;
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            RegexClass regexclass = new RegexClass();
            switch (cBoxChart.Text)
            {
                case "直方图":
                    if (regexclass.IsNum(cBoxGroup.Text))
                    {
                        if (checkData(Convert.ToInt32(cBoxGroup.Text)))
                        {
                            groupn = Convert.ToInt32(cBoxGroup.Text);
                            chartname = cBoxChart.Tag.ToString();
                            Histogram();
                        }
                    }
                    else
                    {
                        MessageBox.Show("分组只能为数字！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "散布图":
                    break;
                case "均值图":
                    break;
                case "Cpk趋势图":
                    if (regexclass.IsNum(cBoxGroup.Text))
                    {
                        if (listview_right.SelectedItems == null)
                        {

                        }
                        else
                        {
                            groupn = Convert.ToInt32(cBoxGroup.Text);
                            chartname = cBoxChart.Tag.ToString();
                            Cpk();
                        }
                    }
                    else
                    {
                        MessageBox.Show("分组只能为数字！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "X控制图":
                    groupn = 1;
                    string[] linename = new string[3];
                    chartname = "X";
                    linename[0] = "X-CL";
                    linename[1] = "X-UCL";
                    linename[2] = "X-LCL";
                    commonChart(linename);
                    break;
                case "Xbar-R控制图":
                    if (regexclass.IsNum(cBoxGroup.Text))
                    {
                        if (checkData(Convert.ToInt32(cBoxGroup.Text)))
                        {
                            groupn = Convert.ToInt32(cBoxGroup.Text);
                            string[] linenamea = new string[3];
                            if (radioBtn1.Checked)
                            {
                                chartname = "Xbar";
                                linenamea[0] = "Xbar-CL";
                                linenamea[1] = "Xbar-UCL";
                                linenamea[2] = "Xbar-LCL";
                            }
                            else
                            {
                                chartname = "R";
                                linenamea[0] = "R-CL";
                                linenamea[1] = "R-UCL";
                                linenamea[2] = "R-LCL";
                            }
                            commonChart(linenamea);
                        }
                    }
                    else
                    {
                        MessageBox.Show("分组只能为数字！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "Xmedian-R控制图":

                    if (regexclass.IsNum(cBoxGroup.Text))
                    {
                        if (checkData(Convert.ToInt32(cBoxGroup.Text)))
                        {
                            groupn = Convert.ToInt32(cBoxGroup.Text);
                            string[] linenameb = new string[3];
                            if (radioBtn1.Checked)
                            {
                                chartname = "Xmedian";
                                linenameb[0] = "Xmedian-CL";
                                linenameb[1] = "Xmedian-UCL";
                                linenameb[2] = "Xmedian-LCL";
                            }
                            else
                            {
                                chartname = "R";
                                linenameb[0] = "R-CL";
                                linenameb[1] = "R-UCL";
                                linenameb[2] = "R-LCL";
                            }
                            commonChart(linenameb);
                        }
                    }
                    else
                    {
                        MessageBox.Show("分组只能为数字！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "X-Rs控制图":
                    groupn = 2;
                    string[] linenamec = new string[3];
                    if (radioBtn1.Checked)
                    {
                        chartname = "X";
                        linenamec[0] = "X-CL";
                        linenamec[1] = "X-UCL";
                        linenamec[2] = "X-LCL";
                    }
                    else
                    {
                        chartname = "Rs";
                        linenamec[0] = "Rs-CL";
                        linenamec[1] = "Rs-UCL";
                        linenamec[2] = "Rs-LCL";
                    }
                    commonChart(linenamec);
                    break;
            }
        }

        private void 搜索CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchform = new SearchForm();
            searchform.Text = "分类搜索";
            searchform.ShowDialog();
            if(searchform.Form_OK)
            {
                UpdateListview(searchform.sql);

            }
            else
            {
                MessageBox.Show("已取消搜索操作！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        ExportClass exportclass = new ExportClass();

        private void 导出数据PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportclass.ExportToExecl(listview_right);
        }

        private void 设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetForm setform = new SetForm();
            setform.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发者：李欢\n指导老师：梁平\n学校：合肥工业大学\n学院：机械与汽车工程学院\n专业：工业工程11-02班\n学号：20110913\n手机：18789071403\n邮箱：lihuan.hsf@163.com\n个人主页：www.lihuan.com.cn\n", "关于本程序", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}

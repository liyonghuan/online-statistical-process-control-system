namespace onlineSPC
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.product = new System.Windows.Forms.Label();
            this.wordshop = new System.Windows.Forms.Label();
            this.machine = new System.Windows.Forms.Label();
            this.worker = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cBox_product = new System.Windows.Forms.ComboBox();
            this.cBox_workshop = new System.Windows.Forms.ComboBox();
            this.cBox_machine = new System.Windows.Forms.ComboBox();
            this.cBox_worker = new System.Windows.Forms.ComboBox();
            this.cBox_process = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lab_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // product
            // 
            this.product.AutoSize = true;
            this.product.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.product.Location = new System.Drawing.Point(39, 26);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(56, 16);
            this.product.TabIndex = 0;
            this.product.Text = "产品：";
            // 
            // wordshop
            // 
            this.wordshop.AutoSize = true;
            this.wordshop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordshop.Location = new System.Drawing.Point(39, 72);
            this.wordshop.Name = "wordshop";
            this.wordshop.Size = new System.Drawing.Size(56, 16);
            this.wordshop.TabIndex = 1;
            this.wordshop.Text = "车间：";
            // 
            // machine
            // 
            this.machine.AutoSize = true;
            this.machine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.machine.Location = new System.Drawing.Point(39, 124);
            this.machine.Name = "machine";
            this.machine.Size = new System.Drawing.Size(56, 16);
            this.machine.TabIndex = 2;
            this.machine.Text = "机床：";
            // 
            // worker
            // 
            this.worker.AutoSize = true;
            this.worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.worker.Location = new System.Drawing.Point(39, 177);
            this.worker.Name = "worker";
            this.worker.Size = new System.Drawing.Size(56, 16);
            this.worker.TabIndex = 3;
            this.worker.Text = "人员：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(39, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "工序：";
            // 
            // cBox_product
            // 
            this.cBox_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_product.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_product.FormattingEnabled = true;
            this.cBox_product.Location = new System.Drawing.Point(95, 23);
            this.cBox_product.Name = "cBox_product";
            this.cBox_product.Size = new System.Drawing.Size(200, 24);
            this.cBox_product.TabIndex = 0;
            this.cBox_product.SelectedIndexChanged += new System.EventHandler(this.cBox_product_SelectedIndexChanged);
            // 
            // cBox_workshop
            // 
            this.cBox_workshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_workshop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_workshop.FormattingEnabled = true;
            this.cBox_workshop.Location = new System.Drawing.Point(95, 69);
            this.cBox_workshop.Name = "cBox_workshop";
            this.cBox_workshop.Size = new System.Drawing.Size(200, 24);
            this.cBox_workshop.TabIndex = 1;
            this.cBox_workshop.SelectedIndexChanged += new System.EventHandler(this.cBox_workshop_SelectedIndexChanged);
            // 
            // cBox_machine
            // 
            this.cBox_machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_machine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_machine.FormattingEnabled = true;
            this.cBox_machine.Location = new System.Drawing.Point(95, 121);
            this.cBox_machine.Name = "cBox_machine";
            this.cBox_machine.Size = new System.Drawing.Size(200, 24);
            this.cBox_machine.TabIndex = 2;
            this.cBox_machine.SelectedIndexChanged += new System.EventHandler(this.cBox_machine_SelectedIndexChanged);
            // 
            // cBox_worker
            // 
            this.cBox_worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_worker.FormattingEnabled = true;
            this.cBox_worker.Location = new System.Drawing.Point(95, 174);
            this.cBox_worker.Name = "cBox_worker";
            this.cBox_worker.Size = new System.Drawing.Size(200, 24);
            this.cBox_worker.TabIndex = 3;
            this.cBox_worker.SelectedIndexChanged += new System.EventHandler(this.cBox_worker_SelectedIndexChanged);
            // 
            // cBox_process
            // 
            this.cBox_process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_process.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_process.FormattingEnabled = true;
            this.cBox_process.Location = new System.Drawing.Point(95, 226);
            this.cBox_process.Name = "cBox_process";
            this.cBox_process.Size = new System.Drawing.Size(200, 24);
            this.cBox_process.TabIndex = 4;
            this.cBox_process.SelectedIndexChanged += new System.EventHandler(this.cBox_process_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定(&Y)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.Location = new System.Drawing.Point(95, 265);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 12;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 329);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cBox_process);
            this.Controls.Add(this.cBox_worker);
            this.Controls.Add(this.cBox_machine);
            this.Controls.Add(this.cBox_workshop);
            this.Controls.Add(this.cBox_product);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.worker);
            this.Controls.Add(this.machine);
            this.Controls.Add(this.wordshop);
            this.Controls.Add(this.product);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label product;
        private System.Windows.Forms.Label wordshop;
        private System.Windows.Forms.Label machine;
        private System.Windows.Forms.Label worker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBox_product;
        private System.Windows.Forms.ComboBox cBox_workshop;
        private System.Windows.Forms.ComboBox cBox_machine;
        private System.Windows.Forms.ComboBox cBox_worker;
        private System.Windows.Forms.ComboBox cBox_process;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lab_message;
    }
}
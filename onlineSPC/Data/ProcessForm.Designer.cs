namespace onlineSPC.Data
{
    partial class ProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            this.lab_process_name = new System.Windows.Forms.Label();
            this.lab_process_product = new System.Windows.Forms.Label();
            this.lab_process_ucl = new System.Windows.Forms.Label();
            this.lab_process_lcl = new System.Windows.Forms.Label();
            this.txt_process_name = new System.Windows.Forms.TextBox();
            this.txt_process_ucl = new System.Windows.Forms.TextBox();
            this.txt_process_lcl = new System.Windows.Forms.TextBox();
            this.cBox_process_product = new System.Windows.Forms.ComboBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lab_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_process_name
            // 
            this.lab_process_name.AutoSize = true;
            this.lab_process_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_process_name.Location = new System.Drawing.Point(39, 26);
            this.lab_process_name.Name = "lab_process_name";
            this.lab_process_name.Size = new System.Drawing.Size(88, 16);
            this.lab_process_name.TabIndex = 0;
            this.lab_process_name.Text = "工序名称：";
            // 
            // lab_process_product
            // 
            this.lab_process_product.AutoSize = true;
            this.lab_process_product.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_process_product.Location = new System.Drawing.Point(39, 81);
            this.lab_process_product.Name = "lab_process_product";
            this.lab_process_product.Size = new System.Drawing.Size(88, 16);
            this.lab_process_product.TabIndex = 1;
            this.lab_process_product.Text = "产品名称：";
            // 
            // lab_process_ucl
            // 
            this.lab_process_ucl.AutoSize = true;
            this.lab_process_ucl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_process_ucl.Location = new System.Drawing.Point(39, 132);
            this.lab_process_ucl.Name = "lab_process_ucl";
            this.lab_process_ucl.Size = new System.Drawing.Size(88, 16);
            this.lab_process_ucl.TabIndex = 2;
            this.lab_process_ucl.Text = "数据上限：";
            // 
            // lab_process_lcl
            // 
            this.lab_process_lcl.AutoSize = true;
            this.lab_process_lcl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_process_lcl.Location = new System.Drawing.Point(39, 185);
            this.lab_process_lcl.Name = "lab_process_lcl";
            this.lab_process_lcl.Size = new System.Drawing.Size(88, 16);
            this.lab_process_lcl.TabIndex = 3;
            this.lab_process_lcl.Text = "数据下限：";
            // 
            // txt_process_name
            // 
            this.txt_process_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_process_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_process_name.Location = new System.Drawing.Point(121, 20);
            this.txt_process_name.Multiline = true;
            this.txt_process_name.Name = "txt_process_name";
            this.txt_process_name.Size = new System.Drawing.Size(200, 30);
            this.txt_process_name.TabIndex = 0;
            this.txt_process_name.TextChanged += new System.EventHandler(this.txt_process_name_TextChanged);
            // 
            // txt_process_ucl
            // 
            this.txt_process_ucl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_process_ucl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_process_ucl.Location = new System.Drawing.Point(121, 125);
            this.txt_process_ucl.Multiline = true;
            this.txt_process_ucl.Name = "txt_process_ucl";
            this.txt_process_ucl.Size = new System.Drawing.Size(200, 30);
            this.txt_process_ucl.TabIndex = 2;
            this.txt_process_ucl.TextChanged += new System.EventHandler(this.txt_process_ucl_TextChanged);
            // 
            // txt_process_lcl
            // 
            this.txt_process_lcl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_process_lcl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_process_lcl.Location = new System.Drawing.Point(121, 179);
            this.txt_process_lcl.Multiline = true;
            this.txt_process_lcl.Name = "txt_process_lcl";
            this.txt_process_lcl.Size = new System.Drawing.Size(200, 30);
            this.txt_process_lcl.TabIndex = 3;
            this.txt_process_lcl.TextChanged += new System.EventHandler(this.txt_process_lcl_TextChanged);
            // 
            // cBox_process_product
            // 
            this.cBox_process_product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_process_product.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_process_product.FormattingEnabled = true;
            this.cBox_process_product.Location = new System.Drawing.Point(121, 77);
            this.cBox_process_product.Name = "cBox_process_product";
            this.cBox_process_product.Size = new System.Drawing.Size(200, 24);
            this.cBox_process_product.TabIndex = 1;
            this.cBox_process_product.SelectedIndexChanged += new System.EventHandler(this.cBox_process_product_SelectedIndexChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(121, 243);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确定(&Y)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reset.Location = new System.Drawing.Point(241, 243);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 30);
            this.btn_reset.TabIndex = 5;
            this.btn_reset.Text = "重置(&R)";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.ForeColor = System.Drawing.Color.Red;
            this.lab_message.Location = new System.Drawing.Point(127, 221);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 10;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.cBox_process_product);
            this.Controls.Add(this.txt_process_lcl);
            this.Controls.Add(this.txt_process_ucl);
            this.Controls.Add(this.txt_process_name);
            this.Controls.Add(this.lab_process_lcl);
            this.Controls.Add(this.lab_process_ucl);
            this.Controls.Add(this.lab_process_product);
            this.Controls.Add(this.lab_process_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工序信息";
            this.Load += new System.EventHandler(this.ProcessForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_process_name;
        private System.Windows.Forms.Label lab_process_product;
        private System.Windows.Forms.Label lab_process_ucl;
        private System.Windows.Forms.Label lab_process_lcl;
        private System.Windows.Forms.TextBox txt_process_name;
        private System.Windows.Forms.TextBox txt_process_ucl;
        private System.Windows.Forms.TextBox txt_process_lcl;
        private System.Windows.Forms.ComboBox cBox_process_product;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lab_message;
    }
}
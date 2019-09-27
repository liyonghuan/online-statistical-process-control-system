namespace onlineSPC.Data
{
    partial class MachineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineForm));
            this.lab_machine_name = new System.Windows.Forms.Label();
            this.lab_machine_worker = new System.Windows.Forms.Label();
            this.lab_machine_workshop = new System.Windows.Forms.Label();
            this.txt_machine_name = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.cBox_machine_worker = new System.Windows.Forms.ComboBox();
            this.cBox_machine_workshop = new System.Windows.Forms.ComboBox();
            this.lab_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_machine_name
            // 
            this.lab_machine_name.AutoSize = true;
            this.lab_machine_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_machine_name.Location = new System.Drawing.Point(39, 26);
            this.lab_machine_name.Name = "lab_machine_name";
            this.lab_machine_name.Size = new System.Drawing.Size(88, 16);
            this.lab_machine_name.TabIndex = 0;
            this.lab_machine_name.Text = "设备名称：";
            // 
            // lab_machine_worker
            // 
            this.lab_machine_worker.AutoSize = true;
            this.lab_machine_worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_machine_worker.Location = new System.Drawing.Point(39, 82);
            this.lab_machine_worker.Name = "lab_machine_worker";
            this.lab_machine_worker.Size = new System.Drawing.Size(88, 16);
            this.lab_machine_worker.TabIndex = 1;
            this.lab_machine_worker.Text = "加工员工：";
            // 
            // lab_machine_workshop
            // 
            this.lab_machine_workshop.AutoSize = true;
            this.lab_machine_workshop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_machine_workshop.Location = new System.Drawing.Point(39, 140);
            this.lab_machine_workshop.Name = "lab_machine_workshop";
            this.lab_machine_workshop.Size = new System.Drawing.Size(88, 16);
            this.lab_machine_workshop.TabIndex = 2;
            this.lab_machine_workshop.Text = "所属车间：";
            // 
            // txt_machine_name
            // 
            this.txt_machine_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_machine_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_machine_name.Location = new System.Drawing.Point(123, 20);
            this.txt_machine_name.Multiline = true;
            this.txt_machine_name.Name = "txt_machine_name";
            this.txt_machine_name.Size = new System.Drawing.Size(200, 30);
            this.txt_machine_name.TabIndex = 0;
            this.txt_machine_name.TextChanged += new System.EventHandler(this.txt_machine_name_TextChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(123, 195);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定(&Y)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_reset.Location = new System.Drawing.Point(243, 195);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 30);
            this.btn_reset.TabIndex = 4;
            this.btn_reset.Text = "重置(&R)";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // cBox_machine_worker
            // 
            this.cBox_machine_worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_machine_worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_machine_worker.FormattingEnabled = true;
            this.cBox_machine_worker.Location = new System.Drawing.Point(123, 80);
            this.cBox_machine_worker.Name = "cBox_machine_worker";
            this.cBox_machine_worker.Size = new System.Drawing.Size(200, 24);
            this.cBox_machine_worker.TabIndex = 1;
            this.cBox_machine_worker.SelectedIndexChanged += new System.EventHandler(this.cBox_machine_worker_SelectedIndexChanged);
            // 
            // cBox_machine_workshop
            // 
            this.cBox_machine_workshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_machine_workshop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_machine_workshop.FormattingEnabled = true;
            this.cBox_machine_workshop.Location = new System.Drawing.Point(123, 137);
            this.cBox_machine_workshop.Name = "cBox_machine_workshop";
            this.cBox_machine_workshop.Size = new System.Drawing.Size(200, 24);
            this.cBox_machine_workshop.TabIndex = 2;
            this.cBox_machine_workshop.SelectedIndexChanged += new System.EventHandler(this.cBox_machine_workshop_SelectedIndexChanged);
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.ForeColor = System.Drawing.Color.Red;
            this.lab_message.Location = new System.Drawing.Point(123, 172);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 10;
            // 
            // MachineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 241);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.cBox_machine_workshop);
            this.Controls.Add(this.cBox_machine_worker);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_machine_name);
            this.Controls.Add(this.lab_machine_workshop);
            this.Controls.Add(this.lab_machine_worker);
            this.Controls.Add(this.lab_machine_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MachineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备信息";
            this.Load += new System.EventHandler(this.WorkshopForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_machine_name;
        private System.Windows.Forms.Label lab_machine_worker;
        private System.Windows.Forms.Label lab_machine_workshop;
        private System.Windows.Forms.TextBox txt_machine_name;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.ComboBox cBox_machine_worker;
        private System.Windows.Forms.ComboBox cBox_machine_workshop;
        private System.Windows.Forms.Label lab_message;
    }
}
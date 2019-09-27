namespace onlineSPC
{
    partial class MeasureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasureForm));
            this.lab_measure_data = new System.Windows.Forms.Label();
            this.lab_measure_machine = new System.Windows.Forms.Label();
            this.lab_measure_process = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.txt_measure_data = new System.Windows.Forms.TextBox();
            this.cBox_measure_machine = new System.Windows.Forms.ComboBox();
            this.cBox_measure_process = new System.Windows.Forms.ComboBox();
            this.lab_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lab_measure_data
            // 
            this.lab_measure_data.AutoSize = true;
            this.lab_measure_data.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_measure_data.Location = new System.Drawing.Point(39, 26);
            this.lab_measure_data.Name = "lab_measure_data";
            this.lab_measure_data.Size = new System.Drawing.Size(88, 16);
            this.lab_measure_data.TabIndex = 0;
            this.lab_measure_data.Text = "测量数据：";
            // 
            // lab_measure_machine
            // 
            this.lab_measure_machine.AutoSize = true;
            this.lab_measure_machine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_measure_machine.Location = new System.Drawing.Point(39, 82);
            this.lab_measure_machine.Name = "lab_measure_machine";
            this.lab_measure_machine.Size = new System.Drawing.Size(88, 16);
            this.lab_measure_machine.TabIndex = 1;
            this.lab_measure_machine.Text = "机床名称：";
            // 
            // lab_measure_process
            // 
            this.lab_measure_process.AutoSize = true;
            this.lab_measure_process.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_measure_process.Location = new System.Drawing.Point(39, 132);
            this.lab_measure_process.Name = "lab_measure_process";
            this.lab_measure_process.Size = new System.Drawing.Size(88, 16);
            this.lab_measure_process.TabIndex = 2;
            this.lab_measure_process.Text = "工序名称：";
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(121, 178);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定(&Y)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(241, 178);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 30);
            this.btn_reset.TabIndex = 4;
            this.btn_reset.Text = "重置(&R)";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // txt_measure_data
            // 
            this.txt_measure_data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_measure_data.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_measure_data.Location = new System.Drawing.Point(121, 21);
            this.txt_measure_data.Multiline = true;
            this.txt_measure_data.Name = "txt_measure_data";
            this.txt_measure_data.Size = new System.Drawing.Size(200, 30);
            this.txt_measure_data.TabIndex = 0;
            this.txt_measure_data.TextChanged += new System.EventHandler(this.txt_measure_data_TextChanged);
            // 
            // cBox_measure_machine
            // 
            this.cBox_measure_machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_measure_machine.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_measure_machine.FormattingEnabled = true;
            this.cBox_measure_machine.Location = new System.Drawing.Point(121, 78);
            this.cBox_measure_machine.Name = "cBox_measure_machine";
            this.cBox_measure_machine.Size = new System.Drawing.Size(200, 24);
            this.cBox_measure_machine.TabIndex = 1;
            this.cBox_measure_machine.SelectedIndexChanged += new System.EventHandler(this.cBox_measure_machine_SelectedIndexChanged);
            // 
            // cBox_measure_process
            // 
            this.cBox_measure_process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_measure_process.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_measure_process.FormattingEnabled = true;
            this.cBox_measure_process.Location = new System.Drawing.Point(121, 127);
            this.cBox_measure_process.Name = "cBox_measure_process";
            this.cBox_measure_process.Size = new System.Drawing.Size(200, 24);
            this.cBox_measure_process.TabIndex = 2;
            this.cBox_measure_process.SelectedIndexChanged += new System.EventHandler(this.cBox_measure_process_SelectedIndexChanged);
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.ForeColor = System.Drawing.Color.Red;
            this.lab_message.Location = new System.Drawing.Point(119, 159);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 8;
            // 
            // MeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 221);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.cBox_measure_process);
            this.Controls.Add(this.cBox_measure_machine);
            this.Controls.Add(this.txt_measure_data);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lab_measure_process);
            this.Controls.Add(this.lab_measure_machine);
            this.Controls.Add(this.lab_measure_data);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeasureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "测量数据";
            this.Load += new System.EventHandler(this.MeasureForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_measure_data;
        private System.Windows.Forms.Label lab_measure_machine;
        private System.Windows.Forms.Label lab_measure_process;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox txt_measure_data;
        private System.Windows.Forms.ComboBox cBox_measure_machine;
        private System.Windows.Forms.ComboBox cBox_measure_process;
        private System.Windows.Forms.Label lab_message;
    }
}
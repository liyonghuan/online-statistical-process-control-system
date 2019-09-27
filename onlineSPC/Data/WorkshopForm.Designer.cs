namespace onlineSPC.Data
{
    partial class WorkshopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkshopForm));
            this.lab_workshop_name = new System.Windows.Forms.Label();
            this.lab_workshop_worker = new System.Windows.Forms.Label();
            this.txt_workshop_name = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lab_message = new System.Windows.Forms.Label();
            this.cBox_workshop_worker = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lab_workshop_name
            // 
            this.lab_workshop_name.AutoSize = true;
            this.lab_workshop_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_workshop_name.Location = new System.Drawing.Point(39, 26);
            this.lab_workshop_name.Name = "lab_workshop_name";
            this.lab_workshop_name.Size = new System.Drawing.Size(88, 16);
            this.lab_workshop_name.TabIndex = 0;
            this.lab_workshop_name.Text = "车间名称：";
            // 
            // lab_workshop_worker
            // 
            this.lab_workshop_worker.AutoSize = true;
            this.lab_workshop_worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_workshop_worker.Location = new System.Drawing.Point(39, 82);
            this.lab_workshop_worker.Name = "lab_workshop_worker";
            this.lab_workshop_worker.Size = new System.Drawing.Size(88, 16);
            this.lab_workshop_worker.TabIndex = 1;
            this.lab_workshop_worker.Text = "车间主任：";
            // 
            // txt_workshop_name
            // 
            this.txt_workshop_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_workshop_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_workshop_name.Location = new System.Drawing.Point(123, 20);
            this.txt_workshop_name.Multiline = true;
            this.txt_workshop_name.Name = "txt_workshop_name";
            this.txt_workshop_name.Size = new System.Drawing.Size(200, 30);
            this.txt_workshop_name.TabIndex = 0;
            this.txt_workshop_name.TextChanged += new System.EventHandler(this.txt_workshop_name_TextChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(123, 139);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "确定(&Y)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(243, 139);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 30);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "重置(&R)";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // lab_message
            // 
            this.lab_message.AutoSize = true;
            this.lab_message.ForeColor = System.Drawing.Color.Red;
            this.lab_message.Location = new System.Drawing.Point(121, 119);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 6;
            // 
            // cBox_workshop_worker
            // 
            this.cBox_workshop_worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBox_workshop_worker.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cBox_workshop_worker.FormattingEnabled = true;
            this.cBox_workshop_worker.Location = new System.Drawing.Point(123, 79);
            this.cBox_workshop_worker.Name = "cBox_workshop_worker";
            this.cBox_workshop_worker.Size = new System.Drawing.Size(200, 24);
            this.cBox_workshop_worker.TabIndex = 1;
            this.cBox_workshop_worker.SelectedIndexChanged += new System.EventHandler(this.cBox_workshop_worker_SelectedIndexChanged);
            // 
            // WorkshopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.Controls.Add(this.cBox_workshop_worker);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_workshop_name);
            this.Controls.Add(this.lab_workshop_worker);
            this.Controls.Add(this.lab_workshop_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorkshopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "车间信息";
            this.Load += new System.EventHandler(this.WorkshopForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_workshop_name;
        private System.Windows.Forms.Label lab_workshop_worker;
        private System.Windows.Forms.TextBox txt_workshop_name;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lab_message;
        private System.Windows.Forms.ComboBox cBox_workshop_worker;
    }
}
namespace onlineSPC.Data
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.lab_product_name = new System.Windows.Forms.Label();
            this.lab_product_model = new System.Windows.Forms.Label();
            this.lab_product_batch = new System.Windows.Forms.Label();
            this.lab_product_text = new System.Windows.Forms.Label();
            this.txt_product_model = new System.Windows.Forms.TextBox();
            this.txt_product_batch = new System.Windows.Forms.TextBox();
            this.txt_product_text = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.lab_message = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_product_name
            // 
            this.txt_product_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_product_name.Location = new System.Drawing.Point(121, 20);
            this.txt_product_name.Multiline = true;
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.Size = new System.Drawing.Size(200, 30);
            this.txt_product_name.TabIndex = 0;
            this.txt_product_name.TextChanged += new System.EventHandler(this.txt_product_name_TextChanged);
            // 
            // lab_product_name
            // 
            this.lab_product_name.AutoSize = true;
            this.lab_product_name.BackColor = System.Drawing.SystemColors.Control;
            this.lab_product_name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_product_name.Location = new System.Drawing.Point(39, 26);
            this.lab_product_name.Name = "lab_product_name";
            this.lab_product_name.Size = new System.Drawing.Size(88, 16);
            this.lab_product_name.TabIndex = 1;
            this.lab_product_name.Text = "产品名称：";
            // 
            // lab_product_model
            // 
            this.lab_product_model.AutoSize = true;
            this.lab_product_model.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_product_model.Location = new System.Drawing.Point(39, 82);
            this.lab_product_model.Name = "lab_product_model";
            this.lab_product_model.Size = new System.Drawing.Size(88, 16);
            this.lab_product_model.TabIndex = 2;
            this.lab_product_model.Text = "产品型号：";
            // 
            // lab_product_batch
            // 
            this.lab_product_batch.AutoSize = true;
            this.lab_product_batch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_product_batch.Location = new System.Drawing.Point(39, 140);
            this.lab_product_batch.Name = "lab_product_batch";
            this.lab_product_batch.Size = new System.Drawing.Size(88, 16);
            this.lab_product_batch.TabIndex = 3;
            this.lab_product_batch.Text = "产品批次：";
            // 
            // lab_product_text
            // 
            this.lab_product_text.AutoSize = true;
            this.lab_product_text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_product_text.Location = new System.Drawing.Point(39, 185);
            this.lab_product_text.Name = "lab_product_text";
            this.lab_product_text.Size = new System.Drawing.Size(88, 16);
            this.lab_product_text.TabIndex = 4;
            this.lab_product_text.Text = "产品备注：";
            // 
            // txt_product_model
            // 
            this.txt_product_model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product_model.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_product_model.Location = new System.Drawing.Point(121, 75);
            this.txt_product_model.Multiline = true;
            this.txt_product_model.Name = "txt_product_model";
            this.txt_product_model.Size = new System.Drawing.Size(200, 30);
            this.txt_product_model.TabIndex = 1;
            this.txt_product_model.TextChanged += new System.EventHandler(this.txt_product_model_TextChanged);
            // 
            // txt_product_batch
            // 
            this.txt_product_batch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product_batch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_product_batch.Location = new System.Drawing.Point(121, 131);
            this.txt_product_batch.Multiline = true;
            this.txt_product_batch.Name = "txt_product_batch";
            this.txt_product_batch.Size = new System.Drawing.Size(200, 30);
            this.txt_product_batch.TabIndex = 2;
            this.txt_product_batch.TextChanged += new System.EventHandler(this.txt_product_batch_TextChanged);
            // 
            // txt_product_text
            // 
            this.txt_product_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_product_text.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_product_text.Location = new System.Drawing.Point(121, 186);
            this.txt_product_text.Multiline = true;
            this.txt_product_text.Name = "txt_product_text";
            this.txt_product_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_product_text.Size = new System.Drawing.Size(220, 100);
            this.txt_product_text.TabIndex = 3;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(121, 320);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 30);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "确定(&Y)";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(241, 320);
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
            this.lab_message.Location = new System.Drawing.Point(119, 299);
            this.lab_message.Name = "lab_message";
            this.lab_message.Size = new System.Drawing.Size(0, 12);
            this.lab_message.TabIndex = 10;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 361);
            this.Controls.Add(this.lab_message);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_product_text);
            this.Controls.Add(this.txt_product_batch);
            this.Controls.Add(this.txt_product_model);
            this.Controls.Add(this.lab_product_text);
            this.Controls.Add(this.lab_product_batch);
            this.Controls.Add(this.lab_product_model);
            this.Controls.Add(this.txt_product_name);
            this.Controls.Add(this.lab_product_name);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "产品参数";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Label lab_product_name;
        private System.Windows.Forms.Label lab_product_model;
        private System.Windows.Forms.Label lab_product_batch;
        private System.Windows.Forms.Label lab_product_text;
        private System.Windows.Forms.TextBox txt_product_model;
        private System.Windows.Forms.TextBox txt_product_batch;
        private System.Windows.Forms.TextBox txt_product_text;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label lab_message;
    }
}
namespace Json2Form.App {
    partial class CreateRaw {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_create = new System.Windows.Forms.Button();
            this.tb_raw = new System.Windows.Forms.TextBox();
            this.tb_wrapper = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(790, 430);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(102, 31);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // tb_raw
            // 
            this.tb_raw.Location = new System.Drawing.Point(12, 31);
            this.tb_raw.Multiline = true;
            this.tb_raw.Name = "tb_raw";
            this.tb_raw.Size = new System.Drawing.Size(354, 389);
            this.tb_raw.TabIndex = 1;
            // 
            // tb_wrapper
            // 
            this.tb_wrapper.Location = new System.Drawing.Point(372, 31);
            this.tb_wrapper.Multiline = true;
            this.tb_wrapper.Name = "tb_wrapper";
            this.tb_wrapper.Size = new System.Drawing.Size(520, 389);
            this.tb_wrapper.TabIndex = 2;
            this.tb_wrapper.Text = "head %%%%%%% tail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Raw";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(368, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wrapper";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(651, 430);
            this.tb_name.Multiline = true;
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(133, 31);
            this.tb_name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Prefix Name";
            // 
            // CreateRaw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_wrapper);
            this.Controls.Add(this.tb_raw);
            this.Controls.Add(this.btn_create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateRaw";
            this.Text = "CreateRaw";
            this.Load += new System.EventHandler(this.CreateRaw_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox tb_raw;
        private System.Windows.Forms.TextBox tb_wrapper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label3;
    }
}
namespace Json2Form.App {
    partial class Main {
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
            this.tb_json = new System.Windows.Forms.TextBox();
            this.tb_form = new System.Windows.Forms.TextBox();
            this.btn_tra = new System.Windows.Forms.Button();
            this.cb_copytoclipboard = new System.Windows.Forms.CheckBox();
            this.lb_all_raws = new System.Windows.Forms.ListBox();
            this.btn_create_prefix = new System.Windows.Forms.Button();
            this.cb_process_when_back = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_json
            // 
            this.tb_json.Location = new System.Drawing.Point(12, 12);
            this.tb_json.Multiline = true;
            this.tb_json.Name = "tb_json";
            this.tb_json.Size = new System.Drawing.Size(353, 469);
            this.tb_json.TabIndex = 0;
            // 
            // tb_form
            // 
            this.tb_form.Location = new System.Drawing.Point(595, 11);
            this.tb_form.Multiline = true;
            this.tb_form.Name = "tb_form";
            this.tb_form.Size = new System.Drawing.Size(320, 469);
            this.tb_form.TabIndex = 1;
            // 
            // btn_tra
            // 
            this.btn_tra.Location = new System.Drawing.Point(371, 383);
            this.btn_tra.Name = "btn_tra";
            this.btn_tra.Size = new System.Drawing.Size(218, 75);
            this.btn_tra.TabIndex = 2;
            this.btn_tra.Text = "To Form";
            this.btn_tra.UseVisualStyleBackColor = true;
            this.btn_tra.Click += new System.EventHandler(this.btn_tra_Click);
            // 
            // cb_copytoclipboard
            // 
            this.cb_copytoclipboard.AutoSize = true;
            this.cb_copytoclipboard.Checked = true;
            this.cb_copytoclipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_copytoclipboard.Location = new System.Drawing.Point(371, 464);
            this.cb_copytoclipboard.Name = "cb_copytoclipboard";
            this.cb_copytoclipboard.Size = new System.Drawing.Size(126, 16);
            this.cb_copytoclipboard.TabIndex = 3;
            this.cb_copytoclipboard.Text = "copy to clipboard";
            this.cb_copytoclipboard.UseVisualStyleBackColor = true;
            // 
            // lb_all_raws
            // 
            this.lb_all_raws.FormattingEnabled = true;
            this.lb_all_raws.ItemHeight = 12;
            this.lb_all_raws.Location = new System.Drawing.Point(371, 12);
            this.lb_all_raws.Name = "lb_all_raws";
            this.lb_all_raws.Size = new System.Drawing.Size(218, 184);
            this.lb_all_raws.TabIndex = 4;
            // 
            // btn_create_prefix
            // 
            this.btn_create_prefix.Location = new System.Drawing.Point(372, 202);
            this.btn_create_prefix.Name = "btn_create_prefix";
            this.btn_create_prefix.Size = new System.Drawing.Size(217, 22);
            this.btn_create_prefix.TabIndex = 5;
            this.btn_create_prefix.Text = "Create New Prefix";
            this.btn_create_prefix.UseVisualStyleBackColor = true;
            this.btn_create_prefix.Click += new System.EventHandler(this.btn_create_prefix_Click);
            // 
            // cb_process_when_back
            // 
            this.cb_process_when_back.AutoSize = true;
            this.cb_process_when_back.Location = new System.Drawing.Point(372, 230);
            this.cb_process_when_back.Name = "cb_process_when_back";
            this.cb_process_when_back.Size = new System.Drawing.Size(192, 16);
            this.cb_process_when_back.TabIndex = 6;
            this.cb_process_when_back.Text = "process when window activies";
            this.cb_process_when_back.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 493);
            this.Controls.Add(this.cb_process_when_back);
            this.Controls.Add(this.btn_create_prefix);
            this.Controls.Add(this.lb_all_raws);
            this.Controls.Add(this.cb_copytoclipboard);
            this.Controls.Add(this.btn_tra);
            this.Controls.Add(this.tb_form);
            this.Controls.Add(this.tb_json);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Json2Form";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_json;
        private System.Windows.Forms.TextBox tb_form;
        private System.Windows.Forms.Button btn_tra;
        private System.Windows.Forms.CheckBox cb_copytoclipboard;
        private System.Windows.Forms.ListBox lb_all_raws;
        private System.Windows.Forms.Button btn_create_prefix;
        private System.Windows.Forms.CheckBox cb_process_when_back;
    }
}


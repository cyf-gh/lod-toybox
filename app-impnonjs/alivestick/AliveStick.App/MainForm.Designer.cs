namespace AliveStick.App {
    partial class MainForm {
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
            this.led0 = new System.Windows.Forms.PictureBox();
            this.led1 = new System.Windows.Forms.PictureBox();
            this.led3 = new System.Windows.Forms.PictureBox();
            this.led2 = new System.Windows.Forms.PictureBox();
            this.ledBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.stickBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.led0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).BeginInit();
            this.SuspendLayout();
            // 
            // led0
            // 
            this.led0.BackColor = System.Drawing.Color.Red;
            this.led0.Location = new System.Drawing.Point(112, 10);
            this.led0.Margin = new System.Windows.Forms.Padding(2);
            this.led0.Name = "led0";
            this.led0.Size = new System.Drawing.Size(30, 32);
            this.led0.TabIndex = 0;
            this.led0.TabStop = false;
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.Red;
            this.led1.Location = new System.Drawing.Point(78, 10);
            this.led1.Margin = new System.Windows.Forms.Padding(2);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(30, 32);
            this.led1.TabIndex = 0;
            this.led1.TabStop = false;
            // 
            // led3
            // 
            this.led3.BackColor = System.Drawing.Color.Red;
            this.led3.Location = new System.Drawing.Point(9, 10);
            this.led3.Margin = new System.Windows.Forms.Padding(2);
            this.led3.Name = "led3";
            this.led3.Size = new System.Drawing.Size(30, 32);
            this.led3.TabIndex = 0;
            this.led3.TabStop = false;
            // 
            // led2
            // 
            this.led2.BackColor = System.Drawing.Color.Red;
            this.led2.Location = new System.Drawing.Point(43, 10);
            this.led2.Margin = new System.Windows.Forms.Padding(2);
            this.led2.Name = "led2";
            this.led2.Size = new System.Drawing.Size(30, 32);
            this.led2.TabIndex = 0;
            this.led2.TabStop = false;
            // 
            // ledBackgroundWorker
            // 
            this.ledBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ledBackgroundWorker_DoWork);
            // 
            // stickBackgroundWorker
            // 
            this.stickBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.stickBackgroundWorker_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 402);
            this.Controls.Add(this.led2);
            this.Controls.Add(this.led3);
            this.Controls.Add(this.led1);
            this.Controls.Add(this.led0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "AliveStick";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.led0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.led2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox led0;
        private System.Windows.Forms.PictureBox led1;
        private System.Windows.Forms.PictureBox led3;
        private System.Windows.Forms.PictureBox led2;
        private System.ComponentModel.BackgroundWorker ledBackgroundWorker;
        private System.ComponentModel.BackgroundWorker stickBackgroundWorker;
    }
}


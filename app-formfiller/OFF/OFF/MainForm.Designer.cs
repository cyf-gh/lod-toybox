namespace OFF
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv_Replacements = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFromDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmsRightClickDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invokeReplacementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplatesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Replacements)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cmsRightClickDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Replacements
            // 
            this.dgv_Replacements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Replacements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Replacements.Location = new System.Drawing.Point(0, 0);
            this.dgv_Replacements.Name = "dgv_Replacements";
            this.dgv_Replacements.RowHeadersWidth = 51;
            this.dgv_Replacements.RowTemplate.Height = 27;
            this.dgv_Replacements.Size = new System.Drawing.Size(400, 639);
            this.dgv_Replacements.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.replacementToolStripMenuItem,
            this.templateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invokeReplacementsToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // replacementToolStripMenuItem
            // 
            this.replacementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.addToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.generateFromDocToolStripMenuItem});
            this.replacementToolStripMenuItem.Name = "replacementToolStripMenuItem";
            this.replacementToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.replacementToolStripMenuItem.Text = "Replacement";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // generateFromDocToolStripMenuItem
            // 
            this.generateFromDocToolStripMenuItem.Name = "generateFromDocToolStripMenuItem";
            this.generateFromDocToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.generateFromDocToolStripMenuItem.Text = "GenerateFromDoc";
            this.generateFromDocToolStripMenuItem.Click += new System.EventHandler(this.generateFromDocToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Replacements);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1028, 639);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 2;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(624, 639);
            this.checkedListBox1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 28);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1028, 684);
            this.splitContainer2.SplitterDistance = 41;
            this.splitContainer2.TabIndex = 3;
            // 
            // cmsRightClickDgv
            // 
            this.cmsRightClickDgv.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRightClickDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsRightClickDgv.Name = "cmsRightClickDgv";
            this.cmsRightClickDgv.Size = new System.Drawing.Size(127, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // invokeReplacementsToolStripMenuItem
            // 
            this.invokeReplacementsToolStripMenuItem.Name = "invokeReplacementsToolStripMenuItem";
            this.invokeReplacementsToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.invokeReplacementsToolStripMenuItem.Text = "InvokeReplacements";
            this.invokeReplacementsToolStripMenuItem.Click += new System.EventHandler(this.invokeReplacementsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(243, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTemplatesFolderToolStripMenuItem,
            this.openOutputFolderToolStripMenuItem});
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.templateToolStripMenuItem.Text = "Template";
            // 
            // openTemplatesFolderToolStripMenuItem
            // 
            this.openTemplatesFolderToolStripMenuItem.Name = "openTemplatesFolderToolStripMenuItem";
            this.openTemplatesFolderToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.openTemplatesFolderToolStripMenuItem.Text = "OpenTemplatesFolder";
            this.openTemplatesFolderToolStripMenuItem.Click += new System.EventHandler(this.openTemplatesFolderToolStripMenuItem_Click);
            // 
            // openOutputFolderToolStripMenuItem
            // 
            this.openOutputFolderToolStripMenuItem.Name = "openOutputFolderToolStripMenuItem";
            this.openOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.openOutputFolderToolStripMenuItem.Text = "OpenOutputFolder";
            this.openOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.openOutputFolderToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 712);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Replacements)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsRightClickDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Replacements;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateFromDocToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip cmsRightClickDgv;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ToolStripMenuItem invokeReplacementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTemplatesFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openOutputFolderToolStripMenuItem;
    }
}


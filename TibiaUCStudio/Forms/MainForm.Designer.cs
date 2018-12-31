namespace TibiaUCStudio.Forms
{
    partial class MainForm
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
            this.DockPanel = new DarkUI.Docking.DarkDockPanel();
            this.darkSeparator1 = new DarkUI.Controls.DarkSeparator();
            this.mnuMain = new DarkUI.Controls.DarkMenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.thingsCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outfitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.missilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.exportASPRAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // DockPanel
            // 
            this.DockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DockPanel.Location = new System.Drawing.Point(0, 26);
            this.DockPanel.Name = "DockPanel";
            this.DockPanel.Size = new System.Drawing.Size(1186, 603);
            this.DockPanel.TabIndex = 7;
            // 
            // darkSeparator1
            // 
            this.darkSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.darkSeparator1.Location = new System.Drawing.Point(0, 24);
            this.darkSeparator1.Name = "darkSeparator1";
            this.darkSeparator1.Size = new System.Drawing.Size(1186, 2);
            this.darkSeparator1.TabIndex = 5;
            this.darkSeparator1.Text = "darkSeparator1";
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.mnuMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.thingsCategoryToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(1186, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "darkMenuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFile,
            this.mnuSaveAll,
            this.exportASPRAToolStripMenuItem,
            this.mnuExport,
            this.toolStripSeparator1,
            this.mnuClose});
            this.mnuFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenFile.Size = new System.Drawing.Size(190, 22);
            this.mnuOpenFile.Text = "Open All";
            this.mnuOpenFile.Click += new System.EventHandler(this.mnuOpenFile_Click);
            // 
            // mnuSaveAll
            // 
            this.mnuSaveAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuSaveAll.Name = "mnuSaveAll";
            this.mnuSaveAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSaveAll.Size = new System.Drawing.Size(190, 22);
            this.mnuSaveAll.Text = "Save all";
            this.mnuSaveAll.Click += new System.EventHandler(this.mnuSaveAll_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(191, 22);
            this.mnuExport.Text = "Export ASPR (Classic)";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // mnuClose
            // 
            this.mnuClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuClose.Size = new System.Drawing.Size(190, 22);
            this.mnuClose.Text = "&Close";
            // 
            // thingsCategoryToolStripMenuItem
            // 
            this.thingsCategoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemsToolStripMenuItem,
            this.outfitsToolStripMenuItem,
            this.effectsToolStripMenuItem,
            this.missilesToolStripMenuItem});
            this.thingsCategoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.thingsCategoryToolStripMenuItem.Name = "thingsCategoryToolStripMenuItem";
            this.thingsCategoryToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.thingsCategoryToolStripMenuItem.Text = "Things category";
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.itemsToolStripMenuItem.Text = "Items";
            this.itemsToolStripMenuItem.Click += new System.EventHandler(this.itemsToolStripMenuItem_Click);
            // 
            // outfitsToolStripMenuItem
            // 
            this.outfitsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.outfitsToolStripMenuItem.Name = "outfitsToolStripMenuItem";
            this.outfitsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.outfitsToolStripMenuItem.Text = "Outfits";
            this.outfitsToolStripMenuItem.Click += new System.EventHandler(this.outfitsToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.effectsToolStripMenuItem.Text = "Effects";
            this.effectsToolStripMenuItem.Click += new System.EventHandler(this.effectsToolStripMenuItem_Click);
            // 
            // missilesToolStripMenuItem
            // 
            this.missilesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.missilesToolStripMenuItem.Name = "missilesToolStripMenuItem";
            this.missilesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.missilesToolStripMenuItem.Text = "Missiles";
            this.missilesToolStripMenuItem.Click += new System.EventHandler(this.missilesToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // exportASPRAToolStripMenuItem
            // 
            this.exportASPRAToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exportASPRAToolStripMenuItem.Name = "exportASPRAToolStripMenuItem";
            this.exportASPRAToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.exportASPRAToolStripMenuItem.Text = "Export ASPR (Modern)";
            this.exportASPRAToolStripMenuItem.Click += new System.EventHandler(this.exportASPRAToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 629);
            this.Controls.Add(this.DockPanel);
            this.Controls.Add(this.darkSeparator1);
            this.Controls.Add(this.mnuMain);
            this.Name = "MainForm";
            this.Text = "Tibia UC Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkMenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private DarkUI.Controls.DarkSeparator darkSeparator1;
        private DarkUI.Docking.DarkDockPanel DockPanel;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAll;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem thingsCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outfitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem missilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportASPRAToolStripMenuItem;
    }
}
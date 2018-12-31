namespace TibiaUCStudio.Forms.Elements
{
    partial class ThingsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.spritesListView = new System.Windows.Forms.ListView();
            this.spriteImageList = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageFirst = new DarkUI.Controls.DarkButton();
            this.pagePrev = new DarkUI.Controls.DarkButton();
            this.pageLast = new DarkUI.Controls.DarkButton();
            this.pageNext = new DarkUI.Controls.DarkButton();
            this.pageCurrent = new DarkUI.Controls.DarkTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spritesListView
            // 
            this.spritesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.spritesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.spritesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritesListView.ForeColor = System.Drawing.Color.White;
            this.spritesListView.LargeImageList = this.spriteImageList;
            this.spritesListView.Location = new System.Drawing.Point(0, 0);
            this.spritesListView.Name = "spritesListView";
            this.spritesListView.Size = new System.Drawing.Size(184, 566);
            this.spritesListView.SmallImageList = this.spriteImageList;
            this.spritesListView.TabIndex = 0;
            this.spritesListView.UseCompatibleStateImageBehavior = false;
            this.spritesListView.SelectedIndexChanged += new System.EventHandler(this.spritesListView_SelectedIndexChanged);
            // 
            // spriteImageList
            // 
            this.spriteImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.spriteImageList.ImageSize = new System.Drawing.Size(32, 32);
            this.spriteImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pageFirst
            // 
            this.pageFirst.Location = new System.Drawing.Point(5, 6);
            this.pageFirst.Name = "pageFirst";
            this.pageFirst.Padding = new System.Windows.Forms.Padding(5);
            this.pageFirst.Size = new System.Drawing.Size(27, 20);
            this.pageFirst.TabIndex = 1;
            this.pageFirst.Text = "<<";
            this.pageFirst.Click += new System.EventHandler(this.pageFirst_Click);
            // 
            // pagePrev
            // 
            this.pagePrev.Location = new System.Drawing.Point(38, 6);
            this.pagePrev.Name = "pagePrev";
            this.pagePrev.Padding = new System.Windows.Forms.Padding(5);
            this.pagePrev.Size = new System.Drawing.Size(23, 20);
            this.pagePrev.TabIndex = 3;
            this.pagePrev.Text = "<";
            this.pagePrev.Click += new System.EventHandler(this.pagePrev_Click);
            // 
            // pageLast
            // 
            this.pageLast.Location = new System.Drawing.Point(153, 6);
            this.pageLast.Name = "pageLast";
            this.pageLast.Padding = new System.Windows.Forms.Padding(5);
            this.pageLast.Size = new System.Drawing.Size(27, 20);
            this.pageLast.TabIndex = 5;
            this.pageLast.Text = ">>";
            this.pageLast.Click += new System.EventHandler(this.pageLast_Click);
            // 
            // pageNext
            // 
            this.pageNext.Location = new System.Drawing.Point(126, 6);
            this.pageNext.Name = "pageNext";
            this.pageNext.Padding = new System.Windows.Forms.Padding(5);
            this.pageNext.Size = new System.Drawing.Size(23, 20);
            this.pageNext.TabIndex = 4;
            this.pageNext.Text = ">";
            this.pageNext.Click += new System.EventHandler(this.pageNext_Click);
            // 
            // pageCurrent
            // 
            this.pageCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.pageCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.pageCurrent.Location = new System.Drawing.Point(66, 6);
            this.pageCurrent.Name = "pageCurrent";
            this.pageCurrent.Size = new System.Drawing.Size(55, 20);
            this.pageCurrent.TabIndex = 6;
            this.pageCurrent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pageCurrent_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pageCurrent);
            this.panel1.Controls.Add(this.pageFirst);
            this.panel1.Controls.Add(this.pageLast);
            this.panel1.Controls.Add(this.pagePrev);
            this.panel1.Controls.Add(this.pageNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 30);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.spritesListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 566);
            this.panel2.TabIndex = 8;
            // 
            // ThingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DefaultDockArea = DarkUI.Docking.DarkDockArea.Left;
            this.DockText = "Things";
            this.Icon = global::TibiaUCStudio.Icons.application_16x;
            this.Name = "ThingsView";
            this.Size = new System.Drawing.Size(184, 621);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView spritesListView;
        private System.Windows.Forms.ImageList spriteImageList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DarkUI.Controls.DarkButton pageFirst;
        private DarkUI.Controls.DarkButton pagePrev;
        private DarkUI.Controls.DarkButton pageLast;
        private DarkUI.Controls.DarkButton pageNext;
        private DarkUI.Controls.DarkTextBox pageCurrent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

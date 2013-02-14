namespace Cauldron
{
    partial class CauldronMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CauldronMainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.showFPS = new System.Windows.Forms.CheckBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.baseDrawControl1 = new Cauldron.BaseDrawControl(this.components);
            this.freeCamera = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.freeCamera);
            this.panel2.Controls.Add(this.showFPS);
            this.panel2.Location = new System.Drawing.Point(1289, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 393);
            this.panel2.TabIndex = 3;
            // 
            // showFPS
            // 
            this.showFPS.AutoSize = true;
            this.showFPS.Location = new System.Drawing.Point(19, 187);
            this.showFPS.Name = "showFPS";
            this.showFPS.Size = new System.Drawing.Size(76, 17);
            this.showFPS.TabIndex = 0;
            this.showFPS.Text = "Show FPS";
            this.showFPS.UseVisualStyleBackColor = true;
            this.showFPS.CheckedChanged += new System.EventHandler(this.showFPS_CheckedChanged);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1412, 24);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBlockToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveBlockToolStripMenuItem
            // 
            this.saveBlockToolStripMenuItem.Name = "saveBlockToolStripMenuItem";
            this.saveBlockToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveBlockToolStripMenuItem.Text = "Save Block";
            this.saveBlockToolStripMenuItem.Click += new System.EventHandler(this.saveBlockToolStripMenuItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.baseDrawControl1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1412, 724);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // baseDrawControl1
            // 
            this.baseDrawControl1.Location = new System.Drawing.Point(3, 3);
            this.baseDrawControl1.Name = "baseDrawControl1";
            this.baseDrawControl1.Size = new System.Drawing.Size(1280, 720);
            this.baseDrawControl1.TabIndex = 0;
            this.baseDrawControl1.Text = "baseDrawControl1";
            // 
            // freeCamera
            // 
            this.freeCamera.AutoSize = true;
            this.freeCamera.Location = new System.Drawing.Point(19, 210);
            this.freeCamera.Name = "freeCamera";
            this.freeCamera.Size = new System.Drawing.Size(71, 17);
            this.freeCamera.TabIndex = 1;
            this.freeCamera.Text = "Free Cam";
            this.freeCamera.UseVisualStyleBackColor = true;
            this.freeCamera.CheckedChanged += new System.EventHandler(this.freeCam_CheckedChanged);
            // 
            // CauldronMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 748);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CauldronMainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Cauldron";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox showFPS;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlockToolStripMenuItem;
        private BaseDrawControl baseDrawControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox freeCamera;
    }
}


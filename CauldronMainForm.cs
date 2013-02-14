using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cauldron
{
    public partial class CauldronMainForm : Form
    {
        public static BGame game { get; set; }

        public static bool showingFPS = false;

        public static bool freeCam = false;

        public CauldronMainForm()
        {
            InitializeComponent();
        }

        public List<IntPtr> getBaseDrawControlList()
        {
            List<IntPtr> j = new List<IntPtr>();
            j.Add(baseDrawControl1.Handle);
            //j.Add(baseDrawControl2.Handle);
            return j;
        }

        public BaseDrawControl getBaseDrawControl()
        {
            return this.baseDrawControl1;
        }

        private void showFPS_CheckedChanged(object sender, EventArgs e)
        {
            if (showFPS.Checked)
            {
                showingFPS = true;
            }
            else
            {
                showingFPS = false;
            }
        }

        private void freeCam_CheckedChanged(object sender, EventArgs e)
        {
            if (freeCamera.Checked)
            {
                freeCam = true;
            }
            else
            {
                freeCam = false;
            }
        }

        private void saveBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.ShowDialog();
            System.IO.FileStream stream = new System.IO.FileStream(saveDialog.FileName,System.IO.FileMode.Create, System.IO.FileAccess.Write);
            byte[] b = null;
            object o;
            List<Models.Block> block = new List<Models.Block>();

            block = game.EnvironmentService.BlockList;
            o = block;
            b = (byte[])o;
            
            
            stream.Write(b, 0, b.Length);
            stream.Close();
        }

        private void saveData()
        {
        }
    }
}

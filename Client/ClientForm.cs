using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_FillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                (sender.Equals(btn_lineColor)?btn_lineColor:btn_faceColor).BackColor = colorDialog.Color;
        }

        private void DrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender.Equals(handToolStripMenuItem))
                ddbtn_drawTool.Image = handToolStripMenuItem.Image;
            else if (sender.Equals(pencilToolStripMenuItem))
                ddbtn_drawTool.Image = pencilToolStripMenuItem.Image;
            else if (sender.Equals(lineToolStripMenuItem))
                ddbtn_drawTool.Image = lineToolStripMenuItem.Image;
            else if (sender.Equals(circleToolStripMenuItem))
                ddbtn_drawTool.Image = circleToolStripMenuItem.Image;
            else
                ddbtn_drawTool.Image = rectToolStripMenuItem.Image;
        }

        private void Item_line_Click(object sender, EventArgs e)
        {
            if (sender.Equals(item_line1))
                ddbtn_line.Image = item_line1.Image;
            else if (sender.Equals(item_line2))
                ddbtn_line.Image = item_line2.Image;
            else if (sender.Equals(item_line3))
                ddbtn_line.Image = item_line3.Image;
            else if (sender.Equals(item_line4))
                ddbtn_line.Image = item_line4.Image;
            else
                ddbtn_line.Image = item_line5.Image;
        }
    }
}

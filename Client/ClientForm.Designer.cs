namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ddbtn_drawTool = new System.Windows.Forms.ToolStripDropDownButton();
            this.handToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddbtn_line = new System.Windows.Forms.ToolStripDropDownButton();
            this.item_line1 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_line2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_line3 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_line4 = new System.Windows.Forms.ToolStripMenuItem();
            this.item_line5 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Fill = new System.Windows.Forms.ToolStripButton();
            this.btn_lineColor = new System.Windows.Forms.ToolStripButton();
            this.btn_faceColor = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panel_board = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbtn_drawTool,
            this.ddbtn_line,
            this.btn_Fill,
            this.btn_lineColor,
            this.btn_faceColor});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 50);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // ddbtn_drawTool
            // 
            this.ddbtn_drawTool.AutoSize = false;
            this.ddbtn_drawTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtn_drawTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handToolStripMenuItem,
            this.pencilToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.rectToolStripMenuItem});
            this.ddbtn_drawTool.Image = global::Client.Properties.Resources.연필;
            this.ddbtn_drawTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtn_drawTool.Name = "ddbtn_drawTool";
            this.ddbtn_drawTool.Size = new System.Drawing.Size(50, 50);
            this.ddbtn_drawTool.Text = "toolStripDropDownButton1";
            // 
            // handToolStripMenuItem
            // 
            this.handToolStripMenuItem.Image = global::Client.Properties.Resources.손;
            this.handToolStripMenuItem.Name = "handToolStripMenuItem";
            this.handToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.handToolStripMenuItem.Text = "Hand";
            this.handToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItem_Click);
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Image = global::Client.Properties.Resources.연필;
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.pencilToolStripMenuItem.Text = "Pencil";
            this.pencilToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Image = global::Client.Properties.Resources.직선;
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Image = global::Client.Properties.Resources.원;
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItem_Click);
            // 
            // rectToolStripMenuItem
            // 
            this.rectToolStripMenuItem.Image = global::Client.Properties.Resources.사각형;
            this.rectToolStripMenuItem.Name = "rectToolStripMenuItem";
            this.rectToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.rectToolStripMenuItem.Text = "Rect";
            this.rectToolStripMenuItem.Click += new System.EventHandler(this.DrawToolStripMenuItem_Click);
            // 
            // ddbtn_line
            // 
            this.ddbtn_line.AutoSize = false;
            this.ddbtn_line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddbtn_line.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item_line1,
            this.item_line2,
            this.item_line3,
            this.item_line4,
            this.item_line5});
            this.ddbtn_line.Image = global::Client.Properties.Resources.line1Button;
            this.ddbtn_line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbtn_line.Name = "ddbtn_line";
            this.ddbtn_line.Size = new System.Drawing.Size(50, 50);
            this.ddbtn_line.Text = "toolStripDropDownButton2";
            // 
            // item_line1
            // 
            this.item_line1.Image = global::Client.Properties.Resources.line1Button;
            this.item_line1.Name = "item_line1";
            this.item_line1.Size = new System.Drawing.Size(214, 56);
            this.item_line1.Text = "1";
            this.item_line1.Click += new System.EventHandler(this.Item_line_Click);
            // 
            // item_line2
            // 
            this.item_line2.Image = global::Client.Properties.Resources.line2Button;
            this.item_line2.Name = "item_line2";
            this.item_line2.Size = new System.Drawing.Size(214, 56);
            this.item_line2.Text = "2";
            this.item_line2.Click += new System.EventHandler(this.Item_line_Click);
            // 
            // item_line3
            // 
            this.item_line3.Image = global::Client.Properties.Resources.line3Button;
            this.item_line3.Name = "item_line3";
            this.item_line3.Size = new System.Drawing.Size(214, 56);
            this.item_line3.Text = "3";
            this.item_line3.Click += new System.EventHandler(this.Item_line_Click);
            // 
            // item_line4
            // 
            this.item_line4.Image = global::Client.Properties.Resources.line4Button;
            this.item_line4.Name = "item_line4";
            this.item_line4.Size = new System.Drawing.Size(214, 56);
            this.item_line4.Text = "4";
            this.item_line4.Click += new System.EventHandler(this.Item_line_Click);
            // 
            // item_line5
            // 
            this.item_line5.Image = global::Client.Properties.Resources.line5Button;
            this.item_line5.Name = "item_line5";
            this.item_line5.Size = new System.Drawing.Size(214, 56);
            this.item_line5.Text = "5";
            this.item_line5.Click += new System.EventHandler(this.Item_line_Click);
            // 
            // btn_Fill
            // 
            this.btn_Fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_Fill.Image = ((System.Drawing.Image)(resources.GetObject("btn_Fill.Image")));
            this.btn_Fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Fill.Name = "btn_Fill";
            this.btn_Fill.Size = new System.Drawing.Size(47, 47);
            this.btn_Fill.Text = "채우기";
            // 
            // btn_lineColor
            // 
            this.btn_lineColor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_lineColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_lineColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_lineColor.Image = ((System.Drawing.Image)(resources.GetObject("btn_lineColor.Image")));
            this.btn_lineColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_lineColor.Name = "btn_lineColor";
            this.btn_lineColor.Size = new System.Drawing.Size(47, 51);
            this.btn_lineColor.Text = "         ";
            this.btn_lineColor.Click += new System.EventHandler(this.Btn_FillColor_Click);
            // 
            // btn_faceColor
            // 
            this.btn_faceColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_faceColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_faceColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_faceColor.Image = ((System.Drawing.Image)(resources.GetObject("btn_faceColor.Image")));
            this.btn_faceColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_faceColor.Name = "btn_faceColor";
            this.btn_faceColor.Size = new System.Drawing.Size(47, 51);
            this.btn_faceColor.Text = "         ";
            this.btn_faceColor.Click += new System.EventHandler(this.Btn_FillColor_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "line1Button.JPG");
            this.imageList1.Images.SetKeyName(1, "line2Button.JPG");
            this.imageList1.Images.SetKeyName(2, "line3Button.JPG");
            this.imageList1.Images.SetKeyName(3, "line4Button.JPG");
            this.imageList1.Images.SetKeyName(4, "line5Button.JPG");
            this.imageList1.Images.SetKeyName(5, "꽉찬 사각형.jpg");
            this.imageList1.Images.SetKeyName(6, "꽉찬 원.jpg");
            this.imageList1.Images.SetKeyName(7, "사각형.jpg");
            this.imageList1.Images.SetKeyName(8, "손.png");
            this.imageList1.Images.SetKeyName(9, "연필.jpg");
            this.imageList1.Images.SetKeyName(10, "원.jpg");
            this.imageList1.Images.SetKeyName(11, "직선.jpg");
            // 
            // panel_board
            // 
            this.panel_board.BackColor = System.Drawing.Color.White;
            this.panel_board.Location = new System.Drawing.Point(0, 50);
            this.panel_board.Name = "panel_board";
            this.panel_board.Size = new System.Drawing.Size(800, 340);
            this.panel_board.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 390);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(800, 120);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 510);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(740, 21);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_board);
            this.Controls.Add(this.toolStrip);
            this.Name = "Form1";
            this.Text = "세계그림판";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton ddbtn_drawTool;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripDropDownButton ddbtn_line;
        private System.Windows.Forms.ToolStripButton btn_Fill;
        private System.Windows.Forms.ToolStripButton btn_lineColor;
        private System.Windows.Forms.ToolStripButton btn_faceColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem handToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem item_line1;
        private System.Windows.Forms.ToolStripMenuItem item_line2;
        private System.Windows.Forms.ToolStripMenuItem item_line3;
        private System.Windows.Forms.ToolStripMenuItem item_line4;
        private System.Windows.Forms.ToolStripMenuItem item_line5;
        private System.Windows.Forms.Panel panel_board;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}


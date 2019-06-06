using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Shapes;

namespace Client
{
    public partial class Form1 : Form
    {
        NetworkStream m_Stream;
        MemoryStream ms;
        TcpClient m_Client;
        StreamReader m_Read;
        StreamWriter m_Write;
        BinaryWriter m_bWrite;
        BinaryReader m_bRead;
        private Thread m_thReader;
        bool m_bConnect;
        public static string ip, port, id;

        bool isholding = false;
        int lineSize = 1;
        int drawTool = 1;
        Point point;
        Point finish;
        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Gray);

        MyLine myLine;
        MyCircle myCircle;
        MyRect myRect;
        Shape shape;
        Bitmap bitmap;
        private List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);
            ConnectModal connectModal = new ConnectModal();
            connectModal.ShowDialog();
            Connect();
            //txt_Chat.AppendText("Asdfasdf\r\n");
        }

        private void Btn_FillColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                (sender.Equals(btn_lineColor)?btn_lineColor:btn_faceColor).BackColor = colorDialog.Color;
        }

        private void DrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender.Equals(handToolStripMenuItem))
            {
                ddbtn_drawTool.Image = handToolStripMenuItem.Image;
                drawTool = 0;   //Hand
            }
            else if (sender.Equals(pencilToolStripMenuItem))
            {
                ddbtn_drawTool.Image = pencilToolStripMenuItem.Image;
                drawTool = 1;   //Pencil
            }
            else if (sender.Equals(lineToolStripMenuItem))
            {
                ddbtn_drawTool.Image = lineToolStripMenuItem.Image;
                drawTool = 2;   //Line
            }
            else if (sender.Equals(circleToolStripMenuItem))
            {
                ddbtn_drawTool.Image = circleToolStripMenuItem.Image;
                drawTool = 3;   //Circle
            }
            else
            {
                ddbtn_drawTool.Image = rectToolStripMenuItem.Image;
                drawTool = 4;   //Rectangle
            }
        }

        private void Item_line_Click(object sender, EventArgs e)
        {
            if (sender.Equals(item_line1))
            {
                ddbtn_line.Image = item_line1.Image;
                lineSize = 1;
            }
            else if (sender.Equals(item_line2))
            {
                ddbtn_line.Image = item_line2.Image;
                lineSize = 2;
            }
            else if (sender.Equals(item_line3))
            {
                ddbtn_line.Image = item_line3.Image;
                lineSize = 3;
            }
            else if (sender.Equals(item_line4))
            {
                ddbtn_line.Image = item_line4.Image;
                lineSize = 4;
            }
            else
            {
                ddbtn_line.Image = item_line5.Image;
                lineSize = 5;
            }
            pen = new Pen(btn_lineColor.BackColor, lineSize);
        }

        private void Panel_board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var sh in shapes)
                sh.DrawShape(e);
            panel_board.BackgroundImage = bitmap;
            shape.DrawShape(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myLine = new MyLine();
            myRect = new MyRect();
            myCircle = new MyCircle();
            shape = new Shape();
        }

        private void Panel_board_MouseDown(object sender, MouseEventArgs e)
        {
            pen = new Pen(btn_lineColor.BackColor, lineSize);
            if (btn_Fill.BackColor == Color.Gray)
                brush = new SolidBrush(btn_faceColor.BackColor);
            else
                brush = new SolidBrush(Color.Transparent);
            isholding = true;
            switch (drawTool)
            {
                case 0:     //Hand
                    break;
                case 1:     //Pencil
                    break;
                case 2:     //Line
                    myLine = new MyLine();
                    shape = myLine;
                    break;
                case 3:     //Circle
                    myCircle = new MyCircle();
                    shape = myCircle;
                    break;
                case 4:     //Rectangle
                    myRect = new MyRect();
                    shape = myRect;
                    break;
            }
            point = e.Location;
        }

        private void Panel_board_MouseUp(object sender, MouseEventArgs e)
        {
            isholding = false;
            if (point.Equals(e.Location))
                return;

            switch (drawTool)
            {
                case 0:
                    break;
                //case 1:     //Pencil
                //    pencilbool = false;
                //    break;
                case 2:     //Line
                    m_Write.WriteLine("Line");
                    m_Write.WriteLine(myLine.getPoint1().X);
                    m_Write.WriteLine(myLine.getPoint1().Y);
                    m_Write.WriteLine(myLine.getPoint2().X);
                    m_Write.WriteLine(myLine.getPoint2().Y);
                    m_Write.WriteLine(myLine.GetPen().Width);
                    m_Write.WriteLine(myLine.GetPen().Color.ToArgb());
                    m_Write.Flush();
                    break;
                case 3:     //Circle
                    m_Write.WriteLine("Circle");
                    m_Write.WriteLine(myCircle.getRectC().X);
                    m_Write.WriteLine(myCircle.getRectC().Y);
                    m_Write.WriteLine(myCircle.getRectC().Width);
                    m_Write.WriteLine(myCircle.getRectC().Height);
                    m_Write.WriteLine(myCircle.GetPen().Width);
                    m_Write.WriteLine(myCircle.GetPen().Color.ToArgb());
                    m_Write.WriteLine(myCircle.GetBrush().Color.ToArgb());
                    m_Write.Flush();
                    //shapes.Add(myCircle);
                    break;
                case 4:     //Rectangle
                    m_Write.WriteLine("Rectangle");
                    m_Write.WriteLine(myRect.getRect().X);
                    m_Write.WriteLine(myRect.getRect().Y);
                    m_Write.WriteLine(myRect.getRect().Width);
                    m_Write.WriteLine(myRect.getRect().Height);
                    m_Write.WriteLine(myRect.GetPen().Width);
                    m_Write.WriteLine(myRect.GetPen().Color.ToArgb());
                    m_Write.WriteLine(myRect.GetBrush().Color.ToArgb());
                    m_Write.Flush();
                    //shapes.Add(myRect);
                    break;
            }
        }

        private void Panel_board_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isholding)
                return;
            finish = e.Location;
            switch (drawTool)
            {
                case 0:
                    break;
                case 1:     //Pencil
                    m_Write.WriteLine("Line");
                    m_Write.WriteLine(point.X);
                    m_Write.WriteLine(point.Y);
                    m_Write.WriteLine(finish.X);
                    m_Write.WriteLine(finish.Y);
                    m_Write.WriteLine(pen.Width);
                    m_Write.WriteLine(pen.Color.ToArgb());
                    m_Write.Flush();

                    point = finish;
                    break;
                case 2: //Line
                    myLine.setPoint(point, finish, pen);
                    break;
                case 3: //Circle
                    myCircle.setRectC(point, finish, pen, brush);
                    break;
                case 4: //Rectangle
                    myRect.setRect(point, finish, pen, brush);
                    break;
            }
            panel_board.Invalidate(true);
            panel_board.Update();
        }

        public void Draw()
        {
            this.Invoke(new Action(delegate ()
            {
                panel_board.Invalidate(true);
                panel_board.Update();
            }));
        }

        private void Btn_Fill_Click(object sender, EventArgs e)
        {
            if (btn_Fill.BackColor == Color.Gray)
                btn_Fill.BackColor = Color.White;
            else
                btn_Fill.BackColor = Color.Gray;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!m_bConnect)
                return;
            m_Write.WriteLine("Disconnect");
            m_Write.Flush();

            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_thReader.Abort();
        }

        private void Btn_Send_Click(object sender, EventArgs e)
        {
            m_Write.WriteLine("Message");
            m_Write.WriteLine(id + " : " +  txt_Input.Text);
            m_Write.Flush();
            txt_Input.Clear();
        }

        private void Txt_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            m_Write.WriteLine("Message");
            m_Write.WriteLine(id + " : " + txt_Input.Text);
            m_Write.Flush();
            txt_Input.Clear();
        }

        private void Panel_board_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void Panel_board_Enter(object sender, EventArgs e)
        {
            panel_board.Focus();
        }

        private void Panel_board_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        public void Connect()
        {
            m_Client = new TcpClient();
            try
            {
                m_Client.Connect(IPAddress.Parse("127.0.0.1"), 7777);
            }
            catch
            {
                m_bConnect = false;
                return;
            }
            m_bConnect = true;

            m_Stream = m_Client.GetStream();

            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);
            m_bRead = new BinaryReader(m_Stream);
            m_bWrite = new BinaryWriter(m_Stream);

            m_thReader = new Thread(new ThreadStart(Receive));
            m_thReader.Start();
        }

        private void Receive()
        {
            m_Write.WriteLine("New Client");
            m_Write.WriteLine(id);
            m_Write.Flush();            
            string receive;
            while (m_bConnect)
            {
                //this.Invoke(new Action(delegate ()
                //{
                //    txt_Chat.AppendText("dddddddd\r\n");
                //}));
                receive = m_Read.ReadLine();
                if (receive.Equals("Message"))
                {
                    string message = m_Read.ReadLine();
                    this.Invoke(new Action(delegate ()
                    {
                        txt_Chat.AppendText(message + "\r\n");
                    }));
                }
                else if (receive.Equals("Line"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLine ml = new MyLine();
                    ml.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick));
                    shape = ml;
                    shapes.Add(shape);
                }
                else if (receive.Equals("Circle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    int brush = int.Parse(m_Read.ReadLine());
                    MyCircle mc = new MyCircle();
                    mc.setRectC(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), new SolidBrush(Color.FromArgb(brush)));
                    shape = mc;
                    shapes.Add(shape);
                }
                else if (receive.Equals("Rectangle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    int brush = int.Parse(m_Read.ReadLine());
                    MyRect mr = new MyRect();
                    mr.setRect(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), new SolidBrush(Color.FromArgb(brush)));
                    shape = mr;
                    shapes.Add(shape);
                }
                else if (receive.Equals("Bitmap"))
                {
                    int length = int.Parse(m_Read.ReadLine());
                    byte[] buf = m_bRead.ReadBytes(length);
                    txt_Chat.AppendText(length + "\r\n");
                    ms = new MemoryStream(buf);
                    bitmap = new Bitmap(ms);
                    //bitmap.Save("C:/Users/junhwa/source/repos/Application_Software_3rdPractice/Client/bin/Debug/abc.bmp");
                }
                Draw();
            }
        }
    }

    public class DoubleBufferPanel : Panel
    {
        public DoubleBufferPanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
    }
}

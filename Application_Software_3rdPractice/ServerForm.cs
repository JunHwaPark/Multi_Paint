using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using Shapes;

namespace Application_Software_3rdPractice
{
    public partial class ServerForm : Form
    {
        public static string ip, port;
        public Thread m_thServer = null;
        panel_data.ShapeDataTable shapeRows = new panel_data.ShapeDataTable();
        DataRow dr;
        //Bitmap bmp = new Bitmap("C:/Users/junhwa/source/repos/Application_Software_3rdPractice/Client/bin/Debug/abc.bmp");

        public List<Shape> shapes = new List<Shape>();

        TcpListener m_listener;
        bool m_bStop;
        int index = 0;
        //public List<ServerThread> serverThreads = new List<ServerThread>();
        public ServerThread[] serverThreads = new ServerThread[10];

        public ServerForm()
        {
            InitializeComponent();
            shapeRows.ReadXml("panel_data.xml");
            
            foreach(var item in shapeRows)
            {
                Shape shape;
                if (item.Shape.Equals("Line"))
                {
                    MyLine myLine = new MyLine();
                    myLine.setPoint(new Point(item.x1, item.y1), new Point(item.x2, item.y2),
                        new Pen(Color.FromArgb(item.Color), item.thick));
                    shape = myLine;
                }
                else if (item.Shape.Equals("Circle"))
                {
                    MyCircle myCircle = new MyCircle();
                    myCircle.setRectC(new Point(item.x1, item.y1),
                        new Point(item.x1 + item.x2, item.y1 + item.y2),
                        new Pen(Color.FromArgb(item.Color), item.thick),
                        new SolidBrush(Color.FromArgb(item.Brush)));
                    shape = myCircle;
                }
                else// if (item.Shape.Equals("Rectangle"))
                {
                    MyRect myRect = new MyRect();
                    myRect.setRect(new Point(item.x1, item.y1),
                        new Point(item.x1 + item.x2, item.y1 + item.y2),
                        new Pen(Color.FromArgb(item.Color), item.thick),
                        new SolidBrush(Color.FromArgb(item.Brush)));
                    shape = myRect;
                }
                shapes.Add(shape);
            }

            //shapeRows.Rows.Add(dr);
            //txt_Chat.AppendText(shapeRows.Last().Shape);
            //shapeRows.Rows.Add(dr);
            //txt_Chat.AppendText(shapeRows[0].Shape);
            //txt_Chat.AppendText(shapeRows[0].x1.ToString());

            ConnectModal connectModal = new ConnectModal();
            connectModal.ShowDialog();

            for (int i = 0; i < 10; i++)
                serverThreads[i] = new ServerThread(this);
            
            this.m_thServer = new Thread(new ThreadStart(ServerStart));
            this.m_thServer.Start();
        }

        public void ServerStart()
        {
            m_listener = new TcpListener(IPAddress.Any, 7777);
            m_listener.Start();

            m_bStop = true;

            while (m_bStop)
            {
                TcpClient hClient = m_listener.AcceptTcpClient();
                if (hClient.Connected)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!serverThreads[i].m_bConnect)
                        {
                            index = i; break;
                        }
                    }
                    serverThreads[index].m_bConnect = true;
                    serverThreads[index].m_Stream = hClient.GetStream();
                    serverThreads[index].m_Read = new StreamReader(serverThreads[index].m_Stream);
                    serverThreads[index].m_Write = new StreamWriter(serverThreads[index].m_Stream);
                    serverThreads[index].m_bRead = new BinaryReader(serverThreads[index].m_Stream);
                    serverThreads[index].m_bWrite = new BinaryWriter(serverThreads[index].m_Stream);

                    serverThreads[index].m_thReader = new Thread(new ThreadStart(serverThreads[index].Receive));
                    serverThreads[index].m_thReader.Start();
                }
            }
        }

        public void printChat(string str)
        {
            this.Invoke(new Action(delegate ()
            {
                txt_Chat.AppendText(str + "\r\n");
            }));
        }

        public void Receive_Message(string message)
        {
            printChat(message);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].SendMessage(message);
            }
        }
        public void all_Send_Line(int x1, int y1, int x2, int y2, int thick, int Argb)
        {
            dr = shapeRows.NewRow();
            dr[0] = "Line";
            dr[1] = x1; dr[2] = y1; dr[3] = x2; dr[4] = y2;
            dr[5] = thick; dr[6] = Argb;
            shapeRows.Rows.Add(dr);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].Send_Line(x1, y1, x2, y2, thick, Argb);
            }
        }

        public void all_Send_Circle(int x1, int y1, int wid, int hei, int thick, int Argb, int brush)
        {
            dr = shapeRows.NewRow();
            dr[0] = "Circle";
            dr[1] = x1; dr[2] = y1; dr[3] = wid; dr[4] = hei;
            dr[5] = thick; dr[6] = Argb; dr[7] = brush;
            shapeRows.Rows.Add(dr);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].Send_Circle(x1, y1, wid, hei, thick, Argb, brush);
            }
        }

        public void all_Send_Rectangle(int x1, int y1, int wid, int hei, int thick, int Argb, int brush)
        {
            dr = shapeRows.NewRow();
            dr[0] = "Rectangle";
            dr[1] = x1; dr[2] = y1; dr[3] = wid; dr[4] = hei;
            dr[5] = thick; dr[6] = Argb; dr[7] = brush;
            shapeRows.Rows.Add(dr);
            for (int i = 0; i < 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                    serverThreads[i].Send_Rectangle(x1, y1, wid, hei, thick, Argb, brush);
            }
        }

        public void ServerThreadExit(ServerThread st)
        {
            if (!st.m_bConnect)
                return;

            st.m_Read.Close();
            st.m_Write.Close();

            st.m_Stream.Close();
            st.m_thReader.Abort();
        }
        private void Panel_Board_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var sh in shapes)
                sh.DrawShape(e);
        }

        public void Draw()
        {
            this.Invoke(new Action(delegate ()
            {
                panel_Board.Invalidate(false);
                panel_Board.Update();
            }));
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_listener.Stop();
            m_thServer.Abort();

            for(int i = 0; i< 10; i++)
            {
                if (serverThreads[i].m_bConnect)
                {
                    serverThreads[i].m_Read.Close();
                    serverThreads[i].m_Write.Close();

                    serverThreads[i].m_Stream.Close();
                    serverThreads[i].m_thReader.Abort();
                }
            }
            shapeRows.WriteXml("panel_data.xml");
        }
    }

    public class ServerThread
    {
        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        public BinaryWriter m_bWrite;
        public BinaryReader m_bRead;
        public BinaryFormatter bf;
        public MemoryStream ms;
        public bool m_bConnect = false;
        private ServerForm serverForm;
        public Thread m_thReader = null;
        private string connectedClient;

        public ServerThread(ServerForm serverForm)
        {
            this.serverForm = serverForm;
        }

        public void Receive()
        {
            string Request;
            while (m_bConnect)
            {
                Request = m_Read.ReadLine();
                if (Request.Equals("New Client"))
                {
                    connectedClient = m_Read.ReadLine();
                    serverForm.printChat(connectedClient + "이(가) 입장했습니다.");
                }
                else if (Request.Equals("Message"))
                {
                    serverForm.Receive_Message(m_Read.ReadLine());
                }
                else if (Request.Equals("Line"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int x2 = int.Parse(m_Read.ReadLine());
                    int y2 = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    MyLine myLine = new MyLine();
                    myLine.setPoint(new Point(x1, y1), new Point(x2, y2), new Pen(Color.FromArgb(Argb), thick));
                    Shape shape = myLine;
                    serverForm.shapes.Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Line(x1, y1, x2, y2, thick, Argb);
                }
                else if (Request.Equals("Circle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    int brush = int.Parse(m_Read.ReadLine());
                    MyCircle myCircle = new MyCircle();
                    myCircle.setRectC(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), new SolidBrush(Color.FromArgb(brush)));
                    Shape shape = myCircle;
                    serverForm.shapes.Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Circle(x1, y1, wid, hei, thick, Argb, brush);
                }
                else if (Request.Equals("Rectangle"))
                {
                    int x1 = int.Parse(m_Read.ReadLine());
                    int y1 = int.Parse(m_Read.ReadLine());
                    int wid = int.Parse(m_Read.ReadLine());
                    int hei = int.Parse(m_Read.ReadLine());
                    int thick = int.Parse(m_Read.ReadLine());
                    int Argb = int.Parse(m_Read.ReadLine());
                    int brush = int.Parse(m_Read.ReadLine());
                    MyRect myRect = new MyRect();
                    myRect.setRect(new Point(x1, y1), new Point(x1 + wid, y1 + hei), new Pen(Color.FromArgb(Argb), thick), new SolidBrush(Color.FromArgb(brush)));
                    Shape shape = myRect;
                    serverForm.shapes.Add(shape);
                    serverForm.Draw();

                    serverForm.all_Send_Rectangle(x1, y1, wid, hei, thick, Argb, brush);
                }
                else if (Request.Equals("Disconnect"))
                {
                    serverForm.printChat(connectedClient + "이(가) 퇴장했습니다.");
                    m_bConnect = false;
                    return;
                }
            }
            serverForm.ServerThreadExit(this);
        }

        public void SendMessage(string message)
        {
            m_Write.WriteLine("Message");
            m_Write.WriteLine(message);
            m_Write.Flush();
        }

        public void Send_Line(int x1, int y1, int x2, int y2, int thick, int Argb)
        {
            m_Write.WriteLine("Line");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(x2);
            m_Write.WriteLine(y2);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.Flush();
        }

        public void Send_Circle(int x1, int y1, int wid, int hei, int thick, int Argb, int brush)
        {
            m_Write.WriteLine("Circle");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(wid);
            m_Write.WriteLine(hei);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.WriteLine(brush);
            m_Write.Flush();
        }

        public void Send_Rectangle(int x1, int y1, int wid, int hei, int thick, int Argb, int brush)
        {
            m_Write.WriteLine("Rectangle");
            m_Write.WriteLine(x1);
            m_Write.WriteLine(y1);
            m_Write.WriteLine(wid);
            m_Write.WriteLine(hei);
            m_Write.WriteLine(thick);
            m_Write.WriteLine(Argb);
            m_Write.WriteLine(brush);
            m_Write.Flush();
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
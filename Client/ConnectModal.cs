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
    public partial class ConnectModal : Form
    {
        public ConnectModal()
        {
            InitializeComponent();
        }

        private void Btn_Server_Click(object sender, EventArgs e)
        {
            Form1.ip = txt_ip.Text;
            Form1.port = txt_port.Text;
            Form1.id = txt_id.Text;
            this.Close();
        }

        private void Txt_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            Form1.ip = txt_ip.Text;
            Form1.port = txt_port.Text;
            Form1.id = txt_id.Text;
            this.Close();
        }
    }
}

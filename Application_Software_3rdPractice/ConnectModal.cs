using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Software_3rdPractice
{
    public partial class ConnectModal : Form
    {
        public ConnectModal()
        {
            InitializeComponent();
        }

        private void Btn_Server_Click(object sender, EventArgs e)
        {
            ServerForm.ip = txt_ip.Text;
            ServerForm.port = txt_port.Text;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ServiceReference1;
using Message = Client.ServiceReference1.Message;

namespace Client
{
    public partial class Form1 : Form, IService1Callback
    {
        bool isConnected = false;
        Service1Client client;
        int ID;
        public Form1()
        {
            InitializeComponent();
        }
        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new Service1Client(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(textBox1.Text);
                isConnected = true;
                button1.Text = "Отключиться";
                richTextBox1.Text = ID.ToString();
                textBox1.Enabled = false;
                Message[] prevMessages = client.GetPrevMessages(ID);
                for (int i = 0; i < prevMessages.Length; i++)
                {
                    listBox1.Items.Add(Convert.ToDateTime(prevMessages[i].SendTime.ToString()).ToString("HH:mm:ss") + " " + prevMessages[i].UserName + " " + prevMessages[i].Text);
                }
            }
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                isConnected = false;
                button1.Text = "Подключиться";
                textBox1.Enabled = true;

                listBox1.Items.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }
        public void MsgCallback(string msg)
        {
            listBox1.Items.Add(msg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectUser();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(richTextBox1.Text, ID);
                    richTextBox1.Text = "";
                }
            }
        }
    }
}

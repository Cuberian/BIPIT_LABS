using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceReference.ServiceClient service = new ServiceReference.ServiceClient();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (service.isHostAlive())
                {
                    service.NewRec(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), dateTimePicker1.Value);
                    dataGridView1.DataSource = service.GetData();
                }
            }
            catch
            {
                MessageBox.Show("Host unreachable!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (service.isHostAlive())
                {
                    dataGridView1.DataSource = service.GetData();

                    comboBox1.DataSource = new BindingSource(service.GetClients(), null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";

                    comboBox2.DataSource = new BindingSource(service.GetServices(), null);
                    comboBox2.DisplayMember = "Value";
                    comboBox2.ValueMember = "Key";
                }
            }
            catch
            {
                MessageBox.Show("Host unreachable!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

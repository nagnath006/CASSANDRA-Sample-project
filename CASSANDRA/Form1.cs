using Cassandra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASSANDRA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Cluster _cluster;
        ISession _session;

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
             _session = _cluster.Connect("hr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _session.Execute("insert into users (lastname, city, email, firstname) values ( '" +txtLastName.Text + "' ,'" + txtCity.Text + "' ,'" + txtEmail.Text + "' ,'" + txtFName.Text +"' )" );
            MessageBox.Show("Record Inserted");
            
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           string abh = txtLastName.Text + "' ,'" + txtCity.Text + "' ,'" + txtEmail.Text + "' ,'" + txtFName.Text;
            
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            var a = _session.Execute("select * from users");
            var rows = a.GetRows().ToList();

            DataTable table = new DataTable();
            table.Columns.Add("LName", typeof(string));
            table.Columns.Add("City", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("FName", typeof(string));

            foreach (var row in rows)
            {
                object[] array = new object[row.Length];
                for(int i=0;i<row.Length;i++)
                {
                    array[i] = row[i];

                }
                table.Rows.Add(array);

            }

            dataGridView1.DataSource = table;

           //var b = _session.Execute("select city from users");
           //var c = _session.Execute("select email from users");
           //var d = _session.Execute("select firstname from users");
            
            
            //dataGridView1.ColumnCount = 4;
            //dataGridView1.Columns[0].Name = "Lastname";
            //dataGridView1.Columns[1].Name = "City";
            //dataGridView1.Columns[2].Name = "Email";
            //dataGridView1.Columns[3].Name = "Firstname";

            //string[] row = new string[] {a.ToString(),b.ToString(),c.ToString(),d.ToString()};
            //dataGridView1.Rows.Add(row);

            txtLastName.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtFName.Text = "";
           
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
    }
}

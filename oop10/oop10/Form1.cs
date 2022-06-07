using System.Text;
using System;
using System.Net;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace oop10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var column1 = new DataGridViewColumn();

            column1.HeaderText = "Host adress"; //����� � �����
            column1.Width = 500; //������ �������
            //column1.ReadOnly = true; //�������� � ���� ������� ������ �������
            column1.Name = "name"; //��������� ��� �������, ��� ����� ������������ ������ ��������� �� �������
            column1.Frozen = true; //����, ��� ������ ������� ������ ������������ �� ����� �����
            column1.CellTemplate = new DataGridViewTextBoxCell(); //��� ����� �������

            
            dataGridView1.Columns.Add(column1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    sb.Append(dataGridView1.Rows[row].Cells[col].Value);
                }
            }
            sb.ToString(); // ��� ���� ������

            //textBox1.Text = sb.ToString();


            //������� WebRequest-������ no URI-������.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sb.ToString());

            //���������� ���� ������ � �������� �����.
            HttpWebResponse resp = (HttpWebResponse)
              req.GetResponse();
            //�������� ������ ����.
            string[] names = resp.Headers.AllKeys;
            //���������� ��������� � ���� ��� ���/��������.
            string text = "";
            text += ( "Name", "Value").ToString() + Environment.NewLine;
            foreach (string n in names)
               text += ($"", n, resp.Headers[n]).ToString() + Environment.NewLine;
            //��������� �����, ���������� �����.
            resp.Close();

           // textBox2.Text = text;

            List<string> list = new List<string>();

            string Path = "C://OOP10/Text";

            StreamWriter write = new StreamWriter(Path);

            list.Add(text);
            foreach (var item in list)
            {
                write.WriteLine(item);
            }

            write.Close();
            

        }
    }
}
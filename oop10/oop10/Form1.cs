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

            column1.HeaderText = "Host adress"; //текст в шапке
            column1.Width = 500; //ширина колонки
            //column1.ReadOnly = true; //значение в этой колонке нельз€ править
            column1.Name = "name"; //текстовое им€ колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данна€ колонка всегда отображаетс€ на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            
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
            sb.ToString(); // это ваша строка

            //textBox1.Text = sb.ToString();


            //—оздаем WebRequest-запрос no URI-адресу.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sb.ToString());

            //ќтправл€ем этот запрос и получаем ответ.
            HttpWebResponse resp = (HttpWebResponse)
              req.GetResponse();
            //ѕолучаем список имен.
            string[] names = resp.Headers.AllKeys;
            //ќтображаем заголовок в виде пар им€/значение.
            string text = "";
            text += ( "Name", "Value").ToString() + Environment.NewLine;
            foreach (string n in names)
               text += ($"", n, resp.Headers[n]).ToString() + Environment.NewLine;
            //«акрываем поток, содержащий ответ.
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
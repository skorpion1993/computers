using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.товарыTableAdapter.Fill(this.база_даннхDataSet.Товары);
            //Автозаполнение при запуске
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
            //Добавление
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") { 
            товарыBindingSource.Filter = "[Товар] LIKE'*" + textBox1.Text + "%'";
            }
            //Поиск по товару
            else if
                (textBox2.Text != "")
            {
                товарыBindingSource.Filter = "[Дата_закупа] LIKE'*" + textBox1.Text + "%'";
            }
            //Поиск по дате закупа
            else if
               (textBox3.Text != "" && textBox4.Text != "")
            {
                товарыBindingSource.Filter = "[Количество ед_товара] >=" + textBox3.Text + "AND [Количество ед_товара] <=" + textBox4.Text +"";
            }
            //Поиск по сумме указываются оба параметра
        }

        private void button3_Click(object sender, EventArgs e)
        {
            товарыBindingSource.Filter = String.Empty;
            this.товарыTableAdapter.Fill(this.база_даннхDataSet.Товары);
            //Обновление данных
        }
    }
    }

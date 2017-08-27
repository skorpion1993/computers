using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace inventory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string towar, data_zakupa, cena, kol=null;
            //Создание новых переменных
            towar = textBox1.Text;
            data_zakupa = maskedTextBox1.Text;
            cena = textBox3.Text;
            kol = textBox4.Text;
            //Получение данных из формы
            string connectionString =
               "provider=Microsoft.Jet.OLEDB.4.0;" +
               "data source=База даннх.mdb";
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            //Подключение к базе данных
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            myOleDbConnection.Open();
            myOleDbCommand.CommandText = "INSERT INTO Товары ([Товар], [Дата_закупа], [Стоимость_закупа], [Количество ед_товара]) VALUES (?, ?, ?, ?)";
            //Запрос на добавление
            myOleDbCommand.Parameters.Add("@Товар", OleDbType.VarChar, 255, towar);
            myOleDbCommand.Parameters.Add("@Дата_закупа", OleDbType.DBDate, 255, data_zakupa);
            myOleDbCommand.Parameters.Add("@Стоимость_закупа", OleDbType.Integer, 16777215, cena);
            myOleDbCommand.Parameters.Add("@Количество ед_товара", OleDbType.Integer, 16777215, kol);
            //Связывание для защиты
            myOleDbCommand.ExecuteNonQuery();
            myOleDbConnection.Close();
        }
    }
}

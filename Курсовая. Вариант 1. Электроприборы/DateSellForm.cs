using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсовая.Вариант_1.Электроприборы
{
    public partial class DateSellForm : Form
    {
        SqlConnection connection;
        public DateSellForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала периода не может быть позже даты конца периода!");
            }
            else
            {
                string select = $@"select (select count(ID) from [Sales log] where [Date of sale] between 
'{dateTimePicker1.Value.Year} - {dateTimePicker1.Value.Month} - {dateTimePicker1.Value.Day}' and 
'{dateTimePicker2.Value.Year} - {dateTimePicker2.Value.Month} - {dateTimePicker2.Value.Day}') /
(cast((select count(ID) from [Sales log]) as float) / 100);";
                try 
                {
                    SqlCommand sqlCommand = new SqlCommand(select, connection);
                    connection.Open();
                    double res = (double)sqlCommand.ExecuteScalar();                                     
                    MessageBox.Show($"Доля товаров проданных за выбранный период - {res}%");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

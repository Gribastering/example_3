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
    public partial class AvgDateForm : Form
    {
        SqlConnection connection;
        public AvgDateForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker3.Value > dateTimePicker4.Value)
            {
                MessageBox.Show("Дата начала периода не может быть позже даты конца периода!");
            }
            else
            {
                string select = $@"select AVG(sl.[Price]) from [Product list] pl JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN [EA_type] t
ON t.[ID] = pl.[Type_ID]
where sl.[Date of sale] between 
'{dateTimePicker3.Value.Year}-{dateTimePicker3.Value.Month}-{dateTimePicker3.Value.Day}' and 
'{dateTimePicker4.Value.Year}-{dateTimePicker4.Value.Month}-{dateTimePicker4.Value.Day}';";
                try
                {
                    SqlCommand comander = new SqlCommand(select, connection);
                    connection.Open();
                    decimal res = (decimal)comander.ExecuteScalar();
                    MessageBox.Show($"Средняя стоимость товаров проданных за выбранный период составляет - {res}$");
                }
                catch
                {
                    MessageBox.Show("Товары проданные за данный период не найдены!");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

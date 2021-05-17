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
    public partial class EditForm : Form
    {
        SqlConnection connection;
        public EditForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == null ||
                comboBox2.Text == null ||
                textBox1.Text == null ||
                dateTimePicker1.Value == null ||
                numericUpDown1.Value == 0 ||
                dateTimePicker2.Value == null ||
                numericUpDown2.Value == 0)
            {
                MessageBox.Show("Для редактирования записи заполните все поля!!!");
            }
            else
            {
                try
                {
                    SqlCommand command_1 = new SqlCommand();
                    SqlCommand command_2 = new SqlCommand();
                    SqlCommand command_3 = new SqlCommand(@"select COUNT([ID]) from [Product list];", connection);
                    SqlCommand command_4 = new SqlCommand(@"select COUNT([ID]) from [Sales log];", connection);

                    command_1.Connection = connection;
                    command_2.Connection = connection;

                    // создание параметров для последующих insert-query
                    // т.к. таблицы нормализваны, запись необходимо добавлять в две таблицы
                    command_1.Parameters.Add("@type", SqlDbType.Int).Value = comboBox1.SelectedIndex + 1;
                    command_1.Parameters.Add("@manufacturers", SqlDbType.Int).Value = comboBox2.SelectedIndex + 1;
                    command_1.Parameters.Add("@product_code", SqlDbType.Int).Value = int.Parse(textBox1.Text);

                    int defect_status;
                    if (checkBox1.Checked == true)
                    {
                        defect_status = 1;
                    }
                    else
                    {
                        defect_status = 2;
                    }

                    command_1.Parameters.Add("@defect_status", SqlDbType.Int).Value = defect_status;
                    command_1.Parameters.Add("@manufacture_date", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command_1.Parameters.Add("@mass", SqlDbType.Float).Value = numericUpDown1.Value;

                    command_2.Parameters.Add("@sell_date", SqlDbType.Date).Value = dateTimePicker2.Value;
                    command_2.Parameters.Add("@price", SqlDbType.Money).Value = numericUpDown2.Value;
                    command_2.Parameters.Add("@product_code", SqlDbType.Int).Value = int.Parse(textBox1.Text);

                    //запись в таблице Product list не изменяем, а просто добавляем новую, чтобы сохранить данные об изменном артикуле
                    //а в Sales Log редактируем
                    command_1.CommandText = @"insert into [Product list] values (@type, @manufacturers, @product_code, @manufacture_date, @mass, @defect_status);";
                    command_2.CommandText = $@"UPDATE [Sales log] SET [Product_ID]=(select MAX([ID]) from [Product list]), [Date of sale]=@sell_date, [Price]=@price
where [ID]={numericUpDown3.Value};";

                   
                   
                    if (dateTimePicker1.Value <= dateTimePicker2.Value)
                    {
                        connection.Open();

                        int res = command_1.ExecuteNonQuery();
                        int res_1 = command_2.ExecuteNonQuery();

                        // проверяем, добавлена ли запись
                        if (res>0 &&
                            res_1 >0)
                        {
                            MessageBox.Show("Запись успешно отредактирована");
                        }
                        else
                        {
                            MessageBox.Show(@"Что-то пошло не так. Повторите попытку или обратитесь к тому, кто написал эту ерунду.
Возможно запись с таким ID отсутствует в БД.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Дата продажи не может быть ранее даты производства.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // ограничение на ввод в текст-бокс всего кроме цифр
            char x = e.KeyChar;
            if (!Char.IsDigit(x))
            {
                e.Handled = true;
            }
        }
    }
}
    


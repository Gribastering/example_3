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
    public partial class AvgPriceForm : Form
    {
        SqlConnection connection;
        public AvgPriceForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select;
            decimal res;

            if (comboBox2.SelectedItem == null)
            {
                select = @"select AVG(sl.[Price]) from [Product list] pl JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID];";
            }
            else 
            {
                select = $@"select AVG(sl.[Price]) from [Product list] pl JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID] 
JOIN [EA_type] t
ON t.[ID]=pl.[Type_ID]
where t.[Name]='{comboBox2.SelectedItem}';";
            }

            try
            {
                SqlCommand sqlCommander = new SqlCommand(select, connection);
                connection.Open();
                res = (decimal)sqlCommander.ExecuteScalar();
                if (comboBox2.SelectedItem==null)
                {
                    MessageBox.Show($"Средняя стоимость электроприборов всех типов составляет  - {res}");
                }
                else 
                {
                    MessageBox.Show($"Средняя стоимость электроприборов типа {comboBox2.SelectedItem} составляет  - {res}");
                }          
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

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
    public partial class QueryForm : Form
    {
        SqlConnection connection;
       
        public QueryForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AvgPriceForm form_AVG_Price = new AvgPriceForm(connection); ;
            form_AVG_Price.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string select = @"select t.[Name] from [Product list] pl JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID]
where
(select MAX(sl.[Price]) from[Product list] pl JOIN[Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID]) = sl.[Price]; ";

                SqlCommand sqlCommand = new SqlCommand(select, connection);
                connection.Open();
                string res = (string)sqlCommand.ExecuteScalar();
                MessageBox.Show($"Самый дорогой тип электроприборов - {res}");
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string select = @"select t.[Name] from [Product list] pl JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID]
where
(select MIN(sl.[Price]) from[Product list] pl JOIN[Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID]) = sl.[Price]; ";

                SqlCommand sqlCommand = new SqlCommand(select, connection);
                connection.Open();
                string res = (string)sqlCommand.ExecuteScalar();
                MessageBox.Show($"Самый дешевый тип электроприборов - {res}");
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

        private void button5_Click(object sender, EventArgs e)
        {
            RangePriceForm rangePriceForm = new RangePriceForm(connection);
            rangePriceForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManufacturesForm manufacturesForm = new ManufacturesForm(connection);
            manufacturesForm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateForm dateForm = new DateForm(connection);
            dateForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MassForm massForm = new MassForm(connection);
            massForm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DateSellForm dateSellForm = new DateSellForm(connection);
            dateSellForm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string select = 
                $@"select top 1 table_1.t from(select COUNT(pl.[Type_ID]) c, tp.[Name] t from [Product list] pl
 JOIN [Sales log] sl
 ON pl.[Type_ID] = sl.[Product_ID]
 JOIN [EA_type] tp
 ON pl.[Type_ID]= tp.[ID]
 GROUP BY tp.[Name]) as table_1
 ORDER BY c desc;";
            try
            {
                SqlCommand command = new SqlCommand(select, connection);
                connection.Open();
                string res = (string)command.ExecuteScalar();
                MessageBox.Show($"Самый популярный вид электроприбора - {res}.");
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

        private void button10_Click(object sender, EventArgs e)
        {
            CheapForm cheapForm = new CheapForm(connection);
            cheapForm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DefectiveForm defectiveForm = new DefectiveForm(connection);
            defectiveForm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AvgDateForm avgDateForm = new AvgDateForm(connection);
            avgDateForm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            HigherThanAvgForm higherThanAvgForm = new HigherThanAvgForm(connection);
            higherThanAvgForm.ShowDialog();
        }
    }
}

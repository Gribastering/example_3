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
    public partial class CheapForm : Form
    {
        SqlConnection connection;
        public CheapForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select;
            if (comboBox2.SelectedItem==null)
            {
                select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
[Price] ""Цена продажи"",  [Date of sale] ""Дата продажи"", 
c.[Name] ""Страна - производитель"",  pl.[Product code]  ""Артикул"", t.[Name] ""Тип электроприбора"", ds.[Defective status] ""Товар бракован?"" 
from [Product list] pl
JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN [Manufacturers] m
ON pl.[Manufacturers_ID] = m.ID
JOIN [Defective subtable] ds
ON pl.[Defective status ID] = ds.[ID]
JOIN [Countries] c
ON c.[ID] = m.[Country ID]
JOIN [EA_type] t
ON t.[ID] = pl.[Type_ID]
where sl.[Price] < {numericUpDown1.Value};";
            }
            else 
            {
                select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
[Price] ""Цена продажи"",  [Date of sale] ""Дата продажи"", 
c.[Name] ""Страна - производитель"",  t.[Name] ""Тип электроприбора"", ds.[Defective status] ""Товар бракован?"" 
from [Product list] pl
JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN [Manufacturers] m
ON pl.[Manufacturers_ID] = m.ID
JOIN [Defective subtable] ds
ON pl.[Defective status ID] = ds.[ID]
JOIN [Countries] c
ON c.[ID] = m.[Country ID]
JOIN [EA_type] t
ON t.[ID] = pl.[Type_ID]
where sl.[Price] < {numericUpDown1.Value}
and m.[Name]='{comboBox2.SelectedItem}';";
            }
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "table_1");
                dataGridView1.DataSource = dataSet.Tables["table_1"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

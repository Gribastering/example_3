using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Курсовая.Вариант_1.Электроприборы
{
    public partial class SearchForm : Form
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataSet set;
        SqlCommandBuilder commander;
        string select;

        public SearchForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null &&
                comboBox2.SelectedItem == null)
            {               
               select =
                    @"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
ON t.[ID] = pl.[Type_ID];";
            }
            else if (comboBox1.SelectedItem != null &&
                comboBox2.SelectedItem == null)
            {              
                int sort_index = comboBox1.SelectedIndex+2;
               select =
                    $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
[Price] ""Цена продажи"",  [Date of sale] ""Дата продажи"", 
c.[Name] ""Страна - производитель"", pl.[Product code]  ""Артикул"", t.[Name] ""Тип электроприбора"", ds.[Defective status] ""Товар бракован?""
from [Product list] pl
JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN [Manufacturers] m
ON pl.[Manufacturers_ID] = m.ID
JOIN [Defective subtable] ds
ON pl.[Defective status ID] = ds.[ID]
JOIN [Countries] c
ON c.[ID] = m.[Country ID]
JOIN[EA_type] t
ON t.[ID] = pl.[Type_ID]
ORDER BY {sort_index};";
            }
            else if (comboBox1.SelectedItem == null &&
                comboBox2.SelectedItem != null)
            {
                string type = comboBox2.SelectedItem.ToString();
                select =
                        $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
[Price] ""Цена продажи"",  [Date of sale] ""Дата продажи"", 
c.[Name] ""Страна - производитель"", pl.[Product code]  ""Артикул"", t.[Name] ""Тип электроприбора"", ds.[Defective status] ""Товар бракован?"" 
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
where t.[Name]='{type}';";
            }
            else if (comboBox1.SelectedItem != null &&
                comboBox2.SelectedItem != null)
            {
                string type = comboBox2.SelectedItem.ToString();
                int sort_index = comboBox1.SelectedIndex+2;
                select =
                    $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
[Price] ""Цена продажи"",  [Date of sale] ""Дата продажи"", 
c.[Name] ""Страна - производитель"",  pl.[Product code]  ""Артикул"", t.[Name] ""Тип электроприбора"", ds.[Defective status] ""Товар бракован?""
from [Product list] pl
JOIN [Sales log] sl
ON pl.[ID] = sl.[Product_ID]
JOIN[Manufacturers] m
ON pl.[Manufacturers_ID] = m.ID
JOIN [Defective subtable] ds
ON pl.[Defective status ID] = ds.[ID]
JOIN [Countries] c
ON c.[ID] = m.[Country ID]
JOIN [EA_type] t
ON t.[ID] = pl.[Type_ID]
where t.[Name]='{type}'
ORDER BY {sort_index};";                
            }
            try
            {
                adapter = new SqlDataAdapter(select, connection);
                commander = new SqlCommandBuilder(adapter);
                set = new DataSet();
                adapter.Fill(set, "table_1");
                dataGridView1.DataSource = set.Tables["table_1"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adapter.Update(set, "table_1");
        }
    }
}

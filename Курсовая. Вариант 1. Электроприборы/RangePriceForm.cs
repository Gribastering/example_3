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
    public partial class RangePriceForm : Form
    {
        SqlConnection connection;
        public RangePriceForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select =
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
where sl.[Price] BETWEEN {numericUpDown1.Value} and {numericUpDown2.Value};";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();
                adapter.Fill(set, "table_1");
                dataGridView1.DataSource = set.Tables["table_1"];
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}

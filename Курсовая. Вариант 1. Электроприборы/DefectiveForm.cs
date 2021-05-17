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
    public partial class DefectiveForm : Form
    {
        SqlConnection connection;
        public DefectiveForm(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;
            comboBox1.SelectedIndex = 10;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;
            comboBox6.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = false;
            comboBox9.Visible = false;
            comboBox10.Visible = false;
            comboBox11.Visible = false;
            comboBox12.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null) 
            {
                comboBox1.SelectedIndex = 10;
            }
            string select="";

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    if (comboBox2.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else 
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox2.SelectedItem}';";
                    }
                    break;
                case 1:
                    if (comboBox3.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox3.SelectedItem}';";
                    }
                    break;
                case 2:
                    if (comboBox4.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox4.SelectedItem}';";
                    }
                    break;
                case 3:
                    if (comboBox5.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox5.SelectedItem}';";
                    }
                    break;
                case 4:
                    if (comboBox6.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox6.SelectedItem}';";
                    }
                    break;
                case 5:
                    if (comboBox7.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox7.SelectedItem}';";
                    }
                    break;
                case 6:
                    if (comboBox8.SelectedItem == null)
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox8.SelectedItem}';";
                    }
                    break;
                case 7:
                    if (comboBox9.SelectedItem == null)
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox9.SelectedItem}';";
                    }
                    break;
                case 8:
                    if (comboBox10.SelectedItem == null)
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox10.SelectedItem}';";
                    }
                    break;
                case 9:
                    if (comboBox11.SelectedItem == null)
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where c.[Name]='{comboBox1.SelectedItem}'
and ds.[Defective status]='+';";
                    }
                    else
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and c.[Name]='{comboBox1.SelectedItem}'
and m.[Name]='{comboBox11.SelectedItem}';";
                    }
                    break;
                case 10:
                    if (comboBox12.SelectedIndex == -1)
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+';";
                    }
                    else 
                    {
                        select = $@"select sl.[ID] ""ID"", [Date of manufacture] ""Дата производства"", m.[Name] ""Производитель"", [Mass] ""Масса"",
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
where ds.[Defective status]='+'
and m.[Name]='{comboBox12.SelectedItem}';";
                    }
                    break;
            }
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();
                adapter.Fill(set, "Table_1");
                dataGridView1.DataSource = set.Tables["table_1"];
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void UpdateForm()
        {           
            switch (comboBox1.SelectedIndex) 
            {                
                case 0:
                    comboBox2.Visible = true;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 1:
                    comboBox2.Visible = false;
                    comboBox3.Visible = true;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 2:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = true;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 3:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = true;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 4:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = true;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 5:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = true;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 6:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = true;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 7:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = true;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 8:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = true;
                    comboBox11.Visible = false;
                    comboBox12.Visible = false;
                    break;
                case 9:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = true;
                    comboBox12.Visible = false;
                    break;
                case 10:
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    comboBox4.Visible = false;
                    comboBox5.Visible = false;
                    comboBox6.Visible = false;
                    comboBox7.Visible = false;
                    comboBox8.Visible = false;
                    comboBox9.Visible = false;
                    comboBox10.Visible = false;
                    comboBox11.Visible = false;
                    comboBox12.Visible = true;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            UpdateForm();
        }
    }
}

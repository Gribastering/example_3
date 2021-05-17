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
using System.IO;
using System.Configuration;


namespace Курсовая.Вариант_1.Электроприборы
{
    public partial class MainForm : Form
    {
        SqlConnection connection;
        public MainForm()
        {
            //Строка подключения к БД находится в файле App.Config.
            //Достаточно скорректировать адрес сервера в нем, имя строки - "ConnectionString"
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        SearchForm searchForm;
        EditForm editForm;

        private void Search_Click(object sender, EventArgs e)
        {
            if (searchForm != null)
            {
                searchForm.Close();
            }
            searchForm = new SearchForm(connection);
            searchForm.Show();
           
        }

        private void Query_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm(connection);
            queryForm.ShowDialog();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreateForm createForm = new CreateForm(connection);
            createForm.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (editForm != null) 
            {
                editForm.Close();
            }
            editForm = new EditForm(connection);
            editForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kpCRM
{
    public partial class executionChangeForm : Form
    {
        private loadDbServices loadDbServices = new loadDbServices();
        private SqlDataAdapter adapter;
        public executionChangeForm()
        {
            InitializeComponent();
        }

        private void executionChangeForm_Load(object sender, EventArgs e)
        {

        }

        private void loadDataGridview2()
        {
            adapter = loadDbServices.loadExecutionsStatus(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void updateDataGrid()
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

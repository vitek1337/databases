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
    public partial class fastQuerryForm : Form
    {
        private string querryString;
        private bool isUsed;
        public userPanel _userPanel;   
        public fastQuerryForm(userPanel userPanel)
        {
            InitializeComponent();
            _userPanel = userPanel;
            Isused = false;
        }

        public string QuerryString { get { return querryString; } set {  querryString = value; } }

        public bool Isused {  get { return isUsed; } set {  isUsed = value; } }
        private void button1_Click(object sender, EventArgs e)
        {
            _userPanel.fillTableByQuerry(querryTextBox.Text);
        }

        private void fastQuerryForm_Load(object sender, EventArgs e)
        {

        }
    }
}

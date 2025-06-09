using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kpCRM
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
            fillDivisionsCombo();
            fillPositionsCombo();
            fillRoleComboBox();
        }

        public login login
        {
            get => default;
            set
            {
            }
        }

        public void fillDivisionsCombo()
        {
            dataReading dataReading = new dataReading();
            List<string> divisionList = dataReading.GetDivisions();
            divisionsComboBox.Items.Clear();
            divisionsComboBox.Items.AddRange(divisionList.ToArray());
        }
        public void fillPositionsCombo()
        {
            dataReading dataReading = new dataReading();
            List<string> divisionList = dataReading.getPositions();
            positionsComboBox.Items.Clear();
            positionsComboBox.Items.AddRange(divisionList.ToArray());
        }

        public void fillRoleComboBox()
        {
            chooseRoleComboBox.Items.Add("Администратор");
            chooseRoleComboBox.Items.Add("Начальник");
            chooseRoleComboBox.Items.Add("Рабочий");
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registrationServices newReg = new registrationServices();
            bool isConnectef = newReg.registration(loginTextBox.Text, passwordTextBox.Text, SurnameTextBox.Text, nameTextBox.Text, lastnameTextBox.Text, divisionsComboBox.SelectedItem.ToString(), positionsComboBox.SelectedItem.ToString(), chooseRoleComboBox.SelectedItem.ToString()); //chooseRoleComboBox.SelectedValue);
            if (isConnectef)
            {
                MessageBox.Show("Можно регать");
            }
            else MessageBox.Show("Пользователь с таким именем уже существует");
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void chooseRoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

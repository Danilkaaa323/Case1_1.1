using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace case_1
{
    public partial class Settings : Form
    {
        public List<double> MaxResources;
        public List<double> MaxResourcesDoubles = new List<double>();
        public Settings(List<double> maxResources)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaxResources = maxResources;
            Order_button.Visible = false;
        }

        private void Back_button_Click(object sender, EventArgs e) //выход из приложения
        {
            this.Close();
        }

        private void Order_button_Click(object sender, EventArgs e) //переход в окно "заказы"
        {
            Orders orders = new Orders(MaxResourcesDoubles, Program.ShowOrder); 
            orders.Show();
            this.Hide();
        }

        private void Save_button_Click(object sender, EventArgs e) //сохраняет данные
        {
            string[] maxResourses = new string[] { "", "", "", "", "", "", ""};
            maxResourses[0] = Ore_textBox.Text;
            maxResourses[1] = Nickel_textBox.Text;
            maxResourses[2] = Chrom_textBox.Text;
            maxResourses[3] = Manganese_textBox.Text;
            maxResourses[4] = TimeFurnaces_textBox.Text;
            maxResourses[5] = TimeConverter_textBox.Text;
            maxResourses[6] = Mill_textBox.Text;

            if (NullCheck(maxResourses) == false)
            {
                MessageBox.Show("Поле не может быть пустым");
            }
            else
            {
                bool allNumbers = true; 
                for (int i = 0; i <= 6; i++)
                {
                    if (double.TryParse(maxResourses[i], out double number)) //проверяет что в поле записано число 
                    {
                        MaxResourcesDoubles.Add(number);
                    }
                    else
                    {
                        allNumbers = false;
                        break;
                    }
                }

                if (allNumbers)
                {
                    Order_button.Visible = true;
                    Order_button.Enabled = true;
                }
                else
                {
                    MessageBox.Show("В поле могут быть записаны только числа\n\nЕсли число десятичное то записать через запятую");
                }
            }
        }
        public bool NullCheck(string[] maxResourses) //проверяет пустое ли поле для записи
        {
            int count = 0;
            for (int i = 0; i <= 6; i++)
            {
                if (maxResourses[i] == "")
                {
                    count++;
                }
            }
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

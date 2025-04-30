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
    public partial class Orders : Form
    {
        public List<double> MaxResourses;
        public List<string> ShowOrder;
        public Orders(List<double> maxResourses, List<string> showOrder)
        {
            InitializeComponent();
            order_richTextBox.ReadOnly = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaxResourses = maxResourses;
            ShowOrder = showOrder;  
            if (ShowOrder != null)
            {
                foreach (var line in ShowOrder)
                {
                    order_richTextBox.AppendText(line);
                }
            }
        }

        private void NewOrderForm_button_Click(object sender, EventArgs e) //переход в окно "новый заказ"
        {
            NewOrder newOrder = new NewOrder(MaxResourses, ShowOrder); 
            newOrder.Show();
            this.Hide();
        }

        private void Back_button_Click(object sender, EventArgs e) //переход в окно "настройки склада"
        {
            Settings settings = new Settings(MaxResourses); 
            settings.Show(); 
            this.Hide(); 
        }
    }
}

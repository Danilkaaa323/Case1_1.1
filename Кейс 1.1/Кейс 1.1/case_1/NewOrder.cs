using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace case_1
{
    public partial class NewOrder : Form
    {
        private Steel SteelA;
        private Steel SteelB;
        private Steel SteelC;
        public double[] UsedResources = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        public List<double> MaxResources;
        public List<double> Resourcess = new List<double>();
        public List<string> ShowOrder; 
        public NewOrder(List<double> maxResources, List<string> showOrder)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            saveFile_button.Visible = false;
            this.MaxResources = maxResources;
            ShowOrder = showOrder; 
        }
        private void Back_button_Click(object sender, EventArgs e) //переход в окно "заказы"
        {
            Orders orders = new Orders(MaxResources, ShowOrder); 
            orders.Show();
            this.Hide();
        }

        private void Save_button_Click_1(object sender, EventArgs e) //сохраняет записанные данные
        {
            string[] resourcesA = new string[] { "", "", "", "", "", "", "", "", "" };
            resourcesA[0] = OreA_textBox.Text;
            resourcesA[1] = NickelA_textBox.Text;
            resourcesA[2] = ChromA_textBox.Text;
            resourcesA[3] = ManganeseA_textBox.Text;
            resourcesA[4] = TimeFurnacesA_textBox.Text;
            resourcesA[5] = TimeConverterA_textBox.Text;
            resourcesA[6] = MillA_textBox.Text;
            resourcesA[7] = PriceA_textBox.Text;
            resourcesA[8] = VolumeA_textBox.Text;
            ConvertDouble(resourcesA);

            string[] resourcesB = new string[] { "", "", "", "", "", "", "", "", "" };
            resourcesB[0] = OreB_textBox.Text;
            resourcesB[1] = NickelB_textBox.Text;
            resourcesB[2] = ChromB_textBox.Text;
            resourcesB[3] = ManganeseB_textBox.Text;
            resourcesB[4] = TimeFurnacesB_textBox.Text;
            resourcesB[5] = TimeConverterB_textBox.Text;
            resourcesB[6] = MillB_textBox.Text;
            resourcesB[7] = PriceB_textBox.Text;
            resourcesB[8] = VolumeB_textBox.Text;
            ConvertDouble(resourcesB);

            string[] resourcesC = new string[] { "", "", "", "", "", "", "", "", "" };
            resourcesC[0] = OreC_textBox.Text;
            resourcesC[1] = NickelC_textBox.Text;
            resourcesC[2] = ChromC_textBox.Text;
            resourcesC[3] = ManganeseC_textBox.Text;
            resourcesC[4] = TimeFurnacesC_textBox.Text;
            resourcesC[5] = TimeConverterC_textBox.Text;
            resourcesC[6] = MillC_textBox.Text;
            resourcesC[7] = PriceC_textBox.Text;
            resourcesC[8] = VolumeC_textBox.Text;
            ConvertDouble(resourcesC);

            if (NullCheck(resourcesA) == false || NullCheck(resourcesB) == false || NullCheck(resourcesC) == false)
            {
                MessageBox.Show("Поле не может быть пустым");
                string time = DateTime.Now.ToString("MM.dd HH:mm:ss");
                ShowOrder.Add($"Заказ {time} - Не выполнен (пустое поле)\n");
            }
            else
            {
                if (DoubleCheck(resourcesA) == false || DoubleCheck(resourcesB) == false || DoubleCheck(resourcesC) == false)
                {
                    MessageBox.Show("В поле могут быть записаны только числа\n\nЕсли число десятичное то записать через запятую");
                    string time = DateTime.Now.ToString("MM.dd HH:mm:ss");
                    ShowOrder.Add($"Заказ {time} - Не выполнен (в поле записано не число)\n");
                }
                else
                {
                    SteelA = new Steel(Resourcess);
                    SteelB = new Steel(Resourcess);
                    SteelC = new Steel(Resourcess);

                    CountingUsedResources(SteelA, UsedResources);
                    CountingUsedResources(SteelB, UsedResources);
                    CountingUsedResources(SteelC, UsedResources);

                    int count = 0;
                    for (int i = 0; i < MaxResources.Count; i++) //проверка на превышение доступных ресурсов
                    {
                        if (UsedResources[i] > MaxResources[i])
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        MessageBox.Show($"Недостаточно ресурсов.");
                        for (int i = 0; i <= 7; i++)
                        {
                            UsedResources[i] = 0;
                        }

                        string time = DateTime.Now.ToString("MM.dd HH:mm:ss");
                        ShowOrder.Add($"Заказ {time} - Не выполнен (недостаточно ресурсов)\n");
                    }
                    else
                    {
                        saveFile_button.Visible = true;
                        saveFile_button.Enabled = true;
                    }
                }
            }
        }
        public bool DoubleCheck(string[] resources) //проверяет что в поле записано число 
        {
            int count = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (!double.TryParse(resources[i], out _))
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
        public void ConvertDouble(string[] resources) //конвертирует из string в double
        {
            for (int i = 0; i <= 8; i++)
            {
                if (double.TryParse(resources[i], out double number))
                {
                    Resourcess.Add(number);
                }
            }
        }
        public bool NullCheck(string[] resources) //проверяет пустое ли поле для записи
        {
            int count = 0;
            for (int i = 0; i <= 8; i++)
            {
                if (resources[i] == "")
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
        public static void CountingUsedResources(Steel steel, double[] usedResources) //считает производственный план
        {
            usedResources[0] += steel.Ore * steel.Volume;
            usedResources[1] += steel.Nickel * steel.Volume;
            usedResources[2] += steel.Chrom * steel.Volume;
            usedResources[3] += steel.Manganese * steel.Volume;
            usedResources[4] += steel.TimeFurnaces * steel.Volume;
            usedResources[5] += steel.TimeConverter * steel.Volume;
            usedResources[6] += steel.Mill * steel.Volume;
            usedResources[7] += steel.Price * steel.Volume;
        }

        private void SaveFile_button_Click(object sender, EventArgs e) //сохраняет данные в файле
        {
            for (int i = 0; i < MaxResources.Count; i++)
            {
                MaxResources[i] -= UsedResources[i];
            }

            string time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = $"Результирующие_данные_{time}.txt";
            string[] lines = {
                "Оптимальный производственный план:\n",
                $"Марка стали A: {SteelA.Volume}",
                $"Марка стали B: {SteelB.Volume}",
                $"Марка стали C: {SteelC.Volume}\n",
                $"Использованные ресурсы:",
                $"Руда: {UsedResources[0]} тонн",
                $"Никель: {UsedResources[1]} кг",
                $"Хром: {UsedResources[2]} кг",
                $"Марганец: {UsedResources[3]} кг",
                $"Время работы доменных печей: {UsedResources[4]} часов",
                $"Время работы конвертеров: {UsedResources[5]} часов",
                $"Время работы прокатного стана: {UsedResources[6]} часов\n",
                $"Общая прибыль: {UsedResources[7]}"
            };
            File.WriteAllLines(filePath, lines);
            saveFile_button.Visible = false;

            string timeOrder = DateTime.Now.ToString("MM.dd HH:mm:ss");
            ShowOrder.Add($"Заказ {timeOrder} - Выполнен\n");

            for (int i = 0; i <= 7; i++)
            {
                UsedResources[i] = 0;
            }
        }
    }
}

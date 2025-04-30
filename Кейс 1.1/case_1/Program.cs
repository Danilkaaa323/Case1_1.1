using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace case_1
{
    internal static class Program
    {
        public static List<string> ShowOrder { get; set; } = new List<string>();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<double> maxResources = new List<double>();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Settings(new List<double>()));
        }
    }
}

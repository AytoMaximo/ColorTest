using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorTest
{
    static class Program
    {
        /// <summary>
        /// ������� ����� ����� ��� ����������.
        /// </summary>
        [STAThread]
        static void Main()
        { EFlogger.EntityFramework6.EFloggerFor6.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}


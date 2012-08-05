using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CE1005_OpenFileDialog
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(GetFileName());
        }

        static string GetFileName()
        {
            System.Windows.Forms.OpenFileDialog CSVofd = new System.Windows.Forms.OpenFileDialog();
            CSVofd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            CSVofd.ShowDialog();

            string fileName = CSVofd.FileName;


            return CSVofd.FileName;
        }
    }
}

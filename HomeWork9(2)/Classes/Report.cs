using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_2_.Classes
{
    public class Report
    {
        string text;
        DateTime date;
        Employee worker;

        public Report(string text, Employee worker)
        {
            this.text = text;
            date = DateTime.Today;
            this.worker = worker;
        }
    }
}

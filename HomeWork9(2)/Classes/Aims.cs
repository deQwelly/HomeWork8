using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_2_.Classes
{
    public class Aims
    {
        enum Statuses
        {
            appointed, atWork, checking, complete
        }

        string description;
        DateTime deadlines;
        Employee teamlead;
        Employee worker;
        Statuses status;
        Report report;

        public Aims(string description, DateTime deadlines, Employee teamlead)
        {
            this.description = description;
            this.deadlines = deadlines;
            this.teamlead = teamlead;
            status = Statuses.appointed;
            report = null;
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public DateTime Deadlines
        {
            get
            {
                return deadlines;
            }
        }

        public string Teamlead
        {
            get
            {
                return teamlead.Name;
            }
        }

        public string Worker
        {
            get
            {
                return worker.Name;
            }
        }

        public void SetWorker(Employee worker)
        {
            status = Statuses.atWork;
            this.worker = worker;
        }

        public string Status
        {
            get
            {
                return status.ToString();
            }
        }

        public Report Report
        {
            get
            {
                return report;
            }
            set
            {
                report = value;
            }
        }

        public void Check()
        {
            status = Statuses.checking;
        }

        public void Complete()
        {
            status = Statuses.complete;
        }
    }
}

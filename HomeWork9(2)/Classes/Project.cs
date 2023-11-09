using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_2_.Classes
{
    public class Project
    {
        enum Statuses
        {
            design, execution, closed
        }

        string description;
        DateTime deadlines;
        string customer;
        Employee teamlead;
        List<Aims> aims = new List<Aims>();
        Statuses status;

        public Project(string description, DateTime deadlines, string customer, Employee teamlead)
        {
            this.description = description;
            this.deadlines = deadlines;
            this.customer = customer;
            this.teamlead = teamlead;
            status = Statuses.design;
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

        public string Customer
        {
            get
            {
                return customer;
            }
        }

        public string Teamlead
        {
            get
            {
                return teamlead.Name;
            }
        }
        
        public List<Aims> Aims
        {
            get
            {
                return aims;
            }
        }

        public string Status
        {
            get
            {
                return status.ToString();
            }
        }

        public void AddAim(Aims aim)
        {
            if (aims.Count == 9)
            {
                status = Statuses.execution;
            }
            aims.Add(aim);
        }

        /// <summary>
        /// Выводит на консоль список задач проекта
        /// </summary>
        public void ShowAims()
        {
            int i = 1;
            foreach (Aims aim in aims)
            {
                Console.WriteLine($"\nЗадача №{i}: {aim.Description} (до {aim.Deadlines})\n" +
                    $"от {aim.Teamlead}, выполняет {aim.Worker}, статус {aim.Status}");
                i++;
            }
        }

        public void CloseProject()
        {
            status = Statuses.closed;
        }
    }
}

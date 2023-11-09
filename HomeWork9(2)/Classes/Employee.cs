using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork9_2_.Classes
{
    public class Employee
    {
        string name;
        byte rang;

        public Employee(string name, byte rang)
        {
            this.name = name;
            this.rang = rang;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        //Для Тимлида
        public void CreateAim(Project project, string description, DateTime deadlines)
        {
            if (rang == 2)
            {
                project.AddAim(new Aims(description, deadlines, this));
            }
        }

        public void DeleteAim(Project project, Aims aim)
        {
            if (rang == 2)
            {
                project.Aims.Remove(aim);
            }
        }

        public void GiveAim(Project project, Aims aim, Employee employee)
        {
            Random rnd = new Random();
            if (rang == 2)
            {
                project.Aims[project.Aims.IndexOf(aim)].SetWorker(employee);
            }
        }


        //Для работников
        public void Refuse(Project project, Aims aim)
        {
            if (rang == 1)
            {
                project.Aims[project.Aims.IndexOf(aim)].SetWorker(null);
            }
        }

        public void DelegateAim(Project project, Aims aim, Employee employee) 
        {
            if ((rang == 1) && (employee.rang == 1))
            {
                project.Aims[project.Aims.IndexOf(aim)].SetWorker(employee);
            }
        }

        public void SendReport(Project project, Aims aim, string text)
        {
            project.Aims[project.Aims.IndexOf(aim)].Report = new Report(text, this);
        }
    }
}

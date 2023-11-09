using HomeWork9_2_.Classes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork9_2_
{
    internal class Program
    {
        public static void ComputeTime(Project project1, Employee worker, int numberAim)
        {
            bool temp = true;
            do
            {
                DateTime date = DateTime.Now;
                if (date == project1.Aims[numberAim].Deadlines)
                {
                    worker.SendReport(project1, project1.Aims[0], "Задача выполнена");
                    Console.WriteLine("sdf");
                    project1.Aims[numberAim].Check();
                    temp = false;
                }
            }
            while (temp);
        }

        static void Main(string[] args)
        {
            Employee jeka = new Employee("Жека", 2);
            Employee grisha = new Employee("Гришка", 1);
            Employee misha = new Employee("Миша", 1);
            Employee karina = new Employee("Карина", 1);
            Employee mitya = new Employee("Митя", 1);
            Employee vika = new Employee("Вика", 1);
            Employee lyesha = new Employee("Леша", 1);
            Employee ksyusha = new Employee("Ксюша", 1);
            Employee nastya = new Employee("Настя", 1);
            Employee roma = new Employee("Рома", 1);

            Project project1 = new Project("Создание мессенджера", DateTime.Today.AddMonths(2), "Компания Флажок", jeka);
            Console.WriteLine($"Описание проекта: {project1.Description},\nДедлайн: {project1.Deadlines},\n" +
                $"Заказчик: {project1.Customer},\nРуководитель проекта: {project1.Teamlead}\n");

            jeka.CreateAim(project1, "Разработать дизайн мессенджера", DateTime.Now.AddMinutes(1));
            jeka.CreateAim(project1, "Разработать авторизацию", DateTime.Today.AddMonths(2));
            jeka.CreateAim(project1, "Разработать обмен сообщениями", DateTime.Today.AddMonths(3));
            jeka.CreateAim(project1, "Разработать обмен файлами", DateTime.Today.AddMonths(3));
            jeka.CreateAim(project1, "Разработать push-уведомления", DateTime.Today.AddMonths(2));
            jeka.CreateAim(project1, "Разработать звонки в мессенджере", DateTime.Today.AddMonths(3));
            jeka.CreateAim(project1, "Разработать звонки по видео связи", DateTime.Today.AddMonths(4));
            jeka.CreateAim(project1, "Разработать групповые чаты", DateTime.Today.AddMonths(4));
            jeka.CreateAim(project1, "Разработать групповые звонки", DateTime.Today.AddMonths(4));
            jeka.CreateAim(project1, "Протестировать приложение", DateTime.Today.AddMonths(2));

            jeka.GiveAim(project1, project1.Aims[0], mitya);
            jeka.GiveAim(project1, project1.Aims[1], karina);
            jeka.GiveAim(project1, project1.Aims[2], roma);
            jeka.GiveAim(project1, project1.Aims[3], lyesha);
            jeka.GiveAim(project1, project1.Aims[4], ksyusha);
            jeka.GiveAim(project1, project1.Aims[5], nastya);
            jeka.GiveAim(project1, project1.Aims[6], grisha);
            jeka.GiveAim(project1, project1.Aims[7], vika);
            jeka.GiveAim(project1, project1.Aims[8], misha);
            jeka.GiveAim(project1, project1.Aims[9], roma);

            project1.ShowAims();
            Console.WriteLine($"\nПроект перешел на следующую стадию разработки: {project1.Status}");

            ComputeTime(project1, mitya, 0);
            ComputeTime(project1, karina, 1);
            ComputeTime(project1, roma, 2);
            ComputeTime(project1, lyesha, 3);
            ComputeTime(project1, ksyusha, 4);
            ComputeTime(project1, nastya, 5);
            ComputeTime(project1, grisha, 6);
            ComputeTime(project1, vika, 7);
            ComputeTime(project1, misha, 8);
            ComputeTime(project1, roma, 9);

            for (int i = 0; i < project1.Aims.Count; i++)
            {
                project1.Aims[i].Complete();
            }

            project1.CloseProject();
        }
    }
}

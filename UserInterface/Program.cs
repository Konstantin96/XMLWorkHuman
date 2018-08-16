using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UserInterface
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Report\report.xml");
            Console.Write("Введите возраст: ");
            int age = Int32.Parse( Console.ReadLine());
            foreach (XmlNode item in doc.SelectNodes(@"users/user"))
            {
                int ageUser = Int32.Parse(item.SelectSingleNode("age").InnerText);
                if (ageUser <= age)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine(item.SelectSingleNode("fio").InnerText);
                    Console.Write("Введите статус: ");
                    item.SelectSingleNode("status").InnerText = Guid.NewGuid().ToString();
                    item.SelectSingleNode("updateuser").InnerText = DateTime.Now.ToString();
                    
                }
            }
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Report\report.xml");
        }
    }
}

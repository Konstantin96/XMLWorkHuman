using InviteUser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace InvitesUser.LIB.Modul
{
    public class WorkUser
    {
        public static void DoWork()
        {
            ServiceUser serviceUser = new ServiceUser();
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("results");

            var test = serviceUser.InvokeUser();
            foreach (var item in serviceUser.InvokeUser())
            {
                XmlAttribute gender = doc.CreateAttribute("gender");
                gender.InnerText = item.gender;
                root.Attributes.Append(gender);

                XmlElement name = doc.CreateElement("name");
                XmlElement nameFirst = doc.CreateElement("firstName");
                XmlElement nameLast = doc.CreateElement("lastName");
                nameFirst.InnerText = item.name.first;
                nameLast.InnerText = item.name.last;
                name.AppendChild(nameFirst);
                name.AppendChild(nameLast);
                root.AppendChild(name);

                XmlElement cell = doc.CreateElement("cell");
                cell.InnerText = item.cell;
                root.AppendChild(cell);

                XmlElement dob = doc.CreateElement("dob");
                XmlAttribute dobAge = doc.CreateAttribute("age");
                dobAge.InnerText = item.dob.age;
                dob.Attributes.Append(dobAge);
                dob.InnerText = item.dob.date;
                root.AppendChild(dob);

                XmlElement location = doc.CreateElement("location");
                XmlElement city = doc.CreateElement("city");
                XmlElement state = doc.CreateElement("state");
                city.InnerText = item.location.city;
                state.InnerText = item.location.state;
                location.AppendChild(city);
                location.AppendChild(state);
                root.AppendChild(location);
            }
            doc.AppendChild(root);
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\" + Guid.NewGuid() + ".xml");
        }
        public static void SortHuman()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya");
            foreach (FileInfo item in dirInfo.GetFiles("*.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item.FullName);
                //XmlNode node = doc.SelectSingleNode("results[@name=gender]");
                //if (node.InnerText == "male")
                WorkUser.InfoMoveTo(doc,item.FullName);
                if(doc.DocumentElement.GetAttribute("gender") == "male")
                {
                    item.MoveTo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Male\"+item.Name);
                }
                //else if (node.InnerText == "female")
                else if(doc.DocumentElement.GetAttribute("gender") == "female")
                {
                    item.MoveTo(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Female\" + item.Name);
                }
            }
        }
        static void InfoMoveTo(XmlDocument docinfo, string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Report\report.xml");
            XmlElement root = doc.DocumentElement;

            XmlElement user = doc.CreateElement("user");
            //root.AppendChild(user);

            XmlElement FIO = doc.CreateElement("fio");
            FIO.InnerText = docinfo.SelectSingleNode(@"results/name/firstName").InnerText;
            FIO.InnerText += " "+docinfo.SelectSingleNode(@"results/name/lastName").InnerText;
            user.AppendChild(FIO);

            XmlElement TEL = doc.CreateElement("telephone");
            TEL.InnerText = docinfo.SelectSingleNode(@"results/cell").InnerText ;
            user.AppendChild(TEL);

            XmlElement ADRESS = doc.CreateElement("addres");
            ADRESS.InnerText = docinfo.SelectSingleNode(@"results/location/city").InnerText;
            ADRESS.InnerText += " " + docinfo.SelectSingleNode(@"results/location/state").InnerText;
            user.AppendChild(ADRESS);

            XmlElement AGE = doc.CreateElement("age");
            XmlNode n = docinfo.SelectSingleNode(@"results/dob");
            AGE.InnerText = n.Attributes[0].InnerText;
            user.AppendChild(AGE);

            XmlElement STATUS = doc.CreateElement("status");
            user.AppendChild(STATUS);
            XmlElement UPDATEUSER = doc.CreateElement("updateuser");
            user.AppendChild(UPDATEUSER);
            XmlElement FULLPATH = doc.CreateElement("fullpath");
            FULLPATH.InnerText = filepath;
            user.AppendChild(FULLPATH);
            root.AppendChild(user);
            doc.Save(@"\\dc\Студенты\ПКО\SMP-172.1\XML lesson 3\Kostya\Report\report.xml");
        }
    }
}

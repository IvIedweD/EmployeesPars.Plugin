using Newtonsoft.Json;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace EmployeesPars.Plugin
{
    [Author(Name = "Mikhail Pestryakov")]

    public class Pars : IPluggable
    {
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            string fileName = "users.json";
            string jsonString = File.ReadAllText(fileName);            
            var employeesList = args.Cast<EmployeesDTO>().ToList();
            var peoples = JsonConvert.DeserializeObject<Rootobject>(jsonString);
            foreach(var people in peoples.users)
            {
                employeesList.Add(new EmployeesDTO() { Name = people.lastName + " " + people.firstName, Phone = people.phone });
            }
            return employeesList;


        }
    }
}

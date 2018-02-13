using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevEx.Models.DataGrid
{
    public class InMemoryEmployeesDataContext
    {
        const string SessionKey = "3fd387f5-610a-4060-9204-619ef6e6f3ef";

        public ICollection<Employee> Employees
        {
            get
            {
                var session = HttpContext.Current.Session;
                if (session[SessionKey] == null)
                    session[SessionKey] = SampleData.DataGridEmployees;

                return (ICollection<Employee>)session[SessionKey];
            }
        }

        public void SaveChanges()
        {
            foreach (var employee in Employees.Where(a => a.ID == 0))
            {
                employee.ID = Employees.Max(a => a.ID) + 1;
            }
        }



    }


        }
    }

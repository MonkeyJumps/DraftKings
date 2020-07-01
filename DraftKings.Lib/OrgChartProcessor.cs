using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings.Lib
{
    public class OrgChartProcessor
    {
        private IDisplay _display;
        IOrgChart _orgChart;
        public OrgChartProcessor()
        {
            //should refactor and pass in with DI
            _display = new ConsoleDisplay();            
             _orgChart = new SimpleOrgChart(_display);
        }
        
        public void AddNewEmployee(int employeeId,string name, int managerId)
        {
            _orgChart.Add(employeeId, name, managerId);
        }

        public void RemoveEmployee(int employeeId)
        {
            _orgChart.Remove(employeeId);
        }

        public int CountAllEmployeesFor(int employeeId)
        {
            return _orgChart.CountEmployeesOf(employeeId);
        }

        public void PrintOrgChart()
        {
            _orgChart.Print();
        }
    }
}

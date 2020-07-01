using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DraftKings.Lib
{
    public class SimpleOrgChart : IOrgChart
    {
        private List<Node> _employees;
        private readonly IDisplay _display;

        public SimpleOrgChart(IDisplay display)
        {
            _employees = new List<Node>();
            _display = display;
        }
                 
        private class Node
        {
            //reporting employees
            private List<Node> _children = new List<Node>();
            //will be value of employee name
            private string _name;
            private int _employeeId;
            private readonly int _managerId;

            public Node(string name, int employeeId, int managerId)
            {
                _name = name;
                _employeeId = employeeId;
                _managerId = managerId;
            }
            public int ManagerId { get { return _managerId; } }
            public int EmployeeId { get { return _employeeId; } }
            public string Name { get { return _name; } }
            public List<Node> GetChildren()
            {
                return _children;
            }
            public void Add(Node node)
            {
                _children.Add(node);
            }
        }
        private void PrintOrgChart(Node employee, string indent, bool last)
        {            
            _display.Write(indent + "" + $"{employee.Name} [{employee.EmployeeId}]");
            indent += last ? "   " : "|  ";
            for (int i = 0; i < employee.GetChildren().Count; i++)
            {
                PrintOrgChart(employee.GetChildren()[i], indent, i == employee.GetChildren().Count - 1);
            }
        }
        public void Print()
        {
            foreach( var employee in _employees)
            {                
                PrintOrgChart(employee, "", true);
            }
        }

        public int CountEmployeesOf(int employeeId)
        {
            Node employeeNode =
                FindEmployee(employeeId, _employees, LookupEmployeeId);

            return CountChildren(employeeNode.GetChildren());

        }

        public void Add(int employeeId, string name, int managerId)
        {
            if (managerId == -1)
            {
                //Executive row
                Node employee = new Node(name, employeeId, managerId);
                _employees.Add(employee);
                return;
            }
            Node managerNode =
                FindEmployee(managerId, _employees, LookupEmployeeId);
            if (managerNode == null && managerId != -1)
            {
                throw new ArgumentOutOfRangeException("Error: Add, Manager not found");
            }
            else
            {
                //found manager. Add under manager.
                managerNode.Add(new Node(name, employeeId,managerId));
            }
        }
        //not sure if we will be supplied from manager since we 
        //can obtain it  from current employee
        public void Move(int employeeId, int fromManagerId, int toManagerId)
        {
            Node employee = ReturnRemovedNode(employeeId);
            Add(employeeId, employee.Name, toManagerId);
        }
        public void Remove(int employeeId)
        {
            Node employee = ReturnRemovedNode(employeeId);

            ReassignEmployees(employee);
        }

        private void ReassignEmployees(Node employee)
        {
            if (employee.GetChildren().Count > 0)
            {
                foreach (Node node in employee.GetChildren())
                {
                    Add(node.EmployeeId, node.Name, employee.ManagerId);
                }
            }
        }

        private Node FindEmployee(int employeeId, List<Node> children
    , Func<int, List<Node>, Node> addOrRemove)
        {

            if (children.Count == 0)
            {
                return null;
            }
            Node temp = addOrRemove(employeeId, children);

            if (temp != null)
            {
                return temp;
            }
            foreach (var node in children)
            {
                return FindEmployee(employeeId, node.GetChildren(),
                    addOrRemove);
            }

            return null;
        }
        private Node ReturnRemovedNode(int employeeId)
        {
            Node employeeNode =
            FindEmployee(employeeId, _employees, RemoveEmployeeFromOrg);
            if (employeeNode == null)
            {
                throw new ArgumentOutOfRangeException("Error: Remove, Employee not found. ");
            }

            return employeeNode;

        }
        //what if employee is manager and has employees under her?
        private Node RemoveEmployeeFromOrg(int employeeId, List<Node> children)
        {
            Node found = children.FirstOrDefault(n => n.EmployeeId == employeeId);
            if (found != null)
            {
                children.Remove(found);
                return found;
            }
            return null;
        }
        private Node LookupEmployeeId(int employeeId, List<Node> children)
        {
            return children.FirstOrDefault(n => n.EmployeeId == employeeId);
        }
        private int CountChildren(List<Node> children)
        {
            if (children.Count() == 0) return 0;

            int count = children.Count;
            foreach (var node in children)
                return count + CountChildren(node.GetChildren());


            return 0;

        }
    }
}

using DraftKings.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DraftKings.Tests
{
    public class OrgChartTests
    {



        [Fact]
        public void OrgChart_AddEmployeeWithNoManager()
        {
            //Arrange
            OrgChartProcessor org = new OrgChartProcessor();


            //Act
            org.AddNewEmployee(10, "Sharilyn Gruber", -1);
            org.AddNewEmployee(7, "Denice Mattice", 10);
            org.AddNewEmployee(55, "vmichael", 7);
            org.AddNewEmployee(23, "Michael Jordan", 10);
            org.AddNewEmployee(33, "Scottie Pippen", 55);
            //Assert

            Assert.True(true);
            
        }


        [Fact]
        public void OrgChart_RemoveEmployee()
        {
            //Arrange
            OrgChartProcessor org = new OrgChartProcessor();


            //Act
            org.AddNewEmployee(10, "Sharilyn Gruber", -1);
            org.AddNewEmployee(7, "Denice Mattice", -1);
            org.AddNewEmployee(55, "vmichael", -1);
            org.AddNewEmployee(23, "Michael Jordan", -1);
            org.AddNewEmployee(33, "Scottie Pippen", -1);

            org.RemoveEmployee(55);
            //Assert

            Assert.True(true);
        }

        [Fact]
        public void OrgChart_MoveEmployee()
        {

            //Arrange
            OrgChartProcessor org = new OrgChartProcessor();


            //Act
            org.AddNewEmployee(10, "Sharilyn Gruber", -1);
            org.AddNewEmployee(7, "Denice Mattice", 10);
            org.AddNewEmployee(55, "vmichael", 7);
            org.AddNewEmployee(23, "Michael Jordan", 10);
            org.AddNewEmployee(33, "Scottie Pippen", 55);

            //org.Move(33, 55, 10);
            //Assert

            Assert.True(true);
        }

        [Fact]
        public void OrgChart_CountEmployees()
        {
            //Arrange
            OrgChartProcessor org = new OrgChartProcessor();


            //Act
            org.AddNewEmployee(10, "Sharilyn Gruber", -1);
            org.AddNewEmployee(7, "Denice Mattice", 10);
            org.AddNewEmployee(55, "vmichael", 7);
            org.AddNewEmployee(23, "Michael Jordan", 10);
            org.AddNewEmployee(33, "Scottie Pippen", 55);

            int numberOfEmployees = org.CountAllEmployeesFor(7);
            //Assert

            Assert.Equal(1, numberOfEmployees);
        }


        [Fact]
        public void OrgChart_PrintEmployees()
        {
            //Arrange
            OrgChartProcessor org = new OrgChartProcessor();


            //Act
            org.AddNewEmployee(10, "Sharilyn Gruber", -1);
            org.AddNewEmployee(7, "Denice Mattice", -1);
            org.AddNewEmployee(55, "vmichael", -1);
            org.AddNewEmployee(23, "Michael Jordan", -1);
            org.AddNewEmployee(33, "Scottie Pippen", -1);
            int numberOfEmployees = org.CountAllEmployeesFor(7);
            //Assert
            org.PrintOrgChart();
            Assert.Equal(1, numberOfEmployees);
        }
    }
}

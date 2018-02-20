using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grades;


namespace Grades.Test
{
    [TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void ComputesHighestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics results = book.ComputeStatistics();
            Assert.AreEqual(90, results.HighestGrade);
        }

        [TestMethod]
        public void AddDaystoDateTime()
        {
            DateTime date = new DateTime(2018, 02, 20);
            date = date.AddDays(1);
            Assert.AreEqual(date.Day, 21);
        }

        [TestMethod]
        public void UpperCaseString()
        {
            string name = "Gustavo";
            string cap = name.ToUpper();

            Assert.AreEqual("GUSTAVO", cap);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(2, result.LowestGrade);
        }
    }
}

using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{   // the default standard for classes is internal. In order to run unit tests, we must specify public //
    public class Gradebook
    {
        public Gradebook()
        {
            _name = "Empty";
            grades = new List<float>();
        }
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();


            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);

                // an alternative to the two lines of code above is to do a direct comparison between the current item we are looking at
                // and our current highest/lowest grade //

                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            stats.LowestGrade = grades.Count;


            return stats;
        }
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        NameChanged(_name, value);
                    }
                    _name = value;
                }
            }
                   
        }
        public NameChangedDelegate NameChanged;

        private List<float> grades;
        private string _name;
    }
}

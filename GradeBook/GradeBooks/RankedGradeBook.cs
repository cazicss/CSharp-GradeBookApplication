using System;
using System.Linq;

using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        // constructor
        public RankedGradeBook(string name) : base(name){
            Type = GradeBookType.Ranked;
        }


        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students");
                return;
            }

            // all good to do base method
            base.CalculateStatistics();
        }


        public override char GetLetterGrade(double averageGrade)
        {
            // not enough students to generate a proper curve
            if (Students.Count < 5)
                throw new InvalidOperationException();

            // how many students in each of the 5 brackets
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);

            // create descending ordered list of student grades
            var grades =
                Students
                .OrderByDescending(student => student.AverageGrade)
                .Select(student => student.AverageGrade)
                .ToList();

            // calculate grade from ranked brackets
            if (averageGrade >= grades[threshold - 1]) return 'A';
            else if (averageGrade >= grades[threshold * 2 - 1]) return 'B';
            else if (averageGrade >= grades[threshold * 3 - 1]) return 'C';
            else if (averageGrade >= grades[threshold * 4 - 1]) return 'D';
            else return 'F';
        }

    }
}

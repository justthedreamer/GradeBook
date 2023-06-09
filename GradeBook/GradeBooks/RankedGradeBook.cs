﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type=Enums.GradeBookType.Ranked;
            IsWeighted = isWeighted;

        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count >= 5)
            {
                var AtopOfTheClass = (Students.Count * 0.2);
                var BtopOfTheClass = (Students.Count * 0.4);
                var CtopOfTheClass = (Students.Count * 0.6);
                var DtopOfTheClass = (Students.Count * 0.8);
                List<double> avarageRanking = new List<double>();

                foreach (var student in Students)
                {
                    avarageRanking.Add(student.AverageGrade);
                }
                avarageRanking.Sort();
                avarageRanking.Reverse();
                int index = avarageRanking.IndexOf(averageGrade);


                if (index < AtopOfTheClass)
                    return 'A';
                else if (index >= AtopOfTheClass && index < BtopOfTheClass)
                    return 'B';
                else if (index >= BtopOfTheClass && index < CtopOfTheClass)
                    return 'C';
                else if (index >= CtopOfTheClass && index < DtopOfTheClass)
                    return 'D';
                else
                    return 'F';

            }
            else throw new InvalidOperationException();
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5) { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else
                base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5) { Console.WriteLine("Ranked grading requires at least 5 students."); }
            else
                base.CalculateStudentStatistics(name);
        }

    }
}

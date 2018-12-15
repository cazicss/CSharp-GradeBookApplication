﻿using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        // constructor
        public RankedGradeBook(string name) : base(name){
            Type = GradeBookType.Ranked;
        }

    }
}

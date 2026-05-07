using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cv_11.EFCore
{
    public class Student
    {
        public int StudentId { get; set; } 
        
        public string Jmeno { get; set; } = "";
        public string Prijmeni { get; set; } = "";
        public DateTime DatumNarozeni { get; set; }

        // EF Core
        public List<Predmet> Predmety { get; set; } = new();
        public List<Hodnoceni> Hodnoceni { get; set; } = new();
    }
}
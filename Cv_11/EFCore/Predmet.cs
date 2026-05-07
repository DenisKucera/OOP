using System;
using System.Collections.Generic;

namespace Cv_11.EFCore
{
    public class Predmet
    {
        public string PredmetId { get; set; } = ""; 
        public string Nazev { get; set; } = "";

        // EF Core
        public List<Student> Studenti { get; set; } = new();
        public List<Hodnoceni> Hodnoceni { get; set; } = new();
    }
}
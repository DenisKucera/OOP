using System;

namespace Cv_11.EFCore
{
    public class Hodnoceni
    {
        public int StudentId { get; set; } 
        public Student Student { get; set; } = null!;

        public string PredmetId { get; set; } = "";
        public Predmet Predmet { get; set; } = null!;
        public DateTime DatumHodnoceni { get; set; }
        public int Znamka { get; set; }
    }
}
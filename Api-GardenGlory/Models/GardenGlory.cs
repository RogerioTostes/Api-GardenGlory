using System;

namespace Api_GardenGlory.Models
{
    public class Passaro
    {
        public int Anel { get; set; }
        public int Criador { get; set; }
        public char Sexo { get; set; }
        public string Cor { get; set; }
        public DateTime AnoNascimento { get; set; }
        public string Obs { get; set; }

    }
    public class Gaiola
    {
        public int NumeroOrdem { get; set; }
        public int Anel { get; set; }
        public int QtdOvos { get; set; }
        public int Total { get; set; }
        public int Ferteis { get; set; }
        public DateTime Incubacao { get; set; }
        public DateTime Nascimento { get; set; }
        public int Nascidos { get; set; }
        public int Mortos { get; set; }
        public int Criados { get; set; }
        public string Aneis { get; set; }

    }
}

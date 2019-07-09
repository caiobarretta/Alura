using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Mes : IComparable
    {
        public string Nome { get; private set; }
        public int Dias { get; private set; }

        public Mes(string nome, int dias)
        {
            Nome = nome;
            Dias = dias;
        }

        public override string ToString() => $"Nome: {Nome}, Dias: {Dias}";

        public int CompareTo(object outro)
        {
            if (outro as Mes == null)
                return -1;

            return Nome.CompareTo((outro as Mes).Nome);
        }
    }
}

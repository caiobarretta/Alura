using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Aula : IComparable
    {
        private string _titulo;
        private int _tempo;
        public string Titulo { get => _titulo; set => _titulo = value; }
        public int Tempo { get => _tempo; set => _tempo = value; }

        public Aula(string titulo, int tempo)
        {
            _titulo = titulo;
            _tempo = tempo;
        }

        public override string ToString() => $"Titulo: {Titulo}, Tempo: {Tempo}";

        public int CompareTo(object obj) => (obj as Aula == null ? -1 : Titulo.CompareTo((obj as Aula).Titulo));
    }
}

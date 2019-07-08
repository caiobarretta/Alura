using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Aluno
    {
        private string _nome;
        private int _numeroMatricula;
        public string Nome
        {
            get { return _nome; }
        }
        public int NumeroMatricula
        {
            get { return _numeroMatricula; }
        }
        public Aluno(string nome, int numeroMatricula)
        {
            _nome = nome;
            _numeroMatricula = numeroMatricula;
        }
        public override string ToString()
        {
            return $"Nome: {Nome}, Matrícula: {NumeroMatricula}";
        }
        public override bool Equals(object obj) => (obj as Aluno) != null ? (Nome == (obj as Aluno).Nome && NumeroMatricula == (obj as Aluno).NumeroMatricula) : false;
        public override int GetHashCode() => Nome.GetHashCode();
    }
}

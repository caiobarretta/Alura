using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Curso
    {
        private string _nome;
        private string _instrutor;
        private IList<Aula> _aulas;
        public string Nome => _nome;
        public string Instrutor => _instrutor;
        public IList<Aula> Aulas => new ReadOnlyCollection<Aula>(_aulas);

        public Curso(string nome, string instrutor)
        {
            _nome = nome;
            _instrutor = instrutor;
            _aulas = new List<Aula>();
        }

        public void AdicionarAula(Aula aula) => _aulas.Add(aula);



    }
}

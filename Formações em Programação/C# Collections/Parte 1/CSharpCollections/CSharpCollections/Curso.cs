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

        public int TempoTotal
        {
            get
            {
                int total = 0;
                foreach (var aula in Aulas)
                    total += aula.Tempo;
                return total;
            }
        }

        public int TempoTotalComLinq
        {
            get
            {
                //LINQ = Language Integrated Query
                //Consulta Integrada à Linguagem
                return Aulas.Sum(aula => aula.Tempo);
            }
        }

        public IList<Aula> Aulas => new ReadOnlyCollection<Aula>(_aulas);

        public Curso(string nome, string instrutor)
        {
            _nome = nome;
            _instrutor = instrutor;
            _aulas = new List<Aula>();
        }

        public void AdicionarAula(Aula aula) => _aulas.Add(aula);

        public override string ToString()
        {
            string curso;
            curso = $"Nome: {Nome}, Instrutor: {Instrutor}, TempoTotal: {TempoTotal}{Environment.NewLine}Aulas:{Environment.NewLine}{string.Join(Environment.NewLine, Aulas)}";
            return curso;
        }

    }
}

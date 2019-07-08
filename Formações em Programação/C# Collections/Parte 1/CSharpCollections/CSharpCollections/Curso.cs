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
        private ISet<Aluno> _alunos;
        private IDictionary<int, Aluno> dicionarioAlunos;
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
        //LINQ = Language Integrated Query
        //Consulta Integrada à Linguagem
        public int TempoTotalComLinq => Aulas.Sum(aula => aula.Tempo);
        public IList<Aula> Aulas => new ReadOnlyCollection<Aula>(_aulas);
        public IList<Aluno> Alunos => new ReadOnlyCollection<Aluno>(_alunos.ToList());

        public Curso(string nome, string instrutor)
        {
            _nome = nome;
            _instrutor = instrutor;
            _aulas = new List<Aula>();
            _alunos = new HashSet<Aluno>();
            dicionarioAlunos = new Dictionary<int, Aluno>();
        }
        public void AdicionarAula(Aula aula) => _aulas.Add(aula);
        public void Matricular(Aluno aluno)
        {
            _alunos.Add(aluno);
            dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
        }

        public override string ToString()
        {
            string curso;
            curso = $"Nome: {Nome}, Instrutor: {Instrutor}, TempoTotal: {TempoTotal}{Environment.NewLine}Aulas:{Environment.NewLine}{string.Join(Environment.NewLine, Aulas)}";
            return curso;
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return _alunos.Contains(aluno);
        }

        public Aluno BuscaMatriculado(int numeroMatricula)
        {
            dicionarioAlunos.TryGetValue(numeroMatricula, out Aluno aluno);
            return aluno;
        }
    }
}

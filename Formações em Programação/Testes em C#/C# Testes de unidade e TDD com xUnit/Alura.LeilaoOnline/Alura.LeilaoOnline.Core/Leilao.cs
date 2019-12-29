using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private Interessada _ultimoCliente;
        private readonly IModalidadeAvaliacao _avalidador;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string peca, IModalidadeAvaliacao avalidador)
        {
            Peca = peca;
            _lances = new List<Lance>();
            _avalidador = avalidador;
            Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        private bool NovoLanceEhAceito(Interessada cliente)
        {
            return Estado == EstadoLeilao.LeilaoEmAndamento
                && cliente != _ultimoCliente;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (NovoLanceEhAceito(cliente))
            {
                _lances.Add(new Lance(cliente, valor));
                _ultimoCliente = cliente;
            }
        }

        public void IniciaPregao()
        {
            Estado = EstadoLeilao.LeilaoEmAndamento;

        }

        public void TerminaPregao()
        {
            if (Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new InvalidOperationException("Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().");

            Ganhador = _avalidador.Avalia(this);
            Estado = EstadoLeilao.LeilaoFinalizado;

        }
    }
}

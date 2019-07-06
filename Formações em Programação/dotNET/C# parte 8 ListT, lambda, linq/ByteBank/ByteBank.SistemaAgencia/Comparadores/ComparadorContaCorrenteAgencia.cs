using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Comparadores
{
    public class ComparadorContaCorrenteAgencia : IComparer<ContaCorrente>
    {
        //Retornar negativo quando x precede y
        //Retornar zero quando quando x e y são equivalentes
        //Retornar positivo quando x antecede y
        //public int Compare(ContaCorrente x, ContaCorrente y) => x != y ? (x != null ? y != null ? (x.Agencia < y.Agencia ? -1 : (x.Agencia == y.Agencia ? 0 : 1)) : -1 : 1) : 0;
        public int Compare(ContaCorrente x, ContaCorrente y) => x != y ? (x != null ? y != null ? x.Agencia.CompareTo(y.Agencia) : -1 : 1) : 0;
    }
}

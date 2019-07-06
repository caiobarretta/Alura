using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class ListaObject
    {
        private Object[] _itens;
        private int _proximaPosicao;

        public Object this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public void AdicionarVarios(params Object[] itens)
        {
            foreach (var conta in itens)
                Adicionar(conta);
        }

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }

        public ListaObject(int capacidadeInicial = 5)
        {
            _itens = new Object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(Object item)
        {
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void Remover(Object item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }
            }

            if (indiceItem != -1)
            {
                for (int i = indiceItem; i < (_proximaPosicao - 1); i++)
                    _itens[i] = _itens[i + 1];

                _proximaPosicao--;
                _itens[_proximaPosicao] = null;
            }

        }

        public Object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
                throw new ArgumentOutOfRangeException(nameof(indice), "");
            else
                return _itens[indice];
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
                return;

            int novoTamanho = tamanhoNecessario;
            if (novoTamanho < tamanhoNecessario)
                novoTamanho = tamanhoNecessario;

            Object[] novoArray = new Object[novoTamanho];
            for (int i = 0; i < _itens.Length; i++)
                novoArray[i] = _itens[i];

            _itens = novoArray;
        }
    }
}

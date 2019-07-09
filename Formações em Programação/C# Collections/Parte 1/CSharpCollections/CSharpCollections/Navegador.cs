using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCollections
{
    public class Navegador
    {
        private readonly Stack<string> historicoAnterior;
        private readonly Stack<string> historicoProximo;
        private string atual = string.Empty;

        public Navegador()
        {
            Console.WriteLine("Página atual: {0}", atual);
            historicoAnterior = new Stack<string>();
            historicoProximo = new Stack<string>();
        }

        public void NavegarPara(string url)
        {
            historicoAnterior.Push(atual);
            atual = url;
            Console.WriteLine("Página atual: {0}", atual);
        }

        public  void Anterior()
        {
            if (historicoAnterior.Any())
            {
                atual = historicoAnterior.Pop();
                historicoProximo.Push(atual);
                Console.WriteLine("Página anterior: {0}", atual);
            }
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                atual = historicoProximo.Pop();
                historicoAnterior.Push(atual);
                Console.WriteLine("Página próximo: {0}", atual);
            }
        }
    }
}

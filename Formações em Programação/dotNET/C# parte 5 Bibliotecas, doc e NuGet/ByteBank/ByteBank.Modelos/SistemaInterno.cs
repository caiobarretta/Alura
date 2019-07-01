using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class SistemaInterno
    {
        public string Senha { get; set; }

        public bool Logar(IAutenticavel funcionario, string senhaTentativa)
        {
            bool usuarioAutenticado = funcionario.Autenticar(senhaTentativa);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem-vindo ao sistema!");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta!");
                return false;
            }
        }
    }
}

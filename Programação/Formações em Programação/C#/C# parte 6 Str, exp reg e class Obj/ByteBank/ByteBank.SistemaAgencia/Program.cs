using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, mundo!");
            Console.WriteLine(123);
            Console.WriteLine(10.5);
            Console.WriteLine(true);

            object conta = new ContaCorrente(1234, 12314);
            object desenvolvedor = new Desenvolvedor("12313212312");

            string contaToString = conta.ToString();

            Console.WriteLine(contaToString);


            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            ContaCorrente cc = new ContaCorrente(123, 12344);

            if (carlos_1.Equals(cc))
                Console.WriteLine("São iguais!");
            else
                Console.WriteLine("Não são iguais!");

            Console.ReadLine();
        }

        static void TestaString()
        {
            // pagina ? argumentos
            // 012345678

            //"[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            //"[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            //"[0-9]{4}[-][0-9]{4}";
            //"[0-9]{4,5}[-][0-9]{4}";
            //"[0-9]{4,5}[-]{0,1}[0-9]{4}";
            //"[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Guilherme, me ligue em 4784-4546";

            Match resultado = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine(resultado.Value);
            Console.ReadLine();


            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));
            Console.WriteLine(urlTeste.Contains("bytebank"));

            Console.ReadLine();

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            var extratorValores = new ExtratorValorDeArgumentosURL(urlParametros);

            string valorMoedaDestino = extratorValores.GetValor("moedaDestino");
            Console.WriteLine("Valor moedaDestino:{0}", valorMoedaDestino);

            string valorMoedaOrigem = extratorValores.GetValor("moedaOrigem");
            Console.WriteLine("Valor moedaOrigem:{0}", valorMoedaOrigem);

            string valor = extratorValores.GetValor("valor");
            Console.WriteLine("Valor:{0}", valor);

            Console.ReadLine();

            string palavra = "moedaOrigem=real&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino=";

            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);

            Console.WriteLine("Tamanho string nomeArgumento: {0}", nomeArgumento.Length);

            Console.WriteLine(palavra);
            Console.WriteLine(indice);
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));

            Console.ReadLine();


            string textoVazio = "";
            string textoNulo = null;

            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            Console.ReadLine();

            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL("");

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf('?');

            Console.WriteLine(indiceInterrogacao);

            Console.WriteLine(url);
            var argumentos = url.Substring(indiceInterrogacao + 1);
            Console.WriteLine(argumentos);

        }
    }
}

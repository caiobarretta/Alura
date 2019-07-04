﻿using System;
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

            // pagina?argumentos
            // 012345678



            string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
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

            string urlParametros ="http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
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

            Console.ReadLine();
        }
    }
}

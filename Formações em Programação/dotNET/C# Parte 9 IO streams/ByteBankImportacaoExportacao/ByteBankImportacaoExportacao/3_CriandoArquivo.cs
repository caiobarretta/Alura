using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "ContasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "123,123132,0.50,Gustavo Santos";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoWriter()
        {
            var caminhoNovoArquivo = "ContasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("123,123132,0.50,Gustavo Santos");
            }
        }

        static void TestaEscrita()
        {
            var testaCaminho = "teste.txt";
            using (var fluxoDeArquivo = new FileStream(testaCaminho, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    escritor.Flush();
                    Console.WriteLine($"Essa Linha {i} foi adicionada no arquivo: {testaCaminho}. Tecle enter para continuar");
                    Console.ReadLine();

                }
                
            }
        }
    }
}

using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankImportacaoExportacao 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        {
            var enderecoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1kb
                var numeroDeBytesLidos = -1;


                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, buffer.Length);
                    EscreverBufferNaTela(buffer, numeroDeBytesLidos);
                }
            }

            Console.ReadLine();
        }

        static void EscreverBufferNaTela(byte[] buffer, int bytesLidos)
        {
            //var utf = new UTF32Encoding();
            var utf = Encoding.Default;
            Console.WriteLine(utf.GetString(buffer, 0, bytesLidos));                
        }
    }
} 
 
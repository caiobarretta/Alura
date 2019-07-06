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

            var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open);

            var buffer = new byte[1024]; // 1kb
            var numeroDeBytesLidos = -1;


            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                EscreverBufferNaTela(buffer);
            }

            Console.ReadLine();
        }

        static void EscreverBufferNaTela(byte[] buffer)
        {
            foreach (var meuByte in buffer)
            {
                Console.Write(meuByte);
                Console.Write(" ");
            }
                
        }
    }
} 
 
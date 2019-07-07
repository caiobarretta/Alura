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
        static void Main(string[] args) 
        {

            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");
            Console.WriteLine("Arquivo escrevendoComAClasseFile criado!");

            foreach (var linha in File.ReadAllBytes("contas.txt"))
                Console.WriteLine(linha);

            foreach (var linha in File.ReadAllLines("contas.txt"))
                Console.WriteLine(linha);

            Console.ReadLine();
        }
    }
} 
 
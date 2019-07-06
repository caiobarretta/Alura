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
            var enderecoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDoArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var conta = ConverteStringParaContaCorrente(linha);
                    //Console.WriteLine(linha);
                    Console.WriteLine($"{conta.Titular.Nome}: Conta Número: {conta.Numero}, Agência: {conta.Agencia}, Saldo: {conta.Saldo}");
                }
            }


            Console.ReadLine();
        }

        static ContaCorrente ConverteStringParaContaCorrente(string linha)
        {
            var campos = linha.Split(',');

            var agencia = int.Parse(campos[0]);
            var numero = int.Parse(campos[1]);
            var saldo = double.Parse(campos[2].Replace(".",","));
            var nomeTitular = campos[3];

            var conta = new ContaCorrente(agencia, numero);
            conta.Depositar(saldo);
            var cliente = new Cliente();
            cliente.Nome = nomeTitular;
            conta.Titular = cliente;

            return conta;

        }
    }
} 
 
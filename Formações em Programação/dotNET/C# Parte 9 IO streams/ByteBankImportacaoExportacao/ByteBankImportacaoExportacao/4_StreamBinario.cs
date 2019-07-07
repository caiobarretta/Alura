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
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456); //número da agência
                escritor.Write(54566565); //número conta
                escritor.Write(4000.50); //saldo conta
                escritor.Write("Gustavo Braga"); //titular conta
            }
        }

        static void LeitorBinario()
        {
            using (var fs = new FileStream("ContaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var conta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();
                Console.WriteLine($"agencia: {agencia}, conta: {conta}, saldo: {saldo}, titular: {titular}");
            }
        }
    }
}

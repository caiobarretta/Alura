﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaCorrente = new ContaCorrente(123, 1244356);

            Funcionario funcionario = null;

            Console.WriteLine(contaCorrente.Numero);
            Console.ReadLine();
        }
    }
}

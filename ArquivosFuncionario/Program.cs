using ArquivosFuncionario.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArquivosFuncionario
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.Write("Digite o endereço do diretório desejado: ");
                string endereco = Console.ReadLine();


                Registros registros = new Registros(new OperacoesArquivo(endereco)); //IOC

                registros.ListaDiretorios();
                Console.WriteLine();
                registros.ListaFuncionarios();
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");              
            }

            Console.ReadKey();
        }
    }
}

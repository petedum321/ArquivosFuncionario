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
            Console.WriteLine("Digite o endereço do diretório desejado: ");
            string endereco = Console.ReadLine();
            
            OperacoesArquivo operacoes = new OperacoesArquivo(endereco);

            operacoes.ListarDiretorios();

            


        }
    }
}

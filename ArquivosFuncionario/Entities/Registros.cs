using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivosFuncionario.Entities
{
    class Registros
    {
        
        public OperacoesArquivo OperacoesArquivo { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

        private IProcedimentos _procedimentos;

        public Registros()
        {
        }

        public Registros(IProcedimentos procedimentos)
        {
            _procedimentos = procedimentos;
            Funcionarios = new List<Funcionario>();
        }

        public void ListaDiretorios()
        {
            List<string> arquivos = _procedimentos.ListarDiretorios();

            
            Console.WriteLine("****************** Arquivos do Diretório ********************");

            arquivos.ForEach(x => Console.WriteLine(x));
        }


        public void ListaFuncionarios()
        {
            Funcionarios = _procedimentos.ListaFuncionarios();


            Console.WriteLine("Funcionários: \n");

            Console.WriteLine("Id ".PadRight(15) + " Nome ".PadRight(22) + " Data de Nascimento ".PadRight(30) + " Salario ".PadRight(17));

            Funcionarios.ForEach(x => Console.WriteLine(x));


        }
    }
}

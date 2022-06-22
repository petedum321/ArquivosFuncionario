using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivosFuncionario.Entities
{
    class OperacoesArquivo : IProcedimentos
    {

        public string Endereco { get; set; }
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public OperacoesArquivo()
        {
            Funcionarios = new List<Funcionario>();
        }

        public OperacoesArquivo(string endereco)
        {
            Endereco = endereco;
            Funcionarios = new List<Funcionario>();
        }

        public List<Funcionario> ListaFuncionarios()
        {
            var dotNetFiles = Directory.EnumerateFiles(Endereco, "*.IBMDOTNET");
            foreach (string file in dotNetFiles)
            {
                using (StreamReader registroFuncionarios = File.OpenText(file))
                {
                    registroFuncionarios.ReadLine();
                    while (!registroFuncionarios.EndOfStream)
                    {

                        string[] registro = registroFuncionarios.ReadLine().Split(";");
                        Funcionario funcionario = NovoFuncionario(registro);
                        Funcionarios.Add(funcionario);

                    }
                }
                MoverArquivoSucesso(file);
            }
            return Funcionarios;
        }

        public List<string> ListarDiretorios()
        {
            List<string> files = new List<string>();
            var allFiles = Directory.EnumerateFiles(Endereco, "*.*", SearchOption.AllDirectories);
            Console.WriteLine("************ Arquivos do Diretório ************");
            foreach (var file in allFiles)
            {
                files.Add(Path.GetFileName(file));
            }
            return files;
        }

        public void MoverArquivoErro(string endereco)
        {
            string fileName = Path.GetFileName(endereco);
            string pastaError = $"{Endereco}\\ERROR\\{fileName}";
            File.Move(endereco, pastaError, true);
        }

        public void MoverArquivoSucesso(string endereco)
        {
            string fileName = Path.GetFileName(endereco);
            string pastaProcessados = $"{Endereco}\\PROCESSADO\\{fileName}\n";
            File.Move(endereco, pastaProcessados, true);
            
            Console.WriteLine($"{fileName} foi realocado para a pasta Processados.");
        }


        public Funcionario NovoFuncionario(string[] dadosFuncionario)
        {
            int id = int.Parse(dadosFuncionario[0]);
            string nome = dadosFuncionario[1];
            DateTime dataNascimento = DateTime.Parse(dadosFuncionario[2]);
            decimal salario = decimal.Parse(dadosFuncionario[3]);

            return new Funcionario(id, nome, dataNascimento, salario);
        }

        public void ImprimeFuncionarios()
        {          
            
            if (Funcionarios.Count != 0)
            {
                Console.WriteLine("Funcionarios encontrados: \n");              
                Console.WriteLine("Id ".PadRight(10) + " Nome ".PadRight(20) + " Data de Nascimento ".PadRight(20) + " Salario ".PadRight(10));
                foreach (Funcionario f in Funcionarios)
                {
                    Console.WriteLine(f);
                }
            }          
        }

    }
}

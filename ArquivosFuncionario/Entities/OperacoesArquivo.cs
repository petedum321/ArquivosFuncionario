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
        public List<Funcionario> Funcionarios { get; set; }

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

            BuscaArquivosDotNet(dotNetFiles);

            return Funcionarios;           
        }

        public void BuscaArquivosDotNet(IEnumerable<string> dotNetFiles)
        {
            foreach (string file in dotNetFiles)
            {
                ObterListFuncionarios(file);
            }
        }

        public void ObterListFuncionarios(string file)
        {
            
            try
            {
                using (StreamReader registroFuncionarios = File.OpenText(file))
                {
                    registroFuncionarios.ReadLine();
                    while (!registroFuncionarios.EndOfStream)
                    {

                        string[] registro = registroFuncionarios.ReadLine().Split(";");
                        Funcionario funcionario = NovoFuncionarioLinhaTxt(registro);
                        Funcionarios.Add(funcionario);
                    }
                }
                MoverArquivoSucesso(file);
            }
            catch (FormatException e)
            {
                MoverArquivoErro(file);
                Console.WriteLine("Arquivo incompatível!");
                Console.WriteLine();
            }
        }

        private Funcionario NovoFuncionarioLinhaTxt(string[] fileTxt)
        {
            Console.WriteLine();
            int id = int.Parse(fileTxt[0]);
            string nome = fileTxt[1];
            DateTime dataNascimento = DateTime.Parse(fileTxt[2]);
            decimal salario = decimal.Parse(fileTxt[3]);

            Funcionario funcionarioExistente = Funcionarios.Find(x => x.Name == nome);

            if (funcionarioExistente == null)
                return new Funcionario(id, nome, dataNascimento, salario);
            
            else                   
                throw new FormatException("Esse funcionário já existe!");           
        }


        public List<string> ListarDiretorios()
        {
            
            List<string> files = new List<string>();

            var allFiles = Directory.EnumerateFiles(Endereco, "*.*", SearchOption.AllDirectories);
            
            foreach (var file in allFiles)
            {
                files.Add(Path.GetFileName(file));
            }
            return files;
        }

        public void MoverArquivoErro(string endereco)
        {
            Console.WriteLine();
            string fileName = Path.GetFileName(endereco);
            string diretorioError = $"{Endereco}\\ERROR\\{fileName}";
            File.Move(endereco, diretorioError, true);
            Console.WriteLine($"{fileName} foi realocado para a pasta Error.");
        }

        public void MoverArquivoSucesso(string endereco)
        {
            Console.WriteLine();
            string fileName = Path.GetFileName(endereco);
            string pastaProcessados = $"{Endereco}\\PROCESSADO\\{fileName}";
            File.Move(endereco, pastaProcessados, true);
            Console.WriteLine($"{fileName} foi realocado para a pasta Processados.");
        }
      

    }
}
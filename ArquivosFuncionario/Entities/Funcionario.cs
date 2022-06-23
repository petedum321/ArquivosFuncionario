using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquivosFuncionario.Entities
{
    class Funcionario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }


        public Funcionario()
        {
        }
        public Funcionario(int id, string name, DateTime dataNascimento, decimal salario)
        {
            Id = id;
            Name = name;
            DataNascimento = dataNascimento;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{Id, -13} {Name, -25} {DataNascimento,-27:dd/MM/yyyy} {Salario, -20}"; 
        }
    }
}

using ArquivosFuncionario.Entities;
using System.Collections.Generic;


namespace ArquivosFuncionario
{
    interface IProcedimentos
    {
        List<string> ListarDiretorios();
        List<Funcionario> ListaFuncionarios();
        void MoverArquivoSucesso(string endereco);
        void MoverArquivoErro(string endereco);
    }
}

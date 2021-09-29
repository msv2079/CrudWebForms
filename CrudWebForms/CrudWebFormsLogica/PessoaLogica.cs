using CrudWebFormsConexao;
using CrudWebFormsEntidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebFormsLogica
{
    public class PessoaLogica
    {
        PessoaConexao pessoaConexao = new PessoaConexao();

        public bool TestarPessoa(int idade)
        {
            if (idade >= 18 && idade <= 60)
            {
                return true;
            }

            return false;
        }

        public List<Pessoa> Listar()
        {
            return pessoaConexao.Listar();
        }

        public void Inserir(string nome, string idade, string cpf)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Preencha o nome!");
            }

            if (nome.Length > 100)
            {
                throw new Exception("Preencha o nome com até 100 caracteres!");
            }

            int idadeTeste;

            if (!int.TryParse(idade, out idadeTeste))
            {
                throw new Exception("Preencha a idade com número!");
            }

            if (string.IsNullOrEmpty(cpf))
            {
                throw new Exception("Preencha o cpf!");
            }

            if (cpf.Length > 11)
            {
                throw new Exception("Preencha o cpf com até 11 caracteres!");
            }

            pessoaConexao.Inserir(nome, idadeTeste, cpf);
        }

        public void Excluir(int id)
        {
            pessoaConexao.Excluir(id);
        }
    }
}

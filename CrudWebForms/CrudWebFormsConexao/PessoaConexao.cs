using CrudWebFormsEntidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebFormsConexao
{
    public class PessoaConexao : Conexao
    {
        public List<Pessoa> Listar()
        {
            var lista = new List<Pessoa>();

            var dt = ExecuteDataTable("SELECT * FROM PESSOA");

            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Pessoa
                {
                    Id = Convert.ToInt32(row["Id"].ToString()),
                    Nome = row["Nome"].ToString(),
                    Idade = Convert.ToInt32(row["Idade"].ToString()),
                    CPF = row["CPF"].ToString(),
                });
            }

            return lista;
        }

        public void Inserir(string nome, int idade, string cpf)
        {
            var qry = $"INSERT INTO PESSOA VALUES ('{nome}', {idade}, '{cpf}')";

            ExecuteNonQuery(qry);
        }

        public void Excluir(int id)
        {
            ExecuteNonQuery($"DELETE FROM PESSOA WHERE ID = {id}");
        }
    }
}

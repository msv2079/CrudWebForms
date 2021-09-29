using CrudWebFormsLogica;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudWebFormsApresentacao
{
	public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PreencherLista();
            }
        }

        private void PreencherLista()
        {
            PessoaLogica p = new PessoaLogica();

            var lista = p.Listar();

            ListaRepeater.DataSource = lista;
            ListaRepeater.DataBind();
        }

        protected void InserirButton_Click(object sender, EventArgs e)
        {
            PessoaLogica p = new PessoaLogica();

            try
            {
                p.Inserir(NomeTextBox.Text, IdadeTextBox.Text, CPFTextBox.Text);

                MensagemLabel.Text = "Pessoa Inserida com sucesso!";

                NomeTextBox.Text = "";
                IdadeTextBox.Text = "";
                CPFTextBox.Text = "";

                PreencherLista();
            }
            catch (Exception ex)
            {
                MensagemLabel.Text = ex.Message;
            }
        }

        protected void ListaRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                var id = Convert.ToInt32(e.CommandArgument);

                PessoaLogica p = new PessoaLogica();

                p.Excluir(id);

                MensagemLabel.Text = "Pessoa excluída com sucesso!";
            }
            else if (e.CommandName == "Editar")
            {

            }

            PreencherLista();
        }
    }
}
using AgendaDeContatos.DAO;
using AgendaDeContatos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaDeContatos
{
    public partial class ListagemDePessoas : System.Web.UI.Page
    {
        RegrasDAO dao = new RegrasDAO();
        EntidadePessoa p = new EntidadePessoa();
        EntidadeTelefone t = new EntidadeTelefone();
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView1.DataSource = dao.ListarContatos();
            GridView1.DataBind();

        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pessoa.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = dao.ListarPorNomeOuCPF(txtNome.Text, txtCpf.Text);
            GridView1.DataBind();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = dao.ListarContatos();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);
            dao.DeleteTelefone(id);
            dao.DeletarPessoa(id);
            GridView1.DataSource = dao.ListarContatos();
            GridView1.DataBind();
        }
    }
}
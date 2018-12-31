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
            if (!Page.IsPostBack)
            {
                GridView1.DataSource = dao.ListarContatos();
                GridView1.DataBind();
            }
        }
        
    }
}
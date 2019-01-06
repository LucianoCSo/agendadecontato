using AgendaDeContatos.DAO;
using AgendaDeContatos.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgendaDeContatos
{
    public partial class EditarPessoa : System.Web.UI.Page
    {
        RegrasDAO dao = new RegrasDAO();
        EntidadePessoa pessoa = new EntidadePessoa();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pessoa = dao.ListarPessoaPorId(Convert.ToInt32(Session["Id"]));
                txtNome.Text = pessoa.Nome;
                txtCpf.Text = pessoa.CPF;
                txtNascimento.Text = pessoa.DataNascimento.ToString();
                txtEmail.Text = pessoa.Email;

                List<EntidadeTelefone> lista = new List<EntidadeTelefone>();
                lista = dao.ListarTelefonesPorIdPessoa(Convert.ToInt32(Session["Id"]));
                for (int i = 0; i < lista.Count; i++)
                {
                    if (ViewState["Row"] != null)
                    {
                        dt = (DataTable)ViewState["Row"];
                        DataRow dr = null;
                        if (dt.Rows.Count >= 0)
                        {
                            dr = dt.NewRow();
                            dr["Id"] = lista[i].Id;
                            dr["DDD"] = lista[i].DDD;
                            dr["Numero"] = lista[i].Numero;
                            dr["IdContato"] = lista[i].IdPessoa;
                            dt.Rows.Add(dr);
                            ViewState["Row"] = dt;
                        }
                    }
                    else
                    {
                        dt.Columns.Add("Id", typeof(int));
                        dt.Columns.Add("DDD", typeof(string));
                        dt.Columns.Add("Numero", typeof(string));
                        dt.Columns.Add("IdContato", typeof(int));
                        DataRow drf = dt.NewRow();
                        drf["Id"] = lista[i].Id;
                        drf["DDD"] = lista[i].DDD;
                        drf["Numero"] = lista[i].Numero;
                        drf["IdContato"] = lista[i].IdPessoa;
                        dt.Rows.Add(drf);
                        ViewState["Row"] = dt;

                    }
                }
                GridView1.DataSource = ViewState["Row"];
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text);
            if (id != 0)
            {
                dao.DeleteTelefonePorId(int.Parse(GridView1.Rows[e.RowIndex].Cells[1].Text));
                GridView1.DataSource = dao.ListarTelefonesPorIdPessoa(Convert.ToInt32(Session["Id"]));
                GridView1.DataBind();
            }
            else
            {
                DataTable dtl = (DataTable)ViewState["Row"];
                if (dtl.Rows.Count > 0)
                {
                    dtl.Rows[e.RowIndex].Delete();
                    GridView1.DataSource = dtl;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["Row"];
            DataRow dr = null;
            if (dt.Rows.Count >= 0)
            {
                dr = dt.NewRow();
                dr["Id"] = 0;
                dr["DDD"] = Request["txtDdd"];
                dr["Numero"] = Request["txtTelefone"];
                dr["IdContato"] = Convert.ToInt32(Session["Id"]);
                dt.Rows.Add(dr);
                ViewState["Row"] = dt;
                GridView1.DataSource = ViewState["Row"];
                GridView1.DataBind();
            }
        }

    }
}
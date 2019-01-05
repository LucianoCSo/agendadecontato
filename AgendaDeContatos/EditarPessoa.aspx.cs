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
    public partial class EditarPessoa : System.Web.UI.Page
    {
        RegrasDAO dao = new RegrasDAO();
        EntidadePessoa pessoa = new EntidadePessoa();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pessoa = dao.ListarPessoaPorId(Convert.ToInt32(Session["Id"]));
                txtNome.Text = pessoa.Nome;
                txtCpf.Text = pessoa.CPF;
                txtNascimento.Text = pessoa.DataNascimento.ToString();
                txtEmail.Text = pessoa.Email;
                GridView1.DataSource = dao.ListarTelefonesPorIdPessoa(Convert.ToInt32(Session["Id"]));
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
            CriarTabela();
        }
        private void CriarTabela()
        {
            try
            {
                DataTable dt = new DataTable();
                if (Request["txtDdd"] == string.Empty || Request["txtTelefone"] == string.Empty)
                {
                    labAlerta.Visible = true;
                    labAlerta.Text = "Os campos são obrigatorios.";
                }
                else
                {
                    labAlerta.Visible = false;
                    if (ViewState["RowEdit"] != null)
                    {
                        dt = (DataTable)ViewState["RowEdit"];
                        DataRow dr = null;
                        if (dt.Rows.Count >= 0)
                        {
                            dr = dt.NewRow();
                            dr["Id"] = "";
                            dr["DDD"] = Request["txtDdd"];
                            dr["Telefone"] = Request["txtTelefone"];
                            dt.Rows.Add(dr);
                            ViewState["RowEdit"] = dt;
                            GridView1.DataSource = ViewState["Row"];
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        dt.Columns.Add("Id", typeof(string));
                        dt.Columns.Add("DDD", typeof(string));
                        dt.Columns.Add("Telefone", typeof(string));
                        DataRow drf = dt.NewRow();
                        drf["Id"] = "";
                        drf["DDD"] = Request["txtDdd"];
                        drf["Telefone"] = Request["txtTelefone"];
                        dt.Rows.Add(drf);
                        ViewState["RowEdit"] = dt;
                        GridView1.DataSource = ViewState["RowEdit"];
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
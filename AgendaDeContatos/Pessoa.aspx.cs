using AgendaDeContatos.DAO;
using AgendaDeContatos.Entidades;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AgendaDeContatos
{
    public partial class Pessoa : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
        }
        RegrasDAO dao = new RegrasDAO();
        EntidadePessoa p = new EntidadePessoa();
        EntidadeTelefone t = new EntidadeTelefone();

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
                    if (ViewState["Row"] != null)
                    {
                        dt = (DataTable)ViewState["Row"];
                        DataRow dr = null;
                        if (dt.Rows.Count >= 0)
                        {
                            dr = dt.NewRow();
                            dr["DDD"] = Request["txtDdd"];
                            dr["Telefone"] = Request["txtTelefone"];
                            dt.Rows.Add(dr);
                            ViewState["Row"] = dt;
                            GridView1.DataSource = ViewState["Row"];
                            GridView1.DataBind();
                        }                       
                    }
                    else
                    {
                        dt.Columns.Add("DDD", typeof(string));
                        dt.Columns.Add("Telefone", typeof(string));
                        DataRow drf = dt.NewRow();
                        drf["DDD"] = Request["txtDdd"];
                        drf["Telefone"] = Request["txtTelefone"];
                        dt.Rows.Add(drf);
                        ViewState["Row"] = dt;
                        GridView1.DataSource = ViewState["Row"];
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dtl = (DataTable)ViewState["Row"];
            if(dtl.Rows.Count > 0)
            {
                dtl.Rows[e.RowIndex].Delete();
                GridView1.DataSource = dtl;
                GridView1.DataBind();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                p.Nome = txtNome.Text;
                p.CPF = txtCpf.Text;
                p.DataNascimento = Convert.ToDateTime(txtNascimento.Text);
                p.Email = txtEmail.Text;
                dao.SalvarPessoa(p);

                Int32 id = dao.SelecionarPessoa();
                for(int i = 0; i < GridView1.Rows.Count; i++)
                {
                    t.DDD = GridView1.Rows[i].Cells[1].Text;
                    t.Numero = GridView1.Rows[i].Cells[2].Text;
                    t.IdPessoa = id;
                    dao.SalvarContato(t);
                }
                GridView1.DataSource = null;
            }
            catch(Exception ex)
            {
                labAlerta.Visible = true;
                labAlerta.Text = ex.Message;
            }
        }
    }
}
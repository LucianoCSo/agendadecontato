using AgendaDeContatos.Entidades;
using AgendaDeContatos.Util;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AgendaDeContatos.DAO
{
    public class RegrasDAO
    {
        Teste conectar = new Teste();

        public Int32 SalvarPessoa(EntidadePessoa p)
        {
            string link = @"insert into Pessoa values(@nome, @cpf, @nascimento, @email)";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                com.Parameters.AddWithValue("@nome", p.Nome);
                com.Parameters.AddWithValue("@cpf", p.CPF);
                com.Parameters.AddWithValue("@nascimento", p.DataNascimento);
                com.Parameters.AddWithValue("@email", p.Email);
                Int32 salvar = Convert.ToInt32(com.ExecuteScalar());
                return salvar;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }
        public Int32 SalvarContato(EntidadeTelefone t)
        {
            string link = @"insert into Telefone values(@ddd, @numero, @id)";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                com.Parameters.AddWithValue("@ddd", t.DDD);
                com.Parameters.AddWithValue("@numero", t.Numero);
                com.Parameters.AddWithValue("@id", t.IdPessoa);
                Int32 salvar = Convert.ToInt32(com.ExecuteScalar());
                return salvar;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }
        public int SelecionarPessoa()
        {
            string link = @"select top 1 id from Pessoa order by id desc";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                int id = int.Parse(com.ExecuteScalar().ToString());
                return id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Conectar();
            }
        }
        public DataTable ListarContatos()
        {
            string link = "declare @Hoje datetime = getdate() " + 
                            "select distinct p.id as 'ID', p.nome as 'Nome', p.email as 'E-mail', " +
                             "p.cpf as 'CPF', CONCAT(FLOOR(DATEDIFF(DAY, p.dataNascimento, @Hoje) / 365.25), ' Anos') AS 'Idade', " +
                              "count(t.numero) as 'Quantidade de Telefones' from Pessoa p " +
                               "join Telefone t on t.idPessoa = p.id " +
                                "group by p.id, p.nome, p.cpf, p.email, p.dataNascimento";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }
        public DataTable ListarPorNomeOuCPF(string nome, string cpf)
        {
            string link = "declare @Hoje datetime = getdate() "+ 
                            "select distinct p.id as 'ID', p.nome as 'Nome', p.email as 'E-mail', p.cpf as 'CPF', " +
                            "CONCAT(FLOOR(DATEDIFF(DAY, p.dataNascimento, @Hoje) / 365.25), ' Anos') AS 'Idade', " +
                            "count(t.numero) as 'Quantidade de Telefones' from Pessoa p " +
                            "join Telefone t on t.idPessoa = p.id " +
                            "where p.nome like'%'+ @nome +'%' and p.cpf like'%'+ @cpf +'%' " +
                            "group by p.id, p.nome, p.cpf, p.email, p.dataNascimento";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                com.Parameters.AddWithValue("@nome", nome);
                com.Parameters.AddWithValue("@cpf", cpf);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }

        public Int32 DeleteTelefone(int id)
        {
            string link = "delete Telefone where idPessoa = @id";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                com.Parameters.AddWithValue("@id", id);
                Int32 salvar = Convert.ToInt32(com.ExecuteScalar());
                return salvar;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }
        public Int32 DeletarPessoa(int id)
        {
            string link = "delete Pessoa where id = @id";
            try
            {
                conectar.Conectar();
                SqlCommand com = new SqlCommand(link, conectar.con);
                com.Parameters.AddWithValue("@id", id);
                Int32 salvar = Convert.ToInt32(com.ExecuteScalar());
                return salvar;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conectar.Desconectar();
            }
        }
    }
}
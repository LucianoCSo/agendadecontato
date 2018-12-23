using AgendaDeContatos.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgendaDeContatos.Entidades;
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
    }
}
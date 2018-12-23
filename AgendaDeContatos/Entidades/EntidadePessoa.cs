using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaDeContatos.Entidades
{
    public class EntidadePessoa
    {
        private int id;
        private string nome;
        private string cpf;
        private DateTime dataNascimento;
        private string email;

        public EntidadePessoa() { }

        public EntidadePessoa(string nome, string cpf, DateTime nascimento, string email)
        {
            this.nome = nome;
            this.cpf = cpf;
            this.dataNascimento = nascimento;
            this.email = email;
        }

        public virtual string Nome
        {
            get { return nome; }
            set
            {
                if (value != string.Empty)
                {
                    nome = value;
                }
                else
                {
                    nome = "Nome obrigatorio";
                }
            }
        }
        public virtual string CPF
        {
            get { return cpf; }
            set
            {
                if (value != string.Empty)
                {
                    cpf = value;
                }
                else
                {
                    cpf = "Nome obrigatorio";
                }
            }
        }
        public virtual DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }
        public virtual string Email
        {
            get { return cpf; }
            set
            {
                if (value != string.Empty)
                {
                    email = value;
                }
                else
                {
                    email = "Nome obrigatorio";
                }
            }
        }
    }
}
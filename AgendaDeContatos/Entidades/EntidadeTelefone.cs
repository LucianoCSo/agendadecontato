using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaDeContatos.Entidades
{
    public class EntidadeTelefone
    {
        private int id;
        private string ddd;
        private string numero;
        private int idPessoa;

        public EntidadeTelefone() { }
        public EntidadeTelefone(string ddd, string numero, int idPessoa)
        {
            this.ddd = ddd;
            this.numero = numero;
            this.idPessoa = idPessoa;
        }

        public virtual string DDD
        {
            get { return ddd; }
            set
            {
                if (value != string.Empty)
                {
                    ddd = value;
                }
                else
                {
                    ddd = "Campo obrigatorio.";
                }
            }
        }
        public virtual string Numero
        {
            get { return numero; }
            set
            {
                if (value != string.Empty)
                {
                    numero = value;
                }
                else
                {
                    numero = "Campo obrigatorio.";
                }
            }
        }
        public virtual int IdPessoa
        {
            get { return idPessoa; }
            set { idPessoa = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidade.Entitis
{
    public class Telefone
    {
        private int id;
        private string ddd;
        private string numero;
        private int idPessoa;

        public Telefone() { }
        public Telefone(string ddd, string numero, int idPessoa)
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

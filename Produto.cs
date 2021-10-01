using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Produto : IProduto
    {
        private string nome;
        private string nomeLoja;
        private double preco = 0;

        public Produto(string nome, string nomeLoja, double preco)
        {
            this.Nome = nome;
            this.NomeLoja = nomeLoja;
            this.Preco = preco;
        }

        public string Nome 
        {
            get { return nome; }
            set { nome = value; }  
        }

        public string NomeLoja 
        {
            get { return nomeLoja; }
            set { nomeLoja = value; }
        }

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }
    }     
}

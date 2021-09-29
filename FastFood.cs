using System.Globalization;
using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class FastFood : IAlimentacao
    {
        private string nome;
        private double aluguel = 0;

        public FastFood(string nome)
        {
            this.Nome = nome;
        }

        public FastFood(string nome, double aluguel)
        {
            this.Nome = nome;
            this.Aluguel = aluguel;
        }

        public string Nome 
        {
            get { return nome; }
            set { nome = value; } 
        }

        public double Aluguel
        {
            get { return aluguel; }
            set { aluguel = value; } 
        }

        public int Numeracao
        {
            get { return 101; }
        }

        public void Vender()
        {
            Console.WriteLine($"{Nome} - Venda concluida com sucesso");
        }

        public virtual void PrepararPedido(string produto)
        {
            Console.WriteLine($"{produto} está sendo preparado");
        }
    }
}
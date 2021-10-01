using System.Globalization;
using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class FastFood : IAlimentacao
    {
        private string nome;
        private string tipoLoja;

        public FastFood(string nome)
        {
            this.Nome = nome;
        }

        public FastFood(string nome, string tipoLoja)
        {
            this.Nome = nome;
            this.TipoLoja = tipoLoja;
        }

        public string Nome 
        {
            get { return nome; }
            set { nome = value; } 
        }

        public string TipoLoja
        {
            get { return tipoLoja; }
            set { tipoLoja = value; } 
        }

        public void Vender()
        {
            Console.WriteLine($"{Nome} - Venda concluida com sucesso");
        }

        public virtual void PrepararPedido(string produto)
        {
            Console.WriteLine($"{produto} está sendo preparado(a)");
        }
    }
}
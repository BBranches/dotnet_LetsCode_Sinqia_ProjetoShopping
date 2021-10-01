using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class SelfService : IAlimentacao
    {
        private string nome;
        private string tipoLoja;

        public SelfService(string nome)
        {
            this.Nome = nome;
        }

        public SelfService(string nome, string tipoLoja)
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

        public void PrepararPedido(string produto)
        {
            Console.WriteLine($"{produto} adicionado(a) no prato");
        }
    }
}
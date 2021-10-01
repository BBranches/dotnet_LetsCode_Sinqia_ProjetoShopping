using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class LojaDepartamento : IVestuario
    {

        private string nome;
        private string tipoLoja;

        public LojaDepartamento(string nome)
        {
            this.Nome = nome;
        }

        public LojaDepartamento(string nome, string tipoLoja)
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
            ProcurarNoEstoque();
            Console.WriteLine($"{Nome} - Venda concluida com sucesso");
        }

        public void ProcurarNoEstoque()
        {
            Console.WriteLine("Subir escada correndo");
            Console.WriteLine("Bater o pé no teto");
            Console.WriteLine("Descer correndo");
        }
    }
}
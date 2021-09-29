using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class LojaDepartamento : IVestuario
    {

        private string nome;
        private double aluguel = 0;

        public LojaDepartamento(string nome)
        {
            this.Nome = nome;
        }

        public LojaDepartamento(string nome, double aluguel)
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
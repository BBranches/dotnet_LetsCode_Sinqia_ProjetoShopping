using System;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
    public class SelfService : IAlimentacao
    {

         private string nome;
         public string Nome 
         {
            get { return nome;}
            set { nome = value;}
         
         }
         public int Numeracao
         {
             get { return 101;}
        }

         double aluguel = 100000;
         public double Aluguel
         {
             get { return aluguel;}
         }

         public SelfService(string nome)
         {
             this.Nome = nome;
         }

           public SelfService(string nome, double aluguel)
         {
             this.Nome = nome;
             this.aluguel = aluguel;
         }

         public void Vender()
         {
             PrepararPedido();
             Console.WriteLine($"{Nome} - Venda concluida com sucesso");
         }

         public void PrepararPedido()
         {
             Console.WriteLine("Colando comida no prato");
         }
    }
}
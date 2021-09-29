using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface ILoja
    {
        string Nome { get; set; }
        int Numeracao { get; }
        double Aluguel { get; }
        void Vender();
    }
}
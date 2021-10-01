using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface ILoja
    {
        string Nome { get; set; }
        string TipoLoja { get; set; }
        void Vender();
    }
}
using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IAlimentacao : ILoja
    {
        void PrepararPedido(string produto);
    }
}
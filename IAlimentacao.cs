using System;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
    public interface IAlimentacao : ILoja
    {
        void PrepararPedido();
    }
}
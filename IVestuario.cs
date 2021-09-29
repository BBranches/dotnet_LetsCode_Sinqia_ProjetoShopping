using System;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
    public interface IVestuario : ILoja
    {
        void ProcurarNoEstoque();
    }
}
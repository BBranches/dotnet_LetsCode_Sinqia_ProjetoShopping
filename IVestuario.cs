using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IVestuario : ILoja
    {
        void ProcurarNoEstoque();
    }
}
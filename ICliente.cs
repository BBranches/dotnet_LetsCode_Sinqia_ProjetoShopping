using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface ICliente
    {
        long CPF { get; set; }
        string Nome { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IPassageiro
    {
        string NomePassageiro { get; set; }
        long CPF { get; set; }  
    }
}
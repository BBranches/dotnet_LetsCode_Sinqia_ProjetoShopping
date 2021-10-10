using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public interface IPassagem
    {  
        int NumeroPassagem { get; set; }
        int NumeroVoo { get; set; }
        string Companhia { get; set; }
        string TipoAeronave { get; set; }
        int NumeroAssento { get; set; }
        string Origem { get; set; }
        string Destino { get; set; }
        int HorarioPartida { get; set; }
        int HorarioChegada { get; set; }        
    }
}
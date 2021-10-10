using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class Aeronave : IAeronave
    {
        public string tipoAeronave;
        public int numeroAeronave;

        public Aeronave(string tipoAeronave, int numeroAeronave)
        {
            this.tipoAeronave = tipoAeronave;
            this.numeroAeronave = numeroAeronave;
        }

        public string TipoAeronave {
            get => tipoAeronave;
            set {
                tipoAeronave = value;
            }
        }
            
        public int NumeroAeronave {
            get => numeroAeronave;
            set {
                numeroAeronave = value;
            }
        }
    }
}
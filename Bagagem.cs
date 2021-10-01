using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class Bagagem : IBagagem
    {
        public double peso;
        public string tipoBagagem;

        public Bagagem(string tipoBagagem, double peso)
        {
            this.peso = peso;
        }

        public double Peso {
            get => peso;
            set {
                peso = value;
            }
        }
        public string TipoBagagem {
            get => tipoBagagem;
            set {
                tipoBagagem = value;
            }
        }    
        
    }
}
using System;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Cliente : ICliente
    {
        public string nome;
        public long CPF { get; set; }

        public Cliente(long cpf, string nome)
        {
            this.CPF = cpf;
            this.nome = nome;
        }

        public string Nome {
            get => nome;
            set {
                nome = value;
            }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class CarrinhoPassagem
    {
        List<IPassagem> passagens;
        List<IPassagem> passagensDisponiveis = new List<IPassagem>();
        List<IPassageiro> passageiros;
        List<PassagemComprada> passagensCompradas;
        List<IAeronave> aeronaves;

        Menu menu = new Menu();

        public CarrinhoPassagem(List<IPassagem> passagens,List<IPassageiro> passageiros, List<IAeronave> aeronaves, List<PassagemComprada> passagensCompradas){
            this.passagens = passagens;
            this.passageiros = passageiros;
            this.aeronaves = aeronaves;
            this.passagensCompradas = passagensCompradas;
        }

        public void SelectOptionComprarPassagem(int option){
            switch(option){
                case 0:
                    menu.MenuInicial();
                    break;
                case 1:
                    ComprarPassagem();
                    menu.MenuShoppingAirlines(aeronaves, passagens, passageiros);
                    break;
                case 2:
                    ListarPassagensCompradas();
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                break;
            }
        }

        void ComprarPassagem(){
            long cpf;
            int numeroPassagem;

            Console.WriteLine("Passageiros cadastrados:");
            ListarPassageirosCadastrados();

            Console.WriteLine("Passagens disponíveis:");
            ListarPassagensCadastradas();

            do{
                Console.Write("\nDigite o CPF do(a) passageiro(a): ");
                cpf = Convert.ToInt64(Console.ReadLine());

                int indexPassageiro = passageiros.FindIndex(passageiro => passageiro.CPF == cpf);

                Console.Write("\nDigite o número da passagem: ");
                numeroPassagem = Convert.ToInt32(Console.ReadLine());

                int indexPassagem = passagens.FindIndex(passagem => passagem.NumeroPassagem == numeroPassagem);
                int indexDuplicata = passagensCompradas.FindIndex(passagem => passagem.NumeroPassagem == numeroPassagem);

                if (indexPassageiro == -1)
                {
                    Console.WriteLine("Passageiro não cadastrado. Realize o Cadastro de Passageiro!");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                }
                else if(indexPassagem == -1) {
                    Console.WriteLine("Passagem não disponível!");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                }
                else if(indexPassagem == indexDuplicata){
                    Console.WriteLine("Essa passagem já foi adquirida!");
                    menu.MenuPassagem(aeronaves, passagens, passageiros);
                }
                else {
                    var passageiroBuscado = (from passageiro in passageiros
                                where passageiro.CPF == cpf
                                select passageiro).FirstOrDefault();

                    var passagemBuscada = (from passagem in passagens
                                where passagem.NumeroPassagem == numeroPassagem
                                select passagem).FirstOrDefault();
                    
                    passagensCompradas.Add(new PassagemComprada(passageiroBuscado.NomePassageiro, passageiroBuscado.CPF, passagemBuscada.NumeroPassagem, passagemBuscada.NumeroVoo, passagemBuscada.Companhia, passagemBuscada.TipoAeronave, passagemBuscada.NumeroAssento, passagemBuscada.Origem, passagemBuscada.Destino, passagemBuscada.HorarioPartida, passagemBuscada.HorarioChegada));
                    ListarPassagensCompradas();       
                }
                Console.WriteLine("\nDeseja comprar outra passagem?");
            } while(AdicionarNovo());
        }

        void ListarPassagensCadastradas()
        {
            foreach (IPassagem passagem in passagens)
            {
                Console.WriteLine($"Nº da Passagem: {passagem.NumeroPassagem} - Nº do voo: {passagem.NumeroVoo} - Companhia Aérea: {passagem.Companhia} - Tipo Aeronave: {passagem.TipoAeronave} - Número do assento: {passagem.NumeroAssento}");
                Console.WriteLine($"Origem: {passagem.Origem} - Destino: {passagem.Destino} - Horário de Partida: {passagem.HorarioPartida} - Horário de Chegada: {passagem.HorarioChegada}");
            }
        }

        void ListarPassagensCompradas()
        {
            foreach (PassagemComprada passagem in passagensCompradas)
            {
                Console.WriteLine($"Nome Passageiro: {passagem.NomePassageiro} - CPF Passageiro: {passagem.CPF}");
                Console.WriteLine($"Nº da Passagem: {passagem.NumeroPassagem} - Nº do voo: {passagem.NumeroVoo} - Companhia Aérea: {passagem.Companhia} - Tipo Aeronave: {passagem.TipoAeronave} - Número do assento: {passagem.NumeroAssento}");
                Console.WriteLine($"Origem: {passagem.Origem} - Destino: {passagem.Destino} - Horário de Partida: {passagem.HorarioPartida} - Horário de Chegada: {passagem.HorarioChegada}h");
            }
        }

        void ListarAeronavesCadastradas()
        {
            foreach (IAeronave aeronave in aeronaves)
            {
                Console.WriteLine($"Tipo de Aeronave: {aeronave.TipoAeronave} - Número Aeronave: {aeronave.NumeroAeronave}");
            }
        }

        void ListarPassageirosCadastrados()
        {
            foreach (IPassageiro passageiro in passageiros)
            {
                Console.WriteLine($"Nome: {passageiro.NomePassageiro} - CPF: {passageiro.CPF}");
            }
        }

        public static bool AdicionarNovo() {
            bool adicionar = false;

            Console.WriteLine("1 - Sim ");
            Console.WriteLine("2 - Não ");
            Console.Write("Opção: ");
            int opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao) {
                case 1:
                    adicionar = true;
                    break;
                case 2: 
                    adicionar = false;
                    break;
                default:
                    Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                    adicionar = false;
                    break;
            }       
            return adicionar;
        }
    }
}
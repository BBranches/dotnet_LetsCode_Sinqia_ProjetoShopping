using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    public class CarrinhoPassagem
    {
        List<IPassagem> passagens;
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
                    menu.MenuShoppingAirlines(aeronaves, passagens, passageiros);
                    break;
                case 1:
                    ComprarPassagem();
                    menu.MenuCompraPassagem(passagens, passageiros, aeronaves, passagensCompradas);
                    break;
                case 2:
                    ListarPassagensCompradas();
                    menu.MenuCompraPassagem(passagens, passageiros, aeronaves, passagensCompradas);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuCompraPassagem(passagens, passageiros, aeronaves, passagensCompradas);
                break;
            }
        }

        void ComprarPassagem(){
            long cpf;
            int numeroPassagem;

            Console.WriteLine("Passageiros cadastrados:");
            Cadastro.ListarPassageirosCadastrados();

            Console.WriteLine("\nPassagens disponíveis:");
            Cadastro.ListarPassagensCadastradas();

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
                    Console.WriteLine($"Passagem de número {passagemBuscada.NumeroPassagem} para o passageiro(a): {passageiroBuscado.NomePassageiro} comprada com sucesso!");
                    passagens.RemoveAt(indexPassagem);
                }
                Console.WriteLine("\nDeseja comprar outra passagem?");
            } while(Cadastro.AdicionarNovo());
        }

        void ListarPassagensCompradas()
        {
            foreach (PassagemComprada passagem in passagensCompradas)
            {
                Console.WriteLine($"\nNome Passageiro: {passagem.NomePassageiro} - CPF Passageiro: {passagem.CPF}");
                Console.WriteLine($"Nº da Passagem: {passagem.NumeroPassagem} - Nº do voo: {passagem.NumeroVoo} - Companhia Aérea: {passagem.Companhia} - Tipo Aeronave: {passagem.TipoAeronave} - Número do assento: {passagem.NumeroAssento}");
                Console.WriteLine($"Origem: {passagem.Origem} - Destino: {passagem.Destino} - Horário de Partida: {passagem.HorarioPartida} - Horário de Chegada: {passagem.HorarioChegada}h");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_LetsCode__Sinqia_ProjetoShopping
{
    class Cadastro
    {
        List<ILoja> lojas;
        List<ICliente> clientes;

        public Cadastro(List<ILoja> lojas) {
            this.lojas = lojas;
        }

        public Cadastro(List<ICliente> clientes){
            this.clientes = clientes;
        }

        public void SelectOption(int option) {            
            Menu menu = new Menu();

            switch (option)
            {
                case 0:
                    menu.MenuInicial();
                    break;
                case 1:
                    CadastrarLojaDepartamento();
                    menu.MenuGeral(lojas);
                    break;
                case 2:
                    CadastrarSelfService();
                    menu.MenuGeral(lojas);
                    break;
                case 3:
                    CadastrarFastFood();
                    menu.MenuGeral(lojas);
                    break;
                case 4:
                    ListarLojasCadastradas();
                    menu.MenuGeral(lojas);
                    break;
                case 5:
                    menu.MenuGeral(lojas);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuGeral(lojas);
                    break;
            }
        }

        public void SelectOptionCliente(int option) { 
            Menu menu = new Menu();

            switch(option){
            case 0:
                menu.MenuInicial();
                break;

            case 1:
                CadastrarCliente();
                menu.MenuClientes(clientes);
                break;
                
            case 2:
                ListarClientesCadastrados();
                menu.MenuClientes(clientes);
                break;

            case 3:
                Console.WriteLine("Ainda não implementado :)");
                menu.MenuClientes(clientes);
            break;
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuClientes(clientes);
                break;
            }

            
            
        }
      
        void CadastrarCliente(){
            string nomeCliente = "";
            long CPF;
            bool novamente = false;

            do{
                Console.Write("Digite o nome do cliente a ser cadastrado: ");
                nomeCliente = Console.ReadLine();

                Console.Write("Digite o CPF do cliente: ");
                CPF = Convert.ToInt64(Console.ReadLine());
                clientes.Add(new Cliente(CPF, nomeCliente));

                Console.Write("\nDeseja cadastrar outro Cliente? Sim ou não (sem acento): ");
                string simNao = Console.ReadLine().ToUpper();
                switch (simNao) {
                    case "SIM":
                        novamente = true;
                        break;
                    case "NAO": 
                        novamente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                        novamente = false;
                        break;
                }
            }while(novamente);
        }

        void CadastrarLojaDepartamento()
        {           
            string nomeLoja = "";
            double aluguelLoja;
            bool novamente = false;

            do {
                Console.Write("Digite o nome da loja de departamento que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();

                Console.Write("Digite o valor do aluguel da loja de departamento: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());
                lojas.Add(new FastFood(nomeLoja, aluguelLoja));
                
                Console.Write("\nDeseja cadastrar outra loja? Sim ou não (sem acento): ");
                string simNao = Console.ReadLine().ToUpper();
                switch (simNao) {
                    case "SIM":
                        novamente = true;
                        break;
                    case "NAO": 
                        novamente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                        novamente = false;
                        break;
                }

            } while(novamente);
        }

        void CadastrarFastFood()
        {           
            string nomeLoja = "";
            double aluguelLoja;
            bool novamente = false;

            do {
                Console.Write("Digite o nome do FastFood que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();
                Console.Write("Digite o valor do aluguel do FastFood: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());
                lojas.Add(new FastFood(nomeLoja, aluguelLoja));
                
                Console.Write("\nDeseja cadastrar outro FastFood? Sim ou não (sem acento): ");
                string simNao = Console.ReadLine().ToUpper();
                switch (simNao) {
                    case "SIM":
                        novamente = true;
                        break;
                    case "NAO": 
                        novamente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                        novamente = false;
                        break;
                }

            } while(novamente);
        }

        void CadastrarSelfService()
        {           
            string nomeLoja = "";
            double aluguelLoja;
            bool novamente = false;

            do {
                Console.Write("Digite o nome do Self Service que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();
                Console.Write("Digite o valor do aluguel do Self Service: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());
                lojas.Add(new FastFood(nomeLoja, aluguelLoja));
                
                Console.Write("\nDeseja cadastrar outro Self Service? Sim ou não (sem acento): ");
                string simNao = Console.ReadLine().ToUpper();
                switch (simNao) {
                    case "SIM":
                        novamente = true;
                        break;
                    case "NAO": 
                        novamente = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida, não haverá novo cadastro");
                        novamente = false;
                        break;
                }

            } while(novamente);
        }

        void ListarLojasCadastradas()
        {
            foreach (ILoja loja in lojas)
            {
                Console.WriteLine($"Loja: {loja.Nome} - Aluguel: {loja.Aluguel}");
            }
        }

        void ListarClientesCadastrados()
        {
            foreach (ICliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome} - CPF: {cliente.CPF}");
            }
        }
    }
}

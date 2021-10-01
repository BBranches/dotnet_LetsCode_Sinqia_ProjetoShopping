using System;
using System.Collections.Generic;

namespace dotnet_LetsCode_Sinqia_ProjetoShopping
{
    class Cadastro
    {
        public static List<ILoja> lojas;
        List<ICliente> clientes;
        public static List<IProduto> produtos;
        List<IProduto> produtosComprados = new List<IProduto>();

        Menu menu = new Menu();

        public Cadastro(List<ILoja> lojas, List<IProduto> produtos) {
            Cadastro.lojas = lojas;
            Cadastro.produtos = produtos;
        }

        public Cadastro(List<ICliente> clientes){
            this.clientes = clientes;
        }

        public void SelectOption(int option) {            

            switch (option)
            {
                case 0:
                    menu.MenuInicial();
                    break;
                case 1:
                    CadastrarLojaDepartamento();
                    menu.MenuLojas(lojas, produtos); 
                    break;
                case 2:
                    CadastrarSelfService();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 3:
                    CadastrarFastFood();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 4: 
                    CadastrarProduto();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 5:
                    ListarLojasCadastradas();
                    menu.MenuLojas(lojas, produtos);
                    break;
                case 6: 
                    ListarProdutosCadastrados();
                    menu.MenuLojas(lojas, produtos);
                    break;
                default:
                    Console.WriteLine("Opção incorreta, tente novamente\n");
                    menu.MenuLojas(lojas, produtos);
                    break;
            }
        }

        public void SelectOptionCliente(int option) { 

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
            default:
                Console.WriteLine("Opção incorreta, tente novamente\n");
                menu.MenuClientes(clientes);
                break;
            }    
        }
      
        void CadastrarCliente() {
            string nomeCliente = "";
            long CPF;

            do {
                Console.Write("\nDigite o nome do cliente a ser cadastrado: ");
                nomeCliente = Console.ReadLine();

                Console.Write("Digite o CPF do cliente: ");
                CPF = Convert.ToInt64(Console.ReadLine());
                clientes.Add(new Cliente(CPF, nomeCliente));

                Console.WriteLine("\nDeseja cadastrar outro Cliente?");

            } while(AdicionarNovo());
        }

        void CadastrarLojaDepartamento()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome da loja de departamento que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();

                Console.Write("Digite o valor do aluguel da loja de departamento: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new LojaDepartamento(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outra loja?");

            } while(AdicionarNovo());
        }

        void CadastrarProduto()
        {
            string nomeLoja;
            string nomeProduto;
            double preco;

            do
            {
                    Console.Write("\nDigite o nome da loja em que será cadastrado o produto: ");
                    nomeLoja = Console.ReadLine();

                    int indexLoja = lojas.FindIndex(loja => loja.Nome == nomeLoja);

                    if (indexLoja == -1)
                    {
                        Console.WriteLine("Loja não encontrada. Tente novamente ou cadastre a loja.");
                        menu.MenuLojas(lojas,produtos); 
                    }

                    else
                    {
                        Console.Write("Digite o nome do produto: ");
                        nomeProduto = Console.ReadLine();

                        Console.Write("Digite o preço do produto: ");
                        preco = Convert.ToDouble(Console.ReadLine());
                        produtos.Add(new Produto(nomeProduto, nomeLoja, preco));

                        Console.WriteLine("\n Deseja cadastrar um novo produto?");
                    }
            }while (AdicionarNovo());
        }

        public static int ListarProdutosCadastrados()
        {
            if(produtos == null) {
                return 0;
            } 
            else {
                foreach (IProduto produto in produtos)
                {
                    Console.WriteLine($"Loja: {produto.NomeLoja} - Produto: {produto.Nome} - Preço: R${produto.Preco}");
                }
                return 1;
            }     
        }

        void CadastrarFastFood()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome do FastFood que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();

                Console.Write("Digite o valor do aluguel do FastFood: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new FastFood(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outro FastFood?");

            } while(AdicionarNovo());
        }

        void CadastrarSelfService()
        {           
            string nomeLoja = "";
            double aluguelLoja;

            do {
                Console.Write("\nDigite o nome do Self Service que deseja cadastrar: ");
                nomeLoja = Console.ReadLine();
                
                Console.Write("Digite o valor do aluguel do Self Service: ");
                aluguelLoja = Convert.ToDouble(Console.ReadLine());

                lojas.Add(new SelfService(nomeLoja, aluguelLoja));
                
                Console.WriteLine("\nDeseja cadastrar outro Self Service?");

            } while(AdicionarNovo());
        }

        public static void ListarLojasCadastradas()
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

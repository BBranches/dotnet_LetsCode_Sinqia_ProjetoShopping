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

        public Cadastro(List<ILoja> lojas) {
            this.lojas = lojas;
        }

        public void SelectOption(int option) {            
            Menu menu = new Menu();

            switch (option)
            {
                case 0:
                    Environment.Exit(0);
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
            Console.WriteLine("Estas são as lojas cadastradas: ");
            foreach (ILoja loja in lojas)
            {
                Console.WriteLine($"Loja: {loja.Nome} - Aluguel: {loja.Aluguel}");
            }
        }
    }
}
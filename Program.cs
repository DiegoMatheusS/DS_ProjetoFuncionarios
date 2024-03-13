using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Aula03Colecoes.Models.Enuns;
using Aula03Colecoes.Models;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Aula03Colecoes.Models
{
    class Program
    {
        static List<Funcionarios> Lista = new List<Funcionarios>();

        static void Main(string[] args)
        {
            ExemplosListasColecoes();
            AdicionarFuncionario();
        }

        public static void CriarLista()
        {
            Funcionarios f1 = new Funcionarios();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            Lista.Add(f1);

            Funcionarios f2 = new Funcionarios();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            Lista.Add(f2);

            Funcionarios f3 = new Funcionarios();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            Lista.Add(f3);

            Funcionarios f4 = new Funcionarios();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            Lista.Add(f4);

            Funcionarios f5 = new Funcionarios();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            Lista.Add(f5);

            Funcionarios f6 = new Funcionarios();
            f6.Id = 6;
            f6.Nome = "Rodrigo Garro";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            Lista.Add(f6);
        }
        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < Lista.Count; i++)
            {
                dados += "________________________________________________\n";
                dados += string.Format("Id: {0} \n", Lista[i].Id);
                dados += string.Format("Nome: {0} \n", Lista[i].Nome);
                dados += string.Format("CPF: {0} \n", Lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", Lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", Lista[i].Salario);
                dados += string.Format("Tipo de Funcionário: {0}\n", Lista[i].TipoFuncionario);
                dados += "________________________________________________\n";
            }
            Console.WriteLine(dados);
        }
        public static void ObterPorId(int id)
        {
            Funcionarios fBusca = Lista.Find(x => x.Id == id);

            Console.WriteLine($"Personagem encontrado : {fBusca.Nome}");
            Console.WriteLine($"Personagem encontrado : CPF: {fBusca.Cpf}");
            Console.WriteLine($"Personagem encontrado : Tipo Funcionário: {fBusca.TipoFuncionario}");
            
        }
        public static void ObterPorSalario(decimal valor)
        {
            Lista = Lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }
        public static void BuscarPorNome(string buscaNome)
        {
            Lista = Lista.FindAll(x => x.Nome.ToLower().Contains(buscaNome.ToLower()));
            ExibirLista();

        }
        public static void FuncionariosRecentes(int removeId)
        {
            {
                Lista.RemoveAll(x => x.Id < 4);
        
                ExibirLista();
            }
        }
        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");
            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("2 - Adicionar Funcionario");
                Console.WriteLine("3 - Obter Por Id Digitado");
                Console.WriteLine("4 - Obter Por Salário");
                Console.WriteLine("5 - Buscar Por nome");
                Console.WriteLine("6 - Remover Id menor que 4");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");

                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;
                switch (opcaoEscolhida)
                {
                   /* case 1:
                        ObterPorId();
                        break;*/
                    case 2:
                        AdicionarFuncionario();
                        break;
                    case 3:
                        Console.WriteLine("Digite o Id do Funcionário: ");
                        int id = int.Parse(Console.ReadLine());
                        ObterPorId(id);
                        break;
                    case 4:
                        Console.WriteLine("Digite o Salário para obter todos acima do valor indicado: ");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        ObterPorSalario(salario);
                        break;
                    case 5:
                        Console.WriteLine("Digite o nome: ");
                        string buscaNome = Console.ReadLine();
                        BuscarPorNome(buscaNome);
                        break;
                    case 6:
                        Console.WriteLine("Remover ID menor que 4");
                        int removeId = int.Parse(Console.ReadLine());
                        FuncionariosRecentes(removeId);
                        break;
                    default:
                        Console.WriteLine("Saindo do Sistema...");
                        break;
                }

            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);
            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }
        public static void AdicionarFuncionario()
        {
            Funcionarios f = new Funcionarios();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O Nome deve ser preenchido");
                return;
            }
            else if (f.Salario == 0)
            {
                Console.WriteLine("O valor do Salário não poder ser 0(zero)");
                return;
            }
            else
            {
                Lista.Add(f);
                ExibirLista();
            }

        }
    }
}
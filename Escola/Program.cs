using Escola.Models;
using Escola.Services;
using System;

namespace Escola
{
    class Program
    {


        static void Main(string[] args)
        {
            PessoaService ps = new PessoaService();
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("----------- MENU -------------");
                Console.WriteLine("| 1 - Cadastro de Pessoas    |");
                Console.WriteLine("| 2 - Cadastro de Alunos     |");
                Console.WriteLine("| 3 - Cadastro de Professores|");
                Console.WriteLine("| 4 - Cadastro de Matérias   |");
                Console.WriteLine("| 5 - Sair                   |");
                Console.WriteLine("----------------------------");
                Console.Write("Digite a opção: ");
                opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        string opcao2;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("------ Cadastro de Pessoas -----");
                            Console.WriteLine("| 1 - Listar                   |");
                            Console.WriteLine("| 2 - Inserir                  |");
                            Console.WriteLine("| 3 - Alterar                  |");
                            Console.WriteLine("| 4 - Excluir                  |");
                            Console.WriteLine("| 5 - Voltar                   |");
                            Console.WriteLine("--------------------------------");
                            Console.Write("Digite a opção: ");
                            opcao2 = Console.ReadLine();
                            using (escolaEntities db = new escolaEntities())
                            {
                                switch (opcao2)
                                {
                                    case "1": //LISTAR
                                        ps.listarPessoa();
                                        Console.ReadKey();
                                        break;
                                    case "2": //INSERIR
                                        Console.Clear();
                                        Console.Write("Digite o nome: [0 - Cancela]: ");
                                        string nome = Console.ReadLine();
                                        if (nome == "0" || nome =="")
                                            break;
                                        else
                                        {
                                            Console.Write("Digite o CPF: ");
                                            string cpf = Console.ReadLine();
                                            Console.Write("Digite o E-mail: ");
                                            string email = Console.ReadLine();
                                            ps.inserePessoa(nome, cpf, email);
                                        }
                                        break;
                                    case "3": //ALTERAR
                                        Console.Clear();
                                        ps.listarPessoa();
                                        Console.Write("Digite o codigo a ser alterado [0 - Cancela]: ");
                                        string codAlteracao = Console.ReadLine();
                                        if (codAlteracao == "" || codAlteracao == "0")
                                            break;
                                        else
                                        {
                                            pessoa p = db.pessoas.Find(int.Parse(codAlteracao));
                                            Console.Clear();
                                            Console.Write("Digite o novo nome para ["+p.nome+"][0 - Cancela]: ");
                                            string novonome = Console.ReadLine();
                                            if (novonome == "0")
                                                break;
                                            else
                                            {
                                                Console.Write("Digite o novo CPF ["+p.cpf+"]: ");
                                                string cpf = Console.ReadLine();
                                                Console.Write("Digite o novo E-mail [" + p.email + "]: ");
                                                string email = Console.ReadLine();
                                                ps.alteraPessoa(int.Parse(codAlteracao), novonome, cpf, email);
                                            }
                                        }
                                        break;
                                    case "4": //EXCLUIR
                                        ps.listarPessoa();
                                        Console.Write("Digite o codigo a ser excluído [0 - Cancela]: ");
                                        string cod = Console.ReadLine();
                                        if (cod == "" || cod == "0")
                                            break;
                                        else
                                        {
                                            Console.Clear();
                                            pessoa p1 = db.pessoas.Find(int.Parse(cod));
                                            Console.Write("Confirma a exclusão de: ["+p1.nome+"]? (S/N): ");
                                            string confirma = Console.ReadLine();
                                            if(confirma=="S" || confirma=="s")
                                                ps.excluiPessoa(int.Parse(cod));
                                        }
                                        break;
                                }
                            }
                        } while (opcao2 != "5");
                        break;
                    case "2":
                        break;
                }
            } while (opcao != "5");
        }
    }
}

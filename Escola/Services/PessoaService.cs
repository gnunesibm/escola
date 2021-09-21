using Escola.Models;
using Escola.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Escola.Services
{
    public class PessoaService
    {
        public void inserePessoa(string nome, string cpf, string email)
        {
            using (escolaEntities db = new escolaEntities())
            {
                PessoaViewModel pes = new PessoaViewModel()
                {
                    nome = nome,
                    cpf = cpf,
                    email = email,
                };
                // executa a validacao de acordo com os data anotations da view model
                IEnumerable<ValidationResult> errorValidations = PessoaViewModel.GetValidationErrors(pes);
  
                // insere pessoa se nao tiver erros 
                if (errorValidations.Count() == 0)
                {
                    db.pessoas.Add(PessoaViewModel.ToEntity(pes));
                    db.SaveChanges();
                }
                else
                {
                    foreach (ValidationResult vr in errorValidations)
                    {
                        // mostra o erro
                        Console.WriteLine(vr.ErrorMessage);
                        foreach (var name in vr.MemberNames)
                        {
                            // mostra em qual campo ocorreu o erro
                            Console.WriteLine(name);
                            
                        }
                    }
                    Console.ReadKey();
                }
            }
        }

        public void alteraPessoa(int cod, string nome, string cpf, string email)
        {
            using (escolaEntities db = new escolaEntities())
            {
                pessoa p = db.pessoas.Find(cod);
                if (nome != "")
                    p.nome = nome;
                if (cpf != "")
                    p.cpf = cpf;
                if (email != "")
                    p.email = email;
                db.SaveChanges();
            }
        }

        public void listarPessoa()
        {
            Console.Clear();
            using (escolaEntities db = new escolaEntities())
            {
                int cont = 0;
                foreach (pessoa p in db.pessoas)
                {
                    Console.WriteLine("#" + p.idPessoa + " | Nome: " + p.nome + " | CPF: " + p.cpf + " | Email: " + p.email);
                    cont += 1;
                }
                Console.WriteLine(cont + " Registros encontrados\n");
            }
        }
        public void excluiPessoa(int cod)
        {
            using (escolaEntities db = new escolaEntities())
            {
                pessoa p = db.pessoas.Find(cod);
                db.pessoas.Remove(p);
                db.SaveChanges();
            }
        }
    }
}

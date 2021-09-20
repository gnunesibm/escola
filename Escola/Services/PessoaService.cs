using Escola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services
{
    public class PessoaService
    {
        public void inserePessoa(string nome, string cpf, string email)
        {
            using (escolaEntities db = new escolaEntities())
            {
                pessoa pes = new pessoa()
                {
                    nome = nome,
                    cpf = cpf,
                    email = email,
                };
                if (nome != "")
                {
                    db.pessoas.Add(pes);
                    db.SaveChanges();
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

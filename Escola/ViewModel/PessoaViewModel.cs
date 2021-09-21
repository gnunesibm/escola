using Escola.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.ViewModel
{
    class PessoaViewModel
    {
        [Key]
        [Display(Name = "Pessoa ID")]
        public int idPessoa { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o CPF")]
        [Display(Name = "Cpf")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Informe o E-mail")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Informe um email válido")]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 32 caracteres.")]
        [Display(Name = "Email")]
        public string email { get; set; }


        public static pessoa ToEntity(PessoaViewModel model)
        {
            return new pessoa()
            {
                idPessoa = model.idPessoa,
                nome = model.nome,
                cpf = model.cpf,
                email = model.email

            };
        }

        public static PessoaViewModel ToModel(pessoa entity)
        {
            return new PessoaViewModel()
            {
                idPessoa = entity.idPessoa,
                nome = entity.nome,
                cpf = entity.cpf,
                email = entity.email
            };
        }

        public static IEnumerable<ValidationResult> GetValidationErrors(object obj)
        {
            var result = new List<ValidationResult>();
            var context = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, context, result, true);
            return result;
        }

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Escola.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class aluno_materia
    {
        public int idAluno { get; set; }
        public int idMateria { get; set; }
        public string periodo { get; set; }
        public Nullable<double> nota { get; set; }
    
        public virtual aluno aluno { get; set; }
        public virtual materia materia { get; set; }
    }
}

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
    
    public partial class materia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public materia()
        {
            this.aluno_materia = new HashSet<aluno_materia>();
        }
    
        public int idMateria { get; set; }
        public string nome { get; set; }
        public Nullable<int> idProfessor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aluno_materia> aluno_materia { get; set; }
        public virtual professor professor { get; set; }
    }
}

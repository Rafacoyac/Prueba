//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materia()
        {
            this.Maestro_Materia = new HashSet<Maestro_Materia>();
        }
    
        public string claveMateria { get; set; }
        public string materias { get; set; }
        public int creditos { get; set; }
        public string dia { get; set; }
        public string horainicio { get; set; }
        public string horafin { get; set; }
    
        public virtual dia dia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maestro_Materia> Maestro_Materia { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjekatBaze2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pravi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pravi()
        {
            this.Uzimas = new HashSet<Uzima>();
        }
    
        public int PrekrupacIdPrekrupaca { get; set; }
        public int BrasnoIdBrasna { get; set; }
    
        public virtual Prekrupac Prekrupac { get; set; }
        public virtual Brasno Brasno { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uzima> Uzimas { get; set; }
    }
}

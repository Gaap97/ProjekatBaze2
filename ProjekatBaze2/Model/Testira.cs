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
    
    public partial class Testira
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Testira()
        {
            this.Prihvatas = new HashSet<Prihvata>();
        }
    
        public int PsenicaIdPsenice { get; set; }
        public int TestKvalitetaIdTesta { get; set; }
    
        public virtual Psenica Psenica { get; set; }
        public virtual TestKvaliteta TestKvaliteta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prihvata> Prihvatas { get; set; }
    }
}

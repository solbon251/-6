//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Практика_Вар6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Author()
        {
            this.AuthorsPublications = new HashSet<AuthorsPublications>();
        }
    
        public int idAuthor { get; set; }
        public string Name { get; set; }
        public string adres { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuthorsPublications> AuthorsPublications { get; set; }
    }
}

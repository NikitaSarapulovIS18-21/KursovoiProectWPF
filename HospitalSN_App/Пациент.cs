//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalSN_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class Пациент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пациент()
        {
            this.УчетПриема = new HashSet<УчетПриема>();
        }
    
        public int idПациента { get; set; }
        public string ФИО { get; set; }
        public Nullable<System.DateTime> ДатаРождения { get; set; }
        public string Адрес { get; set; }
        public Nullable<int> Телефон { get; set; }
        public Nullable<int> НомерПолиса { get; set; }
        public Nullable<int> idВрача { get; set; }
    
        public virtual Врач Врач { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<УчетПриема> УчетПриема { get; set; }
    }
}

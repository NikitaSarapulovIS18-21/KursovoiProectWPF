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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalSNEntities : DbContext
    {
        public HospitalSNEntities()
            : base("name=HospitalSNEntities")
        {
        }
        private static HospitalSNEntities _context;
        public static HospitalSNEntities GetContext()
        {
            if (_context == null)
                _context = new HospitalSNEntities();

            return _context;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Врач> Врач { get; set; }
        public virtual DbSet<ДанныеДляВхода> ДанныеДляВхода { get; set; }
        public virtual DbSet<Должность> Должность { get; set; }
        public virtual DbSet<Пациент> Пациент { get; set; }
        public virtual DbSet<Роль> Роль { get; set; }
        public virtual DbSet<УчетПриема> УчетПриема { get; set; }
    }
}

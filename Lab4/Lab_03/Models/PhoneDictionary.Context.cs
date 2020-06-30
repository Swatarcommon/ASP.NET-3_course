namespace PhoneStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhoneDictionaryEntities : DbContext
    {
        public PhoneDictionaryEntities()
            : base("name=PhoneDictionaryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Phones> Phones { get; set; }
    }
}

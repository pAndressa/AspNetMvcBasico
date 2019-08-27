using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMVC.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp():base("DefaultConnection")
        {

        }
        public virtual DbSet<Models.Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //para quando for string trocar para varchar no bd
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //para que sempre quando encontrar um ID ele identificar  para que seja uma chave
            modelBuilder.Properties().Where(p => p.Name == "Id").Configure(p => p.IsKey());
        }
    }
}

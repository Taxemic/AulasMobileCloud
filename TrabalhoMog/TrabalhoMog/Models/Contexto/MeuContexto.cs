using System.Data.Entity;

namespace TrabalhoMog.Models.Contexto
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConnT")
        {

        }

        public System.Data.Entity.DbSet<Web.Models.TrabalhoMog.Models.Item> Items { get; set; }
    }
}
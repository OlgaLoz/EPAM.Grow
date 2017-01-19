using System.Data.Entity;

namespace AspNetMVCDevControllerConception.ORM
{
    public class EntityModel : DbContext
    {

        public EntityModel() : base("EntityModel")
        {
        }

        static EntityModel()
        {
            System.Data.Entity.Database.SetInitializer<EntityModel>(new CreateDatabaseIfNotExists<EntityModel>());
        }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
    }
}
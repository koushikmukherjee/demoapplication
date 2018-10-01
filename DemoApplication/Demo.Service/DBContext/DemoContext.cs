using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Entity;

namespace Demo.Service.DBContext
{
   public class DemoContext: DbContext,IDemoContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public DemoContext(): base("DBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DemoContext, Demo.Service.Migrations.Configuration>("DBConnection"));
        }

        #region DB Set

        public DbSet<Student> Students { get; set; }

        #endregion DB Set

        /// <summary>
        /// On Model Creating event
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Ignore plural name in tables
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Call Base method
            base.OnModelCreating(modelBuilder);
        }
    }
}

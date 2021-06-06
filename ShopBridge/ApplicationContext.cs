using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ShopBridge
{
    public class ApplicationContext : DbContext
    {
        private static ApplicationContext _applicationContext;

        public ApplicationContext() : base("DefaultConnection")
        {
        }

        public static ApplicationContext Instance()
        {
            if (_applicationContext == null)
                _applicationContext = new ApplicationContext();

            return _applicationContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ItemVariant> ItemVariants { get; set; }
    }
}
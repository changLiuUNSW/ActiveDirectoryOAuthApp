using System;
using System.Data;
using System.Data.Entity;
using DataAccess.Model.CompanyModels;
using DataAccess.Model.ContactModels;
using DataAccess.Model.ContractModels;
using DataAccess.Model.LeadModels;
using DataAccess.Model.SiteModels;

namespace DataAccess.Data
{
    public class ResourceManagerEntities : DbContext
    {
        public ResourceManagerEntities()
            : base("Default")
        {
            Database.CreateIfNotExists();
        }

        //compnay table
        public DbSet<Company> Companies { get; set; }

        //site tables
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Address> SiteAddresses { get; set; }

        //contact tables
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<ContactPostAddress> ContactPostAddresses { get; set; }

        //contract tables
        public virtual DbSet<CleaningContract> CleaningContracts { get; set; }
        public virtual DbSet<SecurityContract> SecurityContracts { get; set; }

        //lead tables
        public virtual DbSet<Lead> Leads { get; set; }

        public bool ValidConnection()
        {
            try
            {
                Database.Connection.Open();
                return Database.Connection.State == ConnectionState.Open ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
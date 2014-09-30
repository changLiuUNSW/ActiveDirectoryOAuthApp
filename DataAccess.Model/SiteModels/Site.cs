using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Model.CompanyModels;
using DataAccess.Model.ContactModels;
using DataAccess.Model.ContractModels;

namespace DataAccess.Model.SiteModels
{
    /// <summary>
    ///     SITE table
    /// </summary>
    public class Site
    {
        public Site()
        {
            Contacts = new HashSet<Contact>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int SiteId { get; set; }

        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        //contracts
        public virtual CleaningContract CleaningContract { get; set; }

        public virtual SecurityContract SecurityContract { get; set; }
        //end

        [MaxLength(4), DisplayName("GM Zone")]
        public string Sales_Pref { get; set; }

        [MaxLength(4), DisplayName("Region")]
        public string Sales_Box { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        [MaxLength(65), DisplayName("Company")]
        public string Name { get; set; }

        [MaxLength(50), DisplayName("Building Name")]
        public string Build_Id { get; set; }

        [DisplayName("Property Managed")]
        public bool ManByAgent { get; set; }

        [MaxLength(49), DisplayName("Name")]
        public string Agent_Comp { get; set; }

        [Required, DisplayName("Is this a Property Manager")]
        public bool Pm_Site { get; set; }

        [MaxLength(2), DisplayName("Rec Type")]
        public string Build_Type { get; set; }

        [MaxLength(35), DisplayName("Name")]
        public string Grp_Name { get; set; }

        //moved from contat model
        [MaxLength(15), DisplayName("Phone")]
        public string Phone { get; set; }

        [MaxLength(3), DisplayName("BD")]
        public string Sales_Rep { get; set; }
    }
}
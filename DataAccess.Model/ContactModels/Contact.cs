using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Model.SiteModels;

namespace DataAccess.Model.ContactModels
{
    /// <summary>
    /// contact table
    /// </summary>
    public class Contact
    {
        public Contact()
        {
            this.Sites=new HashSet<Site>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Required]
        public virtual ICollection<Site> Sites { get; set; }

        [Required]
        public virtual ContactDetail ContactDetail { get; set; }

        [Required]
        public virtual ContactPostAddress ContactPostAddress { get; set; }

        //new fields, merged both next call and last call from security / cleaning contract
        [Column(TypeName="Date"), DataType(DataType.Date), DisplayName("Next Call Date")]
        public DateTime? NextCall { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Last Call Date")]
        public DateTime? LastCall { get; set; }
        //end new fields

        [Required, DisplayName("Cleaning")]
        public bool Clean_Cont { get; set; }

        [Required, DisplayName("Security")]
        public bool Secu_Cont { get; set; }

        [Required, DisplayName("Maintenance")]
        public bool Maint_Cont { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Contact Change Date")]
        public DateTime? NewManDate { get; set; }

        [Required, DisplayName("Building Manager")]
        public bool Build_Man { get; set; }

        [Required, DisplayName("Da to check")]
        public bool Data_Updat { get; set; }

        [MaxLength(100), DisplayName("Info to check")]
        public string Info_Updat { get; set; }

    }
}

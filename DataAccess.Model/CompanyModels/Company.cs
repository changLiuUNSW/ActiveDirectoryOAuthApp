using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Model.SiteModels;

namespace DataAccess.Model.CompanyModels
{
    /// <summary>
    ///     main company table
    /// </summary>
    public class Company
    {
        public Company()
        {
            Sites = new HashSet<Site>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        public virtual ICollection<Site> Sites { get; set; }
    }
}
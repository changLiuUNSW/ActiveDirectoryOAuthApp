using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model.SiteModels
{
    public class Address
    {
        //foreigh key
        [Key, ForeignKey("Site")]
        public int SiteId { get; set; }
        public virtual Site Site { get; set; }

        [MaxLength(10), DisplayName("No.")]
        public string Number { get; set; }

        [MaxLength(20), DisplayName("Unit")]
        public string Unit { get; set; }

        [MaxLength(50), DisplayName("St")]
        public string Street { get; set; }

        [MaxLength(25), DisplayName("Sub")]
        public string Suburb { get; set; }

        [MaxLength(25)]
        public string State { get; set; }

        [MaxLength(11)]
        public string P_Code { get; set; }
    }
}

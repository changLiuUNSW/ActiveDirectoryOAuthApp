using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model.ContactModels
{
    public class ContactPostAddress
    {
        [Key, ForeignKey("Contact")]
        public int ContactId { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }

        [MaxLength(80)]
        public string PoBox { get; set; }

        [MaxLength(45)]
        public string Pob_Suburb { get; set; }

        [MaxLength(25)]
        public string Pob_State { get; set; }

        [MaxLength(4)]
        public string Pob_PCode { get; set; }
    }
}

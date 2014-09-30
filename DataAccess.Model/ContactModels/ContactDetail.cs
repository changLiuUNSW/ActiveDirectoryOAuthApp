using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model.ContactModels
{
    public enum TitleType
    {
        Mr,
        Mrs
    }

    public class ContactDetail
    {
        [Key, ForeignKey("Contact")]
        public int ContactId { get; set; }

        [Required]
        public virtual Contact Contact { get; set; }

        [DisplayName("Name")]
        public TitleType? Title { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(22)]
        public string LastName { get; set; }

        [MaxLength(50), EmailAddress, DisplayName("Email")]
        public string Email { get; set; }

        [MaxLength(70), DisplayName("Position")]
        public string Position { get; set; }

        /*move to site model
        [Required, MaxLength(15), DisplayName("Phone")]
        public string Phone { get; set; }*/

        [MaxLength(16), DisplayName("Mobile")]
        public string Mobile { get; set; }

        [MaxLength(16), DisplayName("Fax no")]
        public string Fax_Clean { get; set; }

        [MaxLength(12), DisplayName("Direct Line")]
        public string Dir_Line { get; set; }
    }
}

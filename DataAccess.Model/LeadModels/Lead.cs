using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model.LeadModels
{
   public  class Lead
    {
       [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int LeadNo { get; set; }

       [Timestamp]
       public byte[] TimeStamp { get; set; }

       string Type { get; set; }

       public string LeadHandlePerson { get; set; }

       public string QuoteHandlePerson { get; set; }

       public string LeadStatus { get; set; }

       public string QuoteStatus { get; set; }
    }
}

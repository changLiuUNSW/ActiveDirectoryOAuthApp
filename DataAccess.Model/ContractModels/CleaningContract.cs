using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Model.SiteModels;

namespace DataAccess.Model.ContractModels
{
    public class CleaningContract
    {
        [Key, ForeignKey("Site")]
        public int SiteId { get; set; }

        [Required]
        public virtual Site Site { get; set; }

        [MaxLength(40), DisplayName("Current cleaning contractor")]
        public string Cur_Cln { get; set; }

        [Column(TypeName="Date"), DataType(DataType.Date), DisplayName("Tender/Review Date")]
        public DateTime? Tender_Nex { get; set; }

        [DisplayName("Days cleans per week")]
        public double? Clean_Freq { get; set; }

        [MaxLength(20), DisplayName("Site Qualification")]
        public string Site_Quali { get; set; }

        [Required, DisplayName("Cleaning in House")]
        public bool In_House { get; set; }

        [Required, DisplayName("<50k")]
        public bool Too_Small { get; set; }

        [Required, DisplayName(">350k")]
        public bool Over_350k { get; set; }

        [Required, DisplayName(">750k")]
        public bool Over_750k { get; set; }

        //move to contract
        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Date quoted")]
        public DateTime? DateQuoted { get; set; }

        [DisplayName("Price pa"), DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Price_Pa { get; set; }

        [MaxLength(20), DisplayName("Reason unsuccessful")]
        public string Unsu_Optio { get; set; }

        [DisplayName("Contact at time of quote")]
        public string Cont_Quote { get; set; }


        [Required, DisplayName("TS to call")]
        public bool TsToCall { get; set; }

        [Required, DisplayName("Prospect")]
        public bool Prospect { get; set; }

        /*remove next call and last call fields from contract
        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Last call")]
        public DateTime? LastContac { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Next call")]
        public DateTime? Next_Call { get; set; }*/

        [DisplayName("Note Pad - Cleaning and general notes")]
        public string Note_Pad { get; set; }
    }
}


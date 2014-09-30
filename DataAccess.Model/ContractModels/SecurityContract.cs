using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Model.SiteModels;

namespace DataAccess.Model.ContractModels
{
    public class SecurityContract
    {
        [Key, ForeignKey("Site")]
        public int SiteId { get; set; }

        [Required]
        public virtual Site Site { get; set; }

        [MaxLength(40), DisplayName("Current Security Contract")]
        public string Cur_Sc { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Tender/Review date")]
        public DateTime? Se_Tender { get; set; }

        [Required, DisplayName("GM advised DNQ")]
        public bool SE_GM_DNQ { get; set; }

        [Required,DisplayName("Concierge")]
        public bool Concierge { get; set; }

        [Required, DisplayName("Cas. guards")]
        public bool Se_Cas_Gua { get; set; }

        [Required, DisplayName("Perm. Guards")]
        public bool Sc_Guad { get; set; }

        [Required, DisplayName("B2B monitoring")]
        public bool Sc_B2bMon { get; set; }

        [Required, DisplayName("Mobile Patrol Services")]
        public bool Sc_Mob_Pat { get; set; }

        [Required, DisplayName("None of the above")]
        public bool Se_NotSui { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Date Quoted")]
        public DateTime? Se_Q_Date { get; set; }

        [DisplayName("Price Pa"), DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Se_Pr_Pa { get; set; }

        [MaxLength(20), DisplayName("Resaon unsuccessful")]
        public string Se_Unsu_Op { get; set; }

        [Required, DisplayName("guards")]
        public bool Se_Q_Guard { get; set; }

        [Required, DisplayName("concierge")]
        public bool Se_Q_Conci { get; set; }

        [Required, DisplayName("patrols")]
        public bool Se_Q_Patro { get; set; }

        [DisplayName("Per hr quote rate"), DisplayFormat(DataFormatString = "{0:c}")]
        public decimal? Se_Rate_Ph { get; set; }

        [MaxLength(3), DisplayName("BD")]
        public string Se_Sal_Rep { get; set; }

        [Required, DisplayName("TS to call")]
        public bool SetsToCall { get; set; }

        [Required, DisplayName("Prospect")]
        public bool Se_Prospec { get; set; }

        /*remove next call and last call fields from contract
        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Last call")]
        public DateTime? SeLastCall { get; set; }

        [Column(TypeName = "Date"), DataType(DataType.Date), DisplayName("Next call")]
        public DateTime? SeNextCall { get; set; }*/

        [DisplayName("Note Pad for security")]
        public string Se_Ct_Memo { get; set; }
    }
}

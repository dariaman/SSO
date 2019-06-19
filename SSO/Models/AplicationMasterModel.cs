using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSO.Models
{
    [Table("AplicationMaster")]
    public class AplicationMasterModel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Ket { get; set; }
        //public Boolean IsActive { get; set; }

        //public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}

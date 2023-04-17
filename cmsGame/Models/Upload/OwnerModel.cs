using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmsGame.Models.Upload
{
    [Table("tbl_Owner")]
    public class OwnerModel
    {
        [Key]
        public int Owner_Code { get; set; }

        public string Owner_Name { get; set; }
        public DateTime Time_Stamp { get; set; }
     
      public int Provider_Id { get; set; }
        public string Expire { get; set; }
        public string Password { get; set; }
     
    }
}

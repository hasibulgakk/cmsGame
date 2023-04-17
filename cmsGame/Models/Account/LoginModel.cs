using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmsGame.Models.Account
{
    [Table("tbl_Login")]
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string DesigCode { get; set; }
        public string EmailId { get; set; }
        public string TelNo { get; set; }
        public string Expire { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
 
   
    
      }
}

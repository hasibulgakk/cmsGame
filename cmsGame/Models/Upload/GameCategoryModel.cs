using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmsGame.Models.Upload
{
    [Table("tbl_Game_Portal_Category")]
    public class GameCategoryModel
    {
        [Key]
        public int Category_Code { get; set; }
        public string Category_Title { get; set; }
        public int Parent_Code { get; set; }
        public string Category_Type { get; set; }
        public int Sort_Order { get; set; }
        public string Expire { get; set; }
        public DateTime Create_Date { get; set; }
        public string Create_By { get; set; }
        public int Portal_Code { get; set; }
     
    }
}

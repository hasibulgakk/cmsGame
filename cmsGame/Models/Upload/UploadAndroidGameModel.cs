using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmsGame.Models.Upload
{
    [Table("tbl_Game_Android")]
    public class UploadAndroidGameModel
    {
        [Key]
        public int Game_Code { get; set; }
        public string Game_Title { get; set; }
        public string Preview_URL { get; set; }
        public string Physical_Location { get; set; }
        public int Owner_Code { get; set; }
        public int Game_Type_Code { get; set; }
        public string Game_Price { get; set; }
        public string Android_Version { get; set; }
        public string Description { get; set; }
        public string Expire { get; set; }
        public DateTime Upload_Date { get; set; }   
        public string Upload_By { get; set; }
        public string Banner_Url { get; set; }
        public string Install { get; set; }
        public string CurrentVersion { get; set; }
        public string Size { get; set; }
        public string InstallK { get; set; }
        
    }
}

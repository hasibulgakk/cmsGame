using cmsGame.Models.Publish;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cmsGame.ViewModel
{
    public class ListPublishViewModel
    {
        [Key]
        public int Publish_ID { get; set; }
        public string Game_Title { get; set; }
        public int Portal_Code { get; set; }
        public int Category_Code { get; set; }
        public int Game_Code { get; set; }
        public string Game_Type { get; set; }
        public string Expire { get; set; }
        public DateTime Publish_Date { get; set; }
        public string Publish_By { get; set; }
       
    }
}

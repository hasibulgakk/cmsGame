using System.ComponentModel.DataAnnotations;

namespace cmsGame.ViewModel
{
    public class PublishedGameListViewModel
    {
        [Key]
        public int Game_Code { get; set; }
        public string Game_Title { get; set; }
        public string Preview_URL { get; set; }
        public string Owner_Name { get; set; }
        public string GType_Name { get; set; }
        public string Game_Price { get; set; }
        public string Physical_Location { get; set; }
    }
}

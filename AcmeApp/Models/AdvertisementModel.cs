using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace AcmeApp.Models
{
    public class AdvertisementModel
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime AddDate { get; set; }
        [DisplayName("Newspaper")]
        public int NewsPaperId { get; set; }
        public string PaperName { get; set; }
        public IEnumerable<SelectListItem> Newspapers { get; set; }
    }
}
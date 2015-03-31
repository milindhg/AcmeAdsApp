using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcmeApp.Models
{
    public class AdvertisementModel
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime AddDate { get; set; }
    }
}
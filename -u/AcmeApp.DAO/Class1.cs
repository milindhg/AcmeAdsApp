using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeApp.DAO
{
    public class NewspaperModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddDate { get; set; }
    }

    public class AdModel
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public string Test { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime AddDate { get; set; }
    }
}

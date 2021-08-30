using System;

namespace Marketplace.Web.DataAccess.Entities
{
    public class Sales : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Picture Image { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
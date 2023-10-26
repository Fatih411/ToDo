using EntityLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDo: BaseEntity
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}

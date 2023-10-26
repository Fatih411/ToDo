using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.Dtos.ToDoDtos
{
    public class CreateTodo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Models.Administration
{
    public class Organisation
    {
        public const int NameMaxLength = 128;

        public Guid Id { get; set; }
        public string Name { get; set; }

        //public ICollection<User> Users { get; set; }
    }
}

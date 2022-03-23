using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeLook_models.Models
{
    public class Filter
    {
        public ICollection<User> Publishers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<UserTaggedPost> UsersTags { get; set; }

    }
}

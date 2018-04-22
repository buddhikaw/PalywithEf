using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;

    public class GicsIndustry
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<System.DateTime> UdatedDate { get; set; }

    }
}
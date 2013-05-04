using System;

namespace Artnman.Core.Global
{
    public class Filter
    {
        public bool IsFilterByCategory { get; set; }
        public Guid CategoryId { get; set; }

        public bool IsFilterByName { get; set; }
        public String Name { get; set; }

        public bool IsFilterByCode { get; set; }
        public String Code { get; set; }
    }
}

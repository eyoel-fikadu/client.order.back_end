using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Model
{
    public class EnumResponseModel
    {
        public string enumKey { get; set; }
        public List<KeyValuePair<string, string>> enums { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.EmailServices.EmailTemplatesDomain
{
    public class EmailTemplatesUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string TemplateHtml { get; set; }
    }
}

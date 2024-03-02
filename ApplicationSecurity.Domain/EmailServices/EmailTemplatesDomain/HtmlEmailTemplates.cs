using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationSecurity.Domain.EmailServices.EmailTemplatesDomain
{
    public enum HtmlEmailTemplates
    {
        UserPasswordSetUp = 1,
        UserPasswordReset = 2,
        SuccesPasswordSetUp = 3,
        SuccessForgotPassword = 4
    }
}

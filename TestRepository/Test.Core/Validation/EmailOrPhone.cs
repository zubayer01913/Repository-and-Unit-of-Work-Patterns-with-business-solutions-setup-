using System.ComponentModel.DataAnnotations;

namespace Test.Core.Validation
{
    public class EmailOrPhoneAttribute : RegularExpressionAttribute
    {
        public EmailOrPhoneAttribute()
            : base(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^(?:\+88|01)?(?:\d{11}|\d{13})$")
        {
            ErrorMessage = "Please provide a valid email address or phone number";
        }
    }
}
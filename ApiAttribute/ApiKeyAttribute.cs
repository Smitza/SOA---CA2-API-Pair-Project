using ImplementAPIKeyAuthentication.CustomerFilter;
using Microsoft.AspNetCore.Mvc;

namespace ImplementAPIKeyAuthentication.CustomerAttribute
{
    public class ApiKeyAttribute: ServiceFilterAttribute
    {
        public ApiKeyAttribute()
                :base(typeof(ApiKeyAuthFilter))
        {   
        }
    }
}

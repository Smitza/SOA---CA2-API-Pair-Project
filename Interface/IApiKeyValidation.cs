﻿namespace ImplementAPIKeyAuthentication.Interface
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}

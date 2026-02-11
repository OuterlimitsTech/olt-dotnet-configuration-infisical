using Refit;
using System.Reflection;

namespace OLT.Infisical.API.Wrapper;

public sealed class InfisicalCustomUrlParameterFormatter : IUrlParameterFormatter
{
    public string? Format(object? value, ICustomAttributeProvider attributeProvider, Type type)
    {
        if (value is bool boolVal)
        {
            return boolVal.ToString().ToLower();
        }

        return value?.ToString();
    }
}


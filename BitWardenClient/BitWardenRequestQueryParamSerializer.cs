using System;
using System.Collections.Generic;
using System.Linq;
using RestEase;

namespace BitWardenClient;

/// <summary>
/// This will cause `false` values to not be serialized at all
/// https://github.com/bitwarden/server/issues/2539
/// </summary>
public class BitWardenRequestQueryParamSerializer : RequestQueryParamSerializer
{
    public override IEnumerable<KeyValuePair<string, string>> SerializeQueryParam<T>(string name, T value, RequestQueryParamSerializerInfo info)
    {
        if (value is false or null)
            yield break;

        yield return new KeyValuePair<string, string>(name, value?.ToString());
    }


    public override IEnumerable<KeyValuePair<string, string>> SerializeQueryCollectionParam<T>(string name, IEnumerable<T> values, RequestQueryParamSerializerInfo info)
    {
        if (values == null || name is null)
            yield break;

        foreach (var value in values)
            yield return new KeyValuePair<string, string?>(name, value?.ToString());
    }
}
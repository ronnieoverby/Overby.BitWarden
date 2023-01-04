using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;

namespace BitWardenClient;

public static class BitWardenClientFactory
{
    public const string DefaultBaseUrl = "http://localhost:8087";

    public static IBitWardenVault CreateVaultClient(string baseUrl = DefaultBaseUrl,
        RequestModifier requestModifier = default) => new RestClient(baseUrl, requestModifier)
        { RequestQueryParamSerializer = new BitWardenRequestQueryParamSerializer() }.For<IBitWardenVault>();

    public static IBitWardenVault CreateVaultClient(Action<HttpRequestMessage> requestModifier, string baseUrl = DefaultBaseUrl ) =>
        CreateVaultClient(baseUrl, requestModifier: (r, _) =>
        {
            requestModifier(r);
            return Task.CompletedTask;
        });
}
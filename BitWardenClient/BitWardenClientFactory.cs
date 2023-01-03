using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;

namespace BitWardenClient;

public static class BitWardenClientFactory
{
    public const string DefaultBaseUrl = "http://localhost:8087";
    
    public static IBitWardenVault CreateVaultClient(string baseUrl = DefaultBaseUrl,
        RequestModifier requestModifier = default) => RestClient.For<IBitWardenVault>(baseUrl, requestModifier);

    public static IBitWardenVault CreateVaultClient(Action<HttpRequestMessage> requestModifier, string baseUrl = DefaultBaseUrl ) =>
        CreateVaultClient(baseUrl, requestModifier: (r, _) =>
        {
            requestModifier(r);
            return Task.CompletedTask;
        });
}
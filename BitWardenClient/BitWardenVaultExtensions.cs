using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BitWardenClient;

public static class BitWardenVaultExtensions
{
    /// <summary>
    /// Attach a file to an existing vault item.
    /// </summary>
    public static async Task<Response<Item>> AddAttachment(this IBitWardenVault api, string itemId, Stream stream, string fileName, string mediaType = "application/octet-stream")
    {
        using var httpContent = new MultipartFormDataContent();
        using var binaryContent = new StreamContent(stream);
        binaryContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        httpContent.Add(binaryContent, "file", fileName);
        var result = await api.AddAttachment(itemId, httpContent);
        return result;		
    }

    /// <summary>
    /// Attach a file to an existing vault item.
    /// </summary>
    public static async Task<Response<Item>> AddAttachment(this IBitWardenVault api, string itemId, string sourceFilePath)
    {
        var fileInfo = new FileInfo(sourceFilePath);
        using var stream = fileInfo.OpenRead();
        return await api.AddAttachment(itemId, stream, fileInfo.Name);
    }
}
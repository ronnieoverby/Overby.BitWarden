using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using RestEase;

namespace BitWardenClient;

[Header("User-Agent", "RestEase")]
public interface IBitWardenVault
{
    #region Lock & Unlock
    #endregion
    
    #region Vault Items
    
    /// <summary>
    /// Add a new login, card, secure note, or identity to your vault.
    /// </summary>
    [Post("object/item")]
    Task<Response<Item>> AddItem([Body] Item item);

    /// <summary>
    /// Edit an existing login, card, secure note, or identity in your Vault by specifying a unique object identifier (e.g. 3a84be8d-12e7-4223-98cd-ae0000eabdec) in the path and the new object contents in the request body.
    /// </summary>
    [Put("object/item/{id}")]
    Task<Response<Item>> EditItem([Path] string id, [Body] Item item);

    /// <summary>
    /// Retrieve an existing item from your vault by specifying a unique object identifier (e.g. 3a84be8d-12e7-4223-98cd-ae0000eabdec) in the path.
    /// </summary>
    [Get("object/item/{id}")]
    Task<Response<Item>> GetItem([Path] string id);

    /// <summary>
    /// Delete an existing item from your vault by specifying the unique object identifier (e.g. 3a84be8d-12e7-4223-98cd-ae0000eabdec) in the path.
    /// </summary>
    [Delete("object/item/{id}")]
    Task<Response> DeleteItem([Path] string id);

    /// <summary>
    /// Restore an item that was sent to the trash by specifying the unique object identifier (e.g. 3a84be8d-12e7-4223-98cd-ae0000eabdec) in the path.
    /// </summary>
    [Post("restore/item/{id}")]
    Task<Response> RestoreItem([Path] string id);

    /// <summary>
    /// Retrieve a list of existing items in your vault.
    /// By default, this will return a list of all existing items in your vault,
    /// however you can specify filters or search terms as query parameters to narrow list results.
    /// Using multiple filters will perform a logical OR operation.
    /// Using filters and search terms will perform a logical AND operation.
    /// </summary>
    [Get("list/object/items")]
    Task<Response<Object<Item[]>>> GetItems(
        string organizationid = null,
        string collectionid = null,
        string folderid = null,
        string url = null,
        string search = null,
        bool? trash = null
    );
    
    #endregion
    
    #region Attachments & Fields

    /// <summary>
    /// Attach a file to an existing vault item by specifying a unique object identifier in the path and the file in the request body.
    /// </summary>
    [Post("attachment")]
    Task<Response<Item>> AddAttachment(string itemid, [Body] HttpContent content);

    /// <summary>
    /// Retrieve an attachment by specifying the attachment id in the path and item id as a query parameter.
    /// If you're retrieving any file type other than plaintext,
    /// we recommend posting the request through a browser window for immediate download.
    /// </summary>
    [Get("object/attachment/{id}")]
    Task<Stream> GetAttachment([Path] string id, string itemid);

    /// <summary>
    /// Delete an attachment by specifying the attachment id in the path and item id as a query parameter.
    /// </summary>
    [Delete("object/attachment/{id}")]
    Task<Response> DeleteAttachment([Path] string id, string itemid);
    
    #endregion
    
    #region Folders

    /// <summary>
    /// Delete an existing folder from your vault by specifying the unique folder identifier in the path.
    /// Deleting a folder will not delete the items in it.
    /// </summary>
    [Delete("object/folder/{id}")]
    Task<Response> DeleteFolder([Path] string id);

    /// <summary>
    /// Retrieve a list of folders in your vault. By default, this will return a list of all folders,
    /// however you can specify search terms as query parameters to narrow list results.
    [Get("list/object/folders")]
    Task<Response<Object<Folder[]>>> GetFolders(string search = null);
    
    #endregion
    
    #region Send
    #endregion
    
    #region Collections & Organizations

    /// <summary>
    /// List Collections from all Organizations of which you are a member.
    /// Collections you do not have access to will not be listed.
    /// By default, this will return a list of all Collections,
    /// however you can specify search terms as query parameters to narrow list results.
    /// </summary>
    [Get("list/object/collections")]
    Task<Response<Object<Collection[]>>> GetCollections(string search = default);
    
    /// <summary>
    /// List Organizations of which you are a member.
    /// By default, this will return a list of all Organizations,
    /// however you can specify search terms as query parameters to narrow list results.
    /// </summary>
    [Get("list/object/organizations")]
    Task<Response<Object<Organization[]>>> GetOrganizations(string search = default);

    /// <summary>
    /// List members of a specified Organization by specifying an Organization identifier as a query parameter.
    /// </summary>
    [Get("list/object/org-members")]
    Task<Response<Object<OrgMember[]>>> GetOrganizationMembers(string organizationid);
    
    #endregion
    
    #region Miscellaneous

    /// <summary>
    /// Sync your vault.
    /// </summary>
    [Post("sync")]
    Task<Response<Message>> Sync();
    
    /// <summary>
    /// Get the current serverURL, lastSync, userEmail, userID, and status of your BitWarden CLI client.
    /// </summary>
    [Get("status")]
    Task<Response<Status>> GetStatus();

    /// <summary>
    /// Generate a password or passphrase.
    /// By default, this will generate a 14-character password with uppercase characters, lowercase characters, and numbers.
    /// </summary>
    [Get("generate")]
    Task<Response<Object<string>>> Generate(
        int? length = null,
        bool? uppercase = default,
        bool? lowercase = default,
        bool? number = default,
        bool? special = default,
        bool? passphrase = default,
        int? words = default,
        string separator = default,
        bool? capitalize = default,
        bool? includeNumber = default
    );

    /// <summary>
    /// Retrieve a JSON template for any object, including vault items, sends, folders, and more.
    /// Templates can be used to guide you in creation of new objects.
    /// </summary>
    [Get("object/template/{type}")]
    Task<Response<object>> GetTemplate([Path] string type);

    /// <summary>
    /// Retrieve your fingerprint phrase.
    /// </summary>
    [Get("object/fingerprint/me")]
    Task<Response<Object<string>>> GetFingerprintPhrase();
    
    #endregion
    
    
}
using BankTellerSystem.Domain.Enums;
using System.Text.Json.Serialization;

namespace BankTellerSystem.Domain.Entities;

public sealed class Client : BaseEntity
{
    public string Name { get; private set; }
    public string Doc { get; private set; }
    public DocTypeEnum DocType { get; private set; }

    [JsonIgnore]
    public virtual ICollection<Account>? Accounts { get; set; }

    private Client(string name, string doc, DocTypeEnum docType)
    {
        Guid = Guid.NewGuid();
        Name = name;
        Doc = doc;
        DocType = docType;
        CreatedAt = DateTime.UtcNow;
    }

    public static Client Create(string name, string doc, DocTypeEnum? docType = DocTypeEnum.CPF)
    {
        return new Client(name, doc, docType!.Value);
    }
}

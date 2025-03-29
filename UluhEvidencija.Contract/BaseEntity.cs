using System;
using System.Text.Json.Serialization;

namespace UluhEvidencija.Contract;
public abstract class BaseEntity
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? CreatorId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? DateCreated { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? EditorId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? DateEdited { get; set; }
}
public interface IBaseEntity<TId>
{
    public TId Id { get; set; }
    public int CreatorId { get; set; }
    public DateTime DateCreated { get; set; }
    public int? EditorId { get; set; }
    public DateTime? DateEdited { get; set; }
}
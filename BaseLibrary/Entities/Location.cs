
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Location : AuditBaseEntity
    {
        //One to many relationship with BusinessUnit 
        [JsonIgnore]
        public List<BusinessUnit>? BusinessUnits { get; set; }
    }
}

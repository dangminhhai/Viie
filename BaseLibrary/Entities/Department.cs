
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        //Many to one relationship with BusinessUnit
        public BusinessUnit? BusinessUnit { get; set; }
        public int BusinessUnitId { get; set; }

        // One to many relationship with JobPosition
        [JsonIgnore]
        public List<JobPosition>? JobPositions { get; set; }


    }
}

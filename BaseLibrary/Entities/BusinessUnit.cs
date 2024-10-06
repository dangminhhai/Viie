
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class BusinessUnit : BaseEntity
    {
        //Many to one relationship with Location
        public Location? Location { get; set; }
        public int LocationId { get; set; }

        // One to many relationship with Department
        [JsonIgnore]
        public List<Department>? Departments { get; set; }


    }
}

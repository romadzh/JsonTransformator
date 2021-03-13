using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Consist.JsonTransformator.PL.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("Parent")]
        public int? ParentId { get; set; }

    }
}

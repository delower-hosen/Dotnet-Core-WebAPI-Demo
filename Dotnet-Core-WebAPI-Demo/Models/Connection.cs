using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_Core_WebAPI_Demo.Models
{
    public class Connection
    {
        public string Id { get; set; }
        public string[] Tags { get; set; }
        public string ParentEntityName { get; set; }
        public string ParentEntityId { get; set; }
        public string ChildEntityName { get; set; }
        public string ChildEntityId { get; set; }
    }
}

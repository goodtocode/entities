
//using Goodtocode.Subjects.Resource;
//using Goodtocode.Common.Domain;
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace Goodtocode.Subjects
//{
//    public class Resource : DomainEntity<IResource>, IResource
//    {
//        public override string PartitionKey { get; set; } = "Default";
//        public override Guid RowKey { get { return ResourceKey; } set { ResourceKey = value; } }
//        public Guid ResourceKey { get; set; }
//        public string ResourceName { get; set; }
//        public string ResourceDescription { get; set; }
//    }
//}

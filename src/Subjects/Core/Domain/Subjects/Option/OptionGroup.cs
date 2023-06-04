//using Goodtocode.Subjects.Option;
//using Goodtocode.Library.Ddd;
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace Goodtocode.Subjects
//{
//    public class OptionGroup : DomainEntity<IOptionGroup>, IOptionGroup
//    {
//        public override string PartitionKey { get; set; } = "Default";
//        public override Guid RowKey { get { return OptionGroupKey; } set { OptionGroupKey = value; } }
//        public Guid OptionGroupKey { get; set; }
//        public string OptionGroupName { get; set; }
//        public string OptionGroupDescription { get; set; }
//        public string OptionGroupCode { get; set; }
//    }
//}

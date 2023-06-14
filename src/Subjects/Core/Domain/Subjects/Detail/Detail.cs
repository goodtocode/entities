//using Goodtocode.Subjects.Detail;
//using Goodtocode.Common.Domain;

//namespace Goodtocode.Subjects
//{
//    public class Detail : DomainEntity<IDetail>, IDetail
//    {
//        public override string PartitionKey { get; set; } = "Default";
//        public override Guid RowKey { get { return DetailKey; } set { DetailKey = value; } }
//        public Guid DetailKey { get; set; }
//        public Guid DetailTypeKey { get; set; }
//        public string DetailData { get; set; }
//    }
//}

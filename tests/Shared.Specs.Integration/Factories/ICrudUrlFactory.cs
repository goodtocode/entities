using System;

namespace GoodToCode.Subjects.Specs
{
    public interface ICrudUrlFactory
    {
        Uri CreateUrl { get; }
        Uri DeleteUrl { get; }
        string DomainModel { get; }
        string DomainNamespace { get; }
        Uri GetAllUrl { get; }
        Uri GetByKeyUrl { get; }
        Guid RowKey { get; }
        Uri SaveUrl { get; }
        Uri UpdateUrl { get; }

        Uri CreateCreateUrl();
        Uri CreateDeleteUrl(Guid rowKey);
        Uri CreateGetAllUrl();
        Uri CreateGetByKeyUrl(Guid rowKey);
        Uri CreateSaveUrl(Guid rowKey);
        Uri CreateUpdateUrl(Guid rowKey);
    }
}
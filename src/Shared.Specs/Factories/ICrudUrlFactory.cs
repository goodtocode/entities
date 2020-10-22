using System;

namespace GoodToCode.Subjects.Specs
{
    public interface ICrudUrlFactory
    {
        string DomainModel { get; }
        string DomainModelPlural { get; }
        string AppConfigNamespace { get; }
        Guid RowKey { get; }
        string CreateUrl { get; }
        string DeleteUrl { get; }
        string GetAllUrl { get; }
        string GetByKeyUrl { get; }        
        string SaveUrl { get; }
        string UpdateUrl { get; }

        Uri CreateCreateUrl();
        Uri CreateDeleteUrl(Guid rowKey);
        Uri CreateGetAllUrl();
        Uri CreateGetByKeyUrl(Guid rowKey);
        Uri CreateSaveUrl(Guid rowKey);
        Uri CreateUpdateUrl(Guid rowKey);
    }
}
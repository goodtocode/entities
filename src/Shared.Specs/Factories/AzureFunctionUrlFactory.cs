using DoctorCode.Pluralization;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    public class AzureFunctionUrlFactory : ICrudUrlFactory
    {
        private readonly IConfiguration _config;
        private string _urlBase;
        private string _code;

        public string UrlBase { get { _urlBase = _urlBase.IsNullOrWhiteSpace() ? _config[$"{AppConfigNamespace}:FunctionsUrl"] : _urlBase; return _urlBase; } private set { _urlBase = value; } }        
        public string Code { get { _code = _code.IsNullOrWhiteSpace() ? _config[$"{AppConfigNamespace}:FunctionsCode"] : _code; return _code; } private set { _code = value; } }
        public Guid RowKey { get; private set; } = Guid.Empty;
        public string GetAllUrl { get { return $"{UrlBase}/api/{DomainModelPlural}Get?code={Code}"; } }
        public string GetByKeyUrl { get { return $"{UrlBase}/api/{DomainModel}Get?code={Code}&key={RowKey}"; } }
        public string CreateUrl { get { return $"{UrlBase}/api/{DomainModel}Create?code={Code}"; } }
        public string UpdateUrl { get { return $"{UrlBase}/api/{DomainModel}Update?code={Code}&key={RowKey}"; } }
        public string SaveUrl { get { return $"{UrlBase}/api/{DomainModel}Save?code={Code}&key={RowKey}"; } }
        public string DeleteUrl { get { return $"{UrlBase}/api/{DomainModel}Delete?code={Code}&key={RowKey}"; } }

        public string AppConfigNamespace { get; private set; }        
        public string DomainModel { get; private set; }
        public string DomainModelPlural { get { return new EnglishPluralizationService().Pluralize(DomainModel); } }

        public AzureFunctionUrlFactory(IConfiguration config, string appConfigNamespace, string domainModel)
        {
            _config = config;
            DomainModel = domainModel;
            AppConfigNamespace = appConfigNamespace;
        }

        public Uri CreateCreateUrl()
        {
            RowKey = Guid.Empty;
            return new Uri(CreateUrl);
        }

        public Uri CreateUpdateUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return new Uri(UpdateUrl);
        }
        public Uri CreateDeleteUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return new Uri(DeleteUrl);
        }
        public Uri CreateSaveUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return new Uri(SaveUrl);
        }
        public Uri CreateGetByKeyUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return new Uri(GetByKeyUrl);
        }
        public Uri CreateGetAllUrl()
        {
            RowKey = Guid.Empty;
            return new Uri(GetAllUrl);
        }
    }
}

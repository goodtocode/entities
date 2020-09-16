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

        public string UrlBase { get { _urlBase = _urlBase.IsNullOrWhiteSpace() ? _config["Functions:UrlBase"] : _urlBase; return _urlBase; } private set { _urlBase = value; } }        
        public string Code { get { _code = _code.IsNullOrWhiteSpace() ? _config["Functions:Code"] : _code; return _code; } private set { _code = value; } }
        public Guid RowKey { get; private set; } = Guid.Empty;
        public string GetAllUrl { get { return ReplaceMasks(_config["Functions:GetAllUrlMask"]); } }
        public string GetByKeyUrl { get { return ReplaceMasks(_config["Functions:GetByKeyUrlMask"]); } }
        public string CreateUrl { get { return ReplaceMasks(_config["Functions:CreateUrlMask"]); } }
        public string UpdateUrl { get { return ReplaceMasks(_config["Functions:UpdateUrlMask"]); } }
        public string SaveUrl { get { return ReplaceMasks(_config["Functions:SaveUrlMask"]); } }
        public string DeleteUrl { get { return ReplaceMasks(_config["Functions:DeleteUrlMask"]); } }

        public string DomainNamespace { get; private set; }        
        public string DomainModel { get; private set; }
        public string DomainModelPlural { get { return new EnglishPluralizationService().Pluralize(DomainModel); } }

        public AzureFunctionUrlFactory(IConfiguration config, string domainNamespace, string domainModel)
        {
            _config = config;
            DomainModel = domainModel;
            DomainNamespace = domainNamespace;
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

        private string ReplaceMasks(string raw)
        {
            return raw.Replace("{UrlBase}", UrlBase).Replace("{DomainModel}", DomainModel).Replace("{DomainModelPlural}", DomainModelPlural).Replace("{RowKey}", RowKey.ToString()).Replace("{Code}", Code);
        }
    }
}

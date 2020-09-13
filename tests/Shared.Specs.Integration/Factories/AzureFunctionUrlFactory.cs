using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    public class AzureFunctionUrlFactory : ICrudUrlFactory
    {
        private IConfiguration _config;
        private string _urlBase;
        public string UrlBase { get { _urlBase = _urlBase.IsNullOrWhiteSpace() ? _config["Functions:UrlBase"] : _urlBase; return _urlBase; } private set { _urlBase = value; } }

        public Guid RowKey { get; private set; } = Guid.Empty;
        public string GetAllUrl { get { return _config["Apis:GetAllUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel); } }
        public string GetByKeyUrl { get { return _config["Apis:GetByKeyUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel).Replace("{RowKey}", RowKey.ToString()); } }
        public string CreateUrl { get { return _config["Apis:GetAllUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel); } }
        public string UpdateUrl { get { return _config["Apis:GetAllUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel).Replace("{RowKey}", RowKey.ToString()); } }
        public string SaveUrl { get { return _config["Apis:GetAllUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel).Replace("{RowKey}", RowKey.ToString()); } }
        public string DeleteUrl { get { return _config["Apis:GetAllUrlMask"].Replace("{UrlBase}", _config["Functions:UrlBase"]).Replace("{DomainModel}", DomainModel).Replace("{RowKey}", RowKey.ToString()); } }

        public string DomainNamespace { get; private set; }
        public string DomainModel { get; private set; }

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
    }
}

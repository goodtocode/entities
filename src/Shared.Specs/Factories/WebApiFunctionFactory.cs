﻿using DoctorCode.Pluralization;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    public class WebApiUrlFactory : ICrudUrlFactory
    {
        private readonly IConfiguration _config;
        private string _urlBase;

        public string UrlBase { get { _urlBase = _urlBase.IsNullOrWhiteSpace() ? _config["Apis:UrlBase"] : _urlBase; return _urlBase; } private set { _urlBase = value; } }
        public Guid RowKey { get; private set; } = Guid.Empty;
        public string GetAllUrl { get { return ReplaceMasks(_config["Apis:GetAllUrlMask"]); } }
        public string GetByKeyUrl { get { return ReplaceMasks(_config["Apis:GetByKeyUrlMask"]); } }
        public string CreateUrl { get { return ReplaceMasks(_config["Apis:CreateUrlMask"]); } }
        public string UpdateUrl { get { return ReplaceMasks(_config["Apis:UpdateUrlMask"]); } }
        public string SaveUrl { get { return ReplaceMasks(_config["Apis:SaveUrlMask"]); } }
        public string DeleteUrl { get { return ReplaceMasks(_config["Apis:DeleteUrlMask"]); } }

        public string DomainNamespace { get; private set; }
        public string DomainModel { get; private set; }
        public string DomainModelPlural { get { return new EnglishPluralizationService().Pluralize(DomainModel); } }

        public WebApiUrlFactory(IConfiguration config, string domainNamespace, string domainModel)
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
            return raw.Replace("{UrlBase}", UrlBase).Replace("{DomainModel}", DomainModel).Replace("{DomainModelPlural}", DomainModelPlural).Replace("{RowKey}", RowKey.ToString());
        }
    }
}
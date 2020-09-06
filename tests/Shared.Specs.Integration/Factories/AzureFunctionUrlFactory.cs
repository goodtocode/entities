using System;
using System.Globalization;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    public class AzureFunctionUrlFactory : ICrudUrlFactory
    {
        private string _urlBase;
        public string UrlBase { get { _urlBase = _urlBase.IsNullOrWhiteSpace() ? $@"https://{DomainNamespace}-functions.azurewebsites.net" : _urlBase; return _urlBase; } private set { _urlBase = value; } }

        public Guid RowKey { get; private set; } = Guid.Empty;
        public Uri GetAllUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Get?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ=="); } }
        public Uri GetByKeyUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Get?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={RowKey}"); } }
        public Uri CreateUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Create?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ=="); } }
        public Uri UpdateUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Update?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }
        public Uri SaveUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Save?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }
        public Uri DeleteUrl { get { return new Uri($@"{UrlBase}/api/{DomainModel}Delete?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }

        public string DomainNamespace { get; private set; }
        public string DomainModel { get; private set; }

        public AzureFunctionUrlFactory(string domainNamespace, string domainModel)
        {
            DomainModel = domainModel;
            DomainNamespace = domainNamespace;
        }

        public Uri CreateCreateUrl()
        {
            RowKey = Guid.Empty;
            return CreateUrl;
        }

        public Uri CreateUpdateUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return CreateUrl;
        }
        public Uri CreateDeleteUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return DeleteUrl;
        }
        public Uri CreateSaveUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return SaveUrl;
        }
        public Uri CreateGetByKeyUrl(Guid rowKey)
        {
            RowKey = rowKey;
            return GetByKeyUrl;
        }
        public Uri CreateGetAllUrl()
        {
            RowKey = Guid.Empty;
            return GetAllUrl;
        }

        //private string Pluralize(string singular)
        //{
        //    var pluralizer = new System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));


        //}
    }
}

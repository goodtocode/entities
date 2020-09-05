using System;

namespace GoodToCode.Subjects.Specs
{
    public class AzureFunctionUrlFactory : ICrudUrlFactory
    {
        public Guid RowKey { get; private set; } = Guid.Empty;
        public Uri GetAllUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Get?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ=="); } }
        public Uri GetByKeyUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Get?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={RowKey}"); } }
        public Uri CreateUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Create?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ=="); } }
        public Uri UpdateUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Update?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }
        public Uri SaveUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Save?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }
        public Uri DeleteUrl { get { return new Uri($@"https://{DomainNamespace}-functions.azurewebsites.net/api/{DomainModel}Delete?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={RowKey}"); } }

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
    }
}

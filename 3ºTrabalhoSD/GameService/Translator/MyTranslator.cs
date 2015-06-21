using System;
using System.ServiceModel;

namespace Translator
{
    public class MyTranslator : IMyTranslator
    {
        public string Translate(string from, string to, string msg)
        {
            string res = null;
            try
            {
                BasicHttpBinding bind = new BasicHttpBinding();
                EndpointAddress address = new EndpointAddress("http://api.microsofttranslator.com/V2/soap.svc");
                ChannelFactory<MicrosoftTranslator.LanguageService> factory =
                new ChannelFactory<MicrosoftLanguageService>(bind, address);
                MicrosoftTranslator.LanguageService svc = factory.CreateChannel();

                MicrosoftTranslator.
                res = svc.Translate("F4E6E0444F32B660BED9908E9744594B53D2E864",
                msg, "pt", "en", "text/html", "general");
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }
    }

    [ServiceContract]
    public interface IMyTranslator
    {
        [OperationContract]
        string Translate(string from, string to, string msg);
    }
}

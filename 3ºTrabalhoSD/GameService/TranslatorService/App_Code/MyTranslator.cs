using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyTranslator" in code, svc and config file together.
public class MyTranslator : IMyTranslator
{
	public string Translate(string frase, string to)
	{
        string res=null;
        try  {
           BasicHttpBinding bind = new BasicHttpBinding();
           EndpointAddress address = new EndpointAddress("http://api.microsofttranslator.com/V2/soap.svc");
 
           ChannelFactory<MicrosoftTranslator.LanguageService> factory = new ChannelFactory<MicrosoftTranslator.LanguageService>(bind, address);
           MicrosoftTranslator.LanguageService svc = factory.CreateChannel();
           res = svc.Translate("F4E6E0444F32B660BED9908E9744594B53D2E864", frase, "pt", to, "text/html", "general");
        }
        catch (Exception ex)
        {
            res = ex.Message;
        }
        return res; 
	}
}

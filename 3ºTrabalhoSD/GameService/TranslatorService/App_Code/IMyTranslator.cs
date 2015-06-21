using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyTranslator" in both code and config file together.
[ServiceContract]
public interface IMyTranslator
{
	[OperationContract]
	string Translate(string frase, string to);
}

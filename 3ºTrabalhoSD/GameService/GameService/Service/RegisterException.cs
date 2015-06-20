using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    [DataContract]
    public class RegisterException
    {
        private string m_ErrorMessage = string.Empty;

        public RegisterException(string message)
        {
            this.m_ErrorMessage = message;
        }

        [DataMember]
        public string ErrorMessage
        {
            get { return this.m_ErrorMessage; }
            set { this.m_ErrorMessage = value; }
        }
    }
}

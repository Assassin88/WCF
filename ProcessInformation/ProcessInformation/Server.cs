using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInformation
{
    public class Server
    {
        private Uri _adress;
        private BasicHttpBinding _binding;
        private Type _contract;
        private ServiceHost _host;

        public Server(string localHost)
        {
            _adress = new Uri(localHost);
            _binding = new BasicHttpBinding();
            _contract = typeof(IContract);
            _host = new ServiceHost(typeof(Service));
            _host.AddServiceEndpoint(_contract, _binding, _adress);
        }

        public void OpenHost()
        {
            _host.Open();
        }

        public void CloseHost()
        {
            _host.Close();
        }
    }
}

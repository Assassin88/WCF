using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        private Uri _adress;
        private BasicHttpBinding _binding;
        private EndpointAddress _endpointAdress;
        private ChannelFactory<IContract> _factory;
        private IContract _channel;

        public Client(string adress)
        {
            _adress = new Uri(adress);
            _binding = new BasicHttpBinding();
            _endpointAdress = new EndpointAddress(_adress);
            _factory = new ChannelFactory<IContract>(_binding, _endpointAdress);
        }

        public void GetInformation()
        {
            _channel = _factory.CreateChannel();
            while (true)
            {
                var value = Menu.ShowMenu();
                var responce = _channel.Say(value);
                Console.WriteLine(responce);
                Console.WriteLine();
            }
        }
    }
}

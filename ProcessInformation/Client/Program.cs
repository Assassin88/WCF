using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client Client = new Client("http://localhost:4000/IContract");
            Client.GetInformation();
        }
    }
}

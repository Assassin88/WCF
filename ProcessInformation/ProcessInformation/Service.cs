using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ProcessInformation
{
    class Service : IContract
    {
        private readonly string _pattern = string.Format(@"(\d).(\w+)");
        private readonly string _pattern2 = string.Format(@"\d+");

        public string Say(string input)
        {
            var param = string.Empty;
            var answer = string.Empty;
            ProcInfo _instanceProcess = new ProcInfo();
            if (Regex.IsMatch(input, _pattern, RegexOptions.IgnoreCase))
            {
                string[] arrayValue = input.Split('.');
                var value = Int32.Parse(arrayValue[0]);
                param = arrayValue[1];

                switch (value)
                {
                    case 1:
                        {
                            answer = _instanceProcess.ShowProcesses();
                            return answer;
                        }
                    case 2:
                        {
                            if (Regex.IsMatch(param, _pattern2, RegexOptions.IgnoreCase))
                            {
                                var i = Int32.Parse(param);
                                answer = _instanceProcess.GetProcessById(i);
                                return answer;
                            }
                            return string.Format("Incorrect data entry!!!");
                        }
                    case 3:
                        {
                            _instanceProcess.StartProc(param);
                            _instanceProcess.UpdateProc();
                            break;
                        }
                    case 4:
                        {
                            _instanceProcess.KillProc(param);
                            _instanceProcess.UpdateProc();
                            break;
                        }
                    case 5:
                        {
                            answer = _instanceProcess.ShowThreadsInProcess(param);
                            return answer;
                        }
                    case 6:
                        {
                            answer = _instanceProcess.ShowModulesInProcess(param);
                            return answer;
                        }
                    default:
                        return string.Format("Incorrect data entry!!!");
                }
            }
            return string.Format("Incorrect data entry_END!!!");
        }
    }
}

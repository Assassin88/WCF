using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInformation
{
    class ProcInfo
    {
        private IList<Process> _proc = Process.GetProcesses(".").ToList();
        private string _answer = string.Empty;
        public void UpdateProc()
        {
            _proc = null;
            _proc = Process.GetProcesses(".").ToList();
        }

        public string ShowProcesses()
        {
            foreach (var item in _proc.Select(p => p).OrderBy(p => p.Id))
            {
                _answer += string.Format("Id: {0}, Name:{1}{2};", item.Id, item.ProcessName, Environment.NewLine);
            }
            return _answer;
        }

        public string GetProcessById(int id)
        {
            try
            {
                var proc = Process.GetProcessById(id);
                if (proc != null)
                {
                    return string.Format("Id: {0}, Name: {1}", proc.Id, proc.ProcessName);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Format("This process isn`t exist!!!");
        }

        public string GetProcessByName(string name)
        {
            try
            {
                var proc = Process.GetProcessesByName(name)[0];
                if (proc != null)
                {
                    return string.Format("Id: {0}, Name: {1}", proc.Id, proc.ProcessName);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Format("This process isn`t exist!!!");
        }

        public void StartProc(string name)
        {
            try
            {
                Process.Start(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void KillProc(string name)
        {
            try
            {
                var proc = Process.GetProcessesByName(name)[0];
                proc.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string ShowThreadsInProcess(string name)
        {
            string param = string.Empty;
            try
            {
                var proc = Process.GetProcessesByName(name)[0];
                ProcessThreadCollection collection = proc.Threads;
                param += string.Format("Count threads in current process: {0}{1}", collection.Count, Environment.NewLine);
                foreach (ProcessThread item in collection)
                {
                    param += string.Format("Id: {0}; Name: {1}; Priority: {2}{3}",
                        item.Id, item.StartAddress, item.PriorityLevel, Environment.NewLine);
                }
                return param;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Format("This process isn`t exist!!!");
            }
        }

        public string ShowModulesInProcess(string name)
        {
            string param = string.Empty;
            try
            {
                var proc = Process.GetProcessesByName(name)[0];
                ProcessModuleCollection mod = proc.Modules;
                foreach (ProcessModule item in mod)
                {
                    param += string.Format("Name: {0}, memorySize: {1}{2}",
                        item.ModuleName, item.ModuleMemorySize, Environment.NewLine);
                }
                return param;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Format("This process isn`t exist!!!");
            }
        }

    }
}

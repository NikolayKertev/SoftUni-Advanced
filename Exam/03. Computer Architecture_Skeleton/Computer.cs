using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private string model;
        private int capacity;
        private List<CPU> multiprocessor;
        private int count;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            multiprocessor = new List<CPU>();
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public List<CPU> Multiprocessor
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }
        public int Count
        {
            get { return multiprocessor.Count; }
        }

        public void Add(CPU cpu)
        {
            if (multiprocessor.Count < capacity)
            {
                multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            foreach (var proc in multiprocessor)
            {
                if (proc.Brand == brand)
                {
                    multiprocessor.Remove(proc);
                    return true;
                }
            }
            return false;
        }
        public CPU MostPowerful()
        {
            return multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand)
        {
            foreach (var proc in multiprocessor)
            {
                if (proc.Brand == brand)
                {
                    return proc;
                }
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"CPUs in the Computer {model}:");

            foreach (var proc in multiprocessor)
            {
                sb.Append($"{Environment.NewLine}");
                
                sb.Append(proc.ToString());
            }

            return sb.ToString();
        }
    }
}

namespace Telephony.Core
{
    using System;

    using Interfaces;

    using Telephony.Exceptions;
    using Telephony.IO;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        IStationaryPhone stationaryPhone = new StationaryPhone();
        ISmartphone smartphone = new SmartPhone();

        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CallAllNumbers(numbers);
            BrowseAllURLs(urls);
        }

        private void BrowseAllURLs(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException ire)
                {
                    writer.WriteLine(ire.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void CallAllNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(number));
                    }
                    else
                    {
                        writer.WriteLine(smartphone.Call(number));
                    }

                }
                catch (InvalidPhoneNumberException ipne)
                {

                    writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}

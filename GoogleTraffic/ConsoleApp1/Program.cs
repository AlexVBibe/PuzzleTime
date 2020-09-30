using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string Request = "https://maps.googleapis.com/maps/api/directions/json?";

        static void Main(string[] args)
        {
            var origin = "51.4510894,0.2253994";
            var destination = "51.4841112,0.0162141";
            int arrivalTime = (int)DateTime.Now.AddHours(2).ToBinary();

            var requestText = $"{Request}origin={origin}&destination={destination}&mode=driving&alternatives=false&units=metric&traffic_model=pessimistic&arrival_time={arrivalTime}";
            var request = WebRequest.Create(requestText);
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
        }
    }
}

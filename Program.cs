using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Flightreservationsystem
{
    class Program
    {

        static void Main(string[] args)
        {
            string n;
            string p;

            int flightcount = 0;
            string flightnumber;
            int option;
            string path = "E:\\2nd semester Material\\OOP Lab\\Flightreservationsystem\\Flightdata.txt";

            List<Flight> flightdata = new List<Flight>();
            readdata(flightdata, ref flightcount, path);

            do
            {
                option =Flight.loginmenu();

                if (option == 1)
                {
                    Flight.clearScreen();
                    Console.WriteLine("Enter your name: ");
                    n = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    p = Console.ReadLine();

                    if (n == "Admin" && p == "oslo")
                    {
                        Flight.clearScreen();

                        int adminoption = Flight.adminmenu();
                        if (adminoption == 1)
                        {
                            Flight.clearScreen();
                            for (int i = 0; i < 1; i++)
                            {
                                flightdata.Add(addschedule());
                                storeflights(flightdata, path);
                                flightcount++;
                            }
                        }
                        else if (adminoption == 2)
                        {
                            Flight.clearScreen();
                            Console.WriteLine("Enter flight number whose info you want to update:");
                            flightnumber = Console.ReadLine();
                            Flight.updateschedule(flightdata, flightnumber);
                        }
                        else if (adminoption == 3)
                        {
                            Flight.clearScreen();
                            Console.WriteLine("Enter flight number whose data you want to remove:");
                            flightnumber = Console.ReadLine();
                            Flight.removeflight(flightdata, flightnumber, ref flightcount);
                        }
                        else if (adminoption == 4)
                        {
                            Flight.clearScreen();
                            Flight.ViewSchedule(flightdata);
                        }


                    }

                }
            }
            while (option != 5);
            Flight.clearScreen();
        }

        static void storeflights(List<Flight> flightdata, string path)
        {
            StreamWriter Flightdata = new StreamWriter(path, true);
            for (int i = 0; i < flightdata.Count; i++)
            {
                Flightdata.WriteLine(flightdata[i].flight + "," + flightdata[i].companyname + "," + flightdata[i].flightdeparture + "," +
                flightdata[i].flightdestination + "," + flightdata[i].flighttime + "," + flightdata[i].flightdate);
            }
            Flightdata.Flush();
            Flightdata.Close();
        }

        static string parseData(string line, int field)
        {
            int comma = 0;
            string data = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    data = data + line[i];
                }
            }
            return data;
        }

        static void readdata(List<Flight> flightdata, ref int flightcount, string path)
        {

            StreamReader Flightdata = new StreamReader(path);
            string record;
            while ((record = Flightdata.ReadLine()) != null)
            {
                Flight flights = new Flight();
                flights.flight = parseData(record, 0);
                flights.companyname = parseData(record, 1);
                flights.flightdeparture = parseData(record, 2);
                flights.flightdestination = parseData(record, 3);
                flights.flighttime = parseData(record, 4);
                flights.flightdate = parseData(record, 5);
                flightcount++;
                flightdata.Add(flights);
            }
            Flightdata.Close();
        }


       

        

      

        static Flight addschedule()
        {
            //Flight Obj = new Flight();
            Console.WriteLine("Enter Number of the flight: ");
            string flight = Console.ReadLine();
            Console.WriteLine("Enter Company name of the flight: ");
            string companyname = Console.ReadLine();
            Console.WriteLine("Enter Departure of the flight: ");
            string flightdeparture = Console.ReadLine();
            Console.WriteLine("Enter Destination of the flight: ");
            string flightdestination = Console.ReadLine();
            Console.WriteLine("Enter time of the flight: ");
            string flighttime = Console.ReadLine();
            Console.WriteLine("Enter date of the flight: ");
            string flightdate = Console.ReadLine();
            Flight Obj = new Flight(flight,companyname,flightdeparture,flightdestination,flighttime,flightdate);
            return Obj;

        }


    }
}

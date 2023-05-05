using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flightreservationsystem
{

    class Flight
    {
        public string flight;
        public string companyname;
        public string flightdestination;
        public string flightdeparture;
        public string flighttime;
        public string flightdate;
        
        public Flight()
        {
            /*flight = "1";
             companyname = "qatar";
             flightdeparture = "isl";
             flightdestination = "lah";
             flighttime = "6am";
             flightdate = "2jan2022";
            */
        }
        public Flight(string flight,string companyname,string flightdeparture,string flightdestination,string flighttime,string flightdate)
        {
            this.flight = flight;
            this.companyname = companyname;
            this.flightdeparture = flightdeparture;
            this.flightdestination = flightdestination;
            this.flighttime = flighttime;
            this.flightdate = flightdate;

        }

        public static void updateschedule(List<Flight> flightdata, string flightnumber)
        {
            for (int i = 0; i < flightdata.Count; i++)
            {
                if (flightdata[i].flight == flightnumber)
                {
                    Console.WriteLine("Enter New Date of the Flight: ");
                    flightdata[i].flightdate = Console.ReadLine();
                    Console.WriteLine("Enter New Time of the Flight: ");
                    flightdata[i].flighttime = Console.ReadLine();
                    Console.WriteLine("Enter New Departure of the Flight: ");
                    flightdata[i].flightdeparture = Console.ReadLine();
                    Console.WriteLine("Enter New Destination of the Flight: ");
                    flightdata[i].flightdestination = Console.ReadLine();
                    //return flightdata[i];
                }

            }

            throw new ArgumentException("Flight {flightnumber} not found.");
        }
      public static void removeflight(List<Flight> flightdata, string flightnumber, ref int flightcount)
        {
            for (int i = 0; i < flightdata.Count; i++)
            {
                if (flightdata[i].flight == flightnumber)
                {
                    flightdata.RemoveAt(i);
                    flightcount--;
                    Console.WriteLine("Flight removed successfully.");

                }
            }
            Console.WriteLine("Flight not found.");
        }

       public static void ViewSchedule(List<Flight> flightdata)
        {
            Console.WriteLine("Flight Number\t\tCompany Name\t\tFlight Departure\t\tFlight Destination\t\tFlight Date\t\tFlight Time");
            for (int i = 0; i < flightdata.Count; i++)
            {
                Console.WriteLine(flightdata[i].flight + "\t\t" + flightdata[i].companyname + "\t\t" + flightdata[i].flightdeparture + "\t\t" + flightdata[i].flightdestination +
                 "\t\t" + flightdata[i].flightdate + "\t\t" + flightdata[i].flighttime);
            }
        }


       public static int adminmenu()
        {
            int option;
            Console.WriteLine("1. Add Flight Schedule ");
            Console.WriteLine("2. Update Flight Schedule");
            Console.WriteLine("3. Remove FLight");
            Console.WriteLine("4. View FLight Schedule");
            option = int.Parse(Console.ReadLine());
            return option;
        }

       public static int loginmenu()
        {
            int option;
            Console.WriteLine("Press 1 to login");
            Console.WriteLine("Press 2 to Exit");
            option = int.Parse(Console.ReadLine());
            return option;


        }

       public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }



      
        // public string flightnumber;
    }
}

    


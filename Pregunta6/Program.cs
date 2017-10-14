using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta6
{

    // La interface 'AbstractFactory' 

    interface ProductoFactory
    {
        Hotel GetHotel(string Hotel);
        Airplane GetAirplane(string Airplane);
    }

    // La clase 'ConcreteFactory1' 

    class HotelFactory : ProductoFactory
    {
        public Hotel GetHotel(string Servicio)
        {
            switch (Servicio)
            {
                case "tres":
                    return new Hotel3Estrellas();
                case "cinco":
                    return new Hotel5Estrellas();
                default:
                    throw new ApplicationException(string.Format("Servicio '{0}' no puede ser brindado", Servicio));
            }

        }

        public Airplane GetAirplane(string Servicio)
        {
            switch (Servicio)
            {
                case "ejecutivo":
                    return new Ejecutivo();
                case "turista":
                    return new Turista();
                default:
                    throw new ApplicationException(string.Format("Servicio '{0}' no puede ser brindado", Servicio));
            }

        }
    }

    /// La clase 'ConcreteFactory2' 

    class AirplaneFactory : ProductoFactory
    {
        public Hotel GetHotel(string Servicio)
        {
            switch (Servicio)
            {
                case "tres":
                    return new Hotel3Estrellas();
                case "cinco":
                    return new Hotel5Estrellas();
                default:
                    throw new ApplicationException(string.Format("Servicio '{0}' no puede ser brindado", Servicio));
            }

        }

        public Airplane GetAirplane(string Servicio)
        {
            switch (Servicio)
            {
                case "ejecutivo":
                    return new Ejecutivo();
                case "turista":
                    return new Turista();
                default:
                    throw new ApplicationException(string.Format("Servicio '{0}' no puede ser brindado", Servicio));
            }

        }
    }

    /// la interface 'AbstractProductA' 

    interface Hotel
    {
        string Nombre();
    }


    /// la interface 'AbstractProductB' 

    interface Airplane
    {
        string Nombre();
    }

    /// <summary>
    /// La clase 'ProductA1' class
    /// </summary>
    class Hotel3Estrellas : Hotel
    {
        public string Nombre()
        {
            return "Hotel 3 Estrellas";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Hotel5Estrellas : Hotel
    {
        public string Nombre()
        {
            return "Hotel5Estrellas";
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Ejecutivo : Airplane
    {
        public string Nombre()
        {
            return "Asientos ejecutivos";
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Turista : Airplane
    {
        public string Nombre()
        {
            return "Asientos Turista";
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class ProductoClient
    {
        Hotel objHotel;
        Airplane objAirplane;

        public ProductoClient(ProductoFactory factory, string tipo)
        {
            objHotel = factory.GetHotel(tipo);
            objAirplane = factory.GetAirplane(tipo);
        }

        public string GetHotelNombre()
        {
            return objHotel.Nombre();
        }

        public string GetAirplaneNombre()
        {
            return objAirplane.Nombre();
        }

    }


    /// Demostracion Patron Abstract Factory 

    class Program
    {
        static void Main(string[] args)
        {
            ProductoFactory hotel = new HotelFactory();
            ProductoClient hotelclient = new ProductoClient(hotel, "3 estrellas");

            Console.WriteLine("******* Hotel **********");
            Console.WriteLine(hotelclient.GetHotelNombre());




            ProductoFactory airplane = new AirplaneFactory();
            ProductoClient airplaneclient = new ProductoClient(airplane, "turista");

            Console.WriteLine("******* Airplane **********");

            Console.WriteLine(airplaneclient.GetAirplaneNombre());



            Console.ReadKey();
        }
    }
}

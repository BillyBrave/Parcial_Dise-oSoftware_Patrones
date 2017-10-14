using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta5
{
    // La interface 'Product' 

    public interface IFactory
    {
        void Registrar(String dato);
    }

    // La clase 'ConcreteProduct' 
    public class FileLogger : IFactory 
    {
        public void Registrar(String dato)
        {
            Console.WriteLine("Se registro en File : " + dato );
        }
    }


    //Una clase 'ConcreteProduct' 

    public class BDLogger : IFactory
    {
        public void Registrar(String dato)
        {
            Console.WriteLine("Se registro en BD : " + dato);
        }
    }

    //Una clase 'ConcreteProduct' 

    public class NetworkLogger : IFactory
    {
        public void Registrar(String dato)
        {
            Console.WriteLine("Se registro en Network : " + dato);
        }
    }
    //La clase Abstract

    public abstract class LoggerFactory
    {
        public abstract IFactory GetTIPO(String tipo);

    }


    // Una clase 'ConcreteCreator' 

    public class ConcreteTIPOFactory : LoggerFactory
    {
        public override IFactory GetTIPO(String tipo)
        {
            switch (tipo)
            {
                case "File":
                    return new FileLogger();
                case "BD":
                    return new BDLogger();
                case "NetWork":
                    return new NetworkLogger();
                default:
                    throw new ApplicationException(string.Format("TIPO '{0}' no se puede crear", tipo));
            }
        }

    }


    // Demostracion de Patron Factory 

    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory factory = new ConcreteTIPOFactory();

            IFactory File = factory.GetTIPO("File");
            File.Registrar(" Nombre Juan Perez DNI 07504899");

            IFactory BD = factory.GetTIPO("BD");
            BD.Registrar(" Nombre Juan Perez DNI 07504899");

            IFactory Network = factory.GetTIPO("NetWork");
            Network.Registrar(" Nombre Juan Perez DNI 07504899");
            Console.ReadKey();

        }
    }
}

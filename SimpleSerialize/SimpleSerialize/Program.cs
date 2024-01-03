using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleSerialize
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization *****\n");

            JamesBondCar jbc = new JamesBondCar();

            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPrests = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            SaveAsXmlFormat(jbc, "CarData.xml");
            SaveListOfCars();

            Console.ReadLine();
        }
        
        [Serializable]
        public class Radio
        {
            public bool hasTweeters;
            public bool hasSubWoofers;
            public double[] stationPrests;

            [NonSerialized]
            public string RadioID = "XF-552RR6";
        }

        [Serializable]
        public class Car
        {
            public Radio theRadio = new Radio();
            public bool isHatchBack;
        }

        [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
        public class JamesBondCar : Car
        {
            public JamesBondCar(bool skyWorthy, bool seaWorthy)
            {
                canFly = skyWorthy;
                canSubmerge = seaWorthy;
            }

            public JamesBondCar() {}
            
            [XmlAttribute]
            public bool canFly;
            [XmlAttribute]
            public bool canSubmerge;
        }

        [Serializable]
        public class Person
        {
            public bool isAlive = true;

            private int personAge = 21;

            private string fName = string.Empty;
            public string FirstName
            {
                get { return fName; }
                set { fName = value; }
            }
        }
        public static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));

            using (Stream fStream = new FileStream(fileName, FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }

        static void SaveListOfCars()
        {
            List<JamesBondCar> myCars = new List<JamesBondCar>();

            myCars.Add(new JamesBondCar(true, true));
            myCars.Add(new JamesBondCar(true, false));
            myCars.Add(new JamesBondCar(false, true));
            myCars.Add(new JamesBondCar(false, false));

            using (Stream fStream = new FileStream("CarCollection.xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer xmlFormat = new XmlSerializer (typeof(List<JamesBondCar>));;
                xmlFormat.Serialize(fStream, myCars);
            }
            Console.WriteLine("=> Saved list of cars!");
        }

        //Outdated and unsafe

        //static void SaveAsBinaryFormat(object objGraph, string fileName)
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();

        //    using (Stream fStream = new FileStream(fileName,
        //        FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        binFormat.Serialize(fStream, objGraph);
        //    }
        //    Console.WriteLine("=> Saved car in binary format!");
        //}

        //static void LoadFromBinaryFile(string fileName)
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();

        //    using (Stream fStream = File.OpenRead(fileName))
        //    {
        //        JamesBondCar carFromDisk =
        //            (JamesBondCar)binFormat.Deserialize(fStream);
        //        Console.WriteLine("Can this car fly? : {0}", carFromDisk.canFly);
        //    }
        //}

        //    static void SaveAsSoapFormat(object objGraph, string fileName)
        //    {
        //        SoapFormatter soapFormat = new SoapFormatter();

        //        using (Stream fStream = new FileStream(fileName,
        //            FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            soapFormat.Serialize(fStream, objGraph);
        //        }
        //        Console.WriteLine("=> Saved car in SOAP format!");
        //    }
        //}

        //static void SaveListOfCarsAsBinary()
        //{
        //    List<JamesBondCar> myCars = new List<JamesBondCar>();
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    using (Stream fStream = new FileStream("AllMyCars.dat",
        //      FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        binFormat.Serialize(fStream, myCars);
        //    }
        //    Console.WriteLine("=> Saved list of cars in binary!");
        //}
    }
}
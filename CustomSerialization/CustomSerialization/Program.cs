using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Serialization *****");

            StringData myData = new StringData();

            //Outdated and unsafe
            //SoapFormatter soapFormat = new SoapFormatter();

            //using (Stream fStream = FileStream("MyData.xml",
            //    FileMode.Create, FileAccess.Write, FileShare.None)) 
            //{
            //    soapFormat.Serialize(fStream, myData);
            //}
            Console.ReadLine();
        }

        [Serializable]
        class StringData : ISerializable
        {
            private string dataItemOne = "First data block";
            private string dataItemTwo = "More data";

            public StringData() { } 

            protected StringData(SerializationInfo si, StreamingContext ctx)
            {
                dataItemOne = si.GetString("First_Item").ToLower();
                dataItemOne = si.GetString("dataItemTwo").ToLower();
            }

            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx) 
            {
                info.AddValue("First_Item", dataItemOne.ToUpper());
                info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
            }
        }

        [Serializable]
        class MoreData
        {
            private string dataItemOne = "First data block";
            private string dataItemTwo = "More data";

            [OnSerializing]
            private void OnSerializing(StreamingContext context) 
            {
                dataItemOne = dataItemOne.ToUpper();
                dataItemTwo = dataItemTwo.ToUpper();
            }

            [OnDeserialized]
            private void OnDeserialized(StreamingContext context)
            {
                dataItemOne = dataItemOne.ToLower();
                dataItemTwo = dataItemTwo.ToLower();
            }
        }
    }
}
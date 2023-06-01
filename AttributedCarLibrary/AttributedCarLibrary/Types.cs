[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class Types : System.Attribute
    {
        public string Description { get; set; }
        public Types(string vehicleDescription)
            => Description = vehicleDescription;
        public Types() { }
    }

    [Serializable]
    [Types(Description = "My rocking Harley!")]
    public class Motorcycle
    {
    }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [Types("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy
    {
    }

    [Types("A very long, slow, but feature-rich auto")]
    public class Winnebago
    {
        public void PlayMusic(bool On)
        {

        }
    }
}

[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal sealed class Types : System.Attribute
    {
        public string Description { get; set; }
        internal Types(string vehicleDescription)
            => Description = vehicleDescription;
        internal Types() { }
    }

    [Serializable]
    [Types(Description = "My rocking Harley!")]
    internal class Motorcycle
    {
    }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [Types("The old gray mare, she ain't what she used to be...")]
    internal class HorseAndBuggy
    {
    }

    [Types("A very long, slow, but feature-rich auto")]
    internal class Winnebago
    {
        public void PlayMusic(bool On)
        {

        }
    }
}

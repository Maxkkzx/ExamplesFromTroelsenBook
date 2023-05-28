[assembly: CLSCompliant(true)]
namespace AttributedCarLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal sealed class VehicleDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
        internal VehicleDescriptionAttribute(string vehicleDescription)
            => Description = vehicleDescription;
        internal VehicleDescriptionAttribute() { }
    }

    [Serializable]
    [VehicleDescription(Description = "My rocking Harley!")]
    internal class Motorcycle
    {
    }

    [Serializable]
    [Obsolete("Use another vehicle!")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    internal class HorseAndBuggy
    {
    }

    [VehicleDescription("A very long, slow, but feature-rich auto")]
    internal class Winnebago
    {
        public void PlayMusic(bool On)
        {

        }
    }
}

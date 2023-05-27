using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyingAttributes
{
    [Serializable]
    internal class Motorcycle
    {
        [NonSerialized]
        float weightOfCurrentPassengers;
        bool hasRadioSystem;
        bool hasHeadSet;
        bool hasSissyBar;
    }
}

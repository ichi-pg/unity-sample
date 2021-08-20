using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ichi.Clicker
{
    public class LocalizationText
    {
        public static Ichi.Common.ILocalizationText Instance { get; private set; } = new Ichi.Common.LocalizationText("Ichi.Clicker");
    }
}

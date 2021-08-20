using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clicker
{
    public class LocalizationText
    {
        public static Common.ILocalizationText Instance { get; private set; } = new Common.LocalizationText("Clicker");
    }
}

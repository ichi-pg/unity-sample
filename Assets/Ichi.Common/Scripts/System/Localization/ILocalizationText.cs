using System.Collections;
using System.Collections.Generic;

namespace Ichi.Common
{
    public interface ILocalizationText
    {
        string ToString(string key, params object[] values);
    }
}

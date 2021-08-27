using System.Collections;
using System.Collections.Generic;

namespace Ichi.Common
{
    public interface ITextLocalizer
    {
        string Localize(string key, params object[] values);
    }
}

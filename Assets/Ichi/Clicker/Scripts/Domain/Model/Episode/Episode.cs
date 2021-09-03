using System.Collections;
using System.Collections.Generic;

namespace Ichi.Clicker
{
    public class Episode
    {
        public List<Sentence> Sentences { get; private set; }
        public ILocker Locker { private get; set; }
    }
}

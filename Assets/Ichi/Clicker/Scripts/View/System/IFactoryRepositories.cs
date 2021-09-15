
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public interface IFactoryRepositories
    {
        IFactoryRepository Get(FactoryCategory category);
    }
}

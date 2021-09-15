
using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker.View
{
    public interface IItemRepositories
    {
        IItemRepository Get(ItemCategory category);
    }
}

using System.Collections;
using System.Collections.Generic;
using System;

namespace Ichi.Clicker
{
    public interface IEnemyRepository
    {
        IEnemy Enemy { get; }
        event Action AlterHandler;
        void Encount();
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ichi.Clicker.View
{
    public interface ISkillButton
    {
        bool IsActive { get; }
        void SetButton(Button button);
    }
}

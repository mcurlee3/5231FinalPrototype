using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D.GameCommands
{

    public class SwitchReset : SimpleTransformer
    {
        public bool isActive = true;
        public GameObject s;
        public override void PerformInteraction()
        {
            if (!isActive)
            {
                s.SetActive(true);
            }
            else
            {
                s.SetActive(false);
            }
        }
    }
}

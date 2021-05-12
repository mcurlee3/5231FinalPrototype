using UnityEngine;

namespace Gamekit3D.GameCommands
{

    public class Counter2 : GameCommandHandler
    {
        public int currentCount = 0;
        public int target1Count = 1;
        [Tooltip("Target 1")]
        public GameObject Target1;
        public GameObject Target2;

        [Space]
        [Tooltip("Send a command when increment is performed. (optional)")]
        public SendGameCommand onIncrementSendCommand;
        [Tooltip("Perform an action when increment is performed. (optional)")]
        public GameCommandHandler onIncrementPerformAction;
        [Space]
        [Tooltip("Send a command when target count is reacted. (optional)")]
        public SendGameCommand onTargetReachedSendCommand;
        [Tooltip("Perform an action when target count is reacted. (optional)")]
        public GameCommandHandler onTargetReachedPerformAction;


        public override void PerformInteraction()
        {
            currentCount += 1;
            if (currentCount == target1Count)
            {
                currentCount += 1;
                if (onTargetReachedPerformAction != null) onTargetReachedPerformAction.PerformInteraction();
                if (onTargetReachedSendCommand != null) onTargetReachedSendCommand.Send();
                isTriggered = true;
            }
            else
            {
                if (onIncrementPerformAction != null) onIncrementPerformAction.PerformInteraction();
                if (onIncrementSendCommand != null) onIncrementSendCommand.Send();
                currentCount = 0;
                isTriggered = false;
            }
        }

    }

}


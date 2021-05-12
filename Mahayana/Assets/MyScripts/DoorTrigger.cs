using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Gamekit3D.GameCommands
{
    public class DoorTrigger : SimpleTransformer
    {
        public new Rigidbody rigidbody;
        public Vector3 start = -Vector3.forward;
        public Vector3 end = Vector3.forward;


        public override void PerformTransform(float position)
        {

            var curvePosition = accelCurve.Evaluate(position);

            {
                var pos = transform.TransformPoint(Vector3.Lerp(start, end, curvePosition));
                Vector3 deltaPosition = pos - rigidbody.position;
                if (Application.isEditor && !Application.isPlaying)
                    rigidbody.transform.position = pos;
                rigidbody.MovePosition(pos);
                if (m_Platform != null)
                    m_Platform.MoveCharacterController(deltaPosition);

            }


        }
    }
}

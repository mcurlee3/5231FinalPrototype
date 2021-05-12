using System;
using UnityEngine;

namespace Gamekit3D.GameCommands
{
    public class ResetSimpleTranslate : SimpleTransformer
    {
        public new Rigidbody rigidbody;
        public Vector3 start2 = Vector3.forward;
        public Vector3 end2 = -Vector3.forward;


        public override void PerformTransform(float position)
        {

            var curvePosition = accelCurve.Evaluate(position);

            {
                var pos = transform.TransformPoint(Vector3.Lerp(end2, start2, curvePosition));
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
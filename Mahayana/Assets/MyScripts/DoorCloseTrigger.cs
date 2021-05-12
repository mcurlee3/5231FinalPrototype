using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloseTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpen = true;
    private PlayerGlobals player;

    private void OnCollisionEnter(Collision collision)
    {
        player = FindObjectOfType<PlayerGlobals>();
        bool canClose = player.canClose;

        if ((isOpen) && (canClose))
        {
            player.canClose = false;
            player.canOpen = true;
            isOpen = false;
            door.transform.position += new Vector3(0, -5, 0);
        }
    }
}

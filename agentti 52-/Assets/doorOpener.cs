using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{
    public door door;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("bullet"))
            door.isOpen = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("bullet"))
            door.isOpen = false;
    }
}

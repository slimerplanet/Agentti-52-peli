using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class use : MonoBehaviour
{
    public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }

    void Use()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3))
        {
            if (hit.transform.gameObject.GetComponent<door>() != null)
                hit.transform.gameObject.GetComponent<door>().isOpen = true;
        }
    }
}

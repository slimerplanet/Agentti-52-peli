using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public Vector3 offset;
    private Vector3 startPos;
    private Vector3 Endpos;
    public float speed;

    public bool isOpen;

    private void Start()
    {
        startPos = transform.position;
        Endpos = transform.position;
        Endpos = Endpos + offset;

    }


    // Update is called once per frame
    void Update()
    {
        if(isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, Endpos, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startPos, speed * Time.deltaTime);

        }
    }
}

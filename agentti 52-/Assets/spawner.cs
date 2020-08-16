using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject _object;

    void Start()
    {
        Instantiate(_object, transform.position, transform.rotation);
    }


}

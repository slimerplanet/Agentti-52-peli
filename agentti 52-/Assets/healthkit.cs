using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthkit : MonoBehaviour
{
    public float amount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() != null && other.gameObject.GetComponent<Player>().health <= 100)
        {
            other.gameObject.GetComponent<Player>().health += amount;
            if (other.gameObject.GetComponent<Player>().health > 100)
                other.gameObject.GetComponent<Player>().health = 100;
            Destroy(gameObject);
        }
    }
}

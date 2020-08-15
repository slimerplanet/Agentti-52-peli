using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage;
    public GameObject mesh;
    public bool Enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemy>() != null && !Enemy) 
        {
            collision.gameObject.GetComponent<Enemy>().takeDamage(damage);
        }
        if (collision.gameObject.GetComponent<Player>() != null && Enemy)
        {

            collision.gameObject.GetComponent<Player>().takeDamage(damage);
        }
        print(collision.gameObject.name);

    }



    private void Awake()
    {
        if (Enemy)
            return;
        
        mesh.SetActive(false);
        Invoke("SetVisible", .25f);

    }

    private void SetVisible()
    {
        mesh.SetActive(true);

    }
}

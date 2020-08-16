
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 30;

    public Behaviour[] componentsToDisableOnDeath;
    public GameObject[] objectstoSpawnOnDeath;
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        Vector3 offset = new Vector3(0, 1, 0);
        transform.position += offset;
        for (int i = 0; i < objectstoSpawnOnDeath.Length; i++)
        {
            Instantiate(objectstoSpawnOnDeath[i], transform.position, Quaternion.identity);
        }
        for (int i = 0; i < componentsToDisableOnDeath.Length; i++)
        {
            componentsToDisableOnDeath[i].enabled = false;
        }


        Destroy(gameObject, 5f);
    }
}

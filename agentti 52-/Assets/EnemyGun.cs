using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public float damage = 10;
    public float range = 100;
    public float fireRate = 15;
    public bool isAutomatic;
    public float impactForce = 30;
    public float speed;
    public LayerMask mask;

    public int maxammo = 15;
    private int currentAmmo;
    public float reloadTime;
    private bool isReloading;
    


    public GameObject barrel;
    public ParticleSystem muzzleflash;
    public GameObject bullet;

    private float nextTimeToFire = 0f;


    public AI ai;

    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentAmmo = maxammo;
    }

    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        //Vector3 direction = player.transform.position - barrel.transform.position;
        //Quaternion rotation = Quaternion.LookRotation(direction);
        //if(ai.canSeePlayer)
            //barrel.transform.rotation = rotation;
        if (ai.canSeePlayer)
            Fire();
    }

    
    IEnumerator reload()
    {
        isReloading = true;
        Debug.Log("reloading");


        yield return new WaitForSeconds(reloadTime);


        currentAmmo = maxammo;
        isReloading = false;
    }
    void Fire()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(reload());
            return;
        }

        if (!isAutomatic)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        else
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }
    void Shoot()
    {
        muzzleflash.Play();

        currentAmmo--;
        barrel.transform.LookAt(player.transform);

        GameObject _bullet = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
        _bullet.GetComponent<Rigidbody>().velocity = barrel.transform.forward * speed;
        _bullet.GetComponent<bullet>().damage = damage;



        /*RaycastHit hit;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, range, mask))
        {
            Player player = hit.transform.GetComponent<Player>();
            if(player != null)
            {
                player.takeDamage(damage);
            }
        }

        if(hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * impactForce);
        } */

    }
}

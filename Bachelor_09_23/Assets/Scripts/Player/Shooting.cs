using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; // Abschussposition
    public GameObject bulletPrefab; // Kugel
    public float bulletForce = 10f; // Fluggeschwindigkeit
    public float shootDelay;
    public bool canShoot = true;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);

    }

    public IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    // TODO: Setze weitere Eigenschaften des Projektils (Schaden, Effekte, etc.).
}

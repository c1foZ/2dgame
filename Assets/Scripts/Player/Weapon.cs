using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    private float timeBetweenShots = 0.8f; 
    private float timeSinceLastShot = 0f;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && timeSinceLastShot >= timeBetweenShots)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
        
        timeSinceLastShot += Time.deltaTime;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
    }
}

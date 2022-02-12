using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    private string _shoot = "Shoot";
    private void Start()
    {

        InvokeRepeating(_shoot, 1f, 1f);

    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

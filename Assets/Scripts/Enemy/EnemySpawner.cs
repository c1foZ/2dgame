using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Transform spawn;
    private GameObject _spawnedEnemy;
    private void Awake()
    {
        spawn = GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            _spawnedEnemy = Instantiate(enemyPrefab);
            _spawnedEnemy.transform.position = spawn.position;
        }
    }
}

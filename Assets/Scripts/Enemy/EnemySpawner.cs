using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnLeft;
    [SerializeField] private Transform spawnRight;
    private GameObject _spawnedEnemy;
    private int _randomSide;
    private int _randomSpeed;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            _randomSide = Random.Range(0, 2);
            _randomSpeed = Random.Range(1, 10);
            _spawnedEnemy = Instantiate(enemyPrefab);
            if (_randomSide == 0)
            {
                _spawnedEnemy.transform.position = spawnRight.position;
                _spawnedEnemy.GetComponent<EnemyMovement>().speed = _randomSpeed;
            }
            else
            {
                _spawnedEnemy.transform.position = spawnLeft.position;
                _spawnedEnemy.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                _spawnedEnemy.GetComponent<EnemyMovement>().speed = -_randomSpeed;
            }
        }
    }
}

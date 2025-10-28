using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private float swarmerInterval = 3.5f;

    public GameObject playerTarget;


    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-5f, 5f), 6.5f), Quaternion.identity);
        var enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.player = playerTarget;
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

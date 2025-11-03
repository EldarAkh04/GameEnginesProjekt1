using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject swarmerPrefab;
    [SerializeField] private float swarmerInterval = 3.5f;

    public GameObject playerTarget;

    private int scoreForSpawner = 0;


    void Start()
    {
        Enemy.OneEnemyKilled += AddScore;
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(swarmerInterval);
        GameObject newEnemy = Instantiate(enemy, new Vector2(Random.Range(-5f, 5f), 6.5f), Quaternion.identity);
        var enemyScript = newEnemy.GetComponent<Enemy>();
        enemyScript.player = playerTarget;
        StartCoroutine(spawnEnemy(swarmerInterval, enemy));
    }
    public void AddScore(int scoreIncrease)
    {
        scoreForSpawner += scoreIncrease; 
        InscreSpawnInterval();
    }

    public void InscreSpawnInterval()
    {
        if(scoreForSpawner >= 3 ){
            Debug.Log("Score wird größer");
            swarmerInterval = 1.5f;
        }
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public SceneManage sceneManage;
    public GameObject enemyPrefab;
    public GameObject hazmatEnemyPrefab;
    public Vector3 generatePosition = new Vector3(0, 0, 8.5f);

    public int enemyCount;
    public int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        sceneManage = FindObjectOfType<SceneManage>();

    }


    void Update()
    {

        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            if (waveNumber == 5)
            {
                Debug.Log("Load next scene");
                waveNumber = 1;
                sceneManage.LoadNextLevel();
            }
            else
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
            Debug.Log("Wave Number: " + waveNumber);
        }

    }

    public void SpawnEnemyWave(int _enemyCount)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                var randomPosX = Random.Range(-8.0f, 8.0f);
                var randomPosZ = Random.Range(-8.0f, 8.0f);
                generatePosition = new Vector3(randomPosX, 0, randomPosZ);
                Instantiate(enemyPrefab, generatePosition, enemyPrefab.transform.rotation);
            }
        }

        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                var randomPosX = Random.Range(-8.0f, 8.0f);
                var randomPosZ = Random.Range(-8.0f, 8.0f);
                generatePosition = new Vector3(randomPosX, 0, randomPosZ);
                Instantiate(hazmatEnemyPrefab, generatePosition, hazmatEnemyPrefab.transform.rotation);
            }
        }

    }
}

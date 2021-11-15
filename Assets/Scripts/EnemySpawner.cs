using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public SceneManage sceneManage;
    public GameObject enemyPrefab;
    public GameObject hazmatEnemyPrefab;
    public GameObject[] rubbishEnemyPrefab;
    public GameObject trumpEnemyPrefab;
    public Vector3 generatePosition = new Vector3(0, 0, 8.5f);
    public Transform spawnLocation;

    public int enemyCount;
    public int enemyRubbishCount;
    public int waveNumber = 1;

    [SerializeField]
    private Canvas levelCompleteCanvas;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        sceneManage = FindObjectOfType<SceneManage>();

    }


    void Update()
    {

        enemyCount = FindObjectsOfType<Enemy>().Length;
        enemyRubbishCount = FindObjectsOfType<EnemyRubbish>().Length;

        if (enemyCount == 0 && (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1))
        {
            if (waveNumber == 5)
            {
                levelCompleteCanvas.enabled = true;
            }
            else
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
            Debug.Log("Wave Number: " + waveNumber);
        }
        if (enemyRubbishCount == 0 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (waveNumber == 5)
            {
                Debug.Log("Load next scene");
                waveNumber = 1;
                levelCompleteCanvas.enabled = true;
            }
            else
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
            Debug.Log("Wave Number: " + waveNumber);
        }
        if (enemyCount == 0 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (waveNumber == 1)
            {
                levelCompleteCanvas.enabled = true;
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

        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                var randomPosX = Random.Range(-8.0f, 8.0f);
                var randomPosZ = Random.Range(-8.0f, 8.0f);
                generatePosition = new Vector3(randomPosX, 0, randomPosZ);
                GameObject Rubbish = rubbishEnemyPrefab[Random.Range(0, rubbishEnemyPrefab.Length)];
                Instantiate(Rubbish, generatePosition, spawnLocation.transform.rotation);
            }
        }

        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                var randomPosX = Random.Range(-8.0f, 8.0f);
                var randomPosZ = Random.Range(-8.0f, 8.0f);
                generatePosition = new Vector3(randomPosX, 0, randomPosZ);
                Instantiate(trumpEnemyPrefab, generatePosition, trumpEnemyPrefab.transform.rotation);
            }
        }

    }
}

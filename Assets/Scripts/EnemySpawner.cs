using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static Queue<Bullet> bulletQueue;
    public Bullet bulletPrefab;
    [Range(1, 3)]
    public float timeBetweenWaves;

    public Wave[] waves;
    public Transform[] spawnPoints;


    private Wave currentWave;
    private int currentWaveIndex;

    private bool hasPlayedSound = false;


    void Start()
    {
        bulletQueue = new Queue<Bullet>();

        for (int i = 0; i < 41; i++)
        {
            Bullet newBullet = (Bullet)Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Bullet;
            newBullet.gameObject.SetActive(false);
            bulletQueue.Enqueue(newBullet);
        }

        currentWaveIndex = 0;
        StartCoroutine(SpawnEnemy());
    }


    void Update()
    {   
        if (currentWaveIndex > waves.Length - 1)
        {
            currentWaveIndex = 0;
        }
    }


    IEnumerator SpawnEnemy()
    {


        while (!GameManager.instance.hasGameEnded)
        {

//            Bullet newBullet = bulletQueue.Dequeue();
//            newBullet.gameObject.SetActive(true);
//        }

//            Debug.Log("Started Corroutine");
            currentWave = waves[currentWaveIndex];
            foreach (Pattern p in currentWave.patterns)
            {
                int spawnIndex = 0;
                for (int i = 0; i < p.enemiesToSpawn; i++)
                {
                    hasPlayedSound = !hasPlayedSound;

                    if (!hasPlayedSound)
                    { 
                        AudioManager.instance.Play("WooshShip");
                    }

                       
                    Bullet newBullet = bulletQueue.Dequeue();
                    int value;

                    if (spawnIndex >= p.spawnPositionIndex.Length)
                    {
                        spawnIndex = 0;
                    }

                    value = p.spawnPositionIndex[spawnIndex];
                    newBullet.gameObject.transform.position = spawnPoints[value].position;
                    newBullet.SetDIR(spawnPoints[value].right);
                    newBullet.gameObject.SetActive(true);
                    spawnIndex++;
                    yield return new WaitForSeconds(currentWave.delayBetweenSpawns);
                }

            }
            currentWaveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        yield return null;

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public static Queue<Bullet> bulletQueue;

    [Header("Prefabs")]
    [Tooltip("Prefab do inimigo")]
    public Bullet bulletPrefab;

    [SerializeField]
    [Tooltip("Prefab do Alerta")]
    private GameObject alertPrefab;

    [Header("Parametros")]
    [Range(1, 3)]
    [Tooltip("Tempo de espera entre waves")]
    public float timeBetweenWaves;

    [Header("Waves")]
    [Tooltip("Quantidade de waves que o jogo vai ter")]
    public Wave[] waves;

    [Header("Arrays")]
    [Tooltip("Local dos spawn points")]
    public Transform[] spawnPoints;

    [SerializeField]
    [Tooltip("Local onde vão spawnar os alertas")]
    private Transform[] alertPoints;


    private Wave currentWave;
    private int currentWaveIndex;

    private bool hasPlayedSound = false;


    void Start()
    {
        //Inicia a fila de inimigos
        bulletQueue = new Queue<Bullet>();

        //Preenche a fila. 41 é um numero arbitrário, mas é o suficiente.
        for (int i = 0; i < 41; i++)
        {
            Bullet newBullet = (Bullet)Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Bullet;
            newBullet.gameObject.SetActive(false);
            bulletQueue.Enqueue(newBullet);
        }

        currentWaveIndex = Random.Range(0, 3);       

        //Começa a spawnar inimigos no mundo
        StartCoroutine(SpawnEnemy());
    }


    void Update()
    {   
        currentWaveIndex = currentWaveIndex % waves.Length;
    }


    IEnumerator SpawnEnemy()
    {

        //Enquanto o jogo não acabar
        while (!GameManager.instance.hasGameEnded)
        {
            //Seta a wave atual
            currentWave = waves[currentWaveIndex];

            //Para cada pattern p contido nessa wave, faça
            foreach (Pattern p in currentWave.patterns)
            {
                int spawnIndex = 0;

                //Enquanto i for menor que a quantidade de inimigos pra spawnar nessa pattern, faça
                for (int i = 0; i < p.enemiesToSpawn; i++)
                {
                    //hasPlayedSound recebe sua negativa;
                    hasPlayedSound = !hasPlayedSound;

                    //Se hasPlayedSound for falsa, toque o som 
                    if (!hasPlayedSound)
                    { 
                        AudioManager.instance.Play("WooshShip");
                    }

                    //Tire o inimigo da fila e instancia ele no mundo.
                    Bullet newBullet = bulletQueue.Dequeue();
                    int value;

                    //Assegura que spawnIndex nunca será maior que o tamanho do vetor
                    spawnIndex = spawnIndex % p.spawnPosition.Length;
                    

                    //Converte o valor do ENUM para um int;
                    value = (int)p.spawnPosition[spawnIndex];

                    //TODO: Indicar para o jogador daonde o inimigo virá.
                    Instantiate(alertPrefab, alertPoints[value].position, Quaternion.identity);

                    //Seta a posicao do inimigo no mundo
                    newBullet.gameObject.transform.position = spawnPoints[value].position;
                    //Seta a direção que ele irá
                    newBullet.SetDIR(spawnPoints[value].right);
                    //Ativa o inimigo
                    newBullet.gameObject.SetActive(true);
                    spawnIndex++;

                    yield return new WaitForSeconds(currentWave.delayBetweenSpawns);
                }
                yield return new WaitForSeconds(currentWave.timeBetweenPatterns);
            }
            currentWaveIndex++;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        yield return null;
    }
}
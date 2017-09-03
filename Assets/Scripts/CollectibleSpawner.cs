using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles;
    public float distanceBetwenObjects;

    public CollectiblePatterns[] patterns;

    public static CollectibleSpawner instance;
    private Vector3[] spawnPoints = new Vector3[9];
    private CollectiblePatterns currentPattern;

    private int collectibleIndex;
    private int lastCollectibleIndex;
    private int patternIndex = -1;
    private int collectiblesLeftToSpawn;
    private int collectiblesLeftToCollect;

    private int gemsCollected = 0;

    public int GetGemsCollected{ get { return gemsCollected; } }



    void Awake()
    {
        if (instance == null)
            instance = this;

        if (patterns.Length == 0)
        {
            Debug.LogError("Coloque alguma pattern, animal de tetas");
        }
    }

    void Start()
    {  
        gemsCollected = 0;
        PopulateSpawnPoints();
        NextPattern();
    }

    int SelectCollectible()
    {
        float value = Random.Range(0f, 1f);

        if (value >= 0.4f)
        {
            return collectibleIndex;   
        }
        else
        {
            do
            {
                collectibleIndex = Random.Range(0, collectibles.Length - 1); 
            } while(collectibleIndex == lastCollectibleIndex);
        }


        lastCollectibleIndex = collectibleIndex;
        return collectibleIndex;
    }

    public void OnCollect(EColor color)
    {
        gemsCollected++;
        collectiblesLeftToCollect--;
        CanvasManager.instance.FillDiamondImage(gemsCollected % 10, color);

        if (collectiblesLeftToCollect <= 0)
        {
            NextPattern();
        }
    }

    void NextPattern()
    {
        patternIndex++;
        patternIndex = patternIndex % patterns.Length;
        currentPattern = patterns[patternIndex];
        collectiblesLeftToCollect = collectiblesLeftToSpawn = currentPattern.ammountToSpawn;
        StartCoroutine(SpawnCollectibles());
    }

    void PopulateSpawnPoints()
    {
        spawnPoints[0] = new Vector3(-distanceBetwenObjects, distanceBetwenObjects, 0f);
        spawnPoints[1] = new Vector3(0f, distanceBetwenObjects, 0f);
        spawnPoints[2] = new Vector3(distanceBetwenObjects, distanceBetwenObjects, 0f);
        spawnPoints[3] = new Vector3(-distanceBetwenObjects, 0f, 0f);
        spawnPoints[4] = Vector3.zero;
        spawnPoints[5] = new Vector3(distanceBetwenObjects, 0f, 0f);
        spawnPoints[6] = new Vector3(-distanceBetwenObjects, -distanceBetwenObjects, 0f);
        spawnPoints[7] = new Vector3(0f, -distanceBetwenObjects, 0f);
        spawnPoints[8] = new Vector3(distanceBetwenObjects, -distanceBetwenObjects, 0f);
    }


    IEnumerator SpawnCollectibles()
    {   
        foreach (int i in currentPattern.spawnPositionIndex)
        {
            Instantiate(collectibles[SelectCollectible()], spawnPoints[i], Quaternion.identity);
            collectiblesLeftToSpawn--;
        }
        yield return null;
    }
}

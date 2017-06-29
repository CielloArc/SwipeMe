using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Patterns/CollectiblePattern")]
public class CollectiblePatterns : ScriptableObject
{
    [Tooltip("Indices das posições dos SpawnPoints. Vai de 0 até 11")]
    public int[] spawnPositionIndex;
    [Tooltip("Quantidade de coletaveis a spawnar.")]
    public int ammountToSpawn;
}

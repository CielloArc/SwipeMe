using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Patterns/SpawnPattern")]
public class Pattern : ScriptableObject
{
    [Tooltip("Indices das posições dos SpawnPoints")]
    public EnemieSpawnPositionEnum[] spawnPosition;

    [Tooltip("Quantidade de inimigos a spawnar. O numero ideal é um multiplo de 2 X quantidade de spawnPoints")]
    public int enemiesToSpawn;
}

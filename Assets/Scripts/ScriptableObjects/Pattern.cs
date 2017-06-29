using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Patterns/SpawnPattern")]
public class Pattern : ScriptableObject
{
    [Tooltip("Indices das posições dos SpawnPoints. Vai de 0 até 11")]
    public int[] spawnPositionIndex;
    [Tooltip("Quantidade de inimigos a spawnar. O numero ideal é um multiplo de 2 X quantidade de spawnPoints")]
    public int enemiesToSpawn;
}

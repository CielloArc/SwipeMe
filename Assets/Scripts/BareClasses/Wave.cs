using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [Tooltip("Patterns que serão utilizadas na Wave")]
    public Pattern[] patterns;

    [Range(0, 5)]
    [Tooltip("Tempo entre spawns")]
    public float delayBetweenSpawns;
}

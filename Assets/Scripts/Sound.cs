using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [Tooltip("Nome do som")]
    public string name;

    [Tooltip("Arquivo de audio")]
    public AudioClip clip;

    [Tooltip("Volume base do som")]
    [Range(0f, 1f)]
    public float baseVolume = .7f;
    [Tooltip("Variacao do volume")]
    [Range(0f, 1f)]
    public float volumeRandomness = .1f;

    [Tooltip("Pitch base do som")]
    [Range(0f, 10f)]
    public float basePitch = 1f;
    [Tooltip("Variacao do pitch")]
    [Range(0f, 1f)]
    public float pitchRandomness = 0.1f;

    [Tooltip("O som deve ficar em loop?")]
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;

}
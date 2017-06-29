using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //Instancia do AudioManager
    public static AudioManager instance;

    [Header("Componentes")]
    [Tooltip("Gamne object que é utilizado para tocar o som no ambiente")]
    public GameObject audioPool;
    [Tooltip("Mixer que gerencia o audio")]
    public AudioMixerGroup masterMixer;

    [Header("Lista de sons")]
    [Tooltip("Aumente ou diminua a lista de acordo com a quantidade de sons do jogo")]
    public Sound[] pool;


    void Awake()
    {
        //Se não houver instancia, esse daqui se torna a instancia;
        if (instance == null)
            instance = this;

        //Adicione no AudioPool um AudioSource para cada som que você tiver no array Pool;
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i].source = audioPool.AddComponent<AudioSource>();
        }

        //Toque a BGM Principal
        Play("BGM");
    }

    //Play: Metodo que toca um audio a partir do nome chamado.
    public void Play(string soundName)
    {   

        //Variavel sound recebe um audio da soundPool, se ele existir;
        Sound sound = Array.Find(pool, element => element.name == soundName);

        //Se sound for nulo, avisar e retornar metodo;
        if (sound == null)
        {
            Debug.LogError("Audio não encontrado: " + soundName);
            return;
        }

        //Do contrário, adicione o componente AudioSource da variável sound a variavel souce;
        AudioSource source = sound.source;
        //O clip da variavel source recebe o clip da variável sound;
        source.clip = sound.clip;
        //O volume da variável source recebe um valor aleatório a partir do valor base de volume da variável sound;
        source.volume = UnityEngine.Random.Range(sound.baseVolume - sound.volumeRandomness, sound.baseVolume + sound.volumeRandomness);
        //O pitch da variável source recebe um valor aleatório a partir do valor base de pitch da variável sound;
        source.pitch = UnityEngine.Random.Range(sound.basePitch - sound.pitchRandomness, sound.basePitch + sound.pitchRandomness);

        //Verifica se é pro audio tocar em loop ou não;
        source.loop = sound.loop;
        //Define o mixer de output;
        source.outputAudioMixerGroup = masterMixer;

        //E, finalmente, toca o audio;
        source.Play();
    }

    //Stop: Metodo que para de tocar um audio a partir do nome passado;
    public void Stop(string soundName)
    {
        Sound sound = Array.Find(pool, element => element.name == soundName);

        sound.source.Stop();
    }
}

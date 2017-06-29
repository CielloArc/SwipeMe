using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int id;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.Play("Collect");
            other.SendMessage("OnCollect", id, SendMessageOptions.DontRequireReceiver);        
            CollectibleSpawner.instance.OnCollect();
            Destroy(gameObject);
        }
    }
}

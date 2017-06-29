using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 dir;

    private Transform myTransform;

    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        myTransform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

    public void SetDIR(Vector3 pDir)
    {
        dir = pDir;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
        EnemySpawner.bulletQueue.Enqueue(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("Die");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    private SpriteRenderer rend;
    private Vector3 dir;

    private Transform myTransform;

    void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        myTransform.Translate(dir * speed * Time.deltaTime, Space.World);
    }

    public void SetDIR(Vector3 pDir, int value)
    {
        dir = pDir;
        SortRenderingLayer(value);
    }

    void SortRenderingLayer(int pos)
    {
        switch (pos)
        {
            case 0:
            case 3:
            case 8:
            case 11:
                rend.sortingOrder = 0;
                break;
            case 1:
            case 4:
            case 7:
            case 10:
                rend.sortingOrder = 1;
                break;
            case 2:
            case 5:
            case 6:
            case 9:                
                rend.sortingOrder = 2;
                break;
            default:
                rend.sortingOrder = 0;
                break;
        }
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

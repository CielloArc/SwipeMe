using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foo : MonoBehaviour
{
    private PlayerMovement pm;


    void Awake()
    {
        pm = GetComponentInParent<PlayerMovement>();
    }

    public void BM()
    {
        pm.BroadcastMessage("Move");
    }

}

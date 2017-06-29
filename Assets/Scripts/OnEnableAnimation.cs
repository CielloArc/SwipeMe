using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableAnimation : MonoBehaviour
{
    public Animation anim;

    void OnEnable()
    {
        anim.Play();
    }
}

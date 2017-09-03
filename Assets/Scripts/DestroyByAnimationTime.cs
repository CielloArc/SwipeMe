using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByAnimationTime : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);   
    }
}

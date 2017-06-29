using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float space = 2.5f;
    public float maxSwipeDistance;
    public Animator anim;

    private Rigidbody2D rb;
    private Vector2 dir;

    private Vector2 touchOrigin;
    private float swipeDistance;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = rb.position;
    }

    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -space, space),
            Mathf.Clamp(transform.position.y, -space, space),
            Mathf.Clamp(transform.position.z, 0f, 0f)
        );

        #if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            dir = rb.position + Vector2.right * space;
            AudioManager.instance.Play("Jump");
            anim.SetTrigger("JumpTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            dir = rb.position + Vector2.right * -space;
            AudioManager.instance.Play("Jump");
            anim.SetTrigger("JumpTrigger");

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            dir = rb.position + Vector2.up * space;
            AudioManager.instance.Play("Jump");
            anim.SetTrigger("JumpTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            dir = rb.position + Vector2.up * -space;
            AudioManager.instance.Play("Jump");
            anim.SetTrigger("JumpTrigger");
        }
        #endif

        #if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;   
            }
            else if (myTouch.phase == TouchPhase.Ended)
            {
                Vector2 touchEnd = myTouch.position;

                Vector2 distance = touchEnd - touchOrigin;

                if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
                {
                    Debug.Log("HorizontalSwipe");
                    if (Mathf.Sign(distance.x) > 0)
                    {
                        dir = rb.position + Vector2.right * space;
                        AudioManager.instance.Play("Jump");
                        anim.SetTrigger("JumpTrigger");
                    }
                    else if (Mathf.Sign(distance.x) < 0)
                    {
                        dir = rb.position + Vector2.right * -space;
                        AudioManager.instance.Play("Jump");
                        anim.SetTrigger("JumpTrigger");
                    }
                }
                else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
                {
                    Debug.Log("VerticalSwipe");
                    if (Mathf.Sign(distance.y) > 0)
                    {
                        dir = rb.position + Vector2.up * space;
                        AudioManager.instance.Play("Jump");
                        anim.SetTrigger("JumpTrigger");
                    }
                    else if (Mathf.Sign(distance.y) < 0)
                    {
                        dir = rb.position + Vector2.up * -space;
                        AudioManager.instance.Play("Jump");
                        anim.SetTrigger("JumpTrigger");
                    }
                }
            }

        }
        #endif

    }

    //    void FixedUpdate()
    //    {
    //        Move();
    //    }
    //
    void Move()
    {
        rb.MovePosition(dir);
    }
}

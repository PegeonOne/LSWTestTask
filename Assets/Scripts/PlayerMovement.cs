using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 4;
    Rigidbody2D rb;
    Animator animator;

    Vector2 moveDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        if (moveDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir.normalized * speed * Time.fixedDeltaTime);
    }
}

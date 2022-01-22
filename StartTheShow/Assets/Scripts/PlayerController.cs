using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isDazing;

    private Rigidbody2D rb;
    private Vector2 moveInputs;

    [Header("角色移动速度")]
    public float moveSpeed;
    public float dragSpeed;
    // Start is called before the first frame update
    void Start()
    {
        dragSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!isDazing)
        {
            moveInputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.velocity = new Vector2(moveInputs.x * moveSpeed, moveInputs.y * moveSpeed);
        }
    }
}

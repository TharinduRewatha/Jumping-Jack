using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [Header("Attachments")]
    public Animator anim;

    public float gravity = -10f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private Vector3 velocity;
    public bool isGrounded;

    private Rigidbody rb;
    private generalmanager generalmanager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        generalmanager = GameObject.FindObjectOfType<generalmanager>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        rb.velocity = velocity;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
            anim.SetBool("isJumping",false);
        }


        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        if (Input.touchCount > 0 && isGrounded)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                jump();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "obs")
        {
            Destroy(gameObject);

            Vector2 pos = new Vector2(0, 0);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            GameObject go = Instantiate(generalmanager.lostPanel, pos, rot);

            generalmanager.isGameOver = true;
            generalmanager.won = false;
        }
    }

    private void jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        anim.SetBool("isJumping", true);
    }
}

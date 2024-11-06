using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConTrol : MonoBehaviour
{
    private bool isfacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float Speed = 10;
    [SerializeField] private float Move;
    [SerializeField] private float jumPing = 9;
    public bool ground= true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Move * Speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)&& ground)
        {
            Jump();
        }
        flip();
        anim.SetBool("run", Move != 0);
        anim.SetBool("grounder", ground);
    }
    public void flip()
    {
        if (Move > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (Move < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumPing);
        anim.SetTrigger("Jump");
        ground = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            ground = true;
        } 
    }
    public bool canAttack()
    {
        return Move == 0;
    }    
}

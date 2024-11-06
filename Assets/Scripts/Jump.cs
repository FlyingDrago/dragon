using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Animator anim;
    public float jumPower = 9;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetButtonDown("Jump"))
        {
            JumPing();
        }
    }
    private void JumPing()
    {
        canJump = false;
        rb.velocity = Vector2.up * jumPower;
        Invoke("ResetJump", 0.5f);
    }
    private void ResetJump()
    {
        canJump=true;
    }
}

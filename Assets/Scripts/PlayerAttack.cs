using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    //private PlayerMovement playerMovement;
    [SerializeField] private float attackcoolDown;
    [SerializeField] private float coolDownTime = Mathf.Infinity;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        //playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTime > attackcoolDown )
        {
            attack();
            coolDownTime += Time.deltaTime;
        }
    }
    private void attack()
    {
        anim.SetTrigger("attack");
        coolDownTime = 0;
        fireBalls[FindFireball()].transform.position=firePoint.position;
        fireBalls[FindFireball()].GetComponent<ProjectTile>().Direction(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }    
        return 0;

    }    
}

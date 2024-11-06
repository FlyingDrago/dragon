using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] private float stratingHeath;
    [SerializeField] public float currentHeath { get; private set; }
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHeath = stratingHeath;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float damage)
    {
        currentHeath = Mathf.Clamp(currentHeath - damage, 0, stratingHeath);
        if (currentHeath > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
        }    
    }

}

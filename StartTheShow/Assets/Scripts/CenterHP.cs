using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterHP : MonoBehaviour
{
    public int healthPointMax;
    public int healthPoint;

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        healthPoint = healthPointMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage(int _damage)
    {
        healthPoint -= _damage;
        Animator.SetTrigger("Hurt");
        if (healthPoint<=0)
        {
            GameManager.Instance.GameLoss();
        }
    }
}

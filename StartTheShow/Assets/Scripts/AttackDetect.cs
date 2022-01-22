using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    private TowerController tower;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponentInParent<TowerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            tower.ShotToMonster(collision.gameObject);
            Debug.Log("Shot");
        }
    }
}

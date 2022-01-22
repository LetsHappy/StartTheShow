using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    PASITIVE, NEGATIVE
}
public class Bullet : MonoBehaviour
{
    // 移动速度
    public float moveSpeedMax;
    public float moveSpeed;


    // 造成的伤害
    public int damage;

    public GameObject target;

    public bool startMove;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = moveSpeedMax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (startMove && target!=null)
        {
            Vector2 toTarget = (target.transform.position - transform.position).normalized;
            //Vector2 toTarget = new Vector2(target.transform.position.x, target.transform.position.y).normalized;
            transform.Translate(toTarget * moveSpeed * Time.deltaTime, Space.World);
;        }
    }
    public void FollowTarget(GameObject _target)
    {
        target = _target;
        startMove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.GetComponent<MonsterController>().GetDamage(damage);
            Destroy(this.gameObject);
        }
    }
    
}

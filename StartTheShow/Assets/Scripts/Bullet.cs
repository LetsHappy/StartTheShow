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
    public float rotateSpeed;


    // 造成的伤害
    public int damage;

    private GameObject target;
    public GameObject fromTower;
    public GameObject targetTower;

    public bool startMove;
    public bool ableDamage;

    public BulletType BulletType;

    public GameObject Item;


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
        if (startMove && target != null)
        {
            Vector2 toTarget = (target.transform.position - transform.position).normalized;
            //Vector2 toTarget = new Vector2(target.transform.position.x, target.transform.position.y).normalized;
            transform.Translate(toTarget * moveSpeed * Time.deltaTime, Space.World);
            //float angelZ = Vector2.Angle(transform.position, toTarget);
            //transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angelZ));
            transform.up = Vector2.Lerp(transform.up, toTarget, rotateSpeed);
;        }
    }
    public void FollowTarget(GameObject _target)
    {
        startMove = true;
        ableDamage = false;
        target = _target;
        BulletType = BulletType.NEGATIVE;
    }
    public void FollowTarget(GameObject _target, GameObject _tower, GameObject _from)
    {
        target = _target;
        startMove = true;
        targetTower = _tower;
        ableDamage = true;
        fromTower = _from;
        BulletType = BulletType.PASITIVE;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") && ableDamage)
        {
            collision.GetComponent<MonsterController>().GetDamage(damage);
            //Destroy(this.gameObject);
            target = targetTower;
            Debug.Log("Bullet: Hit monster");
        }
        if (collision.gameObject.CompareTag("NegativeTower") && BulletType == BulletType.PASITIVE)
        {
            collision.gameObject.GetComponent<TowerController>().ShotToTower(fromTower);
            Destroy(this.gameObject);
            Debug.Log("Bullet: Hit tower");
        }
        if (collision.gameObject.CompareTag("Tower") && BulletType == BulletType.NEGATIVE)
        {
            collision.gameObject.GetComponent<TowerController>().bulletCount++;
            Destroy(this.gameObject);
            Debug.Log("Bullet: Hit pasitive tower");
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    NORMAL, BOSS
}
public class MonsterController : MonoBehaviour
{
    // 怪物生命值
    public int healthPointMax;
    public int healthPoint;

    // 怪物移动速度
    public float moveSpeedMax;
    public float moveSpeed;

    // 怪物对主基地造成的伤害
    public int damage;

    // 怪物种类
    public MonsterType MonsterType;

    // 怪物移动路径
    public int pathID;

    private int pathNodeState;
    private Path path = new Path();

    public GameObject target;
    public bool startMove;

    // Start is called before the first frame update
    void Start()
    {
        path = GameManager.Instance.paths[pathID];
        healthPoint = healthPointMax;
        moveSpeed = moveSpeedMax;

        startMove = true;
        target = path.nodes[pathNodeState];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (startMove && target != null)
        {
            Vector2 toTarget = target.transform.position - transform.position;
            //Vector2 toTarget = new Vector2(target.transform.position.x, target.transform.position.y).normalized;
            transform.Translate(toTarget.normalized * moveSpeed * Time.deltaTime, Space.World);
            if (toTarget.magnitude <= 0.1)
            {
                NextCheckPoint();
            }
        }
    }
    private void NextCheckPoint()
    {
        if (pathNodeState < path.nodes.Count-1)
        {
            pathNodeState++;
            target = path.nodes[pathNodeState];
            //Debug.Log("Node: " + pathNodeState);
        }
        else
        {
            Debug.Log("End Node: " + pathNodeState);
            startMove = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("Center"))
        {
            collision.gameObject.GetComponent<CenterHP>().GetDamage(damage);
            Destroy(this.gameObject);// 播放怪物消失动画
        }
    }
    public void GetDamage(int _damage)
    {
        healthPoint -= _damage;
        if (healthPoint <= 0)
        {
            Destroy(this.gameObject);// 播放怪物死亡动画
        }
    }
}

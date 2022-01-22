using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    PASITIVE, NEGATIVE
}
public class TowerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject ngBltPrefab;
    public TowerType TowerType;

    // 拥有的子弹的数量
    public int bulletCount = 1;

    public float attackRange;
    public GameObject attackDetect;

    public GameObject connectTower;

    public bool isSelected;



    // Start is called before the first frame update
    void Start()
    {
        connectTower = GameManager.Instance.negativeTower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (TowerType == TowerType.PASITIVE)
        {
            UpdateAttackRange();
        }
        
    }

    public void ShotToMonster(GameObject _target)
    {
        if (CostBullet())
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, this.transform);
            bullet.GetComponent<Bullet>().FollowTarget(_target, connectTower, this.gameObject);
        }
    }
    public void ShotToTower(GameObject _tower)
    {
        GameObject bullet = GameObject.Instantiate(ngBltPrefab, this.transform);
        bullet.GetComponent<Bullet>().FollowTarget(_tower);
    }
    public bool CostBullet()
    {
        if (bulletCount > 0)
        {
            bulletCount--;
            return true;
        }
        else
        {
            bulletCount = 0;
            return false;
        }
    }
    public void TowerMove()
    {

    }
    public void UpdateAttackRange()
    {
        attackDetect.transform.position = (transform.position + connectTower.transform.position) / 2;
        attackDetect.GetComponent<BoxCollider2D>().size = new Vector2(Mathf.Abs(transform.position.x - connectTower.transform.position.x),
                                                                      Mathf.Abs(transform.position.y - connectTower.transform.position.y));
    }
    public void ShowRange(int _range)
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (connectTower != null)
        {
            Gizmos.DrawLine(transform.position, connectTower.transform.position);           
        }
    }
}

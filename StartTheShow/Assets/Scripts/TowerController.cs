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

    public void ShotToMonster(GameObject _target)
    {
        if (CostBullet())
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, this.transform);
            bullet.GetComponent<Bullet>().FollowTarget(_target);
            
        }
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

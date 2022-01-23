using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    public List<GameObject> nodes = new List<GameObject>();
}
[System.Serializable]
public class Monster
{
    public int ID;
    public int path;
    public float time;
}
public class GameManager : MonoSingleton<GameManager>
{
    
    // 路径序列
    [Header("路径序列")]
    public List<Path> paths = new List<Path>();
    // 怪物序列
    [Header("怪物生成序列")]
    public List<Monster> monsters = new List<Monster>();
    private int monsterNum;// 准备刷出的怪物
    // 怪物预制体
    [Header("怪物预制体")]
    public List<GameObject> monsterPrefabs = new List<GameObject>();

    // 唯一的玩家控制负极塔
    public GameObject negativeTower;

    public float timeCountMax;
    public float timeCounter;
    public bool generateStop;

    public List<GameObject> particlePrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = monsters[monsterNum].time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        else if(!generateStop)
        {
            GenerateMonster(monsters[monsterNum]);
            SetNextMonster();
        }
    }
    public void GenerateMonster(Monster _monster)
    {
        int _id = _monster.ID;
        int _path = _monster.path;
        GameObject monster = GameObject.Instantiate(monsterPrefabs[_id], paths[_path].nodes[0].transform.position, Quaternion.identity);
        monster.GetComponent<MonsterController>().pathID = _path;
    }
    public void SetNextMonster()
    {
        if (++monsterNum < monsters.Count)
        {
            timeCounter = monsters[monsterNum].time;
        }
        else
        {
            generateStop = true;
        }
        
    }
    public void GenerateParticle(int _id, Transform _transform)
    {
        GameObject particle = GameObject.Instantiate(particlePrefabs[_id], _transform.position, Quaternion.identity);
    }

    public void GameLoss()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var path in paths)
        {
            for (int i = 0; i < path.nodes.Count-1; i++)
            {
                Gizmos.DrawLine(path.nodes[i].transform.position, path.nodes[i+1].transform.position);
            }       
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path
{
    public List<GameObject> nodes = new List<GameObject>();
}
public class GameManager : MonoSingleton<GameManager>
{
    

    public List<Path> paths = new List<Path>();

    public List<GameObject> objects = new List<GameObject>();

    public GameObject negativeTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateMonster()
    {

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

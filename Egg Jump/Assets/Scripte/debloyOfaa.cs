using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debloyOfaa : MonoBehaviour
{
    public GameObject ofaaPrefab;
    public int poss = 0;
    public int count = 0;
    public int count_2 = 0 ;
    public int count_3 = 0;
    public int createdOfaas = 2;
    // Start is called before the first frame update
    void Start()
    {
   
        SpwnEnemy_1();
        SpwnEnemy_1();
    }
    private void Update()
    {
        if (count < 2 && count_2 < 3)
        {
            createdOfaas += 1;
            SpwnEnemy();
            count_2 += 1;
        }
        if (count >= 2 && count_2 >= 3)
        {
            
            count_2 = 0;
            count = 0;
        }
        if (count_3 >= 3)
        {
            count_3 = 0;
        } 
    }
    private void SpwnEnemy()
    {
        GameObject a = Instantiate(ofaaPrefab) as GameObject;
        
        if (createdOfaas < 2)
        {
            a.transform.position = new Vector2(0, poss - 4);
        }
        else
        {
            a.transform.position = new Vector2(Random.Range(-5, 5), poss - 4);
        }
        
        poss += 4;
        count_3 += 1;
    }
   
    private void SpwnEnemy_1()
    {
        GameObject a = Instantiate(ofaaPrefab) as GameObject;
        a.transform.position = new Vector2(0, poss - 4);
        
        poss += 4;
        count_3 += 1;
    }
}

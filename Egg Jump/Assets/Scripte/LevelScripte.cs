using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScripte : MonoBehaviour
{
    private EggController eggObj;
    // Start is called before the first frame update
    void Start()
    {
        eggObj = FindObjectOfType<EggController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < eggObj.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
    
}

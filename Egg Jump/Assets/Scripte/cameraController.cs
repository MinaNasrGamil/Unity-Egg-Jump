using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private EggController eggObj;
    public Rigidbody2D rb;
    public float poss = 0f;
    private GroundScript groundObj;
    // Start is called before the first frame update
    void Start()
    {
        eggObj = FindObjectOfType<EggController>();
        rb = GetComponent<Rigidbody2D>();
        groundObj = FindObjectOfType<GroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eggObj.ofaas != 0 && eggObj.ofaas % 2 == 0 && transform.position.y <= poss && eggObj.upOrDown && groundObj.isDide)
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
            Debug.Log("up");
                
        }
        else if (transform.position.y >= poss)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Debug.Log("Down");
        }   
        if(eggObj.ofaas %2 ==0 && eggObj.ofaas != 0)
        {
            poss = eggObj.ofaas * 4;
        }
    }
}

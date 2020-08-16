using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ofaa : MonoBehaviour
{

    public PolygonCollider2D coliderofaa;
    public Rigidbody2D rigibody;
    public float randomNum;
    public float left;
    public float right;
    public int ofaaValue;
    public float poss;
    private cameraController cameraObj;
    private debloyOfaa debloyObj;
    private EggController eggObj;
    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(-1, 1);
        left = Random.Range(-1.5f, -1f);
        right = Random.Range(1f, 1.5f);
        eggObj = FindObjectOfType<EggController>();
        debloyObj = FindObjectOfType<debloyOfaa>();
        rigibody = this.GetComponent<Rigidbody2D>();
        if (debloyObj.count_3 > 0 )
        {
            if (randomNum >0)
            {
                rigibody.velocity = new Vector2(1, 0);
            }
            else
            {
                rigibody.velocity = new Vector2(-1, 0);
            }

        }
        else
        {
            rigibody.velocity = new Vector2(0, 0);
        }
        coliderofaa = GetComponent<PolygonCollider2D>();
        cameraObj = FindObjectOfType<cameraController>();

    }

    // Update is called once per frame
    void Update()
    {   
        if (debloyObj.createdOfaas < 2)
        {
            rigibody.velocity = new Vector2(0, 0);
        }
        if (debloyObj.count_3 > 0)
        {
            if (transform.position.x <= -5)
                rigibody.velocity = new Vector2(right, 0);
            else if (transform.position.x >= 5)
            {
                rigibody.velocity = new Vector2(left, 0);
            }
        }
        // 3laket alEgg blOfaa
        if (eggObj.rigiBody.velocity.y < 0)
        {
            eggObj.coliderBall.isTrigger = false;
            if (eggObj.transform.position.y > transform.position.y + 4)
            {
                coliderofaa.isTrigger = true;
            }
            if (eggObj.transform.position.y < transform.position.y - 1)
            {
                coliderofaa.isTrigger = false;
            }

        }
        if (transform.position.y < cameraObj.transform.position.y && (cameraObj.transform.position.y - transform.position.y) > 6)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Egg")
        {
            eggObj.transform.position = new Vector2(transform.position.x, eggObj.transform.position.y);
        }
            
    }
}


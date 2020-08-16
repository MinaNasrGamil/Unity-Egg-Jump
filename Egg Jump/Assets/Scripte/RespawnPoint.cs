using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private EggController eggObj;
    private bool onPoint = false;
    private GroundScript groundObj;
    // Start is called before the first frame update
    void Start()
    {
        eggObj = FindObjectOfType<EggController>();
        groundObj = FindObjectOfType<GroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eggObj.rigiBody.velocity.y <= 0 && onPoint == true)
        {
            eggObj.poss = new Vector2(transform.position.x,transform.position.y);
        }
        if (eggObj.rigiBody.velocity.y == 0 && eggObj.transform.position.y > transform.position.y + 3)
        {
            onPoint = false;
        }
        if (eggObj.rigiBody.velocity.y > 0 && eggObj.transform.position.y > eggObj.poss.y + 3 && groundObj.isDide == false)
        {
            groundObj.isDide = true;
            eggObj.ofaas += 1;
            Debug.Log("new"+eggObj.ofaas);
            Debug.Log(groundObj.isDide);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Egg")
        {
            if (eggObj.rigiBody.velocity.y <= 0)
            {
                onPoint = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundScript : MonoBehaviour
{
    private EggController eggObj;
    public bool isDide ;
    public int heartPoints = 3 ;
    public Text hearts;
    // Start is called before the first frame update
    void Start()
    {
        isDide = true;
        eggObj = FindObjectOfType<EggController>();
        hearts.text = "==    " + heartPoints;
    }

    // Update is called once per frame
    void Update()
    {
        hearts.text = "==    " + heartPoints;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.tag == "Egg")
            {
                StartCoroutine("RespawnDelay");
            }
        }
    }

    public IEnumerator RespawnDelay()
    {
        SoundManagerScript.playSound("fall");
        eggObj.ofaas -= 1;
        heartPoints -= 1;
        isDide = false;
        yield return new WaitForSeconds(1f);
        eggObj.transform.position = new Vector2(eggObj.poss.x, eggObj.poss.y+1);
        Debug.Log(isDide);
        Debug.Log(eggObj.ofaas);
    }
}

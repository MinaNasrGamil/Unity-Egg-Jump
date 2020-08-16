using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggController : MonoBehaviour
{
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    public Rigidbody2D rigiBody;
    public float jumpSpeed = 8f;
    public PolygonCollider2D coliderBall;
    private ofaa ofaaobj;
    private Animator egganimation;
    public int ofaas;
    public Vector2 poss;
    private cameraController cameraObj;
    public bool upOrDown;
    private debloyOfaa debloyObj;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        coliderBall = GetComponent<PolygonCollider2D>();
        ofaaobj = FindObjectOfType<ofaa>();
        egganimation = GetComponent<Animator>();
        cameraObj = FindObjectOfType<cameraController>();
        debloyObj = FindObjectOfType<debloyOfaa>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump") && isTouchingGround && upOrDown)
        {
            coliderBall.isTrigger = true;
            rigiBody.velocity = new Vector2(0, jumpSpeed);
            upOrDown = false;
            SoundManagerScript.playSound("jump");
        }
        egganimation.SetBool("ISGround", isTouchingGround);
        Score.text = "==    " + ofaas;

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ofaa")
        {
            upOrDown = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "level")
        {
            ofaas += ofaaobj.ofaaValue;
            debloyObj.count += 1;
            Debug.Log(ofaas);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public float speed = 1f;
    public Rigidbody2D rb;
    public bool crouch = false;
    public bool portal = false;
    public bool exitPortal = false;

    public static PlayerPhase currentPhase = PlayerPhase.Baby;
        

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            crouch = true;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(0,0);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            crouch = false;
        }
    }

    public void Action()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 position;
    public float speed = 1f;
    public Rigidbody2D rb;
    public int age = 1;
    public int niveau = 0;

    public bool crouch = false;
    public bool portal = false;
    public bool exitPortal = false;

    private float timePortal = 1f;
    private float timeP = 0f;

    public static PlayerPhase currentPhase = PlayerPhase.Baby;
        

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (portal)
        {
           
        }
        
    }

    public void Move()
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

    public void PushElement(GameObject element) {
        element.transform.position = this.transform.position;
    }


    public void ShowLock(GameObject element) {
        if (!element.activeSelf) {
            element.SetActive(true);
        }
    }

    public void Action(string tag)
    {
       
        /*if (Input.GetKeyDown(KeyCode.Space))
        { Debug.Log("Portal activé");
            if(string.Equals(tag, "Portal"))
            {
                
                Vector3 newPos = new Vector3(transform.position.x + 0.5f, 0f, -1);
                portal = true;
                if (timeP < timePortal)
                {
                    transform.position = Vector3.Lerp(transform.position, newPos, timeP);
                    timeP = Time.deltaTime / timePortal;
                }

            }
        }*/
    }

    public void UsePortal()
    {
        portal = true;
        niveau++;
    }

    public void ExitPortal()
    {
        exitPortal = true;
        if(niveau%3 == 0)
        {
            age++;
        }
    }

    
    /*
    private void OnTriggerEnter(Collider other)
    {
       // if (Input.GetKeyDown(KeyCode.Space))
            
            
        if(other.CompareTag("Puzzle"))
        {
            
            //Action("Puzzle");
        }
        else  if(other.CompareTag("Portal"))
        {
            //Action("Portal");
            
                Debug.Log("Portail activé");
                UsePortal();
            }
        
    }*/
}

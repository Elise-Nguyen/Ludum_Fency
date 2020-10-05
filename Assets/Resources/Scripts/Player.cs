using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject hands;
    public Vector2 position;
    public float speed = 1f;
    public Rigidbody2D rb;
    public int age = 0;
    public int niveau = 0;

    public bool crouch = false;
    public bool portal = false;
    public bool exitPortal = false;
    public GameObject bulletprefab;

    private float timePortal = 1f;
    private float timeP = 0f;
    private bool canThrowbone = true;

    public static PlayerPhase currentPhase = PlayerPhase.Baby;

    // TODO : Need to be set a true when babyEnigma is clear
    [HideInInspector] public bool babyEnigma;

    public List<Sprite> sprites = new List<Sprite>();
    public SpriteRenderer currentSprite;
        

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ThrowBone();
        if (portal)
        {
           
        }
        
    }

    public void Move()
    {
       if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * speed;
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * speed;
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
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

    // Méthode qui permet de pousser un élément, appelé à travers les interactions
    public void PushElement(GameObject element) {
        element.transform.position = hands.transform.position;
    }

    // Méthode qui permet d'afficher le cadenas, appelé à travers les interactions
    public void ShowLock(GameObject element) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!element.activeSelf) {
                element.SetActive(true);
            } else {
                element.SetActive(false);
            }
        }
    }

    public void InteractObject(GameObject element) {
        // Interaction avec le tableau
        if (element.tag == "Tableau" && Input.GetKeyDown(KeyCode.Space)) {
            var rotation = element.transform.rotation.eulerAngles;
            Debug.Log(rotation.z);
            if (rotation.z == 90) {
                rotation.z = 0;
                element.transform.rotation = Quaternion.Euler(rotation);
                element.transform.position += new Vector3(-GetComponent<SpriteRenderer>().bounds.size.x / 1.8f, -GetComponent<SpriteRenderer>().bounds.size.y / 1.8f, 0);

            } else {
                rotation.z = 90;
                element.transform.rotation = Quaternion.Euler(rotation);
                element.transform.position += new Vector3(GetComponent<SpriteRenderer>().bounds.size.x / 1.8f, GetComponent<SpriteRenderer>().bounds.size.y / 1.8f, 0);
            }
        }   
    }

    public void ThrowBone()
    {
        if(currentPhase == PlayerPhase.Squeleton && Input.GetKey(KeyCode.LeftControl) && canThrowbone)
        {
            GameObject bulletInstance = Instantiate(bulletprefab, transform.position, Quaternion.identity);
            canThrowbone = false;
            if(!canThrowbone)
            {
                StartCoroutine(CooldownBone());
            }
        }
        else
        {
            Debug.LogWarning("You are not in correct phase to throw bones");
        }
    }

    public IEnumerator CooldownBone()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        canThrowbone = true;
        yield return null;
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
        //niveau++;
        age++;

        currentSprite.sprite = sprites[age - 1];
    }

    public void ExitPortal()
    {
        exitPortal = true;
        if(niveau%3 == 0)
        {
            age++;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Decor")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
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

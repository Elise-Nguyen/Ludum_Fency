using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public bool isInRange;
    public bool isInValidation;
    public UnityEvent interactAction;
    //public UnityEvent validateAction;
    //public GameObject valider;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                interactAction.Invoke();
                return;
            }
        }
       /* if (isInValidation)
        {
            validateAction.Invoke();
            this.gameObject.SetActive(false);
        }*/
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            //Debug.Log("Player enter in range");
            TextDisplay pickupText = GetComponent<TextDisplay>();
            pickupText.ShowPickupText("Press SPACE to interact");
        }
        if (collision.gameObject == valider)
        {
            isInValidation = true;
            // this.gameObject.SetActive(false);
            // Debug.Log("Valider"); //
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            isInRange = false;
            //Debug.Log("Player enter in range");
        }
        if (collision.gameObject == valider)
        {
            isInValidation = false;
            // this.gameObject.SetActive(false);
            // Debug.Log("Valider"); //
        }
    }
}

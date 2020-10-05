using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validation : MonoBehaviour
{
    public GameObject valider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if (collision.gameObject == valider)
        {
            this.gameObject.SetActive(false);
            Debug.Log("Valider");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == valider)
        {
            this.gameObject.SetActive(false);
            Debug.Log("Valider");
        }
    }

}
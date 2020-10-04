using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 position;
    public GameObject player;

    
    public float timeZoom = 1f;
    public float timeDeZoom = 0f;
    private float timeZ = 0;
    private float timeD = 0;
    private bool zoom = false;
    private bool deZoom = false;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        
        DeZoom();

        //Move();
    }
    /*
    public void Move()
    {
        position = new Vector3(player.transform.position.x, 0,-5);
        transform.position = position;
    }
    */
    public void Zoom()
    {
        
        Vector3 newPos = new Vector3(player.GetComponent<Player>().transform.position.x, 0, -2);
        if (player.GetComponent<Player>().portal)
        {
            //Debug.Log("Zoom activate");
            deZoom = false;
            zoom = true;
            if (timeZ < timeZoom)
            {
                transform.position = Vector3.Lerp(transform.position, newPos, timeZ);
                timeZ += Time.deltaTime / timeZoom;
               // Debug.Log("temps Zoom " + timeZ);
            }
            else
            {
                player.GetComponent<Player>().exitPortal = true;
                timeZ = 0;
            }
        }


    }

    public void DeZoom()
    {
        
        if (player.GetComponent<Player>().exitPortal
            && player.GetComponent<Player>().portal)
        {
            //Debug.Log("Dezoom activate");
            zoom = false;
            deZoom = true;
            if (timeD < timeDeZoom)
            {
                transform.position = Vector3.Lerp(transform.position, position, timeD);
                timeD += Time.deltaTime / timeDeZoom;
            }
            else
            {
                timeD = 0;
                player.GetComponent<Player>().portal = false;
                player.GetComponent<Player>().exitPortal = false;
                transform.position = position;
            }
        }
    }

}


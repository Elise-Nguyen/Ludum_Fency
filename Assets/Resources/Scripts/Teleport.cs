using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public Transform destinationPosition;
    //private bool waitActive = false;

    /*
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
           TeleportPlayerTo(other.gameObject);
       }   
   }*/

    public void TeleportPlayerTo(GameObject player)
    {

       // if (!waitActive)
        
            Debug.Log("Wait");
            //StartCoroutine(Wait());
        
        player.transform.position = destinationPosition.position;
        
    }
/*
    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(2.0f);
        waitActive = false;
    }
    */

}

   
    

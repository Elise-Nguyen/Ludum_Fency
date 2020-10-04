using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
   public Transform destinationPosition;
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
        new WaitForSecondsRealtime(1f);
       player.transform.position = destinationPosition.position;
   }

    public static void MyDelay(int seconds)
    {
        TimeSpan ts = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < ts);
    }
}

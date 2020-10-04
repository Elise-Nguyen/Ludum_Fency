using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
   public Transform destinationPosition;
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Player")
       {
           TeleportPlayerTo(other.gameObject);
       }   
   }

   void TeleportPlayerTo(GameObject player)
   {
       player.transform.position = destinationPosition.position;
   }
}

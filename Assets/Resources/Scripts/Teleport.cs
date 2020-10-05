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
        Player character = player.GetComponent<Player>();

        if (Player.currentPhase == PlayerPhase.Baby)
        {
            if (!character.babyEnigma)
            {
                if (!GameManager.instance.rocks[0].activeSelf && !GameManager.instance.rocks[1].activeSelf && !GameManager.instance.rocks[2].activeSelf)
                {
                    Player.currentPhase = PlayerPhase.Adult;
                    character.babyEnigma = true;
                    character.UsePortal();
                }
            }
            else
            {
                Debug.Log("Need to store each rock on the good recipient!");
            }
            // Change appareance here
        }
        // if (!waitActive)

        //Debug.Log("Wait");
        //StartCoroutine(Wait());

        //player.transform.position = destinationPosition.position;

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

   
    

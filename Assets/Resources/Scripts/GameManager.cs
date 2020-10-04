using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlayerPhase {Baby, Adult, GrandFather, Squeleton}
    public PlayerPhase currentPhase = PlayerPhase.Baby;
    public static GameManager instance;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else
        {
            Debug.LogError(this + " in " + gameObject.name + " has be destroyed because another " + this + " already exists");
            Destroy(gameObject);
            return;
        }
    }

    public void ChangePlayerState(PlayerPhase selectedPhase)
    {
        currentPhase = selectedPhase;
        switch(selectedPhase){
            case PlayerPhase.Baby:
            {

            }
            break;
            case PlayerPhase.Adult:
            {

            }
            break;
            case PlayerPhase.GrandFather:
            {

            }
            break;
            case PlayerPhase.Squeleton:
            {

            }
            break;

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerPhase {Baby, Adult, GrandFather, Squeleton};
public class GameManager : MonoBehaviour
{
    private bool isTimedout = false; 
    private bool isCompleted = false; 
    public float timerEnigmaBaby = 60f;
    public float timerEnigmaAdult = 45f;
    public float timerEnigmaGrandfather = 30f;
    public float timerEnigmaSqueleton = 20f;
    
    public static GameManager instance;
    public     
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
        Player.currentPhase = selectedPhase;
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

    public void LaunchEnigma()
    {
        isCompleted = false;
        isTimedout = false;
        StartCoroutine(Enigma(Player.currentPhase));
    }
    
    public void CompleteEnigma()
    {
        StopCoroutine(Enigma(Player.currentPhase));
        isCompleted = true;
    }

    IEnumerator Enigma(PlayerPhase timerCategory)
    {
        switch(timerCategory)
        {
            case PlayerPhase.Baby:
            {
                yield return new WaitForSecondsRealtime(timerEnigmaBaby);
            }
            break;
            case PlayerPhase.Adult:
            {
                yield return new WaitForSecondsRealtime(timerEnigmaAdult);
            }
            break;
            case PlayerPhase.GrandFather:
            {
                yield return new WaitForSecondsRealtime(timerEnigmaGrandfather);
            }
            break;
            case PlayerPhase.Squeleton:
            {
                yield return new WaitForSecondsRealtime(timerEnigmaSqueleton);
            }
            break;
        }
        isTimedout = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enigma {
    public PlayerPhase assignedPhase;
    public int enigmaID;
    public bool isCompleted;
        
}

public enum PlayerPhase {Baby, Adult, GrandFather, Squeleton}; 
public class GameManager : MonoBehaviour
{
    #region Private
    bool isTimedOut = false; 
    bool isCompleted = false;
    
    #endregion

    #region Public
    public List<Enigma> enigmaRegistry = new List<Enigma>(12);
    [Range(1,12)]
    public Enigma selectedEnigma;
    public float timerEnigmaBaby = 60f;
    public float timerEnigmaAdult = 45f;
    public float timerEnigmaGrandfather = 30f;
    public float timerEnigmaSqueleton = 20f;
    [HideInInspector]
    public static GameManager instance;

    [Header("Baby Enigma")]

    public List<GameObject> rocks = new List<GameObject>();

    #endregion 
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
        selectedEnigma = enigmaRegistry[0];
    }

    public void ChangePlayerState(PlayerPhase selectedPhase)
    {
        Player.currentPhase = selectedPhase;
        switch(selectedPhase){
            case PlayerPhase.Baby:
            {
                //Code apparition phase bébé
            }
            break;
            case PlayerPhase.Adult:
            {
                //Code apparition phase adulte
            }
            break;
            case PlayerPhase.GrandFather:
            {
                //Code apparition phase grandpère
            }
            break;
            case PlayerPhase.Squeleton:
            {
                //Code apparition phase squelette
            }
            break;

        }
    }

    public void LaunchEnigma(int selectedEnigmaID)
    {
        if(isCompleted || isTimedOut){
        isCompleted = false;
        isTimedOut = false;
        selectedEnigma = enigmaRegistry[selectedEnigmaID - 1];
        StartCoroutine(Enigma(Player.currentPhase));
        }
        else
        {
            Debug.Log("You are trying to start an enigma while the previous one is still active");
        }
    }
    
    public void CompleteEnigma()
    {
        StopCoroutine(Enigma(Player.currentPhase));
        selectedEnigma.isCompleted = true;
        CompleteGameCheck();
    }

    public void CompleteGameCheck()
    {
        int completedEnigmas = 0;
        foreach(Enigma e in enigmaRegistry)
        {
            if(e.isCompleted)
            {
                completedEnigmas++;
            }
        }
        if(completedEnigmas == 12)
        {
            //Code de fin de jeu
        }
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
        isTimedOut = true;
    }
}

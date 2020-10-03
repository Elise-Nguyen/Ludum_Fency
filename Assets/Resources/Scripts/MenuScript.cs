using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int gameSceneID;
    public GameObject[] menuScreens = new GameObject[2]; 
    void Start()
    {
        ClearAllScreens();
        menuScreens[0].SetActive(true);
    }
    public void StartGame()
    {
        if(gameSceneID == 0)
        {
            Debug.LogError("You are trying to load scene N°0, which is usualy the menu scene. Please set your game scene to an ID other than 0");
            Application.Quit(2);
            
        }
        else if (gameSceneID < 0)
        {
            Debug.LogError("You are trying to load a scene with an incorrect ID, please check the ID in the Menu script");
            Application.Quit(2);
        }
        else
        {
            SceneManager.LoadScene(gameSceneID);
        }
    }
    public void QuitGame()
    {
        Application.Quit(0);
    }
    public void ClearAllScreens()
    {
        foreach(GameObject screen in menuScreens)
        {
            screen.SetActive(false);
        }
    }
    public void SwitchMenuScreen(int screenToDisplay)
    {   
        ClearAllScreens();
        menuScreens[screenToDisplay].SetActive(true);
    }
}

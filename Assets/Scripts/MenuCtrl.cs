using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 *This class handles the transfer of scene
 * between the home scene and the gameplay scene 
 * 
 * 
 **/
public class MenuCtrl : MonoBehaviour
{

    private GameManager mGameManager;

    //Used to create a GameManager obect which can be used to call methods.
    private GameManager mGM
    {
        get
        {
            if (mGameManager == null)
            {
                mGameManager = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return mGameManager;
        }
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

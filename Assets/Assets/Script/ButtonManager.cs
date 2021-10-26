using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.Save();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (SceneManager.GetActiveScene().name == "story21")
        {
            PlayerPrefs.SetInt("level", 34);
        }
    }

    public void ChangeScene(string sceneName)
    {
        PlayerPrefs.Save();
        if (sceneName == "start" || sceneName == "fakeStart" || sceneName == "pack2")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (int.Parse(sceneName) <= PlayerPrefs.GetInt("level")){
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(sceneName);
        }

    }

    public void EndGameNow()
    {
        Application.Quit();
    }
}

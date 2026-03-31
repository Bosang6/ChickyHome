using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnBeginScene : MonoBehaviour
{
    public void OnStartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitBtn()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

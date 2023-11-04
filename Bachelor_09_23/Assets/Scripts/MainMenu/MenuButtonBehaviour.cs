using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonBehaviour : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnSettingsClick()
    {

    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
    }
}

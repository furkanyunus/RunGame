using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bitti_panel : MonoBehaviour
{
    public void evet_btn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/bolum1");
    }
    public void hayir_btn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

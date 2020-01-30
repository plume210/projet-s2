using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ChangeScenes : MonoBehaviour {
    public string LevelToLoad;
    void LoadMenu () {
        SceneManager.LoadScene("maptestobj");
    }
    void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
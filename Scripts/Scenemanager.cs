using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    public void Restarter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void loadSceneId(int Id)
    {
        SceneManager.LoadScene(Id);
    }
}

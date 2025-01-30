using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SnenName; 

    public void LoadScene()
    {
        SceneManager.LoadScene(SnenName); 
    }
}
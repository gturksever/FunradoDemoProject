using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClicked : MonoBehaviour
{
    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{ 

    public void Delay()
    {
        Invoke("ChangeMainScene", 1f);
    }
    public void ChangeMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
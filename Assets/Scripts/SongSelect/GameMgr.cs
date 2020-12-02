using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public AudioSource back;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        back = GetComponent<AudioSource>();
        Screen.SetResolution(1920, 1080, true);
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Main")
            if (Input.GetKeyDown(KeyCode.Escape))
                LoadScene();
    }
    void LoadScene() {
        SceneManager.LoadScene("Select");
    }
    private void OnEnable() {
        back.Play();
    }
}

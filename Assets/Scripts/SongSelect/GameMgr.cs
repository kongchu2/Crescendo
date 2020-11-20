using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public AudioSource back;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        back = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "Main")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LoadScene();
            }
        }
    }
    void LoadScene()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("Start");
    }
    private void OnEnable()
    {
        back.Play();
    }
}

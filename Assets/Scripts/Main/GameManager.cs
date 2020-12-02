using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TextAsset sheet;
    private void Awake()
    {
        sheet = SongInfo.Instance.getSheet();
    }
    private void Start()
    {
        SheetParser parser = new SheetParser(sheet);
        MusicManager.musicInfo = parser.InfoParse();
        parser.NoteParse(SongInfo.Instance.getDifficulty());
        Record.Instance.reset();
    }
    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SelectScene()
    {
        PauseMenu.Instance.PauseAndResume(false);
        ChangeScene("Select");
    }
    public void ReStart() {
        ChangeScene("Main");
    }
}

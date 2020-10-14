using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static readonly int KEY = 4;

    public TextAsset sheet;

    public NoteManager noteManager;

    public static int score = 0;

    public static float userSpeedRate = 16f;
    private void Awake()
    {
        sheet = SongInfo.Instance.getSheet();
    }
    private void Start()
    {
        SheetParser parser = new SheetParser(sheet);
        MusicManager.musicInfo = parser.InfoParse();
        parser.NoteParse();
    }
    private void Update()
    {
        noteManager.NoteGenerate();
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            userSpeedRate++;
            Debug.Log(userSpeedRate+ "위");
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            userSpeedRate--;
            Debug.Log(userSpeedRate + "아래");
        }
    }
}

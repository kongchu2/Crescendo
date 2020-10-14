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


    public static float userSpeedRate = 16f;//세팅make
    private void Awake()
    {
        sheet = SongInfo.Instance.getSheet();
    }
    private void Start()
    {
        MusicManager.musicInfo = SheetParser.InfoParse(sheet);
        SheetParser.NoteParse(sheet);
    }
    private void Update()
    {
        noteManager.NoteGenerate();
    }
}

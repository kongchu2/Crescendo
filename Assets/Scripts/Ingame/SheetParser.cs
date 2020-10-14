using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SheetParser
{//음악 정보 파일을 읽는 코드
    public static Dictionary<string, string> InfoParse(TextAsset sheet)
    {
        string[] textSplit;
        string sheetText;
        StringReader stringReader = new StringReader(sheet.text);
        Dictionary<string, string> musicInfo = new Dictionary<string, string>();
        while (!(sheetText = stringReader.ReadLine()).Contains("[MusicInfo]")){}
        while (!(sheetText = stringReader.ReadLine()).Contains("[MusicInfoEND]"))
        {//음악정보부분
            textSplit = sheetText.Split('=');
            musicInfo.Add(textSplit[0], textSplit[1]);
        }
        return musicInfo;
    }
    public static void NoteParse(TextAsset sheet)
    {
        string[] textSplit;
        string sheetText;
        StringReader stringReader = new StringReader(sheet.text);
        while (!(sheetText = stringReader.ReadLine()).Contains("[NotesInfo]")){}
        while(!(sheetText = stringReader.ReadLine()).Contains("[NotesInfoEND]"))
        {//노트부분
            textSplit = sheetText.Split(',');
            int noteLaneNum = int.Parse(textSplit[0]);
            float noteTime = (int.Parse(textSplit[1])+int.Parse(MusicManager.musicInfo["Offset"])) * 0.001f;
            float longNoteTime = int.Parse(textSplit[2]) * 0.001f;
            NoteManager.SetNote(noteLaneNum, noteTime, longNoteTime);
        }
    }
}
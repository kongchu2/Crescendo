using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SheetParser
{//음악 정보 파일을 읽는 코드
    TextAsset sheet;
    public SheetParser(TextAsset sheet) {
        this.sheet = sheet;
    }//이미 파싱해놓고 값을 주는식.
    public Dictionary<string, string> InfoParse()
    {
        string[] textSplit;
        string sheetText;
        StringReader stringReader = new StringReader(sheet.text);
        Dictionary<string, string> musicInfo = new Dictionary<string, string>();
        while (!stringReader.ReadLine().Contains("[MusicInfo]")){}
        while (!(sheetText = stringReader.ReadLine()).Contains("[MusicInfoEND]"))
        {//음악정보부분
            textSplit = sheetText.Split('=');
            musicInfo.Add(textSplit[0], textSplit[1]);
        }
        return musicInfo;
    }
    public void NoteParse(string diffculty)
    {
        string[] textSplit;
        string sheetText;
        StringReader stringReader = new StringReader(sheet.text);
        int noteCount = 0;
        while (!stringReader.ReadLine().Contains("[NotesInfo]")) {}
        while (!stringReader.ReadLine().Contains("[" + diffculty + "]")) {}
        while(!(sheetText = stringReader.ReadLine()).Contains("[NotesInfoEND]"))
        {//노트부분
            textSplit = sheetText.Split(',');
            int noteLaneNum = int.Parse(textSplit[0]);
            float noteTime = (int.Parse(textSplit[1])+int.Parse(MusicManager.musicInfo["Offset"])) * 0.001f;
            float longNoteTime = int.Parse(textSplit[2]) * 0.001f;
            NoteGenerator.noteTimeList[noteLaneNum-1].Add(new NoteInfo(noteTime, longNoteTime));
            noteCount++;
        }
        Record.Instance.noteCount = noteCount;
    }
}
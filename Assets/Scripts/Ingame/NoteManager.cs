using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static Queue<NoteInfo>[] noteTimeQueue;

    public GameObject[] notePrefabList;
    
    public Transform Lanes;
    public static Transform[] SpawnPosList;

    private void Awake()
    {
        noteTimeQueue = new Queue<NoteInfo>[GameManager.KEY];
        for(int i=0;i<GameManager.KEY;i++)
            noteTimeQueue[i] = new Queue<NoteInfo>();

        SpawnPosList = new Transform[GameManager.KEY];
        for(int i=0;i<GameManager.KEY;i++)
            SpawnPosList[i] = Lanes.GetChild(i);
    }
    public void NoteGenerate()
    {
        for (int i = 0; i < GameManager.KEY; i++)
        {
            if (noteTimeQueue[i].Count == 0)
                continue;
            float noteSpawnLeftTime = (MusicManager.currentMusicTime - noteTimeQueue[i].Peek().noteTime) * -GameManager.userSpeedRate;
            if (noteSpawnLeftTime-1 <= SpawnPosList[i].position.y)
            {
                NoteInfo noteInfo = noteTimeQueue[i].Dequeue();
                GameObject note = Instantiate(notePrefabList[i],
                new Vector2(SpawnPosList[i].position.x,//x
                            SpawnPosList[i].position.y),//y
                            Quaternion.identity,//Rotation
                            SpawnPosList[i]);//Parent
                note.GetComponent<Note>().myTime = noteInfo.noteTime;
                if (noteInfo.longNoteTime > 0)
                    note.transform.localScale = new Vector3(1f, noteInfo.longNoteTime, 1f);
            }
        }
    }   
}
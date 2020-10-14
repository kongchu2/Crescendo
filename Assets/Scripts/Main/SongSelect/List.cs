using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public List<SongName> items = new List<SongName>();
    public SongDisplay songPanelPrefab;

    void Start()
    {
        SongDisplay song = (SongDisplay)Instantiate(songPanelPrefab);
        song.Prime(items);
    }

}

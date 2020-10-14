using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public AudioSource back;

    public GameObject Mainmenu;
    public GameObject SelectSong;
    void Start()
    {
        back = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            back.Play();
            SelectSong.SetActive(false);
            Mainmenu.SetActive(true);
            }
    }
}

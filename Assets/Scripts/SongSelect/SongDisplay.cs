using System.Collections.Generic;
using UnityEngine;

public class SongDisplay : MonoBehaviour
{
    public Transform targetTransform;
    public SongPanel itemDisplayPrefab;
    public void Prime(List<SongName> items)
    {
        foreach (SongName item in items)
        {
            SongPanel display = (SongPanel)Instantiate(itemDisplayPrefab);
            display.transform.SetParent(targetTransform, false);
            display.Prime(item);
        }


    }
}

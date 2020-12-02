using UnityEngine;

public class Note : MonoBehaviour
{
    public float myTime;
    void Update()
    {
        if (!PauseMenu.Instance.isPause)
        {
            Move();
            if (MusicManager.currentMusicTime - myTime > 0.1275f)
            {
                Record.Instance.ComboBreak(false);
                Record.Instance.HPminusplus(-1);
                UIManager.Instance.setJudgementSpriteByIndex(5);
                Record.Instance.judgementedNoteCount++;
                Destroy(gameObject);
            }
        }
    }
    void Move() {
        float movePosy = (MusicManager.currentMusicTime - myTime) * -Setting.Instance.userSpeedRate;
        transform.position = new Vector2(transform.position.x, movePosy);
    }
    private void OnDestroy()
    {
        Judgement.listIndex[(int)transform.parent.transform.localPosition.x+2]++;
    }
}

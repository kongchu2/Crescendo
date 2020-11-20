using UnityEngine;

public class Note : MonoBehaviour
{
    public float myTime;
    void Update()
    {
        if (!PauseMenu.isPause)
        {
            Move();
            if (MusicManager.currentMusicTime - myTime > 0.1275f)
            {
                Destroy(gameObject);
                Record.Instance.ComboBreak(false);
                UIManager.Instance.setJudgementSpriteByIndex(5);
            }
        }
    }
    void Move() {
        float movePosy = (MusicManager.currentMusicTime - myTime) * -Setting.Instance.userSpeedRate;
        transform.position = new Vector2(transform.position.x, movePosy);
    }
    private void OnDestroy()
    {
        Judgement.noteTimeQueue[(int)transform.parent.transform.localPosition.x+2].Dequeue();
    }
}

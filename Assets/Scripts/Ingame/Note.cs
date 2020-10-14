using UnityEngine;

public class Note : MonoBehaviour
{
    public float myTime;
    void Update()
    {
        Move();
        if(MusicManager.currentMusicTime - myTime > 0.1275f)
        {
            Destroy(gameObject);
            Combo.ComboBreak();
            UIManager.Instance.setJudgementUI(5);
        }
    }
    void Move() {
        float movePosy = (MusicManager.currentMusicTime - myTime) * -GameManager.userSpeedRate;
        transform.position = new Vector2(transform.position.x, movePosy);
    }
    //musictime set -> move
    private void OnDestroy()
    {
        Judgement.noteTimeQueue[(int)transform.parent.transform.localPosition.x+2].Dequeue();
    }
}

using UnityEngine;
public class AnimationManager : MonoBehaviour{
    public Transform hitAnimParent;
    public static Animator[] hitAnims;

    private void Start()
    {
        hitAnims = new Animator[hitAnimParent.childCount];
        for(int i=0;i<hitAnimParent.childCount;i++)
            hitAnims[i] = hitAnimParent.GetChild(i).GetComponent<Animator>();
    }
    public static void HitPlay(int lane) {
        hitAnims[lane].SetBool("isHit", true);
    }
}
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
        /*if(!(hitAnims[lane].GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f))
            hitAnims[lane].Play("Hit",0,0f);*/
        hitAnims[lane].SetTrigger("Hit");
    }
}
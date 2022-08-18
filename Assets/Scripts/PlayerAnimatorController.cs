using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // 1 - TOP
    // 2 - DOWN
    // 3 - LEFT
    // 4 - RIGHT
    // 5 - IdleTop
    // 6 - IdleDown
    // 7 - IdleLeft
    // 8 - IdleRight
    public void SetWalkAnimation(int walk)
    {
        anim.SetInteger("WalkPosition", walk);
    }
}

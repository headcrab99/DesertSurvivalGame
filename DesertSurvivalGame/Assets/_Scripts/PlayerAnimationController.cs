using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator animator;
    private PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetBool("Move", controller.isMoving);
    }
}

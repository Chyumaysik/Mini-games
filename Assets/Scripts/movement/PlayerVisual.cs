using Unity.AppUI.Core;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private const string IS_RUNNING = "IsRunning";
    private const string MOVE_Y = "MoveY";
    private const string IS_MOVING_Y = "IsMovingY";
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());

        animator.SetBool(IS_MOVING_Y, Player.Instance.IsMovingY());

        Vector2 dir = Player.Instance.GetMovementDirection();

        animator.SetFloat(MOVE_Y, dir.y);

        if (dir.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (dir.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private bool isMovingY = false;


    private Vector2 moveDir = Vector2.zero;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

    }
    [SerializeField] private float movingspeed = 8f;

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {

        Vector2 inputVector = Gameinput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;

        if (inputVector != Vector2.zero)
        {
            moveDir = inputVector;
        }

        rb.MovePosition(rb.position + inputVector * movingspeed * Time.fixedDeltaTime);

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isMovingY = true;
        }
        else
        {
            isMovingY = false;
        }
    }
    public bool IsRunning()
    {
        return isRunning;
    }

    public bool IsMovingY()
    {
        return isMovingY;
    }

    public Vector2 GetMovementDirection()
    {
        return moveDir;
    }
}

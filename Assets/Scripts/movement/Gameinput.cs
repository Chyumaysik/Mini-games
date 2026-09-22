using UnityEngine;

public class Gameinput : MonoBehaviour
{
    public static Gameinput Instance { get; private set; }
    private Playerinputactions Playerinputactions;
    private void Awake()
    {
        Instance = this;
        Playerinputactions = new Playerinputactions();
        Playerinputactions.Enable();
    }
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = Playerinputactions.Player.Move.ReadValue<Vector2>();

        return inputVector;
    }
}

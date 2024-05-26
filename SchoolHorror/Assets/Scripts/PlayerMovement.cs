using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100;
    private InputManager _inputManager;
    private Rigidbody _rb;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var movementVector = _inputManager.GetMovementVector();
        var move = movementVector * moveSpeed * Time.deltaTime;
        _rb.linearVelocity = new Vector3(move.x, 0f, move.y);
    }
}

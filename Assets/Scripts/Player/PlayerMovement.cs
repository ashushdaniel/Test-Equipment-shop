using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public bool canMove;
    public Vector2 moveDirection;

    [SerializeField] float baseMovementSpeed = 5f;
    [SerializeField] float scale = 1;

    Canvas titleCanvas;
    Rigidbody2D rb;
    StatData movementSpeedStat;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        titleCanvas = GetComponentInChildren<Canvas>();
        movementSpeedStat = GetComponent<PlayerStats>().GetStatData(StatData.StatsType.movement_Speed);
        canMove = true;
    }
    void Update()
    {
        Walk();
    }

    //using the new unity input system
    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    void Walk()
    {
        if (!canMove) return;
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            if (Mathf.Abs(moveDirection.x) > 0.01f)
            {
                int faceDirection = (int)Mathf.Sign(moveDirection.x);

                //reverse the player x scale if he is going backwards
                titleCanvas.transform.localScale = new Vector3(faceDirection * scale, scale, 1f);
                transform.localScale = new Vector3(faceDirection * scale, scale, 1f);
            }
        }
        float movementSpeed = baseMovementSpeed + movementSpeedStat.value;
        rb.linearVelocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}

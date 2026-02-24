using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float maxSpeed = 4f;
    public float acceleration = 10f;
    public float deceleration = 15f;

    private float inputX;
    private float currentSpeed;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    public void MoveInput(Vector2 direction)
    {
        inputX = direction.x;
    }

    public void Movement()
    {
        if (Mathf.Abs(inputX) > 0.1f)
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                inputX * maxSpeed,
                acceleration * Time.deltaTime
            );
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                0f,
                deceleration * Time.deltaTime
            );
        }

        Vector3 move = new Vector3(currentSpeed, 0f, 0f);
        characterController.Move(move * Time.deltaTime);
    }
    
    public void Interact()
    {
        
    }

    public void Bark()
    {
        
    }
}
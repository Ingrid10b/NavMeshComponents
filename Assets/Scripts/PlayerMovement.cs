using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //parar camara
    public bool camaraOff = false;

    public Transform cam;
    float vMouse;
    float hMouse;
    float yReal = 0.0f;
    public float horizontalSpeed;
    public float verticalSpeed;

    public CharacterController controller;
    public float speed = 12f;
    float x;
    float z;
    Vector3 move;

    Vector3 velocity;
    public float gravity = -15f;
    bool isGrounded = false;

    public float jumpForce = 1f;
    float jumpValue;
    bool jumping;

    // Sonidos de caminata y salto
    public AudioClip walkSound;
    public AudioSource audioSource;
    public AudioClip jumpSound;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jumpValue = Mathf.Sqrt(jumpForce * -2 * gravity);

        // Obtener AudioSource del GameObject o agregar uno si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (camaraOff)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            LookMouse();

            if (isGrounded == true && velocity.y < 0)
            {
                velocity.y = gravity;
            }

            Movement();
            Jump();
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            velocity.y = jumpValue;
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        if (jumpSound != null && audioSource != null)
        {
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }
    void LookMouse()
    {
        hMouse = Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;
        vMouse = Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;

        yReal -= vMouse;
        yReal = Mathf.Clamp(yReal, -90f, 90f);
        transform.Rotate(0f, hMouse, 0f);
        cam.localRotation = Quaternion.Euler(yReal, 0f, 0f);
    }

    void Movement()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Reproducir sonido de caminata si el jugador se está moviendo
        if (x != 0 || z != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = walkSound;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}

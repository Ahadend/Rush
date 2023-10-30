using System.Collections;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed;
    public float maxFloatHeight = 10;
    public float minFloatHeight;
    public Camera freeLookCamera;

    private Rigidbody rb;
    private Animator anim;
    private float xRotation;
    private float currentHeight;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        currentHeight = transform.position.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        xRotation = freeLookCamera.transform.rotation.eulerAngles.x;

        if (Input.GetKey(KeyCode.W))
        {
            MoveCharacter();
        }
        else
        {
            DisableMovement();
        }
    }

    void MoveCharacter()
    {
        Vector3 cameraForward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0, 0), Space.Self);

        anim.SetBool("isFlying", true);
        Vector3 forward = freeLookCamera.transform.forward;
        rb.velocity = forward.normalized * moveSpeed;
        // rb.position = new Vector3(rb.position.x, currentHeight, rb.position.z);
    }

    void DisableMovement()
    {
        anim.SetBool("isFlying", false);
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 10;
    public float gravity = -4f;
    public float rotateSpeed;
    float speedSmoothTime = 0.1f;
    private CharacterController characterController => GetComponent<CharacterController>();
    [HideInInspector]
    public Vector3 moveDirection;

    [HideInInspector]
    public Animator anim => GetComponentInChildren<Animator>();

    [SerializeField] private FloatingJoystick joystick;
    void Awake()
    {

      
    }

    public bool mobile;
    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (mobile)
        {
            vInput = joystick.Vertical;
            hInput = joystick.Horizontal;
        }


        Vector3 v = vInput * Camera.main.transform.forward;
        Vector3 h = hInput * Camera.main.transform.right;

        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        float m = Mathf.Abs((v).magnitude) + Mathf.Abs((h).magnitude);
        float moveAmount = Mathf.Clamp01(m);

        Vector3 desiredMoveDirection = cameraForward * vInput + Camera.main.transform.right * hInput;
        moveDirection = new Vector3(desiredMoveDirection.x, moveDirection.y, desiredMoveDirection.z);


        moveDirection.y += gravity * Time.deltaTime;



        characterController.Move(moveDirection * speed * Time.deltaTime);
        anim.SetFloat("Speed", 1f * moveAmount, speedSmoothTime, Time.deltaTime);
        RotatePlayer(v, h);


       
    }

  


    void RotatePlayer(Vector3 v, Vector3 h)
    {
        if (moveDirection != Vector3.zero)
        {
            float m = Mathf.Abs((v).magnitude) + Mathf.Abs((h).magnitude);
            float moveAmount = Mathf.Clamp01(m);

            Vector3 targertDir = moveDirection;
            targertDir.y = 0;
            if (targertDir == Vector3.zero)
                targertDir = transform.forward;
            Quaternion tr = Quaternion.LookRotation(targertDir);
            Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * moveAmount * rotateSpeed);
            transform.rotation = targetRotation;
        }
    }

    public GameObject hitbox;
    public void EnableHitBox()
    {
        hitbox.active = !hitbox.active;
    }

}

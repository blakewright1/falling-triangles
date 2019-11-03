using System.Collections;           //not needed for mobile
using System.Collections.Generic;   //not needed for mobile
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;     //not needed for mobile

public class PlayerMove : MonoBehaviour//, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody2D rb;
    public event System.Action OnPlayerDeath;

    //horizontal movement-----------------------
    [SerializeField] //lets the inspector access a private variable
    private float movementSpeed;

    //Jumping-----------------------------------
    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField] 
    private float groundRadius = 0;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool isGrounded;

    private bool jump;

    private float horizontal;

    public Joystick joystick;

    public Text runningScore;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //horizontal movement

        //horizontal = Input.GetAxis("Horizontal");  //keyboard
        horizontal = joystick.Horizontal;            //mobile


        HandleJump();
        isGrounded = IsGrounded();
        HandleMovement(horizontal * Time.fixedDeltaTime * 65);
        runningScore.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }
    
    private void HandleMovement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 6);
        }
        jump = false;
    }

    private void HandleJump()
    {
        //keyboard
        /*
        if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }
        */
        //touchscreen
        
        if (Input.touchCount > 0)
        {
            for (int i=0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).position.x > Screen.width / 2)
                {
                    jump = true;
                }
            }
        } 
    }

    private bool IsGrounded()
    {
        if (rb.velocity.y <= 0)
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i =0; i<colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //makes sure it is not colliding with the player
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Triangle")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }


}

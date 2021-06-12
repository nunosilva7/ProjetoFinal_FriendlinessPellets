using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* 
    This code is based on:
        Bracekys (https://www.youtube.com/watch?v=_QajrabyTJc&t=1208s) FPS Controller
            
*/

public class FPSController : MonoBehaviour
{
    [SerializeField]
    float walkingSpeed = 10f;


    [SerializeField]
    float runningSpeed = 30f;

    [SerializeField]
    float gravity = -10f;

    [SerializeField]
    float jumpHeight = 2f;

    [SerializeField]
    Text ColectableText;

    [SerializeField]
    public float timer = 90;

    [SerializeField]
    Text timerText;

    public int count = 0;

    float speed;
    public CharacterController controller;



    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.4f;
    public bool isGrounded;
    public bool normalGravity = true;

    

     Vector3 velocity;

    
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        TimerCount();
        




        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log(isGrounded);


        Jump();
        isRunning();
        playerMovement();

    }

  


    // movimento do jogador
    void playerMovement()
    {
        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

        controller.Move(movement * speed * Time.deltaTime);


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    // controlar velocidade do jogador, se está a correr ou andar
    void isRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else
        {
            speed = walkingSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight *-2f * gravity);
            Debug.Log("Salto");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with" + other.name + " Tag=" + other.tag);

        if (other.gameObject.CompareTag("Colectable"))
        {
            other.gameObject.SetActive(false);
            CountColectable();
            timer += 20;


        }
        if (other.gameObject.CompareTag("ChangeGravity") && normalGravity==true)
        {
            normalGravity = false;


            gravity = 10;
            
            controller.transform.eulerAngles = new Vector3(
                controller.transform.eulerAngles.x +180,
                controller.transform.eulerAngles.y,
                controller.transform.eulerAngles.z 
                );
        }
        if (other.gameObject.CompareTag("ChangeBackGravity") && normalGravity == false)
        {
            normalGravity = true;


            gravity = -30;

            controller.transform.eulerAngles = new Vector3(
                controller.transform.eulerAngles.x - 180,
                controller.transform.eulerAngles.y,
                controller.transform.eulerAngles.z
                );
        }
    }

    private void CountColectable()
    {
        count++;
        ColectableText.text = "Colectaveis x" + count.ToString();

    }

    void TimerCount()
    {
        ShowTime(timer);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            InGameMenu.gameOver = true;

        }
    }

    // função para mostrar tempo na interface gráfica
    void ShowTime(float clock)
    {
        float minutes = Mathf.FloorToInt(clock / 60);
        float seconds = Mathf.FloorToInt(clock % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}


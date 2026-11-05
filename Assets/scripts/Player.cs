using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private InputAction moveInput;

    //  public float force;
    public float speed;
    public float jumpPower;

    public Rigidbody2D myBody;
    private Vector2 inputForce;

    public Transform groundChecker;
    public float checkSize;
    public LayerMask groundLayer;

    private bool onGround;
    public float jumpCount;
    public float maxJumpCount;


    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public Transform resetPoint;
    public Transform player;

    public float hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        hp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>(); 
    }
    private void FixedUpdate()
    {
        //myBody.AddForce(inputForce * force);
        myBody.linearVelocityX = inputForce.x * speed;
        if(inputForce.y>0&&jumpCount<maxJumpCount)
        {
            myBody.linearVelocityY = inputForce.y * jumpPower;
            jumpCount = jumpCount + 1;
          //  onGround = false;
        }
        else
        {
            onGround = Physics2D.OverlapCircle(groundChecker.position, checkSize, groundLayer);
            
        }

        if (onGround == true)
        {
            jumpCount = 0;
        }



        if (hp == 3)
        {
            hp1.SetActive(true);
            hp2.SetActive(true);
            hp3.SetActive(true);

        }

        if (hp == 2)
        {
            hp1.SetActive(false);
            hp2.SetActive(true);
            hp3.SetActive(true);

        }
        if (hp == 1)
        {
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(true);

        }
        if (hp == 0)
        {
            hp1.SetActive(false);
            hp2.SetActive(false);
            hp3.SetActive(false);
            SceneManager.LoadScene("Lose_Scene");
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hazard"))
        {
            player.localPosition = new Vector3(resetPoint.localPosition.x, resetPoint.localPosition.y, resetPoint.localPosition.z);
            hp = hp - 1;
        }
    }
}

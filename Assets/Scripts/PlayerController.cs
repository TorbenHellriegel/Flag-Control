using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 3;
    [SerializeField] private int jumpForce = 500;
    [SerializeField] private bool canChangeGravity;
    [SerializeField] private Vector2 direction;
    [SerializeField] private string gravityDirection;
    [SerializeField] private bool hasFlag;
    private Rigidbody2D playerRigidbody;
    public FlagController flag;
    public DoorController door;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Flag").GetComponent<FlagController>();
        door = GameObject.Find("Door").GetComponent<DoorController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        direction = Vector2.right;
        Physics2D.gravity = new Vector2(0,-9.8f);
        gravityDirection = "down";
        canChangeGravity = false;
        hasFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        
        if((Input.GetKeyDown(KeyCode.W)
            || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.Space))
            && gravityDirection != "up"
            && canChangeGravity)
        {
            RotatePlayer(180);
            ChangeGravity("up");
            Jump(jumpForce);
            canChangeGravity = false;
        }
        if((Input.GetKeyDown(KeyCode.S)
            || Input.GetKeyDown(KeyCode.DownArrow)
            || Input.GetKeyDown(KeyCode.Space))
            && gravityDirection != "down"
            && canChangeGravity)
        {
            RotatePlayer(180);
            ChangeGravity("down");
            Jump(-jumpForce);
            canChangeGravity = false;
        }
        // if(Input.GetKeyDown(KeyCode.A)){
        //     transform.rotation = new Quaternion(0,0,180,0);
        // }
        // if(Input.GetKeyDown(KeyCode.D)){
        //     transform.rotation = new Quaternion(0,0,180,0);
        // }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            RotatePlayer(0,180);
        }

        if (col.gameObject.tag == "Floor")
        {
            canChangeGravity = true;
        }

        if (col.gameObject.tag == "Spike")
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Flag")
        {
            hasFlag = true;
            flag.RemoveFlag();
            door.OpenDoor();
        }

        if (col.gameObject.name == "Door" && hasFlag)
        {
            gameManager.LevelClear();
        }
    }

    private void RotatePlayer(int x=0, int y=0)
    {
        transform.Rotate(new Vector3(x,y,0));
    }

    private void ChangeGravity(string direction)
    {
        if(gravityDirection=="down")
        {
            Physics2D.gravity = new Vector2(0,9.8f);
            gravityDirection = "up";
        }else if(gravityDirection=="up")
        {
            Physics2D.gravity = new Vector2(0,-9.8f);
            gravityDirection = "down";
        }
    }

    private void Jump(int force)
    {
        playerRigidbody.AddForce(new Vector2(0,force));
    }
}

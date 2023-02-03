using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int speed = 3;
    [SerializeField] private bool canChangeGravity;
    [SerializeField] private Vector2 direction;
    [SerializeField] private string gravityDirection;
    [SerializeField] private bool hasFlag;
    public FlagController flag;
    public DoorController door;

    // Start is called before the first frame update
    void Start()
    {
        flag = GameObject.Find("Flag").GetComponent<FlagController>();
        door = GameObject.Find("Door").GetComponent<DoorController>();

        direction = Vector2.right;
        gravityDirection = "down";
        canChangeGravity = true;
        hasFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        
        if(Input.GetKeyDown(KeyCode.W) && gravityDirection != "up" && canChangeGravity){
            RotatePlayer(180);
            ChangeGravity("up");
            canChangeGravity = false;
        }
        if(Input.GetKeyDown(KeyCode.S) && gravityDirection != "down" && canChangeGravity){
            RotatePlayer(180);
            ChangeGravity("down");
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
            Debug.Log("GAME OVER");//TODO
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Flag")
        {
            Debug.Log("Flag collected");
            hasFlag = true;
            flag.RemoveFlag();
            door.OpenDoor();
        }

        if (col.gameObject.name == "Door" && hasFlag)
        {
            Debug.Log("GAME WON");//TODO
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
}

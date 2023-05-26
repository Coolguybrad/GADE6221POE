using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject lLane;
    [SerializeField]
    private GameObject mLane;
    [SerializeField]
    private GameObject rLane;
    [SerializeField]
    private float jumpHeight;



    private int lane = 1; //0 = left lane 1 = middle 2 = right

    //Attempt 1 Lerping
    //public float fistMoveDist = 20f;
    //private Vector3 fistStartPos;
    //private Vector3 fistEndPos;
    //private float duration = 10f;
    //private float elapsedTime;

    //public float punchDist = 5f;
    //public float punchSpeed = 2f;
    //private Vector3 startPosition;
    //private Vector3 endPosition;
    //private float startTime;


    public bool gotPickup = false;
    public Pickup.pickupType currentPickup;




    void Start()
    {
        
        //player.transform.position.Set(player.transform.position.x, lLane.transform.position.y, player.transform.position.z); 
        //startPosition = this.gameObject.transform.GetChild(1).position;
        //endPosition = startPosition + Vector3.right * punchDist;
        //startTime = Time.time;
        //endPosition = rLane.transform.position;
    }



    // Update is called once per frame
    void Update()
    {

        if (gotPickup) //if the player has a pickup displays shield equipped (to be changed to accomodate other pickups)
        {
            if (currentPickup == Pickup.pickupType.Shield)
            {
                GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "Shield Equipped";
            }
            else if (currentPickup == Pickup.pickupType.Pointboost)
            {
                GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "2x boost";
            }
            else if (currentPickup == Pickup.pickupType.Moonboots)
            {
                GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "Moonboots Equipped";
            }

        }
        else //if player doesnt have a pickup text is set to nothing
        {
            GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "";
        }

        //playerY = player.transform.position.y;
        if (Input.GetKeyDown(KeyCode.UpArrow)) //when up arrow is pressed calls jump
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))//when down arrow is pressed calls down
        {
            Down();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))//when left arrow is pressed
        {
            lane--; //lane is decremented
            if (lane < 0) //if lane is lower that 0 set it back to 0
            {
                lane = 0;
            }
            //print(lane);

            checkLane(); //calls checkLane
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))//when right arrow is pressed
        {
            lane++; //lane is incremented
            if (lane > 2) //if lane is greater than 2 set it back to 2
            {
                lane = 2;
            }

            // print(lane);
            checkLane(); //calls checkLane
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    //Attempt 1 Lerping
        //    //fistStartPos = this.gameObject.transform.GetChild(1).position;
        //    //fistEndPos = new Vector3(this.gameObject.transform.GetChild(1).position.x + fistMoveDist, this.gameObject.transform.GetChild(1).position.y, this.gameObject.transform.GetChild(1).position.z);
        //    //elapsedTime += Time.deltaTime;
        //    //float percentageDone = elapsedTime/duration;

        //    //this.gameObject.transform.GetChild(1).transform.position = Vector3.Lerp(fistStartPos, fistEndPos, percentageDone);

        //    //float t = (Time.time - startTime) / punchDuration;
        //    startPosition = this.gameObject.transform.GetChild(1).position;
        //    float step = punchSpeed * Time.fixedDeltaTime;
        //    this.gameObject.transform.GetChild(1).transform.position = Vector3.MoveTowards(startPosition, endPosition, step);
        //    //this.gameObject.transform.GetChild(1).transform.position = Vector3.Lerp(startPosition, rLane.transform.position, t);


        //}



    }

    private void FixedUpdate()
    {


    }

    private void Down()
    {
        rb.AddForce(new Vector3(0, -jumpHeight * 2, 0), ForceMode.Impulse); //puts a downward force on the player to move them down quicker
    }

    private void Jump()
    {
        if (rb.transform.position.y < 0.47f)//prevents player from jumping while in the air
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);//puts an upward force on the player to make them jump
        }

    }

    private void checkLane()
    {
        if (lane == 0) //if lane is 0 the player is put in the same position as the left lane and an audio is played
        {

            player.transform.position = lLane.transform.position;
            //player.transform.position.Set(lLaneX, playerY, lLaneZ);
            GameManager.instance.playAudio();

        }
        else if (lane == 1) //if lane is 1 the player is put in the same position as the middle lane and an audio is played
        {
            //player.transform.position.Set(mLaneX, playerY, mLaneZ);
            player.transform.position = mLane.transform.position;
            GameManager.instance.playAudio();

        }
        else //if lane equals anything else the player is put in the same position as the right lane and an audio is played
        {
            //player.transform.position.Set(rLaneX, playerY, rLaneZ);
            player.transform.position = rLane.transform.position;
            GameManager.instance.playAudio();

        }
    }






}

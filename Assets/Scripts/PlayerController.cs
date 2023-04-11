using UnityEngine;

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

    [SerializeField]
    public bool gotPickup = false;


    
    void Start()
    {
        player.transform.position.Set(player.transform.position.x, lLane.transform.position.y, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gotPickup)
        {
            GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "Shield Equipped";
        }
        else
        {
            GameObject.Find("UI").GetComponent<UIInteraction>().txtPickup.text = "";
        }

        //playerY = player.transform.position.y;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane < 0)
            {
                lane = 0;
            }
            print(lane);

            checkLane();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane > 2)
            {
                lane = 2;
            }

            print(lane);
            checkLane();
        }

        
        
    }

    private void FixedUpdate()
    {


    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
    }

    private void checkLane() 
    { 
    if (lane == 0)
        {
            
            player.transform.position = lLane.transform.position;
            //player.transform.position.Set(lLaneX, playerY, lLaneZ);
        }
        else if (lane == 1)
        {
            //player.transform.position.Set(mLaneX, playerY, mLaneZ);
            player.transform.position = mLane.transform.position;
        }
        else
        {
            //player.transform.position.Set(rLaneX, playerY, rLaneZ);
            player.transform.position = rLane.transform.position;
        }
    }

    




}

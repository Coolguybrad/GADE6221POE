using System.Collections;
using UnityEngine;


public class CharacterCollision : MonoBehaviour
{

    public GameObject ui; //Calls the UI so that text an buttons can be edited on collisions
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    //Happens when player character enters a collider trigger
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Obstacle" && !this.gameObject.GetComponent<PlayerController>().gotPickup) //if the player collides with an obstacle and doesnt have a pickup (changed for future to specific pickup)
        {
            //GAME OVER
            this.gameObject.transform.position = new Vector3(0f, -10f, 0f); //moves player under the map out of sight
            this.gameObject.GetComponent<Rigidbody>().useGravity = false; //stops player unecessary falling when game should be over
            Time.timeScale = 0; //Sets the game's time scale to zero effectively pausing the game


        }
        else if (other.gameObject.tag == "Obstacle" && this.gameObject.GetComponent<PlayerController>().gotPickup) //if the player collides with an obstacle and has a pickup
        {
            if (this.gameObject.GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Shield)
            {
                Destroy(other.gameObject); //obstacle is destroyed
                this.gameObject.GetComponent<PlayerController>().gotPickup = false; //removes the player's pickup
            }
            else
            {
                this.gameObject.transform.position = new Vector3(0f, -10f, 0f); //moves player under the map out of sight
                this.gameObject.GetComponent<Rigidbody>().useGravity = false; //stops player unecessary falling when game should be over
                Time.timeScale = 0; //Sets the game's time scale to zero effectively pausing the game
            }
            

        }
        else if (other.gameObject.tag == "goblin" && this.gameObject.GetComponent<PlayerController>().gotPickup)
        {
            if (this.gameObject.GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Shield)
            {
                other.gameObject.SetActive(false); //obstacle is destroyed
                this.gameObject.GetComponent<PlayerController>().gotPickup = false; //removes the player's pickup
            }
            else
            {
                this.gameObject.transform.position = new Vector3(0f, -10f, 0f); //moves player under the map out of sight
                this.gameObject.GetComponent<Rigidbody>().useGravity = false; //stops player unecessary falling when game should be over
                Time.timeScale = 0; //Sets the game's time scale to zero effectively pausing the game
            }
        }
        if (other.gameObject.tag == "goblin" && !this.gameObject.GetComponent<PlayerController>().gotPickup) //if the player collides with an obstacle and doesnt have a pickup (changed for future to specific pickup)
        {
            //GAME OVER
            this.gameObject.transform.position = new Vector3(0f, -10f, 0f); //moves player under the map out of sight
            this.gameObject.GetComponent<Rigidbody>().useGravity = false; //stops player unecessary falling when game should be over
            Time.timeScale = 0; //Sets the game's time scale to zero effectively pausing the game

           


        }
        else if (other.gameObject.tag == "Pickup") //if the player collides into a pickup
        {

            this.gameObject.GetComponent<PlayerController>().gotPickup = true; //sets player's got pickup to true
            //if (this.gameObject.GetComponent<PlayerController>().currentPickup != Pickup.pickupType.Moonboots)
            //{
            //    this.gameObject.GetComponent<Rigidbody>().mass = 1f;
            //}
            if (other.gameObject.GetComponent<Pickup>().pU == Pickup.pickupType.Shield)
            {
                this.gameObject.GetComponent<Rigidbody>().mass = 1f;
                StartCoroutine(shield());
                
            }
            else if (other.gameObject.GetComponent<Pickup>().pU == Pickup.pickupType.Pointboost)
            {
                this.gameObject.GetComponent<Rigidbody>().mass = 1f;
                StartCoroutine(pointBoost());
            }
            else if (other.gameObject.GetComponent<Pickup>().pU == Pickup.pickupType.Moonboots)
            {
                StartCoroutine(moonBoots());
            }
            Destroy(other.gameObject); //destroys the pickup object

        }
        else if (other.gameObject.tag == "Boss")
        {
            if (this.gameObject.GetComponent<PlayerController>().lane == 1)
            {
                other.gameObject.GetComponentInParent<BossMechanics>().lFistHP--;
            }
            else if (this.gameObject.GetComponent<PlayerController>().gotPickup)
            {
                if (this.gameObject.GetComponent<PlayerController>().currentPickup == Pickup.pickupType.Shield)
                {
                    other.gameObject.GetComponentInParent<BossMechanics>().lFistHP -= 5;
                    this.gameObject.GetComponent<PlayerController>().gotPickup = false; //removes the player's pickup
                }
            }
            else
            {
                this.gameObject.transform.position = new Vector3(0f, -10f, 0f); //moves player under the map out of sight
                this.gameObject.GetComponent<Rigidbody>().useGravity = false; //stops player unecessary falling when game should be over
                Time.timeScale = 0; //Sets the game's time scale to zero effectively pausing the game
            }
        }
       
    }

    IEnumerator shield() 
    {
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Shield;
        yield return new WaitForSeconds(10);
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Nothing;
        this.gameObject.GetComponent<PlayerController>().gotPickup = false;
    }

    IEnumerator pointBoost()
    {
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Pointboost;
        yield return new WaitForSeconds(20);
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Nothing;
        this.gameObject.GetComponent<PlayerController>().gotPickup = false;
    }

    IEnumerator moonBoots()
    {
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Moonboots;
        this.gameObject.GetComponent<Rigidbody>().mass = 0.5f;
        yield return new WaitForSeconds(15);
        this.gameObject.GetComponent<Rigidbody>().mass = 1f;
        this.gameObject.GetComponent<PlayerController>().currentPickup = Pickup.pickupType.Nothing;
        this.gameObject.GetComponent<PlayerController>().gotPickup = false;
    }

    

}

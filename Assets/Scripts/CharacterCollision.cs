using UnityEngine;

public class CharacterCollision : MonoBehaviour
{

    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Obstacle" && !this.gameObject.GetComponent<PlayerController>().gotPickup)
        {
            
            this.gameObject.transform.position = new Vector3(0f, -10f, 0f);
            Time.timeScale = 0;


        }
        else if (other.gameObject.tag == "Obstacle" && this.gameObject.GetComponent<PlayerController>().gotPickup)
        {

            Destroy(other.gameObject);
            this.gameObject.GetComponent<PlayerController>().gotPickup = false;

        }
        else if (other.gameObject.tag == "Pickup")
        {

            this.gameObject.GetComponent<PlayerController>().gotPickup = true;
            Destroy(other.gameObject);

        }
    }


}

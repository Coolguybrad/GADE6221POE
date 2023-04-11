using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [SerializeField]
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

            Destroy(this.gameObject);
            Time.timeScale = 0;
            //ui.GetComponent<UIInteraction>().txtFinalScore.text = "Final Score: " + ui.GetComponent<UIInteraction>().player.GetComponent<Score>().score;

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

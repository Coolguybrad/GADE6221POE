using System.Collections;
using UnityEngine;

public class BossMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rFist;
    public int rFistHP = 10;
    public GameObject lFist;
    public int lFistHP = 10;
    public bool isDead = false;
    public float moveTo = 1;
    public bool isSpawned = false;

    public GameObject lLane;
    public GameObject rLane;
    public GameObject player;

    public float windUpSpeed = 1f;
    public float punchDelay = 3f;
    public float punchThrowSpeed = 8f;

    public bool isPunching = false;

    public bool enteredLane = false;

    // private float current;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned && !isDead)
        {
            if (player.transform.position == lLane.transform.position)
            {
                enteredLane = true;
            }
            if (enteredLane)
            {
                StartCoroutine(LeftFistPunch());
            }

        }

    }

    IEnumerator LeftFistPunch()
    {
        //int posCheck = 0;
        isPunching = true;
        bool forward = false;
        bool back = false;
        while (lFist.transform.position.z < 1 && lFist.transform.position.z! < 0 && !forward)
        {
            lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
            //posCheck++;
            forward = true;
            yield return new WaitForSeconds(punchDelay);
        }
        while (lFist.transform.position.z > lLane.transform.position.z && !back)
        {
            lFist.transform.Translate(Vector3.back * punchThrowSpeed * Time.fixedDeltaTime);
            yield return new WaitForSeconds(punchDelay);
        }
        while (lFist.transform.position.z < 0)
        {
            lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
            isPunching = false;
            enteredLane = false;
        }
        //if (lFist.transform.position.z < 1 && lFist.transform.position.z! < 0)
        //{

        //    lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
        //    //posCheck++;
        //    yield return new WaitForSeconds(punchDelay);


        //}
        //if (lFist.transform.position.z > lLane.transform.position.z)
        //{
        //    lFist.transform.Translate(Vector3.back * punchThrowSpeed * Time.fixedDeltaTime);
        //    yield return new WaitForSeconds(punchDelay);


        //}
        //if (lFist.transform.position.z < 0)
        //{
        //    lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
        //    isPunching = false;
        //}

        //current = Mathf.MoveTowards(current, 1, punchThrowSpeed * Time.deltaTime);
        //lFist.transform.position = Vector3.Lerp(Vector3.zero, new Vector3(0,0,1), current);
        //yield return new WaitForSeconds(punchDelay);



    }
}

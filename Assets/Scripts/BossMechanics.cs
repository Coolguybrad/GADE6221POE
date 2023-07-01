using System.Collections;
using UnityEngine;

public class BossMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bossMainBody;
    public GameObject lFist;
    public int lFistHP = 10;
    public bool isDead = false;
    public float moveTo = 1;
    public bool isSpawned = false;

    public GameObject[] obstacleArr;

    public GameObject lLane;
    public GameObject rLane;
    public GameObject player;
    public GameObject spawner;

    public float obstacleSpawnTime = 1;

    public float windUpSpeed = 3f;
    public float punchDelay = 3f;
    public float punchThrowSpeed = -8f;

    public bool isPunching = false;
    public bool enteredLeftLane = false;
    public bool forward = false;
    public bool back = false;

    private Vector3 startPosition;
    private Vector3 originalPosition;

    //to check if punch is working correctly



    // private float current;



    void Start()
    {
        GameManager.instance.onBossThresholdPassing += spawnBoss;
        //trying what ever I can to get coordinates to match up
        lFist.transform.SetParent(bossMainBody.transform, true);
        Invoke("rightFistSpawner", obstacleSpawnTime);
    }

    private void spawnBoss()
    {
        if (GameManager.instance.level > 0)
        {
            if (this.transform.position.y < 1)
            {

                this.transform.Translate(Vector3.up * 0.5f * Time.fixedDeltaTime);

                //boss.transform.position = new Vector3(transform.position.x, startY + Mathf.PingPong(Time.time * speed, distance), transform.position.z);

            }
            else
            {
                this.GetComponent<BossMechanics>().isSpawned = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isSpawned && !isDead)
        {
            if (player.transform.position == lLane.transform.position)
            {
                enteredLeftLane = true;
            }

            if (enteredLeftLane)
            {
                StartCoroutine(LeftFistPunch());
            }




        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lFistHP < 0)
        {
            lFist.SetActive(false);
            if (player.GetComponent<Score>().levelsBeat == 0)
            {
                GameManager.instance.level = 2;
            }
            else
            {
                GameManager.instance.level = Random.Range(1,2);
            }
            isDead = true;
            player.GetComponent<Score>().levelsBeat++;
            lFistHP = 5;
            lFist.SetActive(true);
        }

    }

    IEnumerator LeftFistPunch()
    {
        //int posCheck = 0;
        Vector3 fistOGPosition = lFist.transform.position;
        isPunching = true;
        startPosition = fistOGPosition;
        originalPosition = startPosition;
        Vector3 currentpos;





        //while (lFist.transform.position.z < 1 && lFist.transform.position.z! < 0 && !forward)
        //{
        //    lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
        //    //lFist.transform.position = Vector3.MoveTowards(lFist.transform.position, new Vector3(lFist.transform.position.x, lFist.transform.position.y, lFist.transform.position.z +1), windUpSpeed*Time.deltaTime);
        //    //posCheck++;
        //    forward = true;
        //    yield return new WaitForSeconds(punchDelay);
        //}
        //while (lFist.transform.position.z > lLane.transform.position.z && !back)
        //{
        //    lFist.transform.Translate(Vector3.back * punchThrowSpeed * Time.fixedDeltaTime);
        //    yield return new WaitForSeconds(punchDelay);
        //}
        //while (lFist.transform.position.z < 0)
        //{
        //    lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
        //    isPunching = false;
        //    enteredLane = false;
        //}

        //while (lFist.transform.position.z < 1 && lFist.transform.position.z! < 0 && !forward)
        //{
        //    lFist.transform.position += Vector3.back * windUpSpeed * Time.fixedDeltaTime;
        //    yield return new WaitForSeconds(punchDelay);
        //    if (lFist.transform.position.z >=1)
        //    {
        //        forward = true;
        //    }
        //}
        //while ( lFist.transform.position.z > lLane.transform.position.z && !back)
        //{
        //    lFist.transform.position += Vector3.forward * punchThrowSpeed * Time.fixedDeltaTime;
        //    yield return new WaitForSeconds(punchDelay);
        //    if (lFist.transform.position.z <= lLane.transform.position.z)
        //    {
        //        back = true;
        //    }
        //}
        //while (lFist.transform.position.z < 0)
        //{
        //    lFist.transform.position += Vector3.back * windUpSpeed * Time.fixedDeltaTime;

        //}









        //WORKING KINDA
        if (lFist.transform.position.z < 1 && !back)
        {

            lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
            //posCheck++;
            print("First");
            yield return new WaitForSeconds(punchDelay);



            if (lFist.transform.position.z > 1f)
            {
                back = true;
            }

        }

        if (lFist.transform.position.z > lLane.transform.position.z && !forward)
        {
            back = true;
            lFist.transform.Translate(Vector3.back * punchThrowSpeed * Time.fixedDeltaTime);
            print("Second");
            yield return new WaitForSeconds(punchDelay);

            if (lFist.transform.position.z <= -3.9)
            {
                forward = true;

            }

        }
        if (lFist.transform.position.z <= bossMainBody.transform.position.z)
        {

            forward = true;
            yield return new WaitForSeconds(punchDelay);
            lFist.transform.Translate(Vector3.back * windUpSpeed * Time.fixedDeltaTime);
            print("Third\n" + lFist.transform.position.z);
            if (lFist.transform.position.z >= bossMainBody.transform.position.z)
            {

                isPunching = false;
                enteredLeftLane = false;
                back = false;
                forward = false;

            }
        }





        //current = Mathf.MoveTowards(current, 1, punchThrowSpeed * Time.deltaTime);
        //lFist.transform.position = Vector3.Lerp(Vector3.zero, new Vector3(0, 0, 1), current);
        //yield return new WaitForSeconds(punchDelay);



    }






}

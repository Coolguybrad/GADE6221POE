using System.Collections;
using UnityEngine;


public class StiffGoblin : MonoBehaviour
{
    // Start is called before the first frame update
    public int randTime;
    public int rndSpawn;


    public bool isDead = false;
    public bool spawned = false;

    public GameObject stiffGoblinMain;
    public GameObject stiffGoblinLeft;
    public GameObject stiffGoblinMid;
    public GameObject stiffGoblinRight;
    public Vector3 ogPos;
    void Start()
    {
        ogPos = stiffGoblinMain.transform.position;
        GameManager.instance.onBossThresholdPassing += spawnGoblin;
        Invoke("attack", 3f);
    }

    private void spawnGoblin()
    {
        if (GameManager.instance.level == 2)
        {
            spawned = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!stiffGoblinLeft.activeInHierarchy)
        {
            if (!stiffGoblinMid.activeInHierarchy)
            {
                if (!stiffGoblinRight.activeInHierarchy)
                {
                    isDead = true;
                    spawned = false;
                    stiffGoblinLeft.transform.localPosition = new Vector3(stiffGoblinLeft.transform.localPosition.x, -4f, stiffGoblinLeft.transform.localPosition.z);
                    stiffGoblinMid.transform.localPosition = new Vector3(stiffGoblinMid.transform.localPosition.x, -4f, stiffGoblinMid.transform.localPosition.z);
                    stiffGoblinRight.transform.localPosition = new Vector3(stiffGoblinRight.transform.localPosition.x, -4f, stiffGoblinRight.transform.localPosition.z);
                    GameManager.instance.bossSpawnPoints = 0;
                }
            }
        }
    }


    private IEnumerator LanePick()
    {

        randTime = Random.Range(3, 8);
        rndSpawn = Random.Range(1, 4);
        yield return new WaitForSeconds(randTime);
        if (rndSpawn == 1)
        {
            stiffGoblinLeft.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            stiffGoblinLeft.transform.GetChild(0).gameObject.SetActive(false);
            stiffGoblinLeft.transform.localPosition = new Vector3(stiffGoblinLeft.transform.localPosition.x, 0, stiffGoblinLeft.transform.localPosition.z);
            yield return new WaitForSeconds(1);
            stiffGoblinLeft.transform.localPosition = new Vector3(stiffGoblinLeft.transform.localPosition.x, -4f, stiffGoblinLeft.transform.localPosition.z);
            //stiffGoblinLeft.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (rndSpawn == 2)
        {
            stiffGoblinMid.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            stiffGoblinMid.transform.GetChild(0).gameObject.SetActive(false);
            stiffGoblinMid.transform.localPosition = new Vector3(stiffGoblinMid.transform.localPosition.x, 0, stiffGoblinMid.transform.localPosition.z);
            yield return new WaitForSeconds(1);
            stiffGoblinMid.transform.localPosition = new Vector3(stiffGoblinMid.transform.localPosition.x, -4f, stiffGoblinMid.transform.localPosition.z);
            //stiffGoblinMid.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            stiffGoblinRight.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            stiffGoblinRight.transform.GetChild(0).gameObject.SetActive(false);
            stiffGoblinRight.transform.localPosition = new Vector3(stiffGoblinRight.transform.localPosition.x, 0, stiffGoblinRight.transform.localPosition.z);
            yield return new WaitForSeconds(1);
            stiffGoblinRight.transform.localPosition = new Vector3(stiffGoblinRight.transform.localPosition.x, -4f, stiffGoblinRight.transform.localPosition.z);
            //stiffGoblinRight.transform.GetChild(0).gameObject.SetActive(false);
        }
        stiffGoblinMid.transform.GetChild(0).gameObject.SetActive(false);
        stiffGoblinMid.transform.GetChild(0).gameObject.SetActive(false);
        stiffGoblinRight.transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(3);

    }

    private void attack()
    {
        if (!isDead && spawned)
        {
            StartCoroutine(LanePick());

        }
        Invoke("attack", 3f);
    }
}

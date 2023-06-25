using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.objectPassed();
    }
}

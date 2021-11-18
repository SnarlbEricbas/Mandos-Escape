using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class objective : MonoBehaviour
{
    public int score = 0;
    private void OnTriggerEnter(Collider collision) //character touch = next level
    {
        score += 1;
        Destroy(gameObject);
    }
}

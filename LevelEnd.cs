using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    int sore;
    objective obj;
    void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("objective").GetComponent<objective>();
    }
    private void OnTriggerEnter(Collider collision) //character touch = next level
    {
        sore = obj.score;
        if (sore >= 1)
        {
            loadnextlevel();
        }
    }

    public void loadnextlevel() //function to load next level
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex; //gets active level
        SceneManager.LoadScene(currentLevelIndex + 1); //proceeds to next level
    }
}

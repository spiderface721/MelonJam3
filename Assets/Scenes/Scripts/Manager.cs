using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField ]private int score;

    public int sceneToComeBackToIndex;
    
    void Awake() {
        
        GameObject[] e = GameObject.FindGameObjectsWithTag("manager");
        if(e.Length > 1) {
            Destroy(e[0]);
        }

        //Debug.Log(backFromNewScene);
        DontDestroyOnLoad(this.gameObject);
    }

    public void addToScore(int a) {
        score += a;
    }

    public int getScore() {
        return score;
    }

    public void setMinigamesFinished(int a) {
        PlayerPrefs.SetInt("minigames finished", a);
    }
}

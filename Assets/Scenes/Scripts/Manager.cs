using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private int score;
    
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
}

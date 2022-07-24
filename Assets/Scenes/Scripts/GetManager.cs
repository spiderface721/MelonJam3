using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetManager : MonoBehaviour
{
    private Manager manager;

    void Start() {
        manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
    }

    public Manager getManager() {
        return manager;
    }

    public void addToScore(int a) {
        manager.addToScore(a);
    }
}

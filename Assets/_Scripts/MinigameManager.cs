using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public int minigameIndex;

    [SerializeField] bool isLastMinigame;

    [SerializeField] int firstRunBlocks;
    [SerializeField] int normalBlocksAmount;

    public bool isHandlingPlacing;

    public int blocksAvailable;

    [SerializeField] int rounds;


    PigMovement pigMovement;
    // Start is called before the first frame update
    void Awake()
    {
        pigMovement = FindObjectOfType<PigMovement>();    
    }
    void Start()
    {
        StartCoroutine(HandleRounds(rounds));
    }

    IEnumerator HandleRounds(int rounds)
    {
        bool isFirstRun = true;
        for (int i = 0; i < rounds; i++)
        {
            isHandlingPlacing = true;
            if (!isFirstRun)
            {
                blocksAvailable += normalBlocksAmount;
            }
            else
            {
                blocksAvailable += firstRunBlocks;
                isFirstRun = false;
            }
            yield return new WaitUntil(() => isHandlingPlacing == false);
            pigMovement.DoBestMoves(1, true);
            yield return new WaitUntil(() => pigMovement.isMovingToTarget == false);
        }
    }

    public void HandleWin()
    {
        print(GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>().getScore());
        if (isLastMinigame)
        {
            if (GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>().getScore() >= 13)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            }
           
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void HandleLoss()
    {
        FindObjectOfType<Manager>().sceneToComeBackToIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(9);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

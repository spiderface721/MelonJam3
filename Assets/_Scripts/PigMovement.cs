using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    [SerializeField] float movementDistanceSides;

    [SerializeField] float movementDistanceTopBottomX;
    [SerializeField] float movementDistanceTopBottomY;

    int moveDir;    //0 - left, rest clockwised

    void RandomizeDir()
    {
        moveDir = Random.Range(1, 7);      
    }
    void MakeMove()
    {
        Debug.Log(moveDir);
        switch (moveDir)
        {
            case 1:
                transform.position += new Vector3(-movementDistanceSides, 0);
                break;
            case 2:
                transform.position += new Vector3(-movementDistanceTopBottomX, movementDistanceTopBottomY);
                break;
            case 3:
                transform.position += new Vector3(movementDistanceTopBottomX, movementDistanceTopBottomY);
                break;
            case 4:
                transform.position += new Vector3(movementDistanceSides, 0);
                break;
            case 5:
                transform.position += new Vector3(movementDistanceTopBottomX, -movementDistanceTopBottomY);
                break;
            case 6:
                transform.position += new Vector3(-movementDistanceTopBottomX, -movementDistanceTopBottomY);
                break;
            default:
                Debug.LogError("MOVE DIRECTION NUMBER NOT IDenTIFIED");
                break;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        MakeMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

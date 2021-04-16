using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPatten : MonoBehaviour
{
    public float speed;

    public bool ByPlace;
    public bool ByDirection;
    [Header("ByPlace")]
    public Transform destination;
    public Transform[] point;
    public int pointIndex;
    public float ChangeLocationTime;
    [SerializeField] float ChangeLocationCount;
    [SerializeField] bool moveFirstToLast;

    [Header("ByDirection")]
    public Vector2 direction;
    public float distant;
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (ByPlace)
        {

            transform.position = Vector2.MoveTowards(this.transform.position, point[pointIndex].transform.position, Time.deltaTime * speed);

            ChangeLocationCount += Time.deltaTime;
            if (ChangeLocationCount >= ChangeLocationTime)
            {
                ChangeLocationCount = 0;
                ChangeDestination();

            }

        }
    }

    void ChangeDestination()
    {
        print("Change");
        if (moveFirstToLast == true)
        {
            if (pointIndex == point.Length-1)
            {
                moveFirstToLast = false;
                return;
            }
                pointIndex += 1;
            
        } 

        if (moveFirstToLast == false)
        {
            if (pointIndex == 0)
            {
                moveFirstToLast = true;
                return;
            }
            pointIndex -= 1;
        }

    }
}

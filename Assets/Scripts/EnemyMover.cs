using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speedOfEnemyMovement = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPosition = 0f;

            transform.LookAt(endPosition);

            while(travelPosition< 1f)
            {
                travelPosition += Time.deltaTime *speedOfEnemyMovement;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPosition);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

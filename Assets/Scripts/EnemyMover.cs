using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
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
            transform.position = new Vector3
                (
                Mathf.RoundToInt(waypoint.transform.position.x), 
                0, 
                Mathf.RoundToInt(waypoint.transform.position.z)
                );
            yield return new WaitForSeconds(1f);
        }
    }
}

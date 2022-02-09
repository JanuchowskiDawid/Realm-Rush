using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speedOfEnemyMovement = 1f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (GameObject child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FinishPath()
    {
        enemy.PenaltyGold();
        gameObject.SetActive(false);

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
        FinishPath();
    }
}

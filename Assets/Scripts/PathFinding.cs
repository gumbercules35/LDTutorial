using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private WaveConfigSO waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;
    void Start()
    {   //Grab the list of Waypoints from the Scriptable Object
        waypoints = waveConfig.GetWaypoints();
        //Set initial transform to the first waypoint
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        //As long as we arent at the last waypoint
        if (waypointIndex < waypoints.Count){
            //Set the target position of the waypoint
            Vector2 targetPosition = waypoints[waypointIndex].position;
            //Set the movespeed of the enemy, independent of frame rate
            float deltaPosition = waveConfig.GetMoveSpeed() * Time.deltaTime;
            //Move the current transform towards the target transform
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, deltaPosition);
            //if when called we've reached that position, increment the waypointIndex to look for the next waypoint to follow
            if ((Vector2)(transform.position) == targetPosition){
                waypointIndex ++;
            }
        } else {
            //This triggers once there are no more waypoints and the enemy is disposed of
            Destroy(gameObject);
        }
    }
}

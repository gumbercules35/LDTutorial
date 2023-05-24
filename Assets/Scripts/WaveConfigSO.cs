using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
   [SerializeField] private Transform pathPrefab;
   [SerializeField] private float moveSpeed = 3f;
   [SerializeField] private List<GameObject> enemyPrefabs;

   public float GetMoveSpeed(){
    return moveSpeed;
   }

  public Transform GetPathStart(){
    return pathPrefab.GetChild(0);
  }

  public List<Transform> GetWaypoints() {
    //This is done to avoid mutation of the original waypoints
    List<Transform> waypoints = new List<Transform>();
    foreach (Transform transform in pathPrefab)
    {
        waypoints.Add(transform);
    }
    return waypoints;
  }

  public int GetEnemyCount(){
    return enemyPrefabs.Count;
  }

  public GameObject GetEnemyPrefab(int listIndex) {
    return enemyPrefabs[listIndex];
  }
}

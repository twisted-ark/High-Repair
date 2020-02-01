using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject box;

    private void OnEnable ()
    {
        //ControllableBox.Dropped += Climb;
        //ControllableBox.Landed += SpawnNew;
    }

    private void OnDisable ()
    {
        //ControllableBox.Dropped -= Climb;
        //ControllableBox.Landed -= SpawnNew;
    }

    public void Climb ()
    {
        transform.position += new Vector3 (0, 1, 0);

    }

    private void SpawnNew ()
    {
        Instantiate(box);
    }
}
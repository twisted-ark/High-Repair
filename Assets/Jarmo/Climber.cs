using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public void Climb ()
    {
        transform.position += new Vector3 (0, 1, 0);
    }
}

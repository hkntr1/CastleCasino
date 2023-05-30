using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatetor : MonoBehaviour
{
    [Header("Rotating Axis")]
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;
    [SerializeField] private int direction;
    public float speed;
    public bool rotate;
    [System.Obsolete]
    void Update()
    {
        if (StateManager.instance.eState == StateManager.GameState.Game&&rotate)
        {
            
            if (x)
                transform.Rotate(new Vector3(1 * direction, 0, 0), 90 * Time.deltaTime * speed, Space.Self);
            else if (y)
                transform.Rotate(new Vector3(0, 1 * direction, 0), 90 * Time.deltaTime * speed, Space.Self);
            else if (z)
                transform.Rotate(new Vector3(0, 0, 1 * direction), 90 * Time.deltaTime * speed, Space.Self);
    
        }

    }
}

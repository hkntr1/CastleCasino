using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTriggers : MonoBehaviour
{
  public float triggerSecond;
    public float triggerGoal;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("FailChecker"))
        {
            triggerSecond+=0.1f;
            {
                if (triggerSecond >= triggerGoal)
                {
                    if (StateManager.instance.eState != StateManager.GameState.Fail)
                    {
                        StateManager.instance.UpdateGameState(StateManager.GameState.Fail);
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("FailChecker"))
        {
            triggerSecond = 0;
        }
    }
}

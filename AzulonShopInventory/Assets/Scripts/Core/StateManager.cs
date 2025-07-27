using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static GameState CurrentState { get; private set; }

    public static void SetState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log("State changed to: " + CurrentState);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour {

	public State[] states;

	public State whichState (string name)
	{
		State s = Array.Find (states, state => state.name == name);
		State currentState;

		if (s == null) {
			Debug.LogWarning ("State: " + name + " not found!");
			currentState = s;
			return currentState;
		}
		else
		{
			currentState = s;
			return currentState;
		}
	}
}

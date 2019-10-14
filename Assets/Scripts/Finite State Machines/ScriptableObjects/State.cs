  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluggable/State")]
public class State : ScriptableObject 
{
	public string name;
	public Actions[] actions;

	public void UpdateState(PlayerController controller)
	{
		DoActions (controller);
	} 

	private void DoActions(PlayerController controller)
	{
		for (int i = 0; i < actions.Length; i++)
		{
			actions [i].Act (controller);
		}
	}
}

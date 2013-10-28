using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour 
{
	public NightVisionEffect nightVisionEffect;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.M))
		{
			nightVisionEffect.ToggleEnable();
		}
	}
}

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public NightVisionEffect nightVisionEffect;
	public OldFilmEffect oldFilmEffect;
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.N))
		{
			nightVisionEffect.ToggleEnable();
		}
		if(Input.GetKeyDown(KeyCode.M))
		{
			oldFilmEffect.ToggleEnable();
		}
	}
}

using UnityEngine;
using System.Collections;

public class NightVisionEffect : MonoBehaviour 
{
	#region shader parameters
	public bool isEnable = false;
	
	public Shader nightVisionShader;
	public float contrast = 1.0f;
	public float brightness = 0.2f;
	public Color nightVisionColor = Color.green;
	
	public Texture2D vignetteTexture;
	public Texture2D scanLineTexture;
	public float scanLineTileAmount = 4.0f;
	
	public Texture2D nightVisionNoise;
	public float noiseXSpeed = 100.0f;
	public float noiseYSpeed = 100.0f;
	
	public  float distortion = 0.2f;
	public float scale = 0.8f;
	
	private float randomValue = 0.0f;
	private Material curMaterial;
	#endregion
	
	void Start()
	{
		nightVisionShader = Shader.Find("Custom/NightVisionEffect");
		curMaterial = new Material(nightVisionShader);
	}
	
	public void ToggleEnable()
	{
		if(isEnable)
			isEnable = false;
		else
			isEnable = true;
	}
	
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		if(nightVisionShader != null && isEnable)
		{
				curMaterial.SetFloat("_Contrast", contrast);
				curMaterial.SetFloat("_Brightness", brightness);
				curMaterial.SetColor("_NightVisionColor", nightVisionColor);
				curMaterial.SetFloat("_RandomValue", randomValue);
				curMaterial.SetFloat("_Distortion", distortion);
				curMaterial.SetFloat("_Scale", scale);
			
			if(vignetteTexture)
			{
				curMaterial.SetTexture("_VignetteTex", vignetteTexture);
			}
			
			if(scanLineTexture)
			{
				curMaterial.SetTexture("_ScanLineTex", scanLineTexture);
				curMaterial.SetFloat("_ScanLineTileAmount", scanLineTileAmount);
			}
			
			if(nightVisionNoise)
			{
				curMaterial.SetTexture("_NoiseTex", nightVisionNoise);
				curMaterial.SetFloat("_NoiseXSpeed", noiseXSpeed);
				curMaterial.SetFloat("_NoiseYSpeed", noiseYSpeed);
			}
			
			Graphics.Blit(src, dst, curMaterial);
		}
		else
		{
			Graphics.Blit(src, dst);
		}
	}
	
	void Update()
	{
		contrast = Mathf.Clamp(contrast, 0.0f, 4.0f);
		brightness = Mathf.Clamp(brightness, 0.0f, 2.0f);
		randomValue = Random.Range(-1.0f, 1.0f);
		distortion = Mathf.Clamp(distortion, -1.0f, 1.0f);
		scale = Mathf.Clamp(scale, 0.0f, 3.0f);
	}
}

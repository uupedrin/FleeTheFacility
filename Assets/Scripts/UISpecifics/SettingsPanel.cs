using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : Panel
{
	[SerializeField] Slider masterSlider, musicSlider, sfxSlider;
	float masterVol, musicVol, sfxVol;
	void Start()
	{
		Setup();
	}
	
	public void Setup()
	{
		try
		{
			masterVol = PlayerPrefsHandler.instance.LoadValueF("MasterVol");
			musicVol = PlayerPrefsHandler.instance.LoadValueF("MusicVol");
			sfxVol = PlayerPrefsHandler.instance.LoadValueF("SFXVol");
		}
		catch (KeyNotFoundException)
		{
			masterVol = 0;
			PlayerPrefsHandler.instance.SaveValue("MasterVol", masterVol);
			musicVol = 0;
			PlayerPrefsHandler.instance.SaveValue("MusicVol", musicVol);
			sfxVol = 0;
			PlayerPrefsHandler.instance.SaveValue("SFXVol", sfxVol);
		}
		OnMasterValueChange(masterVol);
		OnMusicValueChange(musicVol);
		OnSFXValueChange(sfxVol);
				
		masterSlider.value = masterVol;
		musicSlider.value = musicVol;
		sfxSlider.value = sfxVol;
	}
	public void SliderChanged(int id)
	{
		switch (id)
		{
			case 0:
				OnMasterValueChange(masterSlider.value);
			break;
			case 1:
				OnMusicValueChange(musicSlider.value);
			break;
			case 2:
				OnSFXValueChange(sfxSlider.value);
			break;
		}
	}
	private void OnMasterValueChange(float value)
	{
		AudioManager.instance.mixer.SetFloat("MasterMix", value);
		PlayerPrefsHandler.instance.SaveValue("MasterVol", value);
	}
	private void OnMusicValueChange(float value)
	{
		AudioManager.instance.mixer.SetFloat("MusicMix", value);
		PlayerPrefsHandler.instance.SaveValue("MusicVol", value);
	}
	private void OnSFXValueChange(float value)
	{
		AudioManager.instance.mixer.SetFloat("SFXMix", value);
		PlayerPrefsHandler.instance.SaveValue("SFXVol", value);
	}
}

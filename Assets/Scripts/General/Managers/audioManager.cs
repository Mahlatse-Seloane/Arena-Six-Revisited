using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class audioManager : MonoBehaviour 
{
	public static audioManager instance;
	public Sound[] sounds;

	// Use this for initialization
	void Awake () 
	{
		foreach (Sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	void Start ()
	{
		Play ("ThemeMusic");
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Play (string name)
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Play ();
		Debug.Log("PLAY: " + name);
	}

	public void StopPlaying (string name)
	{
		Sound s = Array.Find (sounds, sound => sound.name == name);

		if (s == null)
		{
			Debug.LogWarning ("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop ();
	}

	public void soundsPaused(string name)
	{
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

	public void soundsUnpaused(string name)
	{
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.UnPause();
    }
}

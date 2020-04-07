using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public List<Sound> sounds = new List<Sound>();

    private void Awake() {
		if(instance == null)
			instance = this;

		else if(instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

        foreach (Sound item in sounds)
        {
            item.source = gameObject.AddComponent<AudioSource>();
            item.source.clip = item.clip;

            item.source.volume = item.volume;
            item.source.playOnAwake = item.awakePlay;
            item.source.loop = item.loop;
        }
	}
    
    private void Start() {
        Play("bgm");
    }

    public void Play (string _name) {
        sounds.Find(x => x.name == _name).source.Play();
        //Debug.Log(sounds.Find(x => x.name == _name));
    }

    public void Stop(string _name)
    {
        sounds.Find(x => x.name == _name).source.Stop();
        //Debug.Log(sounds.Find(x => x.name == _name));
    }

    public void Mute (string _name) {
        sounds.Find(x => x.name == _name).source.mute = true;
    }

    public void Unmute (string _name) {
        sounds.Find(x => x.name == _name).source.mute = false;
    }

}

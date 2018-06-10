using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
    public static AudioController instance;
    private static uint counter = 0;
    private Dictionary<string, AudioSource> list = new Dictionary<string, AudioSource>();
    public static AudioController Load() {
        if (instance == null) {
            GameObject g = new GameObject("AudioControl");
            instance = g.AddComponent<AudioController>();
            DontDestroyOnLoad(g);
        } return instance;
    }
    public static AudioController getInstance() {
        return Load();
    }
    public AudioSource registerSound(string path) {
       return registerSound(path, "" + counter++);
       
    }
    public AudioSource registerSound(string path, string name) {
        GameObject g = new GameObject();
        AudioSource audio = g.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load(path) as AudioClip;
        audio.clip = clip;
        list.Add(name, audio);
        print("success adding audio " + name);
        return list[name];
    }
    public void removeSound(AudioSource audio) 
    {
        foreach (string key in list.Keys) {
            if (list[key].Equals(audio)) {
                removeSound(key);
                break;
            }
        }
    }

    public void removeSound(GameObject audio) {
        if (audio.GetComponent<AudioSource>() != null) {
            removeSound(audio.GetComponent<AudioSource>());
        }
    }
    public void removeSound(string name) {
        AudioSource audio = list[name];
        audio.Stop();
        if (audio.gameObject != null)
        {
            Destroy(audio.gameObject);
        }
    }
    public AudioSource getAudioSource(string name) {
        return list[name];
    }
}

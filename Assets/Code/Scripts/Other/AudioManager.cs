﻿using UnityEngine.Audio;
using System;
using UnityEngine;

namespace SE
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioManager Instance;
        // Start is called before the first frame update
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogError("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
        }
    }
}
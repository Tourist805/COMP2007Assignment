using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLogic : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    
    public void StartEggCrackingMusic()
    {
        audioMixer.SetFloat("EggVolume", -20f);
    }
}

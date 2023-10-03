using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "newAudioData", menuName = "Data/Audio Data/Clip Data")]
public class AudioData : ScriptableObject
{
    public float Volume => volume; 
    public AudioClip[] Clips => clips;

    [SerializeField][Tooltip("hallo")][Range(0f, 1f)] private float volume = 1.0f;
    [SerializeField] private AudioClip[] clips;
}

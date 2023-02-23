using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] public AudioSource MainSound;
    [SerializeField] public AudioSource TileSound;
    private void Awake() {
        if(Instance == null)
            Instance = this;
    }


}

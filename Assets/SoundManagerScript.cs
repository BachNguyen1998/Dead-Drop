using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip runConcrete, runWood, jump, land, crushed, scream;
    static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
        runConcrete = Resources.Load<AudioClip>("FootstepConcrete1");
        runWood = Resources.Load<AudioClip>("FootstepWood1");
        jump = Resources.Load<AudioClip>("PlayerJump");
        land = Resources.Load<AudioClip>("PlayerLand");
        crushed = Resources.Load<AudioClip>("PlayerGib");
        scream = Resources.Load<AudioClip>("Wilhelm");

        audioSrc = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "runConcrete":
                audioSrc.PlayOneShot(runConcrete);
                break;
            case "runWood":
                audioSrc.PlayOneShot(runWood);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "land":
                audioSrc.PlayOneShot(land);
                break;
            case "crushed":
                audioSrc.PlayOneShot(crushed);
                break;
            case "scream":
                audioSrc.PlayOneShot(scream);
                break;
        }
    }
}

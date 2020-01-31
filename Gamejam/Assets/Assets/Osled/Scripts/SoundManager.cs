using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip jump, walk, grab, drop,throws;
    static AudioSource audioSrc;
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        walk = Resources.Load<AudioClip>("walk");
        throws = Resources.Load<AudioClip>("throws");
        grab = Resources.Load<AudioClip>("grab");
        drop = Resources.Load<AudioClip>("drop");
        audioSrc = GetComponent < AudioSource >();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Playsound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "walk":
                audioSrc.PlayOneShot(walk);
                break;
            case "grab":
                audioSrc.PlayOneShot(jump);
                break;
            case "drop":
                audioSrc.PlayOneShot(jump);
                break;
            case "throws":
                audioSrc.PlayOneShot(throws);
                break;
        }
    }
}

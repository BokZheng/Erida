using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWarpMode : MonoBehaviour
{
    public AnimationClip[] animationClips;

    void Start()
    {
        foreach (var clip in animationClips)
        {
            clip.wrapMode = WrapMode.ClampForever;
        }
    }
}

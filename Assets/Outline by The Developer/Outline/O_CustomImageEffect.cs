using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class O_CustomImageEffect : MonoBehaviour
{
    public Material imageEffect;
    
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (imageEffect != null)
            Graphics.Blit(src, dest, imageEffect);
        else
            dest = src;
    }
}

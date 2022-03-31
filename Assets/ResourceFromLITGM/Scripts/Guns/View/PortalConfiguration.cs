using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Portal configuration")]
public class PortalConfiguration : ScriptableObject
{
    [SerializeField]private float radius;
    [SerializeField]private RenderTexture renderTexturePortal1, renderTexturePortal2;
    [SerializeField]private Material materialPortal1, materialPortal2;
    [SerializeField]private List<string> tagsSuccess;
    public float Radius => radius;
    public RenderTexture RenderTexturePortal1 => renderTexturePortal1;
    public RenderTexture RenderTexturePortal2 => renderTexturePortal2;
    public Material MaterialPortal1 => materialPortal1;
    public Material MaterialPortal2 => materialPortal2;
    public List<string> TagsSuccess => tagsSuccess;
    
}
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] private PortalBullet _camera;
    [SerializeField] private Camera cameraSelf;
    [SerializeField] private RawImage _image;
    private PortalBullet _otherCamera;
    private bool canTeleport = true;

    private Camera GetCamera()
    {
        return cameraSelf;
    }

    private void Update()
    {
        if(_camera != null && _otherCamera != null)
        {
            Quaternion direction = Quaternion.Inverse(transform.rotation) * Camera.main.transform.rotation;
            _otherCamera.GetCamera().transform.localEulerAngles = new Vector3(direction.eulerAngles.x, direction.eulerAngles.y+180, direction.eulerAngles.z);
            Vector3 distancia = transform.InverseTransformPoint(Camera.main.transform.position);
            _otherCamera.GetCamera().transform.localPosition = - new Vector3(distancia.x, -distancia.y, distancia.z);
        }
    }

    public void Configure(PortalBullet otherPortal, RenderTexture withShowImage,RenderTexture withCaptureCamera)
    {
        _otherCamera = otherPortal;
        _image.texture = withShowImage;
        cameraSelf.targetTexture = withCaptureCamera;
    }

    public void Configure()
    {
        var objectTocoll = Physics.SphereCastAll(transform.position, 0.5f, Vector3.back);
        if (objectTocoll.Length > 0)
        {
            foreach (var hit in objectTocoll)
            {
                if (hit.collider.CompareTag("Wall"))
                {
                    //Debug.Log($"name {hit.collider.name}");
                    break;
                }
            }
        }
    }
}

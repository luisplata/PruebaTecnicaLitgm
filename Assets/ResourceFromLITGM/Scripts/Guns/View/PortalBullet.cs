using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] private PortalBullet _camera;
    [SerializeField] private Camera cameraSelf;
    [SerializeField] private RawImage _image;
    private GameObject _player;
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
            Quaternion direction = Quaternion.Inverse(_otherCamera.transform.rotation) * Camera.main.transform.rotation;
            _otherCamera.GetCamera().transform.localEulerAngles = new Vector3(direction.x, direction.y, direction.z);
            Vector3 distancia = transform.InverseTransformPoint(Camera.main.transform.position);
            _otherCamera.GetCamera().transform.localPosition = - new Vector3(distancia.x, -distancia.y, distancia.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Collider>().enabled = false;
            _otherCamera.DisableCollider();
            _player.transform.position = _otherCamera.transform.position;
            var eulerAngles = _otherCamera.GetCamera().transform.eulerAngles;
            _player.transform.eulerAngles = Vector3.up * 
                                            (eulerAngles.y -
                                                (GetCamera().transform.eulerAngles.y - _player.transform.eulerAngles.y) + 180);
            _player.transform.localEulerAngles = Vector3.right * (eulerAngles.x + _player.transform.localEulerAngles.x);
            other.GetComponent<Collider>().enabled = true;
        }
    }

    private void DisableCollider()
    {
        StartCoroutine(DisableColliderCoroutine());
    }

    private IEnumerator DisableColliderCoroutine()
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Collider>().enabled = true;
    }

    public void Configure(PortalBullet otherPortal, GameObject player, RenderTexture withShowImage,RenderTexture withCaptureCamera)
    {
        _otherCamera = otherPortal;
        _player = player;
        _image.texture = withShowImage;
        cameraSelf.targetTexture = withCaptureCamera;
    }
}

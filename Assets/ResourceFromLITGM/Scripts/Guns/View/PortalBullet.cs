using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] private PortalBullet _camera;
    [SerializeField] private Camera cameraSelf;
    [SerializeField] private RawImage _image;
    [SerializeField] private Collider collider;
    private GameObject _player;
    private PortalBullet _otherCamera;
    private bool canTeleport = true;
    private Collider wallToStay;

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

    private void OnTriggerStay(Collider other)
    {
        return;//la implementacion de esto es muy fea; solo se podra ver atravez del portal
        if (other.CompareTag("Player"))
        {
            Vector3 playerFromPortal = transform.InverseTransformPoint(_player.transform.position);
            //Debug.Log($"distance {Vector3.Distance(transform.position, _player.transform.position)}");
            if(playerFromPortal.z <= 0.52f && wallToStay != null)
            {
                Debug.Log("disanble");
                wallToStay.enabled = false;
            }
            else if(wallToStay != null)
            {
                wallToStay.enabled = true;
            }
            if (playerFromPortal.z <= 0.01f && canTeleport)
            {
                _otherCamera.DisableCollider();
                DisableCollider();
                //_player.transform.position = _otherCamera.transform.position + new Vector3(-playerFromPortal.x, +playerFromPortal.y, -playerFromPortal.z);
                Quaternion ttt = Quaternion.Inverse(transform.rotation) * _player.transform.rotation;
                _player.transform.eulerAngles = Vector3.up * (_otherCamera.transform.eulerAngles.y -
                    (transform.eulerAngles.y - Camera.main.transform.eulerAngles.y) + 180);
                _player.transform.localEulerAngles= Vector3.up * (_otherCamera.GetCamera().transform.eulerAngles.x + Camera.main.transform.localEulerAngles.x);

                _player.transform.Translate(_otherCamera.transform.position);// + new Vector3(-playerFromPortal.x, +playerFromPortal.y, -playerFromPortal.z));
            }
        }
    }

    private void DisableCollider()
    {
        StartCoroutine(DisableColliderCoroutine());
    }

    private IEnumerator DisableColliderCoroutine()
    {
        canTeleport = false;
        //collider.enabled = false;
        yield return new WaitForSeconds(1f);
        //collider.enabled = true;
        canTeleport = true;
    }

    public void Configure(PortalBullet otherPortal, GameObject player, RenderTexture withShowImage,RenderTexture withCaptureCamera)
    {
        _otherCamera = otherPortal;
        _player = player;
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
                    Debug.Log($"name {hit.collider.name}");
                    wallToStay = hit.collider;
                    break;
                }
            }
        }
    }
}

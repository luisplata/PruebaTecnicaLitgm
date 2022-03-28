using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBullet : MonoBehaviour
{
    [SerializeField] private PortalBullet _camera;
    [SerializeField] private PortalBullet _otherCamera;
    [SerializeField] private Camera cameraSelf;
    [SerializeField] private RenderTexture renderTextureFromOtherCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject _pointToSpawn;

    private Camera GetCamera()
    {
        return cameraSelf;
    }

    private void Update()
    {
        if(_camera != null && _otherCamera != null)
        {
            //Debug.Log("Updating");
            Quaternion direction = Quaternion.Inverse(_otherCamera.transform.rotation) * Camera.main.transform.rotation;
            _otherCamera.GetCamera().transform.localEulerAngles = new Vector3(direction.x, direction.y, direction.z);
            Vector3 distancia = transform.InverseTransformPoint(Camera.main.transform.position);
            _otherCamera.GetCamera().transform.localPosition = - new Vector3(distancia.x, -distancia.y, distancia.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerFromPortal = transform.InverseTransformPoint(player.transform.position);
            //Debug.Log($"distance: {playerFromPortal.z}");
            if (playerFromPortal.z <= .5f)
            {
                Debug.Log($"teleporting {gameObject.name}");
                var transform1 = _otherCamera.transform;
                player.transform.position = transform1.position + new Vector3(-playerFromPortal.x, +playerFromPortal.y, -playerFromPortal.z);

                var eulerAngles = transform1.eulerAngles;
                player.transform.eulerAngles = Vector3.up * 
                                               (eulerAngles.y -
                                                   (transform.eulerAngles.y - player.transform.eulerAngles.y) + 180);
                player.transform.localEulerAngles = Vector3.right * (eulerAngles.x + player.transform.localEulerAngles.x);
            }
        }
    }

    private Vector3 GetPointToSpawn()
    {
        return _pointToSpawn.transform.position;
    }
}

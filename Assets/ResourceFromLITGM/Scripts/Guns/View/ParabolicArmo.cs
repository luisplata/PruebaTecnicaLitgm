using System;
using System.Collections.Generic;
using Mathematics;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class ParabolicArmo : MonoBehaviour, ISimulatorView
    {
        private Calculating calc;
        private float time;
        private GameObject target;
        public void Configure(float angle, ParabolicConfiguration parabolicConfiguration, Vector3 targetPoint)
        {
            target = new GameObject
            {
                transform =
                {
                    position = targetPoint
                }
            };
            //Debug.Log($"position {transform.position} target {targetPoint}");
            calc = new Calculating(parabolicConfiguration.ForceOfLaunch, parabolicConfiguration.HeightOfLaunch, angle, this);
            time = 0;
        }

        private void Update()
        {
            try
            {
                if (calc == null) return;
                time += Time.deltaTime;
                var position = calc.Calc3D(transform.position, target.transform.position, time);
                var positionWithTime = new Vector3( position.x, position.y, position.z);
                //Debug.Log($"update {position}");
                transform.position = positionWithTime;
                if((target.transform.position - transform.position).magnitude < .1f)
                {
                    Destroy(target);
                    Destroy(gameObject);
                }
            }
            catch (Exception e)
            {
                //Debug.Log(e);
            }
        }

        public float PositionInX()
        {
            return transform.position.x;
        }

        public float PositionInY()
        {
            return transform.position.y;
        }

        public string GetAngle()
        {
            return "0";
        }

        public string GetPower()
        {
            return "0";
        }

        public string GetEstimate()
        {
            return "0";
        }

        public void CreatePoint(Vector2 position)
        {
            throw new System.NotImplementedException();
        }

        public void PlayerWin()
        {
            throw new System.NotImplementedException();
        }

        public void PlayerFail()
        {
            throw new System.NotImplementedException();
        }

        public void ResetList()
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePoints(List<Vector2> resultList)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 PositionOrigin()
        {
            return transform.position;
        }

        public Vector3 PositionEnd()
        {
            return target.transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
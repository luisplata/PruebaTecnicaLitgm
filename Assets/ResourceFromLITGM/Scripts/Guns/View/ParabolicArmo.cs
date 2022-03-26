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
        public void Configure(float angle, ParabolicConfiguration parabolicConfiguration)
        {
            calc = new Calculating(parabolicConfiguration.ForceOfLaunch, angle, this);
            time = 0;
        }

        private void Update()
        {
            try
            {
                if (calc == null) return;
                time += Time.deltaTime;
                var position = calc.Calc(time);
                var positionWithTime = new Vector3( transform.position.x, position.y, position.x);
                //var alterPosition = transform.position + positionWithTime;
                transform.position = positionWithTime;
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
    }
}
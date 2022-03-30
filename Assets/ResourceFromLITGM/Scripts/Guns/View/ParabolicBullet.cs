using System;
using System.Collections.Generic;
using Mathematics;
using UnityEngine;

namespace ResourceFromLITGM.Scripts.Guns.View
{
    class ParabolicBullet : RecyclableObject, ISimulatorView
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
            calc = new Calculating(parabolicConfiguration.ForceOfLaunch, parabolicConfiguration.HeightOfLaunch, this);
            time = 0;
        }

        private void Update()
        {
            try
            {
                if (calc == null) return;
                time += Time.deltaTime;
                var position = calc.CalcParabolic3D(transform.position, target.transform.position, time);
                transform.position = position;
                if((target.transform.position - transform.position).magnitude < .1f)
                {
                    Destroy(target);
                    Recycle();
                }
            }
            catch (Exception e)
            {
                Destroy(target);
                Recycle();
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

        internal override void Init()
        {
            //Invoke(nameof(Recycle), 10f);
        }

        internal override void Release()
        {
            //throw new NotImplementedException();
        }
    }
}
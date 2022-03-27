﻿using System;
using System.Collections.Generic;
using Codice.CM.Client.Differences;
using UnityEngine;

namespace Mathematics
{
    public class Calculating
    {
        private float _power;
        private float _angle;
        private readonly ISimulatorView _view;
        private readonly float _positionX;
        private readonly float _positionY;
        private float _height;

        //Constuctor for the simulator in 2D
        public Calculating(float potencia, float height, float angle, ISimulatorView view)
        {
            _power = potencia;
            _angle = angle;
            _view = view;
            _height = height;
            _positionX = _view.PositionInX();
            _positionY = _view.PositionInY();
            
            if (_power < 0)
            {
                throw new CalculatinException("La Velocidad inicial debe ser positiva");
            }

            if (_angle < 0 || _angle > 90)
            {
                throw new CalculatinException("El angulo debe ser entre 0 y 90 grados");
            }
        }
        
        //Constuctor for the simulator in 3D
        public Calculating(float potencia, float height, ISimulatorView view)
        {
            _power = potencia;
            _view = view;
            _height = height;
        }

        public Vector2 Calc(float time)
        {
            var v0 = _power;
            var v0X = (float)Math.Cos(Mathf.Deg2Rad * _angle) * v0;
            var v0Y = (float)Math.Sin(Mathf.Deg2Rad * _angle) * v0;
            var x0 = _positionX;
            var y0 = _positionY;

            //calculating
            var x1 = v0X * time + x0;
            var y1 = v0Y * time - 0.5f * Word.Gravity * Mathf.Pow(time, 2) + y0;

            if (y1 < _view.PositionInY())
            {
                throw new CalcLimitException("Hasta aqui llega la simulación");
            }
            
            //Result
            return new Vector2(x1, y1);
        }
        
        public Vector3 Calc3D(Vector3 start, Vector3 end, float time)
        {
            Func<float, float> f = x => (_power * -1) * _height * x * x + _power * _height * x;

            var mid = Vector3.Lerp(start, end, time);

            return new Vector3(mid.x, f(time) + Mathf.Lerp(start.y, end.y, time), mid.z);
        }

        public List<Vector2> Prediction()
        {
            return Prediction(_power, _angle);
        }
        public List<Vector2> Prediction(float power, float angle)
        {
            var list = new List<Vector2>();
            _power = power;
            _angle = angle;
            var increment = Word.TimePrediction/1000;
            for (float i = 0; i < Word.TimePrediction; i+= increment)
            {
                try
                {
                    list.Add(Calc(i));
                }
                catch (CalcLimitException)
                {
                    break;
                }
            }

            return list;
        } 
    }
}
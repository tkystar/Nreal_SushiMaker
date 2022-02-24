using System;

namespace NRKernal
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TimingVisualize : MonoBehaviour
    {
        public GameObject hitPosObj;
        public GameObject spawnPosObj;
        private Vector3 _hitPos;
        private Vector3 _spawnPos;
        private double _nxtRng;
        [SerializeField] private Metronome _metrnome;
        public GameObject noot;
        private Rigidbody _nootRB;
        private double _distance;
        private double _time;
        public double _speed;
        private double _divided_num;
        private double _divided_dis;
        private GameObject _noot;
        public double _distance_per_sec;

        [SerializeField] private MoveSushi _moveSushi;
        // Start is called before the first frame update
        void Awake()
        {
            
            _hitPos = hitPosObj.transform.position;
            _spawnPos = spawnPosObj.transform.position;
            _time = 60d / _metrnome.bpm;
            Debug.Log("TIME : "+_time);
            _divided_num = _time / 0.02;
            Debug.Log("_divided_num"+_divided_num);
            //_distance = speed * _time;
            _distance = (_hitPos - _spawnPos).magnitude;
            Debug.Log("Distance"+_distance);
            _divided_dis = _distance / _divided_num;
            //_speed = _distance / _time;
            _distance_per_sec = _distance / _time;
            Debug.Log("_divided_dis : "+_divided_dis);
            //_spawnPos = _hitPos;
            //_spawnPos.x = _hitPos.x - (float)_distance;
            
        }

        // Update is called once per frame
        void Update()
        {
            _nxtRng = _metrnome.nxtRng;
        }

        public void CreateNoots()
        {
            _noot = Instantiate(noot,_spawnPos,Quaternion.identity);
            _moveSushi = _noot.AddComponent<MoveSushi>();
            _moveSushi.GetDeltaDistance(_divided_dis);

        }

        private void FixedUpdate()
        {
            
        }
    }
}
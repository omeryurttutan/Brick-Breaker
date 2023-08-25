/*
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

    public class BrickMaker : MonoBehaviour
    {
        public Brick brick;
        public GameObject brickGroup; 
        public int rows = 0;
        public int colums = 0;

        [ContextMenu("Test")]
        private void BrcMaker()
        {
            var holder = Instantiate(brickGroup, transform.position, Quaternion.identity);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    //var br=Instantiate(brick, transform.position, Quaternion.identity);
                    var br = (Brick)PrefabUtility.InstantiatePrefab(brick);
                    br.transform.Translate(Vector3.up * i/3);
                    br.transform.Translate(Vector3.right * j/3);
                    br.transform.parent = holder.transform;
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                BrcMaker();
            }
        }
    }
*/

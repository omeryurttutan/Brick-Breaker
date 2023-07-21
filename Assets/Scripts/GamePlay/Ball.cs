using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
   public float speed = 10f;
   public new Rigidbody rb { get; private set; }


   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
   }

   void Start()
   {
     ResetBall();

   }
   
   public void ResetBall()
   {
      rb.velocity = Vector3.zero;
      transform.position = Vector3.zero;

      Invoke(nameof(SetRandomTrajectory), 1f);
   }

   private void FixedUpdate()
   {
      rb.velocity = rb.velocity.normalized * speed;
   }


   private void SetRandomTrajectory()
   {
      Vector3 force=Vector3.zero;
      force.x = Random.Range(-1f, 1f);
      force.y = -1f;
      
      this.rb.AddForce(force* speed, ForceMode.Impulse);
      
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nav_aibot : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
  
    public Animator animAI;
   
    Transform trans;
    public bool isActive = false;
    public void Init()
    {
        isActive = true;
        trans = transform;
       
       


    }
    RaycastHit hit;
    private void Update()
    {
       
        //if(Physics.Raycast( out hit))
        //{

        //}
    }


}

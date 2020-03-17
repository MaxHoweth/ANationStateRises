using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class dayNightController : MonoBehaviour
{
    public int days = 0;
    public float globalTime = 0;

    bool lightDisabled = false;

    public float sunHeight = 3500;
    public float sunDepth = -7000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        globalTime += 0.1f;

        //HIGH NOON
        if ( globalTime > 0 && globalTime < 14000) {
            lightDisabled = false;
            sunDepth += 0.1f;
            transform.position = new Vector3(sunDepth, 3500, 0);
        }

        //SUNSET
        if (globalTime > 14000 && globalTime < 21000)  {
            if(sunHeight < 0) {  lightDisabled = true;  }
            else              {  lightDisabled = false; }
            
            sunHeight -= 0.1f;
            sunDepth = 7000;
            transform.position = new Vector3(sunDepth, sunHeight, 0);
        }

        //NIGHT
        if (globalTime > 21000 && globalTime < 35000){
            lightDisabled = true;
            sunHeight = -3500;
            sunDepth -= 0.1f;
            transform.position = new Vector3(sunDepth, sunHeight, 0);
        }

        //SUNRISE
        if (globalTime > 35000 && globalTime < 42000){
            if (sunHeight < 0) {  lightDisabled = true;  }
            else               {  lightDisabled = false; }

            sunHeight += 0.1f;
            sunDepth = 7000;
            transform.position = new Vector3(sunDepth, sunHeight, 0);
        }

        //RESET
        if (globalTime > 42000) {
            days += 1;
            sunDepth = -7000;
            sunHeight = 3500;
            globalTime = 0;
        }

        if (lightDisabled) {  gameObject.GetComponent<Light>().enabled = false;  }
        else               {  gameObject.GetComponent<Light>().enabled = true;   }


    }
}

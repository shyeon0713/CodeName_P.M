using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitleSceneLight : MonoBehaviour
{
    // Start is called before the first frame update
        public UnityEngine.Rendering.Universal.Light2D light2D;
        public float minIntensity = 0.5f;
        public float maxIntensity = 1.5f;
        public float speed = 1f;

        private void Update()
        {
            float intensity = Mathf.PingPong(Time.time * speed, maxIntensity - minIntensity) + minIntensity;
            light2D.intensity = intensity;
        }
    
}

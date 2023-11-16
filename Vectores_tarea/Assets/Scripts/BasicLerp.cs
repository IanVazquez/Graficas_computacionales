using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLerp : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Vector3 startPos;
    [SerializeField] Vector3 finalPos;
    [Range(0.0f,1.0f)]
    [SerializeField] float t;
    [SerializeField] float moveTime;
    float elapsedTime=0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t=elapsedTime/moveTime;
        //USe a function smooth
        t=t*t;
        Vector3 position = startPos + (finalPos-startPos) * t;

        //Move the object using Unity transforms
        transform.position=position;
        //To move using matrix transormations, put the vector 3 into a 
        //TRanslation matrix, and apply to the vertices
        Matrix4x4 move=HW_Transforms.TranslationMat(position.x, position.y, position.z);
        elapsedTime += Time.deltaTime;
        if (elapsedTime>moveTime){
            //elapsedTime=,moveTime;
            elapsedTime=0.0f;

            Vector3 temp=finalPos;
            finalPos=startPos;
            startPos=temp;
        }
    }
}

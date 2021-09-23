using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{ 
    [SerializeField]
private Transform[] transformArray ;
private int lastTime;
private float timer; 
const float moveWait = 2.0f;
const float scaleWait = 4.0f;
void Start(){
    lastTime = 0;
    ResetTime();
    Camera.main.orthographic = true;
    Camera.main.orthographicSize = moveWait;
    InvokeRepeating("MoveObjects", 0f, moveWait);
    ResetTime();
}
void Update(){
    timer += Time.deltaTime;
    if(timer > lastTime){
        Debug.Log(lastTime++);
    }


    if (Input.GetKeyDown(KeyCode.Space)){
        if (Time.timeScale == 1){
             Time.timeScale = 0;
        }else{
             Time.timeScale = 1;
        }
        Debug.Log("Spacebar pressed");
        }


    if (Input.GetKeyDown(KeyCode.Return)){
            lastTime = 0;
        }

         ResetTime();
       
     StartCoroutine(RotateObjects(Random.Range(0.25f, 0.75f)));
}

private void ResetTime(){
    if (Input.GetKeyDown(KeyCode.Return)){
                timer = 0;
                lastTime = 0;
                InvokeRepeating("ScaleObjects", 0f, scaleWait);
        }     
}

private void MoveObjects(){
        float t0X = transformArray[0].position.x;
        float t0Y = transformArray[0].position.y;
        float t1X = transformArray[1].position.x;
        float t1Y = transformArray[1].position.y;

            if((transformArray[0].transform.position.x == 2 && transformArray[0].transform.position.y == 1)||(transformArray[0].position.x == -2 && transformArray[0].position.y == -1))
            {
                transformArray[0].position = new Vector3(t0X,t1Y,0);
                transformArray[1].position = new Vector3(t1X,t0Y,0);
            }
            else if ((transformArray[0].position.x == 2 && transformArray[0].position.y == -1)||(transformArray[0].position.x == -2 && transformArray[0].position.y == 1))
            {
                transformArray[0].position = new Vector3(t1X,t0Y,0);
                transformArray[1].position = new Vector3(t0X,t1Y,0);

        }
    }

private void ScaleObjects(){
        if (transformArray[0].transform.localScale.x > 1.5f && transformArray[1].transform.localScale.x > 1.5f)
        {
            transformArray[0].transform.localScale = transformArray[0].transform.localScale/1.2f;
            transformArray[1].transform.localScale =  transformArray[1].transform.localScale/1.2f;
        }
        else
        {
            transformArray[0].transform.localScale = transformArray[0].transform.localScale*1.2f;
            transformArray[1].transform.localScale = transformArray[1].transform.localScale*1.2f;
        }

}
     IEnumerator RotateObjects(float random)
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        for (int repeat = 0; repeat <= 3; repeat++)
        {
            yield return new WaitForSeconds(random);
            transformArray[0].transform.Rotate(0f, 0f, 90f);
            transformArray[1].transform.Rotate(0f, 0f, 90f);
        }

    }
    }


}

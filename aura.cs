using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class aura : MonoBehaviour
{  
    public float transitionTime = 10;
    float lerpValue = 0;
    bool isGoing = false;

    Vector3 startPosition;
    Vector3 endPosition;

    public Button leftButton;
    public Button rightButton;

    public RawImage leftArrow;
    public RawImage rightArrow;

    bool goingLeft = false;
    bool goingRight = false;
    
    public GameObject obj0;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;
    public GameObject obj7;

    GameObject[] objectArray = new GameObject[8]; 

    bool isObj0in0 = true;
    bool isObj1in0 = false;
    bool isObj2in0 = false;
    bool isObj3in0 = false;
    bool isObj4in0 = false;
    bool isObj5in0 = false;
    bool isObj6in0 = false;
    bool isObj7in0 = false;

    public bool[] pos0array = new bool[8];

    int[] objPosArray = new int[8];

    Vector3 pos0 = new Vector3(0,0,-2);
    Vector3 pos1 = new Vector3(-4,0,0);
    Vector3 pos2 = new Vector3(-6,0,4);
    Vector3 pos3 = new Vector3(-4,0,6);
    Vector3 pos4 = new Vector3(0,0,8);
    Vector3 pos5 = new Vector3(4,0,6);
    Vector3 pos6 = new Vector3(6,0,4);
    Vector3 pos7 = new Vector3(4,0,0);

    Vector3[] positionArray = new Vector3[8];

    public GameObject position0;
    public GameObject position1;
    public GameObject position2;
    public GameObject position3;
    public GameObject position4;
    public GameObject position5;
    public GameObject position6;
    public GameObject position7;

    bool is0small = false;
    bool is1small = true;
    bool is2small = true;
    bool is3small = true;
    bool is4small = true;
    bool is5small = true;
    bool is6small = true;
    bool is7small = true;

    bool[] isSmallArray = new bool[8];

    bool is0chosen = false;
    bool is1chosen = false;
    bool is2chosen = false;
    bool is3chosen = false;
    bool is4chosen = false;
    bool is5chosen = false;
    bool is6chosen = false;
    bool is7chosen = false;

    bool[] isChosenArray = new bool[8];

    // Start is called before the first frame update
    void Start()
    {
        for (int n = 0; n <= 7; n++) {
            objPosArray[n] = n;
        }

        positionArray[0] = pos0;
        positionArray[1] = pos1;
        positionArray[2] = pos2;
        positionArray[3] = pos3;
        positionArray[4] = pos4;
        positionArray[5] = pos5;
        positionArray[6] = pos6;
        positionArray[7] = pos7;
   
        objectArray[0] = obj0;
        objectArray[1] = obj1;
        objectArray[2] = obj2;
        objectArray[3] = obj3;
        objectArray[4] = obj4;
        objectArray[5] = obj5;
        objectArray[6] = obj6;
        objectArray[7] = obj7;

        isSmallArray[0] = is0small;
        isSmallArray[1] = is1small;
        isSmallArray[2] = is2small;
        isSmallArray[3] = is3small;
        isSmallArray[4] = is4small;
        isSmallArray[5] = is5small;
        isSmallArray[6] = is6small;
        isSmallArray[7] = is7small;

        isChosenArray[0] = is0chosen;
        isChosenArray[1] = is1chosen;
        isChosenArray[2] = is2chosen;
        isChosenArray[3] = is3chosen;
        isChosenArray[4] = is4chosen;
        isChosenArray[5] = is5chosen;
        isChosenArray[6] = is6chosen;
        isChosenArray[7] = is7chosen;

        pos0array[0] = isObj0in0;
        pos0array[1] = isObj1in0;
        pos0array[2] = isObj2in0;
        pos0array[3] = isObj3in0;
        pos0array[4] = isObj4in0;
        pos0array[5] = isObj5in0;
        pos0array[6] = isObj6in0;
        pos0array[7] = isObj7in0;

        rightButton.onClick.AddListener(MoveRight);
        leftButton.onClick.AddListener(MoveLeft);
        //rightArrow.onClick.AddListener(MoveRight);
        //leftArrow.onClick.AddListener(MoveLeft);
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int n = 0; n <= 7; n++) {
            //objectArray[n].gameObject.transform.position = positionArray[objPosArray[n]];
            //Debug.Log("UPDATE() n = " + n + " objPos = " + objPosArray[n]);

            if (isGoing == true) {
                startPosition = objectArray[n].gameObject.transform.position;
                endPosition = positionArray[objPosArray[n]];
                if (lerpValue < 1) {
                    lerpValue += Time.deltaTime / transitionTime;
                    objectArray[n].gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, lerpValue);
                }
                else {
                    lerpValue = 0;
                    isGoing = false;
                }
            }
        
        }
    }

    void MoveRight() {

        isGoing = true;

        for (int n = 0; n <= 7; n++) {
            if (objPosArray[n] == 7) {
                objPosArray[n] = 0;
                pos0array[n] = true;
            }
            else {
                objPosArray[n] += 1;
                pos0array[n] = false;
            }
            if (objPosArray[n] != 0 && isSmallArray[n] == false) {
                Vector3 objScale = objectArray[n].transform.localScale;
                objectArray[n].transform.localScale = new Vector3(objScale.x*0.5f, objScale.y*0.5f, objScale.z*0.5f);
                isSmallArray[n] = true;
            }
            else if (objPosArray[n] == 0 && isSmallArray[n] == true) {
                Vector3 objScale = objectArray[n].transform.localScale;
                objectArray[n].transform.localScale = new Vector3(objScale.x*2f, objScale.y*2f, objScale.z*2f);
                isSmallArray[n] = false;
            }

            Debug.Log("MOVERIGHT() n = " + n + " objPosArray[" + n + "] = " + objPosArray[n]);
        }

    }

    void MoveLeft() {

        isGoing = true;

        for (int n = 0; n <= 7; n = n + 1) {
            if (objPosArray[n] == 0) {
                objPosArray[n] = 7;
                pos0array[n] = false;
            }
            else if (objPosArray[n] == 1) {
                objPosArray[n] = 0;
                pos0array[n] = true;
            }
            else {
                objPosArray[n] = objPosArray[n] - 1;
                pos0array[n] = false;
            }
            if (objPosArray[n] != 0 && isSmallArray[n] == false) {
                Vector3 objScale = objectArray[n].transform.localScale;
                objectArray[n].transform.localScale = new Vector3(objScale.x*0.5f, objScale.y*0.5f, objScale.z*0.5f);
                isSmallArray[n] = true;
            }
            else if (objPosArray[n] == 0 && isSmallArray[n] == true) {
                Vector3 objScale = objectArray[n].transform.localScale;
                objectArray[n].transform.localScale = new Vector3(objScale.x*2f, objScale.y*2f, objScale.z*2f);
                isSmallArray[n] = false;
            }

            Debug.Log("MOVELEFT() n = " + n + " objPosArray[" + n + "] = " + objPosArray[n]);
        }

    }
}

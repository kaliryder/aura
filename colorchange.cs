using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange : MonoBehaviour
{
    public GameObject sphere;
    public int spherePos;

    MeshRenderer meshRend;

    public bool isScaleGoing = false;
    public bool isPosGoing = false;
    public bool isBig = false;
    public bool isUp = false;
    public bool isCenter = false;

    public float scaleTransitionSpeed = 2;
    float scaleLerpValue = 0;

    public float colorTransitionSpeed = 2;
    float colorTimer = 0;

    float positionTransitionSpeed = 0.5f;
    float posLerpValue = 0;

    public Color initialColor;
    public Color fadeColor1;
    public Color fadeColor2;

    Vector3 initialSphereScale = new Vector3(2f,2f,2f);
    Vector3 endSphereScale = new Vector3(2.5f,2.5f,2.5f);

    Vector3 initialSpherePos;
    Vector3 endSpherePos = new Vector3(0,1,-2);

    bool[] objPosArray;

    // Start is called before the first frame update
    void Start()
    {
        objPosArray = GameObject.Find("script").GetComponent<aura>().pos0array;
        //assigns pos0array from aura script to objPosArray

        meshRend = GetComponent<MeshRenderer>();
        //sets up MeshRenderer

        initialColor = meshRend.material.color;
        //sets initialColor to sphere color
    }

    // Update is called once per frame
    void Update()
    {
        initialSpherePos = sphere.gameObject.transform.position;

        if (objPosArray[spherePos] == true && isUp == false) {
            MoveUp();
            isCenter = true;
        }
        else if (objPosArray[spherePos] == true && isUp == true) {
            isCenter = true;
            sphere.gameObject.transform.position = endSpherePos;
        }
        else if (objPosArray[spherePos] == false) {
            isCenter = false;
            isUp = false;
        }
        else {
            isCenter = false;
            isUp = false;
        }
    }

    void OnMouseOver() {
        if (isCenter == true) { 
            meshRend.material.color = Color.Lerp(initialColor, fadeColor1, colorTimer / colorTransitionSpeed);
            colorTimer += Time.deltaTime;
            meshRend.material.color = Color.Lerp(fadeColor1, fadeColor2, colorTimer / colorTransitionSpeed);
            colorTimer += Time.deltaTime;

            isScaleGoing = true;
            if (isScaleGoing == true) {
                if (scaleLerpValue < 1) {
                    scaleLerpValue += Time.deltaTime / scaleTransitionSpeed;
                    sphere.transform.localScale = Vector3.Lerp(initialSphereScale, endSphereScale, scaleLerpValue);                        isBig = true;
                }
                else {
                    scaleLerpValue = 0;
                    isScaleGoing = false;
                }
            }
        }
    }

    void OnMouseExit() {
        if (isCenter == true) {
            transform.localScale = initialSphereScale;
            isScaleGoing = false;
            //transform.localPosition = initialSpherePos;
            isPosGoing = false;
        }
    }

    void MoveUp() {
        isPosGoing = true;
        if (isPosGoing == true) {
            if (posLerpValue < 1) {
                posLerpValue += Time.deltaTime / positionTransitionSpeed;
                sphere.transform.localPosition = Vector3.Lerp(initialSpherePos, endSpherePos, posLerpValue);
            }
            else {
                posLerpValue = 0;
                isPosGoing = false;
                isUp = true;
            }
        }
    }
}

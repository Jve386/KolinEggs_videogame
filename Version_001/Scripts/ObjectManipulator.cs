using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    public GameObject ArObject;

    [SerializeField] private Camera aRCamera;
    private bool isAROjectSelected;
    private string tagAROjects = "ARObject";
    private Vector2 initialTouchPos;

    [SerializeField] private float speedMovement = 4.0f;
    [SerializeField] private float speedRotation = 5.0f;
    [SerializeField] private float scaleFactor = 0.1f;
    private float screenFactor = 0.0001f; 

    private float touchDis;
    private Vector2 touchPositionDiff;

    private float rotationTolerance = 1.5f;
    private float scaleTolerance = 25f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touchOne = Input.GetTouch(0);

            if (Input.touchCount == 1)
            {

                if (touchOne.phase == TouchPhase.Began)                         
                {
                    initialTouchPos = touchOne.position;   
                    isAROjectSelected = CheckTouchOnARObject(initialTouchPos);

                }
                if (touchOne.phase == TouchPhase.Moved && isAROjectSelected) 
                {
                    Vector2 diffPos = (touchOne.position - initialTouchPos) * screenFactor;

                    ArObject.transform.position = ArObject.transform.position +
                        new Vector3(diffPos.x*speedMovement, diffPos.y * speedMovement, 0);

                    initialTouchPos = touchOne.position;
                }          
            }

            if (Input.touchCount == 2)
            {
                Touch touchTwo = Input.GetTouch(1);
                if (touchOne.phase == TouchPhase.Began || touchTwo.phase == TouchPhase.Began)
                {
                    touchPositionDiff = touchTwo.position - touchOne.position;
                    touchDis = Vector2.Distance(touchTwo.position, touchOne.position);
                }

                if (touchOne.phase == TouchPhase.Moved || touchTwo.phase == TouchPhase.Moved)
                {
                    Vector2 currentTouchPosDiff = touchTwo.position - touchOne.position;
                    float currentTouchDis = Vector2.Distance(touchTwo.position, touchOne.position);

                    float diffDis = currentTouchDis - touchDis; 

                    if (Mathf.Abs(diffDis) > scaleTolerance)
                    {
                        Vector3 newScale = ArObject.transform.localScale + Mathf.Sign(diffDis) * Vector3.one * scaleFactor;
                        ArObject.transform.localScale = Vector3.Lerp(ArObject.transform.localScale, newScale, 0.05f);
                    }

                    float angle = Vector2.SignedAngle(touchPositionDiff, currentTouchPosDiff);

                    if(Mathf.Abs(angle) > rotationTolerance)
                    {
                        ArObject.transform.rotation = Quaternion.Euler(0, ArObject.transform.rotation.eulerAngles.y - Mathf.Sign(angle) * speedRotation,0);

                    }

                    touchDis = currentTouchDis;
                    touchPositionDiff = currentTouchPosDiff;
                }
            }
        }
    }

    private bool CheckTouchOnARObject(Vector2 touchPosition)
    {
        Ray ray = aRCamera.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit hitARObject))
        {
            if (hitARObject.collider.CompareTag(tagAROjects))
            {
                ArObject = hitARObject.transform.gameObject;
                return true;                
            }
        }

        return false;
    }
}

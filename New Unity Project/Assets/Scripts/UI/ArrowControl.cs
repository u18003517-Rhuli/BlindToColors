using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class ArrowControl : MonoBehaviour
{

    public Camera uiCamera;
    public Transform player;
    private Vector3 targetPosition;
    
    private RectTransform pointerRectTranform;

    private void Awake()
    {
        //targetPosition = new Vector3(200, 45);
        pointerRectTranform = transform.Find("Arrow2").GetComponent<RectTransform>();
    }

    private void Update()
    {

        if (!player)
            return;

        Vector3 toPosition = targetPosition;
        //Debug.Log("ARROW TARGET - " + toPosition);
        //Vector3 fromPostion = Camera.main.transform.position;
        Vector3 fromPostion = player.position;
        fromPostion.z = 0f;
        //Debug.Log("ARROW POSITION - " + fromPostion);
        Vector3 direction = (toPosition - fromPostion).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(direction);
        pointerRectTranform.localEulerAngles = new Vector3(0, 0, angle);


        //position

        /*float borderSize = 0f;

        Vector3 targetPostionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen =
            targetPostionScreenPoint.x <= borderSize
            || targetPostionScreenPoint.x >= Screen.width - borderSize
            || targetPostionScreenPoint.y <= borderSize
            || targetPostionScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPostion = targetPostionScreenPoint;

            if (cappedTargetScreenPostion.x <= borderSize)
                cappedTargetScreenPostion.x = borderSize;
            if (cappedTargetScreenPostion.x >= Screen.width - borderSize)
                cappedTargetScreenPostion.x = Screen.width - borderSize;

            if (cappedTargetScreenPostion.y <= borderSize)
                cappedTargetScreenPostion.y = borderSize;
            if (cappedTargetScreenPostion.y >= Screen.height - borderSize)
                cappedTargetScreenPostion.y = Screen.height - borderSize;

            Vector3 pointerWorldPostion = uiCamera.ScreenToWorldPoint(cappedTargetScreenPostion);
            pointerRectTranform.position = pointerWorldPostion;
            pointerRectTranform.localPosition = new Vector3(pointerRectTranform.localPosition.x, pointerRectTranform.localPosition.y, 0f);
        }else
        {
            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(targetPostionScreenPoint);
            pointerRectTranform.position = pointerWorldPosition;
            pointerRectTranform.localPosition = new Vector3(pointerRectTranform.localPosition.x, pointerRectTranform.localPosition.y, 0f);
        }*/
    }

    public void setTarget(Vector3 postion)
    {
        //Debug.Log("welcome to the world");
        targetPosition = postion;
    }
}

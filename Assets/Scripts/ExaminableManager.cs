using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField]
    Transform _examineTarget;

    Transform _priorTargetTransform;
    Vector3 _priorPos;
    Quaternion _priorRot;
    Vector3 _priorScale;

    Examinable _examinedObject;
    private bool isExamining;
    private float _rotSpeed = 25f;

    private void Update()
    {
        if (isExamining && Input.touchCount > 0)
        {
            // Get first touch
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                Vector3 rotation = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0) * _rotSpeed * Time.deltaTime;
                _examinedObject.transform.Rotate(rotation);
            }
        }
    }

    public void PerformExamination(Examinable target)
    {
        if (target == null || _examineTarget == null)
        {
            Debug.Log($"Examine failed: Target: {target} examineTarget: {_examineTarget}");
            return; 
        }

        _examinedObject = target;

        _priorPos = target.transform.position;
        _priorRot = target.transform.rotation;
        _priorScale = target.transform.localScale;
        _priorTargetTransform = target.transform;

        _examinedObject.transform.position = _examineTarget.position;
        _examinedObject.transform.parent = _examineTarget;
        _examinedObject.transform.localScale = _priorScale * target.ExamineScaleOffset();

        isExamining = true;
    }

    public void Unexamine()
    {
        _examinedObject.transform.position = _priorPos;
        _examinedObject.transform.rotation = _priorRot;
        _examinedObject.transform.localScale = _priorScale;

        _examinedObject.transform.parent = null;

        isExamining = false;
    }
}

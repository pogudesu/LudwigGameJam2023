using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField]
    private float clampAngle = 80f;
    [SerializeField]
    private float horizontalSpeed = 10.0f;
    [SerializeField]
    private float verticalSpeed = 10.0f;
    private InputManager inputManager;
    private Vector3 startingRotation;
    public CinemachineVirtualCamera vcam;
    public Vector3 CameraLookAt;
    public GameObject LookatObject;
    protected override void Awake()
    {
        inputManager = InputManager.Instance;
        base.Awake();
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if(startingRotation == null && !inputManager.isCamLocked())
                {
                    startingRotation = transform.localRotation.eulerAngles;
                }
                else
                {
                    vcam.LookAt = null;
                    Vector2 deltaInput = inputManager.GetMouseDelta();
                    startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                    startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0.0f);
                }
            }
        }
    }

}

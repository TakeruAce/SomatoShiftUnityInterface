using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomatoShiftSerialController : MonoBehaviour
{
    [HideInInspector]
    public bool enable_feedback=false;
    [HideInInspector]
    public bool enable_motion_combination=false;
    [HideInInspector]
    public bool isResetPos=false;
    [HideInInspector]
    public bool isPitch=true;
    [HideInInspector]
    public bool is_motor_freed=false;
    [HideInInspector]
    public float GimbalPos1;
    [HideInInspector]
    public float GimbalPos2;

    [HideInInspector]    
    public float wheel_command;
    [HideInInspector]
    public float desired_inertia_difference;
    [HideInInspector]
    public float desired_viscosity_difference;
    [HideInInspector]
    public float manual_bases_command;
    [HideInInspector]
    public float manual_static_torque;
    public SerialHandler serialHandler;
    // Start is called before the first frame update
    // boolean型の値を送信するメソッド
    public void SetBoolCommand(string varName, bool value)
    {
        if (serialHandler.serialPort_ != null && serialHandler.isRunning_)
        {
            string command = varName + ":" + value.ToString();
            serialHandler.serialPort_.WriteLine(command);
        }
    }

    // float型の値を送信するメソッド
    public void SetFloatCommand(string varName, float value)
    {
        if (serialHandler.serialPort_ != null && serialHandler.isRunning_)
        {
            string command = varName + ":" + value.ToString("F5");
            serialHandler.serialPort_.WriteLine(command);
        }
    }
    public void ResetSliderValues()
    {
        GimbalPos1 = 0;
        GimbalPos2 = 0;
        wheel_command = 0;
        desired_inertia_difference = 0;
        desired_viscosity_difference = 0;
        manual_bases_command = 0;
        manual_static_torque = 0;

        // 変更をシリアルポートに送信
        SetFloatCommand("GimbalPos1", GimbalPos1);
        SetFloatCommand("GimbalPos2", GimbalPos2);
        SetFloatCommand("wheel_command", wheel_command);
        SetFloatCommand("desired_inertia_difference", desired_inertia_difference);
        SetFloatCommand("desired_viscosity_difference", desired_viscosity_difference);
        SetFloatCommand("manual_bases_command", manual_bases_command);
        SetFloatCommand("manual_static_torque", manual_static_torque);
    }
    // 使用例
    public void OnEnableFeedbackChanged(bool value)
    {
        SetBoolCommand("enable_feedback", value);
    }

    public void OnEnableMotionCombinationChanged(bool value)
    {
        SetBoolCommand("enable_motion_combination", value);
    }

    public void OnIsResetPosChanged(bool value)
    {
        SetBoolCommand("isResetPos", value);
    }

    public void OnIsPitchChanged(bool value)
    {
        SetBoolCommand("isPitch", value);
    }

    public void OnIsMotorFreedChanged(bool value)
    {
        SetBoolCommand("is_motor_freed", value);
    }

    public void OnGimbalPos1Changed(float value)
    {
        SetFloatCommand("GimbalPos1", value);
    }

    public void OnGimbalPos2Changed(float value)
    {
        SetFloatCommand("GimbalPos2", value);
    }

    public void OnWheelCommandChanged(float value)
    {
        SetFloatCommand("wheel_command", value);
    }

    public void OnDesiredInertiaDifferenceChanged(float value)
    {
        SetFloatCommand("desired_inertia_difference", value);
    }

    public void OnDesiredViscosityDifferenceChanged(float value)
    {
        SetFloatCommand("desired_viscosity_difference", value);
    }

    public void OnManualBasesCommandChanged(float value1)
    {
        SetFloatCommand("manual_bases_command", value1);
    }

    public void OnManualStaticTorqueChanged(float value)
    {
        SetFloatCommand("manual_static_torque", value); 
    }
}
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SomatoShiftSerialController))]
public class SomatoShiftSerialControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        bool guiChanged = false;

        SomatoShiftSerialController sender = (SomatoShiftSerialController)target;

        sender.enable_feedback = EditorGUILayout.Toggle("Enable Feedback", sender.enable_feedback);
        if (GUI.changed) sender.SetBoolCommand("enable_feedback", sender.enable_feedback);

        sender.enable_motion_combination = EditorGUILayout.Toggle("Enable Motion Combination", sender.enable_motion_combination);
        if (GUI.changed) sender.SetBoolCommand("enable_motion_combination", sender.enable_motion_combination);

        sender.isResetPos = EditorGUILayout.Toggle("Is Reset Pos", sender.isResetPos);
        if (GUI.changed) sender.SetBoolCommand("isResetPos", sender.isResetPos);

        sender.isPitch = EditorGUILayout.Toggle("Is Pitch", sender.isPitch);
        if (GUI.changed) sender.SetBoolCommand("isPitch", sender.isPitch);

        sender.is_motor_freed = EditorGUILayout.Toggle("Is Motor Freed", sender.is_motor_freed);
        if (GUI.changed) sender.SetBoolCommand("is_motor_freed", sender.is_motor_freed);

        sender.GimbalPos1 = EditorGUILayout.Slider("Gimbal Pos 1", sender.GimbalPos1, 0, 360);
        if (GUI.changed) sender.SetFloatCommand("GimbalPos1", sender.GimbalPos1);

        sender.GimbalPos2 = EditorGUILayout.Slider("Gimbal Pos 2", sender.GimbalPos2, 0, 360);
        if (GUI.changed) sender.SetFloatCommand("GimbalPos2", sender.GimbalPos2);

        sender.wheel_command = EditorGUILayout.Slider("Wheel Command", sender.wheel_command, 0, 1000);
        if (GUI.changed) sender.SetFloatCommand("wheel_command", sender.wheel_command);

        sender.desired_inertia_difference = EditorGUILayout.Slider("Desired Inertia Difference", sender.desired_inertia_difference, -0.01f, 0.01f);
        if (GUI.changed) sender.SetFloatCommand("desired_inertia_difference", sender.desired_inertia_difference);

        sender.desired_viscosity_difference = EditorGUILayout.Slider("Desired Viscosity Difference", sender.desired_viscosity_difference, -0.1f, 0.1f);
        if (GUI.changed) sender.SetFloatCommand("desired_viscosity_difference", sender.desired_viscosity_difference);

        sender.manual_bases_command = EditorGUILayout.Slider("Manual Bases Command", sender.manual_bases_command, -25, 25);
        if (GUI.changed) sender.SetFloatCommand("manual_bases_command", sender.manual_bases_command);

        sender.manual_static_torque = EditorGUILayout.Slider("Manual Static Torque", sender.manual_static_torque, -0.1f, 0.1f);
        if (GUI.changed) sender.SetFloatCommand("manual_static_torque", sender.manual_static_torque);
        // リセットボタンを追加
        if (GUILayout.Button("Reset Sliders"))
        {
            sender.ResetSliderValues();
            guiChanged = true;
        }

        // 変更が検知された場合、インスペクターを更新
        if (guiChanged)
        {
            EditorUtility.SetDirty(target);
        }
    }
}

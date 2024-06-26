using UnityEditor;
using UnityEngine;
using System.IO.Ports;

[CustomEditor(typeof(SerialHandler))]
public class SerialHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // デフォルトのインスペクター要素を描画
        DrawDefaultInspector();

        SerialHandler handler = (SerialHandler)target;

        // 使用可能なシリアルポートをスキャン
        string[] portNames = SerialPort.GetPortNames();

        // シリアルポート選択用のドロップダウンリストを表示
        int selectedIndex = System.Array.IndexOf(portNames, handler.portName);
        if (selectedIndex == -1) selectedIndex = 0;
        selectedIndex = EditorGUILayout.Popup("Select Serial Port", selectedIndex, portNames);
        if (portNames.Length > 0) handler.portName = portNames[selectedIndex];

        // // シリアルポートを開くボタン
        // if (GUILayout.Button("Open Port"))
        // {
        //     handler.Close();  // 既存のポートを閉じる
        //     handler.Open();   // 新しいポートを開く
        // }

        // ボーレートの設定
        handler.baudRate = EditorGUILayout.IntField("Baud Rate", handler.baudRate);

        // 変更があった場合にインスペクターを更新
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}

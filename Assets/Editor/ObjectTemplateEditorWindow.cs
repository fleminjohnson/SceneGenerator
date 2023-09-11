using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using Unity.Plastic.Newtonsoft.Json;
using Unity.Plastic.Newtonsoft.Json.Linq;


namespace JsonToSceneHierarchy
{
    public class ObjectTemplateEditorWindow : EditorWindow
    {
        private string jsonFilePath;
        private string jsonData;
        private string errorMessage;
        private string statusMessage;
        private static JsonDeserializer deserializer;

        [MenuItem("Custom Tools/Object Template Editor")]
        public static void ShowWindow()
        {
            GetWindow<ObjectTemplateEditorWindow>("Object Template Editor");
            deserializer = new JsonDeserializer();
        }

        bool LoadGOButtonActive = false;
        private void OnGUI()
        {
            GUILayout.Label("Object Template Editor", EditorStyles.boldLabel);

            EditorGUILayout.Space();

            // Display a text field for specifying the JSON file path
            jsonFilePath = EditorGUILayout.TextField("JSON File Path", jsonFilePath);

            EditorGUILayout.Space();

            // Button to open a file dialog for selecting a JSON file
            if (GUILayout.Button("Select JSON File"))
            {
                jsonFilePath = EditorUtility.OpenFilePanel("Select JSON File", "", "json");
                LoadJsonData();
            }

            if (LoadGOButtonActive)
            {
                if (GUILayout.Button("Create GameObjects"))
                    deserializer.Deserialize(jsonData);
            }

            EditorGUILayout.Space();

            // Display JSON data
            EditorGUILayout.LabelField("JSON Data:");
            jsonData = EditorGUILayout.TextArea(jsonData, GUILayout.Height(200));

            EditorGUILayout.Space();

            // Display error message if there is one
            if (!string.IsNullOrEmpty(errorMessage))
            {
                GUIStyle errorStyle = new GUIStyle(GUI.skin.label);
                errorStyle.normal.textColor = Color.red;
                EditorGUILayout.LabelField(errorMessage, errorStyle);
            }

            // Display status message if there is one
            if (!string.IsNullOrEmpty(statusMessage))
            {
                GUIStyle statusStyle = new GUIStyle(GUI.skin.label);
                statusStyle.normal.textColor = Color.green;
                EditorGUILayout.LabelField(statusMessage, statusStyle);
            }

            EditorGUILayout.Space();

            // Save JSON data button
            if (GUILayout.Button("Save JSON Data"))
            {
                SaveJsonData();
            }
        }

        private void LoadJsonData()
        {
            // Clear previous error and status messages
            errorMessage = "";
            statusMessage = "";

            // Ensure the JSON file path is not empty
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                try
                {
                    // Read the JSON data from the specified file path
                    jsonData = File.ReadAllText(jsonFilePath);

                    // Check if the loaded JSON data is valid
                    if (!IsJsonValid(jsonData))
                    {
                        errorMessage = "Invalid JSON data. Please check the format.";
                    }
                    else
                    {
                        statusMessage = "JSON data loaded successfully!";
                        LoadGOButtonActive = true;
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Error loading JSON data: " + e.Message);
                    jsonData = "Error loading JSON data.";
                }
            }
            else
            {
                jsonData = "JSON file path is empty.";
            }
        }

        private void SaveJsonData()
        {
            // Clear previous error and status messages
            errorMessage = "";
            statusMessage = "";

            // Ensure the JSON file path is not empty
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                try
                {
                    // Check if the JSON data is valid before saving
                    if (IsJsonValid(jsonData))
                    {
                        File.WriteAllText(jsonFilePath, jsonData);
                        statusMessage = "JSON data saved successfully!";
                    }
                    else
                    {
                        errorMessage = "Not a valid JSON! Data not saved.";
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError("Error saving JSON data: " + e.Message);
                }
            }
            else
            {
                Debug.LogError("JSON file path is empty.");
            }
        }

        private bool IsJsonValid(string json)
        {
            try
            {
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);
                return jsonObject != null;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }
}


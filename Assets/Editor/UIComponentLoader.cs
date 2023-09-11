using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;

namespace JsonToSceneHierarchy
{
    public class JsonDeserializer
    {
        //// The JSON data as a string
        //private string jsonData = @"{
        //    // Your JSON data goes here
        //}";

        public void Deserialize(string jsonData)
        {
            // Deserialize the JSON data into the Application class
            ComponentModelClass.Application application = JsonConvert.DeserializeObject<ComponentModelClass.Application>(jsonData);

            InstantiateTemplate(application);
        }

        private GameObject InstantiateTemplate(ComponentModelClass.Application template)
        {
            // Instantiate a basic empty GameObject
            GameObject instantiatedObject = new GameObject(template.name);

            // Set the position of the instantiated object
            instantiatedObject.transform.position = new Vector3(template.position.x, template.position.y, template.position.z);

            // Add components based on the JSON data
            foreach (var componentData in template.component)
            {
                switch (componentData.componentType)
                {
                    case "Button":
                        Button button = instantiatedObject.AddComponent<Button>();
                        button.transition = (Selectable.Transition)componentData.transition;
                        break;

                    case "Image":
                        Image imageComponent = instantiatedObject.AddComponent<Image>();
                        ComponentModelClass.RectTransform rect = componentData.rectTransform;
                        
                        imageComponent.rectTransform.position = new Vector3(rect.position.x, rect.position.y, rect.position.z);
                        imageComponent.rectTransform.pivot = new Vector2(rect.pivot.x, rect.pivot.y);
                        imageComponent.rectTransform.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y);
                        imageComponent.rectTransform.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y);
                        imageComponent.color = new UnityEngine.Color(
                            componentData.color.r,
                            componentData.color.g,
                            componentData.color.b,
                            componentData.color.a
                        );
                        break;

                    case "TextMeshPro":
                        TextMeshProUGUI textComponent = instantiatedObject.AddComponent<TextMeshProUGUI>();
                        textComponent.text = componentData.text;
                        textComponent.color = new UnityEngine.Color(
                            componentData.color.r,
                            componentData.color.g,
                            componentData.color.b,
                            componentData.color.a
                        );
                        break;

                    case "Canvas":
                        Canvas canvasComponent = instantiatedObject.AddComponent<Canvas>();
                        canvasComponent.renderMode = (RenderMode)componentData.renderMode;
                        break;

                    case "CanvasScaler":
                        CanvasScaler canvasScalerComponent = instantiatedObject.AddComponent<CanvasScaler>();
                        canvasScalerComponent.uiScaleMode = (CanvasScaler.ScaleMode)componentData.uiScaleMode;
                        canvasScalerComponent.referenceResolution = new Vector2(componentData.referenceResolution.x, componentData.referenceResolution.y);
                        canvasScalerComponent.matchWidthOrHeight = componentData.matchWidthOrHeight; 
                        break;

                    case "GraphicRaycaster":
                        GraphicRaycaster graphicRaycasterComponent = instantiatedObject.AddComponent<GraphicRaycaster>();
                        graphicRaycasterComponent.ignoreReversedGraphics = componentData.ignoreReversedGraphics;
                        graphicRaycasterComponent.blockingMask = componentData.blockingMask;
                        graphicRaycasterComponent.blockingObjects = (GraphicRaycaster.BlockingObjects)componentData.blockingObjects;
                        break;
                }

                //if (componentData != null)
                //{
                //    // Add an Image component with properties from JSON
                //    Image imageComponent = instantiatedObject.AddComponent<Image>();
                //    imageComponent.sprite = Resources.Load<Sprite>(template.component.Image.sprite);
                //    imageComponent.color = new UnityEngine.Color(
                //        template.component.Image.color.r / 255f,
                //        template.component.Image.color.g / 255f,
                //        template.component.Image.color.b / 255f,
                //        template.component.Image.color.a / 255f
                //    );

                //    // You can set other properties as needed
                //}
                //else if (template.component.TextMeshPro != null)
                //{
                //    // Add a Text component with properties from JSON
                //    TextMeshProUGUI textComponent = instantiatedObject.AddComponent<TextMeshProUGUI>();
                //    textComponent.text = template.component.TextMeshPro.text;
                //    textComponent.font = Resources.GetBuiltinResource<TMP_FontAsset>("Arial.ttf");
                //    textComponent.color = new UnityEngine.Color(
                //        template.component.TextMeshPro.color.r / 255f,
                //        template.component.TextMeshPro.color.g / 255f,
                //        template.component.TextMeshPro.color.b / 255f,
                //        template.component.TextMeshPro.color.a / 255f
                //    );

                //    // You can set other properties as needed
                //}
                //else if (template.component.Button != null)
                //{
                //    // Add a Text component with properties from JSON
                //    Button button = instantiatedObject.AddComponent<Button>();
                //    button.transition = (Selectable.Transition)template.component.Button.transition;

                //    // You can set other properties as needed
                //}
            }

            // If you have child nodes, you can process and add them as well
            foreach (ComponentModelClass.Application childNode in template.childNode)
            {
                InstantiateTemplate(childNode).transform.SetParent(instantiatedObject.transform);
            }

            return instantiatedObject;
        }
    }
}

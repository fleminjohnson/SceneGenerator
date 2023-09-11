using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JsonToSceneHierarchy
{
    public static class ComponentModelClass
    {
        [System.Serializable]
        public class UIComponent
        {
            public string type;
            public Vector2 position;
            public Vector2 size;
            public string text;
            public Color color;
            public string onClickEvent;
            public string placeholder;
            public string sprite;
            public string onValueChangedEvent;
        }

        [System.Serializable]
        public class Position
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }

        }

        [System.Serializable]
        public class Rotation
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }

        }

        [System.Serializable]
        public class Scale
        {
            public int x { get; set; }
            public int y { get; set; }
            public int z { get; set; }

        }

        [System.Serializable]
        public class Color
        {
            public int r { get; set; }
            public int g { get; set; }
            public int b { get; set; }
            public int a { get; set; }

        }

        [System.Serializable]
        public class AnchorMin
        {
            public int x { get; set; }
            public int y { get; set; }

        }

        [System.Serializable]
        public class AnchorMax
        {
            public int x { get; set; }
            public int y { get; set; }

        }

        [System.Serializable]
        public class Pivot
        {
            public float x { get; set; }
            public float y { get; set; }

        }

        [System.Serializable]
        public class SizeDelta
        {
            public int x { get; set; }
            public int y { get; set; }

        }

        [System.Serializable]
        public class AnchoredPosition
        {
            public int x { get; set; }
            public int y { get; set; }

        }

        [System.Serializable]
        public class RectTransform
        {
            public AnchorMin anchorMin { get; set; }
            public AnchorMax anchorMax { get; set; }
            public Pivot pivot { get; set; }
            public SizeDelta sizeDelta { get; set; }
            public AnchoredPosition anchoredPosition { get; set; }
            public Position position { get; set; }

        }

        [System.Serializable]
        public class Image
        {
            public string sprite { get; set; }
            public Color color { get; set; }
            public RectTransform rectTransform { get; set; }

        }

        [System.Serializable]
        public class Component
        {
            public string componentType { get; set; }

            public string sprite { get; set; }
            public Color color { get; set; }
            public RectTransform rectTransform { get; set; }

            public string onClick { get; set; }
            public int transition { get; set; }
            public string targetGraphic { get; set; }
            public bool interactable { get; set; }
            public bool blockRaycasts { get; set; }
            public bool ignoreReversedGraphics { get; set; }



            public string text { get; set; }
            public int fontSize { get; set; }
            public string alignment { get; set; }

            public int renderMode { get; set; }
            public int sortingOrder { get; set; }
            public int blockingMask { get; set; }
            public int blockingObjects { get; set; }

            public int uiScaleMode { get; set; }
            public ReferenceResolution referenceResolution { get; set; }
            public int screenMatchMode { get; set; }
            public float matchWidthOrHeight { get; set; }
        }

        [System.Serializable]
        public class ReferenceResolution
        {
            public int x { get; set; }
            public int y { get; set; }

        }

        [System.Serializable]
        public class Application
        {
            public string name { get; set; }
            public Position position { get; set; }
            public Rotation rotation { get; set; }
            public Scale scale { get; set; }
            public IList<Component> component { get; set; }
            public IList<Application> childNode { get; set; }

        }

        [System.Serializable]
        public class Font
        {
            public string name { get; set; }
            public int size { get; set; }

        }

        [System.Serializable]
        public class Text
        {
            public string text { get; set; }
            public Font font { get; set; }
            public Color color { get; set; }
            public string alignment { get; set; }
            public RectTransform rectTransform { get; set; }

        }

        [System.Serializable]
        public class Button
        {
            public string onClick { get; set; }
            public int transition { get; set; }
            public string targetGraphic { get; set; }
            public bool interactable { get; set; }
        }

        [System.Serializable]
        public class TextMeshPro
        {
            public string text { get; set; }
            public int fontSize { get; set; }
            public Color color { get; set; }
            public string alignment { get; set; }
            public RectTransform rectTransform { get; set; }

        }
    }
}

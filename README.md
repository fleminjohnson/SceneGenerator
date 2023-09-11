# SceneGenerator

This project is a Unity tool that allows you to convert JSON data into Unity GameObjects with specific components and properties, effectively creating or modifying your Unity scene hierarchy based on the JSON input.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [JSON Format](#json-format)

## Features

- Convert JSON data into Unity GameObjects.
- Create GameObjects with various components such as `Image`, `Button`, `TextMeshPro`, etc.
- Set properties of these components based on JSON input.
- Handle parent-child relationships in the scene hierarchy.

## Getting Started

### Prerequisites

To use this tool, you need the following software installed:

- Unity (version 2021.3.29f1 or higher)
- [Newtonsoft.Json](https://www.newtonsoft.com/json) for JSON deserialization (you can add it using Unity Package Manager)

### Installation

1. Clone this repository or download the ZIP file and extract it.

2. Open your Unity project.

3. Import the Newtonsoft.Json package into your project if it's not already there.

   - Open Unity Package Manager (Window > Package Manager).
   - Click the '+' button and choose "Add package from git URL..."
   - Enter `https://github.com/JamesNK/Newtonsoft.Json.git` and click "Add."

4. Import the assets from the downloaded or cloned repository into your Unity project.

## Usage

1. Create a JSON file containing the scene hierarchy structure and component data (See [JSON Format](#json-format) for details on the format).

2. In Unity's top panel, go to "Custom Tools" or a similar menu item.

3. Select "Object Template Editor."

4. In the Object Template Editor window, use the "Select JSON File" button to load your JSON data.

5. Use the "Create GameObject" button to generate the GameObjects based on the JSON input.

## JSON Format

The JSON data should follow a specific format to be correctly interpreted by the tool. Here's an example of the JSON format:
A sample JSON file is provided inside the Resources folder, please feel free to customise
```json
{
    "name": "RootObject",
    "position": {
        "x": 0,
        "y": 0,
        "z": 0
    },
    "rotation": {
        "x": 0,
        "y": 0,
        "z": 0
    },
    "scale": {
        "x": 1,
        "y": 1,
        "z": 1
    },
    "component": [
        {
            "componentType": "Image",
            "sprite": "SpriteName",
            "color": {
                "r": 1,
                "g": 1,
                "b": 1,
                "a": 1
            },
            "rectTransform": {
                "anchorMin": {
                    "x": 0,
                    "y": 0
                },
                "anchorMax": {
                    "x": 1,
                    "y": 1
                },
                "pivot": {
                    "x": 0.5,
                    "y": 0.5
                }
                // Add other properties for the component
            }
        }
        // Add more components as needed
    ],
    "childNode": [
        {
            "name": "ChildObject",
            "position": {
                "x": 10,
                "y": 0,
                "z": 0
            },
            "rotation": {
                "x": 0,
                "y": 0,
                "z": 0
            },
            "scale": {
                "x": 1,
                "y": 1,
                "z": 1
            },
            "component": [
                // Add components for the child object
            ],
            "childNode": [
                // Add child objects for the child object (nested hierarchy)
            ]
        }
        // Add more child objects as needed
    ]
}

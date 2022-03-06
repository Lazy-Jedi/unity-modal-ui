# ModalUI
A Modal UI Window in Unity that has customizable options and returns a ModalResult when a button is clicked for example ModalResult.OK. The Modal UI is meant to be similar to how the .Net Forms ShowMessage modal forms work.  

## How To
1. In the Prefabs/UI/Modals you will find a Template_Modal Prefab that you can modify in the Inspector or via Code. 
2. In the same folder mentioned above you will find an Example UI object
   1. This UI Example will demonstrate how to setup a basic Modal Window and how the ModalResult Object is handled upon button click.
3. Drag the Template to the Scene and you can manually modify the Title, Message and which Buttons are show on the Modal Window.
4. In your Script have a reference to the ModalUI
5. You can then use ModalUI.Show() or ModalUI.Show(title, message)
   1. You need to use async to wait for the ModalResult to be returned from the ModalUI.Show method 
   2. Once a button is clicked on the Modal Window, the ModalUI.Show method returns a ModalResult enum that you can evaluate to do specific tasks

## Examples

```c#

[Header("Modals")]
[SerializeField]
private ModalUI _warningModal;

public async void HandleModal()
{
    ModalResult result = await _warningModal.Show("Warning", "Are you sure you want to overwrite you save file?");
    
    switch(result)
    {
        case ModalResult.OK:
            // Your Logic
            break;
        // ...
    }
    
}
```

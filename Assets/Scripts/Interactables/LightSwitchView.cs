using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightSwitchView : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;

    private void Start() => currentState = SwitchState.Off;

    private delegate void ToggleLightDelegate();
    private ToggleLightDelegate toggleLight;

    private void OnEnable()
    {
        toggleLight = ToggleLightSwitch;
        toggleLight += ToggleSoundEffect;
    }

    public void Interact()
    {
        //Todo - Implement Interaction
        toggleLight.Invoke();
    }
    private void toggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void ToggleLightSwitch()
    {
        toggleLights();
        GameService.Instance.GetInstructionView().HideInstruction();
    }

    private void ToggleSoundEffect()
    {
        GameService.Instance.GetSoundView().PlaySoundEffects(SoundType.SwitchSound);
    }
}

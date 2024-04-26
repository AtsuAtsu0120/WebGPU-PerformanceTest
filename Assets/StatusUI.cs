using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private TextMeshProUGUI _aveFpsText;
    [SerializeField] private TextMeshProUGUI _graphicsApi;

    private int _frameCount;
    private float _prevTime;
    private int _fpsCount;
    private float _fpsSum;

    private void Start()
    {
        _graphicsApi.SetText(Enum.GetName(typeof(GraphicsDeviceType), SystemInfo.graphicsDeviceType));
    }
        
    private void Update()
    {
        _frameCount++;
        float time = Time.realtimeSinceStartup - _prevTime;

        if (time >= 0.5f)
        {
            var fps = _frameCount / time;
            _fpsText.SetText("{0}fps", fps);
            
            _fpsSum += fps;
            _fpsCount++;
            _aveFpsText.SetText("ave: {0}", _fpsSum / _fpsCount);
            
            _frameCount = 0;
            _prevTime = Time.realtimeSinceStartup;
        }
    }
}
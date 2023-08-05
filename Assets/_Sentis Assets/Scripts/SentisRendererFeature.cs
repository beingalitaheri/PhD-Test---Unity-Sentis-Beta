//using Unity.Sentis;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SentisRendererFeature : ScriptableRendererFeature
{
    //public ModelAsset m_ModelAsset;

    SentisCustomPostProcessingPass m_SentisPass;
        

    public override void Create()
    {
        m_SentisPass?.CleanupResources();
        
        //m_SentisPass = new SentisCustomPostProcessingPass(m_ModelAsset)
        //{
            //renderPassEvent = RenderPassEvent.AfterRendering
        //};
    }
    
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (isActive && Application.isPlaying && renderingData.cameraData.cameraType == CameraType.Game)
        {
            renderer.EnqueuePass(m_SentisPass);
        }
    }

    protected override void Dispose(bool disposing)
    {
        m_SentisPass?.CleanupResources();
        base.Dispose(disposing);
    }
}

//using Unity.Sentis;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

class SentisCustomPostProcessingPass : ScriptableRenderPass
{
    RenderTargetIdentifier source;
    
    //IWorker m_Engine;
    //TensorFloat m_InputTensor;

    int m_Width = 1024; // We hardcode width and height to prevent the 
    int m_Height = 768; // screen from becomming too big
    
    int m_Channels = 3; // We know we need 3 channels for this data model

    internal SentisCustomPostProcessingPass()//ModelAsset modelAsset)
    {
        //if (modelAsset == null) return;
        
        // Load the model into internal memory from the imported NN Model.
        //var model = ModelLoader.Load(modelAsset);

        // Create a GPU worker with the loaded model
        //m_Engine = WorkerFactory.CreateWorker(BackendType.GPUCommandBuffer, model);
        
        // Shape is formatted as NCHW (number, channels, height, width)
        //var shape = new TensorShape(1, m_Channels, m_Height, m_Width);
        //m_InputTensor = TensorFloat.Zeros(shape);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        var commandBuffer = CommandBufferPool.Get();

        // Grab a reference to the "image" that the camera is "seeing" to render
        source = renderingData.cameraData.renderer.cameraColorTarget;

        // Queue: Convert the input render texture to a tensor and save it as the input
        //TextureConverter.ToTensor(commandBuffer, source, m_InputTensor);
        
        // Queue: Execute model using input tensor
        //commandBuffer.ExecuteWorker(m_Engine, m_InputTensor);
        
        // Queue: Peek output tensor after execution and blit it back to render texture.
        //TextureConverter.RenderToScreen(commandBuffer, m_Engine.PeekOutput() as TensorFloat, source);
        
        // Now we run the queue and then clear it out
        context.ExecuteCommandBuffer(commandBuffer);
        CommandBufferPool.Release(commandBuffer);
    }
    
    public void CleanupResources()
    {
        // Disposing the input tensor and worker allows Sentis to clean up any temporary storage
        // allocated during evaluation and model import.
        //m_InputTensor?.Dispose();
        //m_Engine?.Dispose();
        //m_Engine = null;
    }
}

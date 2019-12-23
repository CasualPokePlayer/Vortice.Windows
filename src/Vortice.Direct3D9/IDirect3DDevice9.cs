// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using SharpGen.Runtime;
using Vortice.Direct3D;
using Vortice.Mathematics;

namespace Vortice.Direct3D9
{
    public partial class IDirect3DDevice9
    {
        public IDirect3DVertexShader9 CreateVertexShader(Blob blob)
        {
            return CreateVertexShader(blob.BufferPointer);
        }

        public IDirect3DPixelShader9 CreatePixelShader(Blob blob)
        {
            return CreatePixelShader(blob.BufferPointer);
        }

        public IDirect3DVertexBuffer9 CreateVertexBuffer(int sizeInBytes, Usage usage, VertexFormat vertexFormat, Pool pool)
        {
            return CreateVertexBuffer(sizeInBytes, usage, vertexFormat, pool, IntPtr.Zero);
        }

        public IDirect3DIndexBuffer9 CreateIndexBuffer(int sizeInBytes, Usage usage, bool sixteenBit, Pool pool)
        {
            return CreateIndexBuffer_(sizeInBytes, usage, sixteenBit ? Format.Index16 : Format.Index32, pool, IntPtr.Zero);
        }

        public IDirect3DIndexBuffer9 CreateIndexBuffer(int sizeInBytes, Usage usage, bool sixteenBit, Pool pool, IntPtr sharedHandle)
        {
            return CreateIndexBuffer_(sizeInBytes, usage, sixteenBit ? Format.Index16 : Format.Index32, pool, sharedHandle);
        }

        public IDirect3DTexture9 CreateTexture(int width, int height, int levels, Usage usage, Format format, Pool pool)
        {
            return CreateTexture(width, height, levels, usage, format, pool, IntPtr.Zero);
        }

        public IDirect3DVolumeTexture9 CreateVolumeTexture(int width, int height, int depth, int levels, Usage usage, Format format, Pool pool)
        {
            return CreateVolumeTexture(width, height, depth, levels, usage, format, pool, IntPtr.Zero);
        }

        public IDirect3DCubeTexture9 CreateCubeTexture(int edgeLength, int levels, Usage usage, Format format, Pool pool)
        {
            return CreateCubeTexture(edgeLength, levels, usage, format, pool, IntPtr.Zero);
        }

        public IDirect3DSurface9 CreateRenderTarget(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, bool lockable)
        {
            return CreateRenderTarget(width, height, format, multiSample, multisampleQuality, lockable, IntPtr.Zero);
        }

        public IDirect3DSurface9 CreateDepthStencilSurface(int width, int height, Format format, MultisampleType multiSample, int multisampleQuality, bool discard)
        {
            return CreateDepthStencilSurface(width, height, format, multiSample, multisampleQuality, discard);
        }

        public IDirect3DSurface9 CreateOffscreenPlainSurface(int width, int height, Format format, Pool pool)
        {
            return CreateOffscreenPlainSurface(width, height, format, pool, IntPtr.Zero);
        }

        /// <summary>
        /// Clears one or more surfaces such as a render target, a stencil buffer, and a depth buffer.
        /// </summary>
        /// <param name="clearFlags">Flags that specify which surfaces will be cleared.</param>
        /// <param name="color">The color that will be used to fill the cleared render target.</param>
        /// <param name="zdepth">The value that will be used to fill the cleared depth buffer.</param>
        /// <param name="stencil">The value that will be used to fill the cleared stencil buffer.</param>
        public void Clear(ClearFlags clearFlags, Color color, float zdepth, int stencil)
        {
            Clear_(0, null, clearFlags, Helpers.ToBgra(color), zdepth, stencil);
        }

        /// <summary>
        /// Clears one or more surfaces such as a render target, a stencil buffer, and a depth buffer.
        /// </summary>
        /// <param name="clearFlags">Flags that specify which surfaces will be cleared.</param>
        /// <param name="color">The color that will be used to fill the cleared render target.</param>
        /// <param name="zdepth">The value that will be used to fill the cleared depth buffer.</param>
        /// <param name="stencil">The value that will be used to fill the cleared stencil buffer.</param>
        public void Clear(ClearFlags clearFlags, System.Drawing.Color color, float zdepth, int stencil)
        {
            Clear_(0, null, clearFlags, Helpers.ToBgra(color), zdepth, stencil);
        }

        /// <summary>
        /// Clears one or more surfaces such as a render target, a stencil buffer, and a depth buffer.
        /// </summary>
        /// <param name="clearFlags">Flags that specify which surfaces will be cleared.</param>
        /// <param name="color">The color that will be used to fill the cleared render target.</param>
        /// <param name="zdepth">The value that will be used to fill the cleared depth buffer.</param>
        /// <param name="stencil">The value that will be used to fill the cleared stencil buffer.</param>
        /// <param name="rectangles">The areas on the surfaces that will be cleared.</param>
        public void Clear(ClearFlags clearFlags, Color color, float zdepth, int stencil, Rect[] rectangles)
        {
            Clear_(rectangles == null ? 0 : rectangles.Length, rectangles, clearFlags, Helpers.ToBgra(color), zdepth, stencil);
        }

        /// <summary>
        /// Clears one or more surfaces such as a render target, a stencil buffer, and a depth buffer.
        /// </summary>
        /// <param name="clearFlags">Flags that specify which surfaces will be cleared.</param>
        /// <param name="color">The color that will be used to fill the cleared render target.</param>
        /// <param name="zdepth">The value that will be used to fill the cleared depth buffer.</param>
        /// <param name="stencil">The value that will be used to fill the cleared stencil buffer.</param>
        /// <param name="rectangles">The areas on the surfaces that will be cleared.</param>
        public void Clear(ClearFlags clearFlags, System.Drawing.Color color, float zdepth, int stencil, Rect[] rectangles)
        {
            Clear_(rectangles == null ? 0 : rectangles.Length, rectangles, clearFlags, Helpers.ToBgra(color), zdepth, stencil);
        }

        /// <summary>	
        /// Allows an application to fill a rectangular area of a D3DPOOL_DEFAULT surface with a specified color.	
        /// </summary>	
        /// <remarks>	
        ///  This method can only be applied to a render target, a render-target texture surface, or an off-screen plain surface with a pool type of D3DPOOL_DEFAULT. IDirect3DDevice9::ColorFill will work with all formats. However, when using a reference or software device, the only formats supported are D3DFMT_X1R5G5B5, D3DFMT_A1R5G5B5, D3DFMT_R5G6B5, D3DFMT_X8R8G8B8, D3DFMT_A8R8G8B8, D3DFMT_YUY2, D3DFMT_G8R8_G8B8, D3DFMT_UYVY, D3DFMT_R8G8_B8G8, D3DFMT_R16F, D3DFMT_G16R16F, D3DFMT_A16B16G16R16F, D3DFMT_R32F, D3DFMT_G32R32F, and D3DFMT_A32B32G32R32F. When using a DirectX 7 or DirectX 8.x driver, the only YUV formats supported are D3DFMT_UYVY and D3DFMT_YUY2. 	
        /// </remarks>	
        /// <param name="surface"> Pointer to the surface to be filled. </param>
        /// <param name="color"> Color used for filling. </param>
        public void ColorFill(IDirect3DSurface9 surface, in Color color)
        {
            ColorFill(surface, null, Helpers.ToBgra(color));
        }

        /// <summary>	
        /// Allows an application to fill a rectangular area of a D3DPOOL_DEFAULT surface with a specified color.	
        /// </summary>	
        /// <remarks>	
        ///  This method can only be applied to a render target, a render-target texture surface, or an off-screen plain surface with a pool type of D3DPOOL_DEFAULT. IDirect3DDevice9::ColorFill will work with all formats. However, when using a reference or software device, the only formats supported are D3DFMT_X1R5G5B5, D3DFMT_A1R5G5B5, D3DFMT_R5G6B5, D3DFMT_X8R8G8B8, D3DFMT_A8R8G8B8, D3DFMT_YUY2, D3DFMT_G8R8_G8B8, D3DFMT_UYVY, D3DFMT_R8G8_B8G8, D3DFMT_R16F, D3DFMT_G16R16F, D3DFMT_A16B16G16R16F, D3DFMT_R32F, D3DFMT_G32R32F, and D3DFMT_A32B32G32R32F. When using a DirectX 7 or DirectX 8.x driver, the only YUV formats supported are D3DFMT_UYVY and D3DFMT_YUY2. 	
        /// </remarks>	
        /// <param name="surface"> Pointer to the surface to be filled. </param>
        /// <param name="color"> Color used for filling. </param>
        public void ColorFill(IDirect3DSurface9 surface, in System.Drawing.Color color)
        {
            ColorFill(surface, null, Helpers.ToBgra(color));
        }

        public void SetClipPlane(int index, Vector4 plane)
        {
            unsafe
            {
                SetClipPlane_(index, new IntPtr(&plane));
            }
        }

        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="immediate">Whether to immediate update.</param>
        public void SetCursorPosition(System.Drawing.Point point, bool immediate)
        {
            SetCursorPosition(point.X, point.Y, immediate ? 1 : 0);
        }

        /// <summary>
        /// Sets the cursor position.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="immediate">Whether to immediate update.</param>
        public void SetCursorPosition(int x, int y, bool immediate)
        {
            SetCursorPosition(x, y, immediate ? 1 : 0);
        }

        /// <summary>
        /// Sets the transform.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="matrix">The matrix transform.</param>
        public void SetTransform(TransformState state, Matrix4x4 matrix)
        {
            SetTransform(state, ref matrix);
        }

        /// <summary>
        /// Sets the world transform.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="matrix">The matrix transform.</param>
        public void SetTransform(int index, Matrix4x4 matrix)
        {
            SetTransform((TransformState)(index + 256), ref matrix);
        }

        /// <summary>
        /// Resets the stream source frequency by setting the frequency to 1.
        /// </summary>
        /// <param name="stream">The stream index.</param>
        public void ResetStreamSourceFrequency(int stream)
        {
            SetStreamSourceFrequency(stream, 1);
        }

        /// <summary>
        /// Sets the stream source frequency.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="frequency">The frequency.</param>
        /// <param name="source">The source.</param>
        public void SetStreamSourceFrequency(int stream, int frequency, StreamSource source)
        {
            int value = (source == StreamSource.IndexedData) ? 0x40000000 : unchecked((int)0x80000000);
            SetStreamSourceFrequency(stream, frequency | value);
        }

        /// <summary>
        /// Gets the state of the render.
        /// </summary>
        /// <typeparam name="T">Type of the state value.</typeparam>
        /// <param name="state">The state.</param>
        /// <returns>
        /// The render state value
        /// </returns>
        /// <unmanaged>HRESULT IDirect3DDevice9::GetRenderState([In] D3DRENDERSTATETYPE State,[In] void* pValue)</unmanaged>
        public T GetRenderState<T>(RenderState state) where T : unmanaged
        {
            unsafe
            {
                T result = default;
                GetRenderState(state, (IntPtr)Unsafe.AsPointer(ref result));
                return result;
            }
        }

        /// <summary>
        /// Sets the RenderState.
        /// </summary>
        /// <param name="renderState">State of the render.</param>
        /// <param name="enable">if set to <c>true</c> [enable].</param>
        public void SetRenderState(RenderState renderState, bool enable)
        {
            SetRenderState(renderState, enable ? 1 : 0);
        }

        /// <summary>
        /// Sets the RenderState.
        /// </summary>
        /// <param name="renderState">State of the render.</param>
        /// <param name="value">A float value.</param>
        public void SetRenderState(RenderState renderState, float value)
        {
            unsafe
            {
                SetRenderState(renderState, *(int*)&value);
            }
        }

        /// <summary>
        /// Sets the RenderState.
        /// </summary>
        /// <typeparam name="T">Type of the enum value</typeparam>
        /// <param name="renderState">State of the render.</param>
        /// <param name="value">An enum value.</param>
        public void SetRenderState<T>(RenderState renderState, T value) where T : struct, IConvertible
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
            {
                throw new ArgumentException("T must be an enum type", "value");
            }

            SetRenderState(renderState, value.ToInt32(CultureInfo.InvariantCulture));
        }

        #region SetVertexShaderConstant
        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, Matrix4x4[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetVertexShaderConstantF(startRegister, (IntPtr)pData, data.Length << 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, Vector4[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetVertexShaderConstantF(startRegister, (IntPtr)pData, data.Length >> 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, bool[] data)
        {
            unsafe
            {
                if (data.Length < 1024)
                {
                    var result = stackalloc int[data.Length];
                    Helpers.ConvertToIntArray(data, result);
                    SetVertexShaderConstantB(startRegister, (IntPtr)result, data.Length);
                }
                else
                {
                    var result = Helpers.ConvertToIntArray(data);
                    fixed (void* pResult = result)
                    {
                        SetVertexShaderConstantB(startRegister, (IntPtr)pResult, data.Length);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, int[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetVertexShaderConstantI(startRegister, (IntPtr)pData, data.Length >> 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, float[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetVertexShaderConstantF(startRegister, (IntPtr)pData, data.Length >> 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, Matrix4x4* data)
        {
            SetVertexShaderConstantF(startRegister, (IntPtr)data, 4);
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetVertexShaderConstant(int startRegister, Matrix4x4 data)
        {
            unsafe
            {
                SetVertexShaderConstantF(startRegister, new IntPtr(&data), 4);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, Matrix4x4* data, int count)
        {
            SetVertexShaderConstantF(startRegister, (IntPtr)data, count << 2);
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, Matrix4x4[] data, int offset, int count)
        {
            fixed (void* pData = &data[offset])
            {
                SetVertexShaderConstantF(startRegister, (IntPtr)pData, count << 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, Vector4[] data, int offset, int count)
        {
            fixed (void* pData = &data[offset])
            {
                SetVertexShaderConstantF(startRegister, (IntPtr)pData, count >> 2);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, bool[] data, int offset, int count)
        {
            if (count < 1024)
            {
                var result = stackalloc int[data.Length];
                Helpers.ConvertToIntArray(data, result);
                SetVertexShaderConstantB(startRegister, new IntPtr(&result[offset]), count);
            }
            else
            {
                var result = Helpers.ConvertToIntArray(data);
                fixed (void* pResult = &result[offset])
                    SetVertexShaderConstantB(startRegister, (IntPtr)pResult, count);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, int[] data, int offset, int count)
        {
            fixed (void* pData = &data[offset])
            {
                SetVertexShaderConstantI(startRegister, (IntPtr)pData, count);
            }
        }

        /// <summary>
        /// Sets the vertex shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetVertexShaderConstant(int startRegister, float[] data, int offset, int count)
        {
            fixed (void* pData = &data[offset])
            {
                SetVertexShaderConstantF(startRegister, (IntPtr)pData, count);
            }
        }
        #endregion

        #region SetPixelShaderConstant
        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetPixelShaderConstant(int startRegister, Matrix4x4[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetPixelShaderConstantF(startRegister, (IntPtr)pData, data.Length << 2); // *4 is enough
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetPixelShaderConstant(int startRegister, Vector4[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetPixelShaderConstantF(startRegister, (IntPtr)pData, data.Length); // a vector4 is only one register
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public unsafe void SetPixelShaderConstant(int startRegister, bool[] data)
        {
            if (data.Length < 1024)
            {
                var result = stackalloc int[data.Length];
                Helpers.ConvertToIntArray(data, result);
                SetPixelShaderConstantB(startRegister, (IntPtr)result, data.Length);
            }
            else
            {
                var result = Helpers.ConvertToIntArray(data);
                fixed (void* pResult = result)
                    SetPixelShaderConstantB(startRegister, (IntPtr)pResult, data.Length);
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetPixelShaderConstant(int startRegister, int[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetPixelShaderConstantI(startRegister, (IntPtr)pData, data.Length >> 2); // /4 as it's the count of Vector4i
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetPixelShaderConstant(int startRegister, float[] data)
        {
            unsafe
            {
                fixed (void* pData = data)
                    SetPixelShaderConstantF(startRegister, (IntPtr)pData, data.Length >> 2); // /4 as it's the count of Vector4f
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public unsafe void SetPixelShaderConstant(int startRegister, Matrix4x4* data)
        {
            SetPixelShaderConstantF(startRegister, (IntPtr)data, 4); // a matrix is only 4 registers
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        public void SetPixelShaderConstant(int startRegister, Matrix4x4 data)
        {
            unsafe
            {
                SetPixelShaderConstantF(startRegister, new IntPtr(&data), 4); // a matrix is only 4 registers
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetPixelShaderConstant(int startRegister, Matrix4x4* data, int count)
        {
            SetPixelShaderConstantF(startRegister, (IntPtr)data, count << 2); // *4 is enough as a matrix is still 4 registers
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public unsafe void SetPixelShaderConstant(int startRegister, Matrix4x4[] data, int offset, int count)
        {
            fixed (void* pData = &data[offset])
            {
                SetPixelShaderConstantF(startRegister, (IntPtr)pData, count << 2); // *4 is enough as a matrix is still 4 registers
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public void SetPixelShaderConstant(int startRegister, Vector4[] data, int offset, int count)
        {
            unsafe
            {
                fixed (void* pData = &data[offset])
                    SetPixelShaderConstantF(startRegister, (IntPtr)pData, count); // count is enough, as a Vector4f is only one register
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public void SetPixelShaderConstant(int startRegister, bool[] data, int offset, int count)
        {
            unsafe
            {
                if (count < 1024)
                {
                    var result = stackalloc int[data.Length];
                    Helpers.ConvertToIntArray(data, result);
                    SetPixelShaderConstantB(startRegister, new IntPtr(&result[offset]), count);
                }
                else
                {
                    var result = Helpers.ConvertToIntArray(data);
                    fixed (void* pResult = &result[offset])
                        SetPixelShaderConstantB(startRegister, (IntPtr)pResult, count);
                }
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public void SetPixelShaderConstant(int startRegister, int[] data, int offset, int count)
        {
            unsafe
            {
                fixed (void* pData = &data[offset])
                    SetPixelShaderConstantI(startRegister, (IntPtr)pData, count);
            }
        }

        /// <summary>
        /// Sets the pixel shader constant.
        /// </summary>
        /// <param name="startRegister">The start register.</param>
        /// <param name="data">The data.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        public void SetPixelShaderConstant(int startRegister, float[] data, int offset, int count)
        {
            unsafe
            {
                fixed (void* pData = &data[offset])
                    SetPixelShaderConstantF(startRegister, (IntPtr)pData, count);
            }
        }
        #endregion

        /// <summary>
        /// Gets the back buffer.
        /// </summary>
        /// <param name="swapChain">The swap chain.</param>
        /// <param name="backBuffer">The back buffer.</param>
        /// <param name="backBufferType">The backbuffer type.</param>
        /// <returns>A <see cref="IDirect3DSurface9" /> object describing the result of the operation.</returns>
        public IDirect3DSurface9 GetBackBuffer(int swapChain, int backBuffer, BackBufferType backBufferType = BackBufferType.Mono)
        {
            return GetBackBuffer_(swapChain, backBuffer, backBufferType);
        }

        /// <summary>
        /// Presents the contents of the next buffer in the sequence of back buffers to the screen.
        /// </summary>
        /// <returns>A <see cref="Result" /> object describing the result of the operation.</returns>
        public Result Present()
        {
            return Present(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Presents the contents of the next buffer in the sequence of back buffers to the screen.
        /// </summary>
        /// <param name="sourceRectangle">The area of the back buffer that should be presented.</param>
        /// <param name="destinationRectangle">The area of the front buffer that should receive the result of the presentation.</param>
        /// <returns>A <see cref="Result" /> object describing the result of the operation.</returns>
        public Result Present(Rect sourceRectangle, Rect destinationRectangle)
        {
            return Present(sourceRectangle, destinationRectangle, IntPtr.Zero);
        }


        /// <summary>
        /// Presents the contents of the next buffer in the sequence of back buffers to the screen.
        /// </summary>
        /// <param name="sourceRectangle">The area of the back buffer that should be presented.</param>
        /// <param name="destinationRectangle">The area of the front buffer that should receive the result of the presentation.</param>
        /// <param name="windowOverride">The destination window whose client area is taken as the target for this presentation.</param>
        /// <returns>A <see cref="Result" /> object describing the result of the operation.</returns>
        public Result Present(Rect sourceRectangle, Rect destinationRectangle, IntPtr windowOverride)
        {
            unsafe
            {
                return Present(new IntPtr(&sourceRectangle), new IntPtr(&destinationRectangle), windowOverride, IntPtr.Zero);
            }
        }
    }
}

// Copyright © Aaron Sun, Amer Koleci, and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

namespace Vortice.DirectML;

public partial struct MaxPooling2OperatorDescription : IOperatorDescription, IOperatorDescriptionMarshal
{
    /// <summary>
    /// Gets the type of operator description.
    /// </summary>
    public OperatorType OperatorType => OperatorType.MaxPooling2;

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::InputTensor']/*" />
    public TensorDescription InputTensor { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::OutputTensor']/*" />
    public TensorDescription OutputTensor { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::OutputIndicesTensor']/*" />
    public TensorDescription? OutputIndicesTensor { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::Strides']/*" />
    public int[] Strides { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::WindowSize']/*" />
    public int[] WindowSize { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::StartPadding']/*" />
    public int[] StartPadding { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::EndPadding']/*" />
    public int[] EndPadding { get; set; }

    /// <include file="Documentation.xml" path="/comments/comment[@id='DML_MAX_POOLING2_OPERATOR_DESC::Dilations']/*" />
    public int[] Dilations { get; set; }

    #region Marshal
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    internal struct __Native
    {
        public IntPtr InputTensor;
        public IntPtr OutputTensor;
        public IntPtr OutputIndicesTensor;
        public int DimensionCount;
        public IntPtr Strides;
        public IntPtr WindowSize;
        public IntPtr StartPadding;
        public IntPtr EndPadding;
        public IntPtr Dilations;
    }

    unsafe IntPtr IOperatorDescriptionMarshal.__MarshalAlloc()
    {
        __Native* @ref = UnsafeUtilities.Alloc<__Native>();

        @ref->InputTensor = InputTensor.__MarshalAlloc();
        @ref->OutputTensor = OutputTensor.__MarshalAlloc();
        @ref->OutputIndicesTensor = (OutputIndicesTensor != null) ? OutputIndicesTensor.Value.__MarshalAlloc() : IntPtr.Zero;

        var dimensionCount = Strides.Length;
        if (WindowSize.Length != dimensionCount) { throw new IndexOutOfRangeException("WindowSize must have the same length as Strides."); }
        if (StartPadding.Length != dimensionCount) { throw new IndexOutOfRangeException("StartPadding must have the same length as Strides."); }
        if (EndPadding.Length != dimensionCount) { throw new IndexOutOfRangeException("EndPadding must have the same length as Strides."); }
        if (Dilations.Length != dimensionCount) { throw new IndexOutOfRangeException("Dilations must have the same length as Strides."); }
        @ref->DimensionCount = dimensionCount;

        @ref->Strides = new(UnsafeUtilities.AllocWithData(Strides));
        @ref->WindowSize = new(UnsafeUtilities.AllocWithData(WindowSize));
        @ref->StartPadding = new(UnsafeUtilities.AllocWithData(StartPadding));
        @ref->EndPadding = new(UnsafeUtilities.AllocWithData(EndPadding));
        @ref->Dilations = new(UnsafeUtilities.AllocWithData(Dilations));

        return new(@ref);
    }

    unsafe void IOperatorDescriptionMarshal.__MarshalFree(ref IntPtr pDesc)
    {
        var @ref = (__Native*)pDesc;

        InputTensor.__MarshalFree(ref @ref->InputTensor);
        OutputTensor.__MarshalFree(ref @ref->OutputTensor);

        if (OutputIndicesTensor != null)
        {
            OutputIndicesTensor.Value.__MarshalFree(ref @ref->OutputIndicesTensor);
        }

        UnsafeUtilities.Free(@ref->Strides);
        UnsafeUtilities.Free(@ref->WindowSize);
        UnsafeUtilities.Free(@ref->StartPadding);
        UnsafeUtilities.Free(@ref->EndPadding);
        UnsafeUtilities.Free(@ref->Dilations);

        UnsafeUtilities.Free(@ref);
    }
    #endregion
}

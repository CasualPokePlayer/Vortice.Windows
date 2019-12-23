// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using SharpGen.Runtime;

namespace Vortice.Direct3D9
{
    public partial class D3D9
    {
        public static IDirect3D9 Create9() => Create9(SdkVersion);

        public static Result Create9Ex(out IDirect3D9Ex result) => Create9Ex(SdkVersion, out result);
    }
}

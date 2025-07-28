// SPDX-FileCopyrightText: 2025 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using System;
using UnityEngine;

namespace GLTFast.Loading
{
    /// <summary>
    /// Provides a mechanism to inspect the progress and result of a texture download
    /// or texture file access request
    /// </summary>
    public interface ITextureDownload : IDownload
    {
        /// <summary>
        /// Resulting texture
        /// </summary>
        Texture2D Texture { get; }
    }
}

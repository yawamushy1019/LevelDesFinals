// SPDX-FileCopyrightText: 2023 Unity Technologies and the glTFast authors
// SPDX-License-Identifier: Apache-2.0

using System;
using Unity.Collections;
using UnityEngine;

namespace GLTFast.Loading
{
    /// <summary>
    /// Provides a mechanism to inspect the progress and result of a download
    /// or file access request
    /// </summary>
    public interface IDownload : IDisposable
    {
        /// <summary>
        /// True, if the request was successful
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Error message in case the request failed. Null otherwise.
        /// </summary>
        string Error { get; }

        /// <summary>
        /// Resulting data as managed byte array.
        /// </summary>
        byte[] Data { get; }

        /// <summary>
        /// Resulting data as text
        /// </summary>
        string Text { get; }

        /// <summary>
        /// True if the result is a glTF-binary, false if it is not.
        /// No value if determining the glTF type was not possible or failed.
        /// </summary>
        bool? IsBinary { get; }
    }
}

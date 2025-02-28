// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describes the basic gallery artifact publishing profile.
    /// </summary>
    public partial class GalleryArtifactPublishingProfileBase
    {
        /// <summary>
        /// Initializes a new instance of the
        /// GalleryArtifactPublishingProfileBase class.
        /// </summary>
        public GalleryArtifactPublishingProfileBase()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// GalleryArtifactPublishingProfileBase class.
        /// </summary>
        /// <param name="targetRegions">The target regions where the Image
        /// Version is going to be replicated to. This property is
        /// updatable.</param>
        public GalleryArtifactPublishingProfileBase(IList<TargetRegion> targetRegions = default(IList<TargetRegion>))
        {
            TargetRegions = targetRegions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the target regions where the Image Version is going to
        /// be replicated to. This property is updatable.
        /// </summary>
        [JsonProperty(PropertyName = "targetRegions")]
        public IList<TargetRegion> TargetRegions { get; set; }

    }
}

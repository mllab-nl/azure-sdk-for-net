// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataShare.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An ADLS Gen 2 file system dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("AdlsGen2FileSystem")]
    [Rest.Serialization.JsonTransformation]
    public partial class ADLSGen2FileSystemDataSet : DataSet
    {
        /// <summary>
        /// Initializes a new instance of the ADLSGen2FileSystemDataSet class.
        /// </summary>
        public ADLSGen2FileSystemDataSet()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ADLSGen2FileSystemDataSet class.
        /// </summary>
        /// <param name="fileSystem">The file system name.</param>
        /// <param name="resourceGroup">Resource group of storage
        /// account</param>
        /// <param name="storageAccountName">Storage account name of the source
        /// data set</param>
        /// <param name="subscriptionId">Subscription id of storage
        /// account</param>
        /// <param name="id">The resource id of the azure resource</param>
        /// <param name="name">Name of the azure resource</param>
        /// <param name="type">Type of the azure resource</param>
        /// <param name="dataSetId">Unique DataSet id.</param>
        public ADLSGen2FileSystemDataSet(string fileSystem, string resourceGroup, string storageAccountName, string subscriptionId, string id = default(string), string name = default(string), string type = default(string), string dataSetId = default(string))
            : base(id, name, type)
        {
            DataSetId = dataSetId;
            FileSystem = fileSystem;
            ResourceGroup = resourceGroup;
            StorageAccountName = storageAccountName;
            SubscriptionId = subscriptionId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets unique DataSet id.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dataSetId")]
        public string DataSetId { get; private set; }

        /// <summary>
        /// Gets or sets the file system name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.fileSystem")]
        public string FileSystem { get; set; }

        /// <summary>
        /// Gets or sets resource group of storage account
        /// </summary>
        [JsonProperty(PropertyName = "properties.resourceGroup")]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Gets or sets storage account name of the source data set
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountName")]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets subscription id of storage account
        /// </summary>
        [JsonProperty(PropertyName = "properties.subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (FileSystem == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "FileSystem");
            }
            if (ResourceGroup == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ResourceGroup");
            }
            if (StorageAccountName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageAccountName");
            }
            if (SubscriptionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SubscriptionId");
            }
        }
    }
}

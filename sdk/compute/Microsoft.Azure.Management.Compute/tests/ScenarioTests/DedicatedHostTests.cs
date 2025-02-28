﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Compute.Tests
{
    public class DedicatedHostTests : VMTestBase
    {
        [Fact]
        public void TestDedicatedHostOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "DH";
                string dhgName = "DHG-1";
                string dhName = "DH-1";

                try
                {
                    // Create a dedicated host group, then get the dedicated host group and validate that they match
                    DedicatedHostGroup createdDHG = CreateDedicatedHostGroup(rgName, dhgName);
                    DedicatedHostGroup returnedDHG = m_CrpClient.DedicatedHostGroups.Get(rgName, dhgName);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    // Update existing dedicated host group 
                    DedicatedHostGroupUpdate updateDHGInput = new DedicatedHostGroupUpdate()
                    {
                        Tags = new Dictionary<string, string>() { { "testKey", "testValue" } }
                    };
                    createdDHG.Tags = updateDHGInput.Tags;
                    returnedDHG =  m_CrpClient.DedicatedHostGroups.Update(rgName, dhgName, updateDHGInput);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //List DedicatedHostGroups by subscription and by resourceGroup
                    var listDHGsResponse = m_CrpClient.DedicatedHostGroups.ListByResourceGroup(rgName);
                    Assert.Single(listDHGsResponse);
                    ValidateDedicatedHostGroup(createdDHG, listDHGsResponse.First());
                    listDHGsResponse = m_CrpClient.DedicatedHostGroups.ListBySubscription();

                    //There might be multiple dedicated host groups in the subscription, we only care about the one that we created.
                    returnedDHG = listDHGsResponse.First(dhg => dhg.Id == createdDHG.Id);
                    Assert.NotNull(returnedDHG);
                    ValidateDedicatedHostGroup(createdDHG, returnedDHG);

                    //Create DedicatedHost within the DedicatedHostGroup and validate
                    var createdDH = CreateDedicatedHost(rgName, dhgName, dhName);
                    var returnedDH = m_CrpClient.DedicatedHosts.Get(rgName, dhgName, dhName);
                    ValidateDedicatedHost(createdDH, returnedDH);

                    //List DedicatedHosts
                    var listDHsResponse = m_CrpClient.DedicatedHosts.ListByHostGroup(rgName, dhgName);
                    Assert.Single(listDHsResponse);
                    ValidateDedicatedHost(createdDH, listDHsResponse.First());

                    //Delete DedicatedHosts and DedicatedHostGroups
                    m_CrpClient.DedicatedHosts.Delete(rgName, dhgName, dhName);
                    m_CrpClient.DedicatedHostGroups.Delete(rgName, dhgName);

                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        private void ValidateDedicatedHostGroup(DedicatedHostGroup expectedDHG, DedicatedHostGroup actualDHG)
        {
            if (expectedDHG == null)
            {
                Assert.Null(actualDHG);
            }
            else
            {
                Assert.NotNull(actualDHG);
                if (expectedDHG.Hosts == null)
                {
                    Assert.Null(actualDHG.Hosts);
                }
                else
                {
                    Assert.NotNull(actualDHG);
                    Assert.True(actualDHG.Hosts.SequenceEqual(expectedDHG.Hosts));
                }
                Assert.Equal(expectedDHG.Location, actualDHG.Location);
                Assert.Equal(expectedDHG.Name, actualDHG.Name);
            }

        }

        private void ValidateDedicatedHost(DedicatedHost expectedDH, DedicatedHost actualDH)
        {
            if (expectedDH == null)
            {
                Assert.Null(actualDH);
            }
            else
            {
                Assert.NotNull(actualDH);
                if (expectedDH.VirtualMachines == null)
                {
                    Assert.Null(actualDH.VirtualMachines);
                }
                else
                {
                    Assert.NotNull(actualDH);
                    Assert.True(actualDH.VirtualMachines.SequenceEqual(expectedDH.VirtualMachines));
                }
                Assert.Equal(expectedDH.Location, actualDH.Location);
                Assert.Equal(expectedDH.Name, actualDH.Name);
                Assert.Equal(expectedDH.HostId, actualDH.HostId);
            }
        }

    }
}
<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AzureCloudService" generation="1" functional="0" release="0" Id="fb297ab4-4838-4c77-9aba-31181fc3feee" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AzureCloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="Imagifation:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/AzureCloudService/AzureCloudServiceGroup/LB:Imagifation:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Imagifation:CloudStorageCon" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudService/AzureCloudServiceGroup/MapImagifation:CloudStorageCon" />
          </maps>
        </aCS>
        <aCS name="Imagifation:LocalStorageCon" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudService/AzureCloudServiceGroup/MapImagifation:LocalStorageCon" />
          </maps>
        </aCS>
        <aCS name="ImagifationInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureCloudService/AzureCloudServiceGroup/MapImagifationInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:Imagifation:Endpoint1">
          <toPorts>
            <inPortMoniker name="/AzureCloudService/AzureCloudServiceGroup/Imagifation/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapImagifation:CloudStorageCon" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudService/AzureCloudServiceGroup/Imagifation/CloudStorageCon" />
          </setting>
        </map>
        <map name="MapImagifation:LocalStorageCon" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudService/AzureCloudServiceGroup/Imagifation/LocalStorageCon" />
          </setting>
        </map>
        <map name="MapImagifationInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureCloudService/AzureCloudServiceGroup/ImagifationInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="Imagifation" generation="1" functional="0" release="0" software="C:\Users\Farid\Desktop\dev\Imagifation\AzureCloudService\csx\Debug\roles\Imagifation" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="CloudStorageCon" defaultValue="" />
              <aCS name="LocalStorageCon" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;Imagifation&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;Imagifation&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureCloudService/AzureCloudServiceGroup/ImagifationInstances" />
            <sCSPolicyUpdateDomainMoniker name="/AzureCloudService/AzureCloudServiceGroup/ImagifationUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AzureCloudService/AzureCloudServiceGroup/ImagifationFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="ImagifationUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="ImagifationFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="ImagifationInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="ffd55518-4a9a-472a-8d8d-6130afea81d9" ref="Microsoft.RedDog.Contract\ServiceContract\AzureCloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="f2a44ddc-8353-4ca5-b0c7-e5dc8e830698" ref="Microsoft.RedDog.Contract\Interface\Imagifation:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AzureCloudService/AzureCloudServiceGroup/Imagifation:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>